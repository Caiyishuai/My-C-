using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//添加命名空间
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;

using System.Runtime.InteropServices;
using System.Reflection;


namespace Pencil
{
    //主窗口类
    public partial class FormMain : Form
    {
        //定义List泛型集合对象，保存所有图元
        private List<Shape> _listShape = new List<Shape>();

        //定义List泛型集合对象，临时保存被撤销的图元
        private List<Shape> _listTempShape = new List<Shape>();

        //保存当前绘制的临时图元
        private Shape _tempShape = null;

        //保存当前的绘图类型(默认为徒手画)
        private DrawType _drawType = DrawType.Sketch;
        //保存当前绘图的线宽(默认为10)
        private int _drawWidth = 10;
        //保存当前绘图的颜色(默认为红色)
        private Color _drawColor = Color.Red;

        //保存BufferedGraphicsContext对象，该对象用来单独分配和管理图形缓冲区
        BufferedGraphicsContext _bufGraphCont = null;
        //保存BufferedGraphics(图形缓冲区)对象
        BufferedGraphics _bufGraph = null;

        //保存当前图形的文件名(默认为空)
        private string _fileName = "";

        //是否需要保存的标记(如果为true,表示需要弹出保存对话框;如果为false,表示无需弹出保存对话框)
        private Boolean _saveFlag = false;

        //保存图形缩放比率(默认为1)
        private double _zoomRatio = 1;
        //保存panelDraw窗口的初始尺寸
        private Size _panelDrawInitSize = new Size(0,0);

        //保存屏幕位图
        private Bitmap _screenBmp = null;
        //保存与屏幕位图相对应的Graphics对象
        private Graphics _screenBmpGraphics = null;


        //=========================================================================================        
        //定义键盘消息结构体
        public struct KeyMSG
        {
            public int vkCode;       //键值虚拟码(1-254)
            public int scanCode;     //硬件扫描码
            public int flags;        //键盘按下时等于128；键盘抬起时等于0
            public int time;         //Window运行时间
            public int dwExtraInfo;
        }

        //定义变量
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        static int hKeyboardHook = 0;
        HookProc KeyboardHookProcedure;

        //安装钩子(需要用到"System.Runtime.InteropServices"命名空间)
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        //钩子处理：就是钩子所要做的事情
        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                //将lParam数据转换成键盘消息
                KeyMSG m = (KeyMSG)Marshal.PtrToStructure(lParam, typeof(KeyMSG));

                //如果按下F3键，则处理屏幕截屏 (注意:键盘按下时flags=128；键盘抬起时flags等于0)
                if (m.flags == 0 && m.vkCode == (int)(Keys.F3))
                {
                    //调用"截屏"菜单click事件响应方法
                    MenuItemScreenPen_Click(this, null);
                    return 1;
                }

                //如果返回1，则结束消息，这个消息到此为止，不再传递。如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
                return 0;
            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

        //安装钩子
        public void HookStart()
        {
            if (hKeyboardHook == 0)
            {
                //创建HookProc实例
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                //设置线程钩子(需要添加"System.Reflection"命名空间)
                hKeyboardHook = SetWindowsHookEx(13, KeyboardHookProcedure, Marshal.GetHINSTANCE(
                                Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                //如果设置钩子失败
                if (hKeyboardHook == 0)
                {
                    HookStop();
                    throw new Exception("SetWindowsHookEx failed.");
                }
            }
        }

        //卸载钩子
        public void HookStop()
        {
            bool retKeyboard = true;
            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            if (!(retKeyboard))
                throw new Exception("UnhookWindowsHookEx failed.");
        }
        //=========================================================================================


        //构造方法
        public FormMain()
        {
            InitializeComponent();

            //安装钩子
            try
            {
                HookStart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("钩子安装失败！提示信息：" + ex.Message);
            }
        }

        //窗口Load(装载)事件响应方法(该事件在窗口首次显示前发生)
        private void FormMain_Load(object sender, EventArgs e)
        {
            //获取当前应用程序域的BufferedGraphicsContext对象，以利用双缓冲技术来减少或消除重绘显示图面时产生的闪烁
            _bufGraphCont = BufferedGraphicsManager.Current;
            //创建指定大小的图形缓冲区，且其像素格式与panelDraw.CreateGraphics()的像素格式相同
            _bufGraph = _bufGraphCont.Allocate(panelDraw.CreateGraphics(), panelDraw.ClientRectangle);
            //清空图形缓冲区
            _bufGraph.Graphics.Clear(Color.White);
            //设置抗锯齿平滑模式(注意：需要添加System.Drawing.Drawing2D命名空间)
            _bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //获取屏幕的宽度和高度
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //创建屏幕位图对象，其大小与屏幕大小相等
            _screenBmp = new Bitmap(screenWidth, screenHeight);
            //获取与屏幕位图相对应的Graphics对象
            _screenBmpGraphics = Graphics.FromImage(_screenBmp);
            //清除屏幕位图，并用白色填充
            _screenBmpGraphics.Clear(Color.White);

            //保存panelDraw窗口的初始尺寸
            _panelDrawInitSize.Width = panelDraw.Width;
            _panelDrawInitSize.Height = panelDraw.Height;

            //禁用MenuItemUndo菜单和toolStripButtonUndo按钮
            MenuItemUndo.Enabled = false;
            toolStripButtonUndo.Enabled = false;
            //禁用MenuItemRedo菜单和toolStripButtonRedo按钮
            MenuItemRedo.Enabled = false;
            toolStripButtonRedo.Enabled = false;

            //以"penci.cur"为源文件(要求放置在Debug目录下)，创建一个Cursor对象，并设置为当前窗口的光标
            Cursor penCur = new Cursor("penci.cur");
            this.Cursor = penCur;
            //把菜单条、工具条、状态条的光标设置为默认的箭头光标
            menuStrip1.Cursor = Cursors.Arrow;
            toolStrip1.Cursor = Cursors.Arrow;
            statusStrip1.Cursor = Cursors.Arrow;
        }   

        //MouseDown(鼠标下压)事件响应方法
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        //MouseMove(鼠标移动)事件响应方法
        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {

        }

        //MouseUp(鼠标抬起)事件响应方法
        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        //Paint(窗口绘制)事件响应方法
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //"直线"菜单的Click事件响应方法
        public void MenuItemLine_Click(object sender, EventArgs e)
        {
            //把当前的绘图类型设置为直线
            _drawType = DrawType.Line;
        }

        //"矩形"菜单的Click事件响应方法
        public void MenuItemRectangle_Click(object sender, EventArgs e)
        {
            //把当前的绘图类型设置为矩形
            _drawType = DrawType.Rectangle;
        }

        //"圆"菜单的Click事件响应方法
        public void MenuItemCircle_Click(object sender, EventArgs e)
        {
            //把当前的绘图类型设置为圆
            _drawType = DrawType.Circle;
        }

        //"徒手画"菜单的Click事件响应方法
        public void MenuItemSketch_Click(object sender, EventArgs e)
        {
            //把当前的绘图类型设置为徒手画
            _drawType = DrawType.Sketch;
        }   

        //"停止"菜单的Click事件响应方法
        private void MenuItemStop_Click(object sender, EventArgs e)
        {
            //把当前的绘图类型设置为停止绘图
            _drawType = DrawType.Stop;
        }

        //"线宽"菜单的Click事件响应方法
        public void MenuItemWidth_Click(object sender, EventArgs e)
        {
            //新建一个线宽对话框对象
            DlgPenWidth dlgPenWidth = new DlgPenWidth();
            //设置线宽对话框默认显示的线宽值
            dlgPenWidth._PenWidth = _drawWidth;
            //显示线宽对话框，判断是否点击了OK按钮
            if (dlgPenWidth.ShowDialog(this) == DialogResult.OK)
            {
                //保存用户设置的线宽到_drawWidth
                _drawWidth = dlgPenWidth._PenWidth;
            }
        }

        //"颜色"菜单的Click事件响应方法
        public void MenuItemColor_Click(object sender, EventArgs e)
        {
            //设置颜色对话框默认选中的颜色
            colorDialog1.Color = _drawColor;
            //显示颜色对话框，判断是否点击了OK按钮
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //保存用户设置的颜色到_drawColor
                _drawColor = colorDialog1.Color;
            }

            //////////////////////////////////////////////////////////////////////
            ////如果不想拖动工具栏上的ColorDialog组件，也可以这样来实现
            //////////////////////////////////////////////////////////////////////
            ////新建一个颜色对话框对象
            //ColorDialog colorDialog = new ColorDialog();
            ////设置颜色对话框默认选中的颜色
            //colorDialog.Color = _drawColor;
            ////显示颜色对话框，判断是否点击了OK按钮
            //if (colorDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    //保存用户设置的颜色到_drawColor
            //    _drawColor = colorDialog.Color;
            //}
        }

        //"撤销"菜单的Click事件响应方法
        public void MenuItemUndo_Click(object sender, EventArgs e)
        {
            //判断_listShape中是否有图元
            if (_listShape.Count != 0)
            {
                //在删除之前，先把_listShape中的最后一个图元保存到_listTempShape
                _listTempShape.Add(_listShape[_listShape.Count - 1]);

                //删除_listShape中的最后一个图元
                _listShape.RemoveAt(_listShape.Count - 1);

                //清空图形缓冲区
                _bufGraph.Graphics.Clear(Color.White);

                //将屏幕位图绘制到图形缓冲区
                _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));

                //逐一将所有图元绘制到图形缓冲区
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                //将图形缓冲区绘制到panelDraw窗口
                _bufGraph.Render(panelDraw.CreateGraphics());

                //判断是否需要禁用MenuItemUndo菜单和toolStripButtonUndo按钮
                if (_listShape.Count == 0)
                {
                    MenuItemUndo.Enabled = false;
                    toolStripButtonUndo.Enabled = false;
                }
                //启用MenuItemRedo菜单和toolStripButtonRedo按钮
                MenuItemRedo.Enabled = true;
                toolStripButtonRedo.Enabled = true;

                //设置保存标记为true(如果为true,表示需要弹出保存对话框;如果为false,表示无需弹出保存对话框)
                _saveFlag = true;
            }
        }

        //"重做"菜单的Click事件响应方法
        private void MenuItemRedo_Click(object sender, EventArgs e)
        {
            //判断_listTempShape中是否有图元
            if (_listTempShape.Count != 0)
            {
                //把_listTempShape中的最后一个图元保存到_listShape
                _listShape.Add(_listTempShape[_listTempShape.Count - 1]);

                //删除_listTempShape中的最后一个图元
                _listTempShape.RemoveAt(_listTempShape.Count - 1);

                //清空图形缓冲区
                _bufGraph.Graphics.Clear(Color.White);
                //逐一将所有图元绘制到图形缓冲区
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                //将图形缓冲区绘制到panelDraw窗口
                _bufGraph.Render(panelDraw.CreateGraphics());

                //判断是否需要禁用MenuItemRedo菜单和toolStripButtonRedo按钮
                if (_listTempShape.Count == 0)
                {
                    MenuItemRedo.Enabled = false;
                    toolStripButtonRedo.Enabled = false;
                }
                //启用MenuItemUndo菜单和toolStripButtonUndo按钮
                MenuItemUndo.Enabled = true;
                toolStripButtonUndo.Enabled = true;

                //设置保存标记为true(如果为true,表示需要弹出保存对话框;如果为false,表示无需弹出保存对话框)
                _saveFlag = true;
            }
        }

        //"1px"菜单的Click事件响应方法
        private void ToolStripMenuItem1px_Click(object sender, EventArgs e)
        {
            //设置当前绘图的线宽(_drawWidth)为1
            _drawWidth = 1;
        }

        //"2px"菜单的Click事件响应方法
        private void ToolStripMenuItem2px_Click(object sender, EventArgs e)
        {
            //设置当前绘图的线宽(_drawWidth)为2
            _drawWidth = 2;
        }

        //"4px"菜单的Click事件响应方法
        private void ToolStripMenuItem4px_Click(object sender, EventArgs e)
        {
            //设置当前绘图的线宽(_drawWidth)为4
            _drawWidth = 4;
        }

        //"8px"菜单的Click事件响应方法
        private void ToolStripMenuItem8px_Click(object sender, EventArgs e)
        {
            //设置当前绘图的线宽(_drawWidth)为8
            _drawWidth = 8;
        }

        //"红色"菜单的Click事件响应方法
        private void toolStripMenuItemRed_Click(object sender, EventArgs e)
        {
            //设置当前绘图的颜色(_drawColor)为红色
            _drawColor = Color.Red;
        }

        //"绿色"菜单的Click事件响应方法
        private void toolStripMenuItemGreen_Click(object sender, EventArgs e)
        {
            //设置当前绘图的颜色(_drawColor)为绿色
            _drawColor = Color.Green;
        }

        //"蓝色"菜单的Click事件响应方法
        private void toolStripMenuItemBlue_Click(object sender, EventArgs e)
        {
            //设置当前绘图的颜色(_drawColor)为蓝色
            _drawColor = Color.Blue;
        }

        //"黄色"菜单的Click事件响应方法
        private void toolStripMenuItemYellow_Click(object sender, EventArgs e)
        {
            //设置当前绘图的颜色(_drawColor)为黄色
            _drawColor = Color.Yellow;
        }   

        //"黑色"菜单的Click事件响应方法
        private void toolStripMenuItemBlack_Click(object sender, EventArgs e)
        {
            //设置当前绘图的颜色(_drawColor)为黑色
            _drawColor = Color.Black;
        }

        //"新建"菜单的Click事件响应方法
        private void MenuItemNew_Click(object sender, EventArgs e)
        {
            //如果保存标记为true，则显示保存提示
            if (_saveFlag == true)
            {
                //弹出保存提示框
                if (MessageBox.Show("图形已经改变,你需要保存吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //调用菜单"保存"的Click事件响应方法
                    MenuItemSave_Click(null, null);
            }

            //清空_listShape中的所有图元
            _listShape.Clear();
            //清空_listTempShape中的所有图元
            _listTempShape.Clear();

            //清空图形缓冲区
            _bufGraph.Graphics.Clear(Color.White);
            //将图形缓冲区绘制到panelDraw窗口
            _bufGraph.Render(panelDraw.CreateGraphics());

            //清空当前图形的文件名
            _fileName = "";
            //设置窗口标题
            this.Text = "画笔-无标题";

            //设置保存标记为false(如果为true,表示需要弹出保存对话框;如果为false,表示无需弹出保存对话框)
            _saveFlag = false;

            //禁用MenuItemUndo菜单和toolStripButtonUndo按钮
            MenuItemUndo.Enabled = false;
            toolStripButtonUndo.Enabled = false;
            //禁用MenuItemRedo菜单和toolStripButtonRedo按钮
            MenuItemRedo.Enabled = false;
            toolStripButtonRedo.Enabled = false;
        }

        //"打开"菜单的Click事件响应方法
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            //调用菜单"新建"的Click事件响应方法
            MenuItemNew_Click(null, null);

            //显示文件打开对话框
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //调用菜单"新建"的Click事件响应方法
                MenuItemNew_Click(null, null);

                //保存用户选择的文件名
                _fileName = openFileDialog1.FileName;
                //设置窗口标题
                this.Text = "画笔-" + _fileName;

                //创建一个文件流对象，用于读出图形信息
                FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                //创建一个与文件流对象相对应的二进制读入流对象
                BinaryReader br = new BinaryReader(fs);

                //从文件中读取图元数量
                int shapeCount = br.ReadInt32();
                //逐一从文件中读取图元信息
                for (int i = 0; i < shapeCount; i++)
                {
                    //从文件中读取图元类型(如"Pencil.Line"、"Pencil.Rectangle"、"Pencil.Circle"等)
                    string ShapeType = br.ReadString();
                    //如果是直线
                    if (ShapeType == "Pencil.Line")
                    {
                        Line shape = new Line();
                        shape.Read(br);
                        _listShape.Add(shape);
                    }
                    //如果是矩形
                    else if (ShapeType == "Pencil.Rectangle")
                    {
                        Rectangle shape = new Rectangle();
                        shape.Read(br);
                        _listShape.Add(shape);
                    }
                    //如果是椭圆
                    else if (ShapeType == "Pencil.Circle")
                    {
                        Circle shape = new Circle();
                        shape.Read(br);
                        _listShape.Add(shape);
                    }
                    //如果是徒手画
                    else if (ShapeType == "Pencil.Sketch")
                    {
                        Sketch shape = new Sketch();
                        shape.Read(br);
                        _listShape.Add(shape);
                    }
                    else
                        //弹出信息提示框
                        MessageBox.Show("图元类型错误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //关闭有关文件流对象
                br.Close();
                fs.Close();

                //设置保存标记为false(如果为true,表示需要弹出保存对话框;如果为false,表示无需弹出保存对话框)
                _saveFlag = false;

                //清空图形缓冲区
                _bufGraph.Graphics.Clear(Color.White);
                //逐一将所有图元绘制到图形缓冲区
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                //将图形缓冲区绘制到panelDraw窗口
                _bufGraph.Render(panelDraw.CreateGraphics());
            }    
        }

        //"保存"菜单的Click事件响应方法
        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            //如果_fileName为空，则需弹出保存文件对话框以设定文件名
            if (_fileName == "")
            {
                //显示文件保存对话框
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    //保存用户选择的文件名
                    _fileName = saveFileDialog1.FileName;
                    //设置窗口标题
                    this.Text = "画笔-" + _fileName;
                }
                else
                    return;
            }

            //创建一个文件流对象，用于写入图形信息
            FileStream fs = new FileStream(_fileName, FileMode.Create);
            //创建一个与文件流对象相对应的二进制写入流对象
            BinaryWriter bw = new BinaryWriter(fs);

            //把图元数量写入到文件
            bw.Write(_listShape.Count);
            //逐一把图元信息写入到文件
            foreach (Shape tempShape in _listShape)
            {
                //把图元类型(如"Pencil.Line"、"Pencil.Rectangle"、"Pencil.Circle"等)写入到文件
                bw.Write(tempShape.GetType().ToString());
                //把图元信息(包括线宽、颜色、坐标x和坐标y等)写入到文件
                tempShape.Write(bw);
            }

            //关闭有关文件流对象
            bw.Close();
            fs.Close();

            //设置保存标记为false(如果为true,表示需要弹出保存对话框;如果为false,表示无需弹出保存对话框)
            _saveFlag = false;
        }

        //"另存为"菜单的Click事件响应方法 
        private void MenuItemSaveAs_Click(object sender, EventArgs e)
        {
            //显示文件保存对话框，设置另存的文件名
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //保存用户设置的文件名
                _fileName = saveFileDialog1.FileName;
                //设置窗口标题
                this.Text = "画笔-" + _fileName;

                //创建一个文件流对象，用于写入图形信息
                FileStream fs = new FileStream(_fileName, FileMode.Create);
                //创建一个与文件流对象相对应的二进制写入流对象
                BinaryWriter bw = new BinaryWriter(fs);

                //把图元数量写入到文件
                bw.Write(_listShape.Count);
                //逐一把图元信息写入到文件
                foreach (Shape tempShape in _listShape)
                {
                    //把图元类型(如"Pencil.Line"、"Pencil.Rectangle"、"Pencil.Circle"等)写入到文件
                    bw.Write(tempShape.GetType().ToString());
                    //把图元信息(包括线宽、颜色、坐标x和坐标y等)写入到文件
                    tempShape.Write(bw);
                }

                //关闭有关文件流对象
                bw.Close();
                fs.Close();

                //设置保存标记为false(如果为true,表示需要弹出保存对话框;如果为false,表示无需弹出保存对话框)
                _saveFlag = false;
            }
        }

        //"另存为图片"菜单的Click事件响应方法 
        private void MenuItemSaveAsPic_Click(object sender, EventArgs e)
        {
            //显示图片保存对话框，设置需要保存的图片文件名
            if (saveFileDialog2.ShowDialog(this) == DialogResult.OK)
            {
                //创建一个位图对象，其尺寸与窗口客户区尺寸相等
                Bitmap bitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                //获取位图的Graphics对象
                Graphics gBitmap = Graphics.FromImage(bitmap);
                //把图形缓冲区绘制到位图
                _bufGraph.Render(gBitmap);

                //获取图片文件的后缀名
                string extension = System.IO.Path.GetExtension(saveFileDialog2.FileName);

                //根据后缀名，存储为相应格式的图片
                if (extension == ".jpg")
                    //(注意：ImageFormat类需要添加System.Drawing.Imaging命名空间)
                    bitmap.Save(saveFileDialog2.FileName, ImageFormat.Jpeg);
                else if (extension == ".gif")
                    bitmap.Save(saveFileDialog2.FileName, ImageFormat.Gif);
                else if (extension == ".bmp")
                    bitmap.Save(saveFileDialog2.FileName, ImageFormat.Bmp);
                else
                    MessageBox.Show("对不起，暂不支持该图片格式。", extension, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //"关闭"菜单的Click事件响应方法 
        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            //关闭主窗口
            this.Close();
        }

        //FormClosed事件响应方法
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //如果保存标记为true，则显示保存提示
            if (_saveFlag == true)
            {
                //弹出保存提示框
                if (MessageBox.Show("图形已经改变,你需要保存吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //调用菜单"保存"的Click事件响应方法
                    MenuItemSave_Click(sender, e);
            }
        }

        //panelDraw控件的MouseDown(鼠标下压)事件响应方法
        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            //判断是否在绘图
            if (_drawType != DrawType.Stop)
            {
                //如果绘制直线
                if (_drawType == DrawType.Line)
                {
                    //为_tempShape生成一个Line类对象
                    _tempShape = new Line();
                    //保存鼠标下压点坐标(即直线起点)到_tempShape._P1
                    ((Line)_tempShape)._P1 = new Point((int)(e.X/_zoomRatio),(int)( e.Y/_zoomRatio));
                }
                //如果绘制矩形
                else if (_drawType == DrawType.Rectangle)
                {
                    //为_tempShape生成一个Rectangle类对象
                    _tempShape = new Rectangle();
                    //保存鼠标下压点坐标(即矩形第一个对角点)到_tempShape._P1
                    ((Rectangle)_tempShape)._P1 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                //如果绘制圆
                else if (_drawType == DrawType.Circle)
                {
                    //为_tempShape生成一个Circle类对象
                    _tempShape = new Circle();
                    //保存鼠标下压点坐标(即圆心)到_tempShape._P1
                    ((Circle)_tempShape)._PCenter = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                //如果绘制徒手画
                else if (_drawType == DrawType.Sketch)
                {
                    //为tempSketch生成一个Sketch类对象                    
                    _tempShape = new Sketch();
                    //保存保存鼠标下压点坐标(即草图起点)到tempSketch._PointList
                    ((Sketch)_tempShape)._PointList.Add(new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio)));
                }

                //保存画笔线宽和颜色到临时图元(_tempShape)中
                _tempShape._PenWidth = _drawWidth;
                _tempShape._PenColor = _drawColor;
            }
        }

        //panelDraw控件的MouseMove(鼠标移动)事件响应方法
        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            //判断鼠标左键是否处于下压状态
            if (e.Button == MouseButtons.Left)
            {
                //判断是否在绘图
                if (_drawType != DrawType.Stop)
                {
                    //清空图形缓冲区
                    _bufGraph.Graphics.Clear(Color.White);

                    //将屏幕位图绘制到图形缓冲区
                    _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));

                    //逐一绘制所有图元到到图形缓冲区
                    foreach (Shape shape in _listShape)
                        //注意:使用DashStyle类时，需要添加System.Drawing.Drawing2D命名空间
                        shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);

                    //根据绘图类型，保存相应信息到临时图元(_tempShape)中
                    if (_drawType == DrawType.Line)
                        //保存鼠标的当前点坐标(即直线终点)到_tempShape._P2
                        ((Line)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio)); 
      
                    else if (_drawType == DrawType.Rectangle)
                        //保存鼠标的当前点坐标(即矩形第二个对角点)到_tempShape._P2
                        ((Rectangle)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));  
                    else if (_drawType == DrawType.Circle)
                        //保存圆半径到_tempShape._R
                        ((Circle)_tempShape)._R = (float)Math.Sqrt(Math.Pow(( (int)(e.X / _zoomRatio) - ((Circle)_tempShape)._PCenter.X), 2) +
                                                                   Math.Pow(( (int)(e.Y / _zoomRatio) - ((Circle)_tempShape)._PCenter.Y), 2));  
                    else if (_drawType == DrawType.Sketch)
                        //保存鼠标的当前点坐标(即徒手画中间点)到_tempShape._PointList
                        ((Sketch)_tempShape)._PointList.Add(new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio)));

                    //将当前的临时图元(_tempShape)绘制到图形缓冲区
                    _tempShape.Draw(_bufGraph.Graphics, DashStyle.Dash, _zoomRatio);

                    //将图形缓冲区绘制到panelDraw窗口
                    _bufGraph.Render(panelDraw.CreateGraphics());
                }
            }

            //在状态条上显示鼠标的坐标
            StatusLabelMousePosition.Text = "鼠标：x=" + e.X + ", y=" + e.Y;
        }

        //panelDraw控件的MouseUp(鼠标抬起)事件响应方法
        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            //判断是否在绘图
            if (_drawType != DrawType.Stop)
            {
                //如果绘制直线
                if (_drawType == DrawType.Line)
                    //保存鼠标抬起点坐标(即直线终点)到_tempShape._P2
                    ((Line)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                //如果绘制矩形
                else if (_drawType == DrawType.Rectangle)
                    //保存鼠标抬起点坐标(即直线终点)到_tempShape._P2
                    ((Rectangle)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                //如果绘制圆
                else if (_drawType == DrawType.Circle)
                    //保存圆的半径到_tempShape._R
                    ((Circle)_tempShape)._R = (float)Math.Sqrt(Math.Pow(((int)(e.X / _zoomRatio) - ((Circle)_tempShape)._PCenter.X), 2) +
                                                               Math.Pow(((int)(e.Y / _zoomRatio) - ((Circle)_tempShape)._PCenter.Y), 2));
                //如果绘制徒手画
                else if (_drawType == DrawType.Sketch)
                    //保存保存鼠标抬起点坐标(即草图终点)到tempSketch._PointList
                    ((Sketch)_tempShape)._PointList.Add(new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio)));

                //把该图元添加到_listShape集合中
                _listShape.Add(_tempShape);

                //设置保存标记为true(如果为true,表示需要弹出保存对话框;如果为false,表示无需弹出保存对话框)
                _saveFlag = true;

                //清空_listTempShape，以禁止Redo操作
                _listTempShape.Clear();
                //禁止MenuItemRedo菜单和toolStripButtonRedo按钮
                MenuItemRedo.Enabled = false;
                toolStripButtonRedo.Enabled = false;

                //启用MenuItemUndo菜单和toolStripButtonUndo按钮
                MenuItemUndo.Enabled = true;
                toolStripButtonUndo.Enabled = true;

                //清空图形缓冲区
                _bufGraph.Graphics.Clear(Color.White);

                //将屏幕位图绘制到图形缓冲区
                _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));

                //逐一将所有图元绘制到图形缓冲区
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);

                //将图形缓冲区绘制到panelDraw窗口
                _bufGraph.Render(panelDraw.CreateGraphics());
            }
        }

        //panelDraw控件的Paint(窗口绘制)事件响应方法
        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            //清空图形缓冲区
            _bufGraph.Graphics.Clear(Color.White);

            //将屏幕位图绘制到图形缓冲区
            _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));

            //逐一将所有图元绘制到图形缓冲区
            foreach (Shape shape in _listShape)
                shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);

            //将图形缓冲区绘制到panelDraw窗口
            _bufGraph.Render(panelDraw.CreateGraphics());
        }

        //"放大"菜单的Click事件响应方法 
        private void MenuItemZoomIn_Click(object sender, EventArgs e)
        {
            //判断是否达到最大放大倍数
            if (_zoomRatio <= 4)
            {
                //保存缩放比率
                _zoomRatio = _zoomRatio * 1.1;
                //设置panelDraw的宽度和高度
                panelDraw.Width = (int)(_panelDrawInitSize.Width * _zoomRatio);
                panelDraw.Height = (int)(_panelDrawInitSize.Height * _zoomRatio);

                //创建指定大小的图形缓冲区，且其像素格式与panelDraw.CreateGraphics()的像素格式相同
                _bufGraph = _bufGraphCont.Allocate(panelDraw.CreateGraphics(), panelDraw.ClientRectangle);
                //设置抗锯齿平滑模式(注意：需要添加System.Drawing.Drawing2D命名空间)
                _bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                //清空图形缓冲区
                _bufGraph.Graphics.Clear(Color.White);
                //逐一将所有图元绘制图形缓冲区
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                //将图形缓冲区绘制到panelDraw窗口
                _bufGraph.Render(panelDraw.CreateGraphics());
            }
            else
                MessageBox.Show("已经达到最大放大倍数，不能再放大了。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //"缩小"菜单的Click事件响应方法 
        private void MenuItemZoomOut_Click(object sender, EventArgs e)
        {
            //判断是否达到最小缩小倍数
            if (_zoomRatio >= 0.1)
            {
                //保存缩放比率
                _zoomRatio = _zoomRatio * 0.9;
                //设置panelDraw的宽度和高度
                panelDraw.Width = (int)(_panelDrawInitSize.Width * _zoomRatio);
                panelDraw.Height = (int)(_panelDrawInitSize.Height * _zoomRatio);

                //创建指定大小的图形缓冲区，且其像素格式与panelDraw.CreateGraphics()的像素格式相同
                _bufGraph = _bufGraphCont.Allocate(panelDraw.CreateGraphics(), panelDraw.ClientRectangle);
                //设置抗锯齿平滑模式(注意：需要添加System.Drawing.Drawing2D命名空间)
                _bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                //清空图形缓冲区
                _bufGraph.Graphics.Clear(Color.White);
                //逐一将所有图元绘制到图形缓冲区
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                //将图形缓冲区绘制到panelDraw窗口
                _bufGraph.Render(panelDraw.CreateGraphics());
            }
            else
                MessageBox.Show("已经达到最小缩小倍数，不能再缩小了。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //"屏幕画笔"菜单的Click事件响应方法 
        private void MenuItemScreenPen_Click(object sender, EventArgs e)
        {      
            //判断是否处于屏幕画笔状态，以免重复按F3键
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                //最小化当前窗口
                this.WindowState = FormWindowState.Minimized;

                //隐藏窗口所有界面(菜单、工具栏、状态栏等)
                menuStrip1.Visible = false;
                toolStrip1.Visible = false;
                statusStrip1.Visible = false;
                //设置窗口边框为无边框
                this.FormBorderStyle = FormBorderStyle.None;

                //当前线程暂停300毫秒(需要添加"System.Threading"命名空间)
                Thread.Sleep(300);

                //获取屏幕的高度和宽度
                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;

                //把屏幕拷贝到屏幕位图
                _screenBmpGraphics.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));

                //设置panelDraw窗口的宽度和高度等于屏幕的宽度和高度
                panelDraw.Width = screenWidth;
                panelDraw.Height = screenHeight;

                //设置图形缩放比率为默认值1
                _zoomRatio = 1;
                //设置panelDraw窗口的初始尺寸
                _panelDrawInitSize = new Size(panelDraw.Width, panelDraw.Height);

                //创建指定大小的图形缓冲区，且其像素格式与panelDraw.CreateGraphics()的像素格式相同
                _bufGraph = _bufGraphCont.Allocate(panelDraw.CreateGraphics(), panelDraw.ClientRectangle);
                //设置抗锯齿平滑模式(注意：需要添加System.Drawing.Drawing2D命名空间)
                _bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //清空图形缓冲区
                _bufGraph.Graphics.Clear(Color.White);

                //将屏幕位图绘制到图形缓冲区
                _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));

                //将图形缓冲区绘制到panelDraw窗口
                _bufGraph.Render(panelDraw.CreateGraphics());

                //最大化当前窗口
                this.WindowState = FormWindowState.Maximized;

                //创建一个绘图工具箱窗口
                DlgDrawTools myDlgDrawTools = new DlgDrawTools();
                //设置myDlgDrawTools的主窗口对象为当前主窗口
                myDlgDrawTools._formMain = this;
                //把绘图工具箱窗口显示为模态对话框(注意:模态对话框的输入焦点可以转移到其它窗口上，而非模态对话框则不行)
                myDlgDrawTools.Show();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void StatusLabelMousePosition_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }        
    }
}
