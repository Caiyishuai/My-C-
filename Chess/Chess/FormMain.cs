using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//添加命名空间
using System.IO;
using System.Media;
using System.Diagnostics;

namespace Chess
{
    //棋子枚举类型
    public enum Piece
    {
        无子 = 0,
        红车 = 1, 红马 = 2, 红相 = 3, 红士 = 4, 红帅 = 5, 红炮 = 6, 红卒 = 7,
        蓝车 = 8, 蓝马 = 9, 蓝象 = 10, 蓝士 = 11, 蓝将 = 12, 蓝炮 = 13, 蓝兵 = 14
    }

    //走棋方枚举类型
    public enum Player
    {
        无 = 0, 红 = 1, 蓝 = 2
    }
    
    //主窗口类
    public partial class FormMain : Form
    {
        //保存象棋棋盘的所有棋子值(棋盘共10行9列，但0行0列保留不用)
        private Piece[,] _chess = new Piece[11, 10];

        //保存所有的走棋步骤(List对象)
        private List<Step> _stepList = new List<Step>();

        //保存棋盘(细框)的左上角坐标
        private Point _leftTop = new Point(60, 60);

        //保存棋盘格子的行高和列宽
        private int _rowHeight = 60;
        private int _colWidth = 60;

        //保存棋子半径
        private int _pieceR = 29;

        //保存拾起的棋子值(默认为"无子"，即目前没有拾起棋子)
        private Piece _pickChess = Piece.无子;
        //保存拾起棋子的行号和列号
        private int _pickRow = 0;
        private int _pickCol = 0;

        //保存落下棋子的行号和列号
        private int _dropRow = 0;
        private int _dropCol = 0;

        //保存当前鼠标所在点坐标
        private Point _curMousePoint = new Point(0, 0);

        //保存棋盘桌面位图
        private Bitmap _deskBmp = new Bitmap("desktop.jpg");

        //保存红蓝双方14种棋子位图(为了与Piece枚举类型值对应，_pieceBmp[0]舍弃不用)
        private Bitmap[] _pieceBmp = new Bitmap[15];

        //保存红方头像位图
        private Bitmap _redBmp = new Bitmap("红方头像.bmp");
        //保存蓝方头像位图
        private Bitmap _blueBmp = new Bitmap("蓝方头像.bmp");

        //保存当前的走棋方
        private Player _curPlayer = Player.无;

        //保存项目".exe"文件的所在路径
        private string _exePath;

        //自定义类方法：绘制棋盘
        public void DrawBoard(Graphics g)
        {
            //绘制棋盘桌面
            g.DrawImage(_deskBmp, new Point(0, 0));

            //创建粗画笔和细画笔
            Pen thickPen = new Pen(Color.Black, 6);
            Pen thinPen = new Pen(Color.Black, 2);
            
            //绘制棋盘外围的粗框
            int gap = (int)(_rowHeight*0.15);
            g.DrawRectangle(thickPen, new Rectangle(_leftTop.X - gap, _leftTop.Y - gap, _colWidth * 8 + 2 * gap, _rowHeight * 9 + 2 * gap));

            //绘制棋盘的10条横线(10行)
            for (int row = 1; row <= 10; row++)
            {
                g.DrawLine(thinPen, new Point(_leftTop.X, _leftTop.Y + _rowHeight * (row - 1)),
                                    new Point(_leftTop.X + 8 * _colWidth, _leftTop.Y + _rowHeight * (row - 1)));
            }

            //绘制棋盘的9条竖线(9列)
            for (int col = 1; col <= 9; col++)
            {
                //绘制棋盘上半部分的竖线
                g.DrawLine(thinPen, new Point(_leftTop.X + (col - 1) * _colWidth, _leftTop.Y),
                                    new Point(_leftTop.X + (col - 1) * _colWidth, _leftTop.Y + _rowHeight * 4));
                //绘制棋盘下半部分的竖线
                g.DrawLine(thinPen, new Point(_leftTop.X + (col - 1) * _colWidth, _leftTop.Y + _rowHeight * 5),
                                    new Point(_leftTop.X + (col - 1) * _colWidth, _leftTop.Y + _rowHeight * 9));
            }

            //绘制连接楚河汉界左右两端的两条短竖线
            g.DrawLine(thinPen, new Point(_leftTop.X, _leftTop.Y + _rowHeight * 4),
                                new Point(_leftTop.X, _leftTop.Y + _rowHeight * 5));
            g.DrawLine(thinPen, new Point(_leftTop.X + 8 * _colWidth, _leftTop.Y + _rowHeight * 4),
                                new Point(_leftTop.X + 8 * _colWidth, _leftTop.Y + _rowHeight * 5));

            //绘制上方九宫格的交叉线
            g.DrawLine(thinPen, new Point(_leftTop.X + 3 * _colWidth, _leftTop.Y),
                                new Point(_leftTop.X + 5 * _colWidth, _leftTop.Y + 2 * _rowHeight));
            g.DrawLine(thinPen, new Point(_leftTop.X + 5 * _colWidth, _leftTop.Y),
                                new Point(_leftTop.X + 3 * _colWidth, _leftTop.Y + 2 * _rowHeight));
            //绘制下方九宫格的交叉线
            g.DrawLine(thinPen, new Point(_leftTop.X + 3 * _colWidth, _leftTop.Y + 7 * _rowHeight),
                                new Point(_leftTop.X + 5 * _colWidth, _leftTop.Y + 9 * _rowHeight));
            g.DrawLine(thinPen, new Point(_leftTop.X + 5 * _colWidth, _leftTop.Y + 7 * _rowHeight),
                                new Point(_leftTop.X + 3 * _colWidth, _leftTop.Y + 9 * _rowHeight));

            //书写"楚河"和"汉界"
            Font font1 = new Font("隶书", (float)(_rowHeight * 0.8), FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString("楚河", font1, brush, new Point(_leftTop.X + _colWidth, (int)(_leftTop.Y + _rowHeight * 4.1)));
            g.DrawString("汉界", font1, brush, new Point(_leftTop.X + _colWidth * 5, (int)(_leftTop.Y + _rowHeight * 4.1)));

            //书写行的数字编号
            Font font2 = new Font("黑体", (float)(_rowHeight * 0.6), FontStyle.Regular, GraphicsUnit.Pixel);
            for (int row = 1; row <= 10; row++)
                g.DrawString(row.ToString(), font2, brush, new Point((int)(_leftTop.X + _colWidth * 8.6),
                                                                     (int)(_leftTop.Y - _rowHeight * 0.4 + _rowHeight * (row - 1))));
            //书写列的数字编号
            string[] colNumber = new string[9] { "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            Font font3 = new Font("黑体", (float)(_rowHeight * 0.5), FontStyle.Regular, GraphicsUnit.Pixel);
            for (int col = 1; col <= 9; col++)
                g.DrawString(colNumber[col - 1], font3, brush, new Point((int)(_leftTop.X - _colWidth * 0.3 + _colWidth * (col - 1)),
                                                                         (int)(_leftTop.Y + _rowHeight * 9.6)));

            //书写"蓝方"和"红方"
            g.DrawString("蓝方", font3, brush, new Point(_leftTop.X + 8 * _colWidth + 95, _leftTop.Y + (int)(2.2 * _rowHeight)));
            g.DrawString("红方", font3, brush, new Point(_leftTop.X + 8 * _colWidth + 95, _leftTop.Y + (int)(6.4 * _rowHeight)));

            //绘制棋盘第3行的炮营营地标志
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 1, _leftTop.Y + _rowHeight * 2), true, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 7, _leftTop.Y + _rowHeight * 2), true, true);
            //绘制棋盘第4行的兵营营地标志
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 0, _leftTop.Y + _rowHeight * 3), false, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 2, _leftTop.Y + _rowHeight * 3), true, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 4, _leftTop.Y + _rowHeight * 3), true, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 6, _leftTop.Y + _rowHeight * 3), true, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 8, _leftTop.Y + _rowHeight * 3), true, false);
            //绘制棋盘第7行的兵营营地标志
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 0, _leftTop.Y + _rowHeight * 6), false, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 2, _leftTop.Y + _rowHeight * 6), true, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 4, _leftTop.Y + _rowHeight * 6), true, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 6, _leftTop.Y + _rowHeight * 6), true, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 8, _leftTop.Y + _rowHeight * 6), true, false);
            //绘制棋盘第8行的炮营营地标志
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 1, _leftTop.Y + _rowHeight * 7), true, true);
            DrawCampMark(g, new Point(_leftTop.X + _colWidth * 7, _leftTop.Y + _rowHeight * 7), true, true);

            //绘制拾子位置的标记
            DrawPickDropMark(g, _pickRow, _pickCol);
            //绘制落子位置的标记
            DrawPickDropMark(g, _dropRow, _dropCol);

            //在相应的位置绘制走棋方的头像
            if (_curPlayer == Player.蓝)
                g.DrawImage(_redBmp, new Point(_leftTop.X + 8 * _colWidth + 95, _leftTop.Y + 1 * _rowHeight - 10));
            else if (_curPlayer == Player.红)
                g.DrawImage(_blueBmp, new Point(_leftTop.X + 8 * _colWidth + 95, _leftTop.Y + 7 * _rowHeight + 10));
        }

        //自定义类方法：绘制(炮和兵的)营地标志
        public void DrawCampMark(Graphics g, Point center, Boolean drawLeft, Boolean drawRight)
        {
            //偏移量
            int offset = (int)(_rowHeight * 0.08);
            //段长度
            int length = (int)(_rowHeight * 0.16);
            //直角点坐标
            Point corner = new Point();
            //画笔对象
            Pen thinPen = new Pen(Color.Black, 1);            

            //是否需要绘制左边标志
            if (drawLeft == true)
            {
                //绘制左上角的直角边
                corner.X = center.X - offset;
                corner.Y = center.Y - offset;
                g.DrawLine(thinPen, new Point(corner.X, corner.Y), new Point(corner.X - length, corner.Y));
                g.DrawLine(thinPen, new Point(corner.X, corner.Y), new Point(corner.X, corner.Y - length));

                //绘制左下角的直角边
                corner.X = center.X - offset;
                corner.Y = center.Y + offset;
                g.DrawLine(thinPen, new Point(corner.X, corner.Y), new Point(corner.X - length, corner.Y));
                g.DrawLine(thinPen, new Point(corner.X, corner.Y), new Point(corner.X, corner.Y + length));
            }

            //是否需要绘制右边标志
            if (drawRight == true)
            {
                //绘制右上角的直角边
                corner.X = center.X + offset;
                corner.Y = center.Y - offset;
                g.DrawLine(thinPen, new Point(corner.X, corner.Y), new Point(corner.X + length, corner.Y));
                g.DrawLine(thinPen, new Point(corner.X, corner.Y), new Point(corner.X, corner.Y - length));

                //绘制右下角的直角边
                corner.X = center.X + offset;
                corner.Y = center.Y + offset;
                g.DrawLine(thinPen, new Point(corner.X, corner.Y), new Point(corner.X + length, corner.Y));
                g.DrawLine(thinPen, new Point(corner.X, corner.Y), new Point(corner.X, corner.Y + length));
            }
        }

        //自定义类方法：绘制棋子
        public void DrawPiece(Graphics g)
        {
            //逐行逐列绘制象棋棋子
            for (int row = 1; row <= 10; row++)
                for (int col = 1; col <= 9; col++)
                {
                    //如果该位置存在棋子                
                    if (_chess[row, col] != Piece.无子)
                    {                        
                        //在棋盘交点位置绘制棋子
                        g.DrawImage(_pieceBmp[(int)_chess[row, col]], 
                                    new Point(_leftTop.X + (col - 1) * _colWidth - _pieceR,
                                    _leftTop.Y + (row - 1) * _rowHeight - _pieceR));
                    }
                }

            //在当前鼠标点位置绘制拾起的棋子，以显示出拾起的棋子随鼠标而动的效果
            if (_pickChess != Piece.无子)
            {
                g.DrawImage(_pieceBmp[(int)_pickChess],
                            new Point(_curMousePoint.X - _pieceR, _curMousePoint.Y - _pieceR));
            }
        }

        //自定义类方法：通过代码绘制单个棋子
        public void DrawPieceByCode(Graphics g, int row, int col, Piece chess)
        {
            //画笔
            Pen pen;
            //实体画刷(分别用于书写文字和填充棋子外圆)
            SolidBrush fontBrush, circleBrush;

            //根据棋盘格子的行高确定棋子半径
            _pieceR = (int)(_rowHeight * 0.45);

            //判断是否为"无子"
            if (chess != Piece.无子)
            {
                //根据棋子的所在方，创建相应颜色的画笔和实体画刷
                if (chess.ToString().Substring(0, 1) == "红")
                {
                    pen = new Pen(Color.Red, 6);
                    fontBrush = new SolidBrush(Color.Red);
                }
                else
                {
                    pen = new Pen(Color.Blue, 6);
                    fontBrush = new SolidBrush(Color.Blue);
                }
                //绘制棋子外圆
                g.DrawEllipse(pen, _leftTop.X + (col - 1) * _colWidth - _pieceR, _leftTop.Y + (row - 1) * _rowHeight - _pieceR, _pieceR * 2, _pieceR * 2);
                //填充棋子外圆
                circleBrush = new SolidBrush(Color.Yellow);
                g.FillEllipse(circleBrush, _leftTop.X + (col - 1) * _colWidth - _pieceR, _leftTop.Y + (row - 1) * _rowHeight - _pieceR,
                              _pieceR * 2, _pieceR * 2);
                //书写棋子文字
                Font font = new Font("隶书", (float)(_pieceR * 1.9), FontStyle.Regular, GraphicsUnit.Pixel);
                g.DrawString(chess.ToString().Substring(1, 1), font, fontBrush, 
                             new Point(_leftTop.X + (col - 1) * _colWidth - (int)((_pieceR * 2.5)/2), 
                                       _leftTop.Y + (row - 1) * _rowHeight - (_pieceR * 2)/2));
            }
        }

        //自定义类方法：把鼠标点击位置坐标转换为棋盘的行号和列号
        public bool ConvertPointToRowCol(Point p, out int row, out int col)
        {
            //获取与鼠标点击位置距离最近的棋盘交叉点的行号
            row = (p.Y - _leftTop.Y) / _rowHeight + 1;
            //如果鼠标点Y坐标超过棋盘行高的中线，则行号需要再加1
            if (((p.Y - _leftTop.Y) % _rowHeight) >= _rowHeight / 2)
                row = row + 1;

            //获取与鼠标点击位置距离最近的棋盘交叉点的列号
            col = (p.X - _leftTop.X) / _colWidth + 1;
            //如果鼠标点X坐标超过棋盘列宽的中线，则列号需要再加1
            if (((p.X - _leftTop.X) % _colWidth) >= _colWidth / 2)
                col = col + 1;

            //获取与鼠标点击位置距离最近的棋盘交叉点的坐标
            Point chessP = new Point();
            chessP.X = _leftTop.X + _colWidth * (col - 1);
            chessP.Y = _leftTop.Y + _rowHeight * (row - 1);

            //判断是否落在棋子半径之内，且在10行9列之内
            double dist = Math.Sqrt(Math.Pow(p.X - chessP.X, 2) + Math.Pow(p.Y - chessP.Y, 2));
            if ((dist <= _pieceR) && (row <= 10) && (row >= 1) && (col <= 9) && (col >= 1))
            {
                //返回true，表示该点击为有效点击
                return true;
            }
            else
            {
                //把行号和列号设置为0，并返回false，表示该点击为无效点击
                row = 0; col = 0;
                return false;
            }
        }

        //自定义类方法：绘制拾子或落子位置的标记
        public void DrawPickDropMark(Graphics g, int row,int col)
        {
            //如果拾子或落子位置不存在
            if (row != 0)
            {
                //画笔对象
                Pen pen = new Pen(Color.Yellow, 4);
                //拾子或落子位置的点坐标
                Point p = new Point(_leftTop.X + _colWidth * (col - 1), _leftTop.Y + _rowHeight * (row - 1));

                //在拾子或落子位置的四个角绘制标记
                g.DrawLine(pen, p.X - _pieceR, p.Y - _pieceR, p.X - _pieceR / 2, p.Y - _pieceR);
                g.DrawLine(pen, p.X - _pieceR, p.Y - _pieceR, p.X - _pieceR, p.Y - _pieceR / 2);

                g.DrawLine(pen, p.X + _pieceR, p.Y - _pieceR, p.X + _pieceR / 2, p.Y - _pieceR);
                g.DrawLine(pen, p.X + _pieceR, p.Y - _pieceR, p.X + _pieceR, p.Y - _pieceR / 2);

                g.DrawLine(pen, p.X - _pieceR, p.Y + _pieceR, p.X - _pieceR / 2, p.Y + _pieceR);
                g.DrawLine(pen, p.X - _pieceR, p.Y + _pieceR, p.X - _pieceR, p.Y + _pieceR / 2);

                g.DrawLine(pen, p.X + _pieceR, p.Y + _pieceR, p.X + _pieceR / 2, p.Y + _pieceR);
                g.DrawLine(pen, p.X + _pieceR, p.Y + _pieceR, p.X + _pieceR, p.Y + _pieceR / 2);
            }
        }

        //自定义类方法：播放声音文件
        public void PlaySound(string wavFile)
        {
            //装载声音文件(需要添加System.Media命名空间)
            SoundPlayer soundPlay = new SoundPlayer(wavFile);
            //使用新线程播放声音
            soundPlay.Play();    //注意：soundPlay.PlaySync()也可以播放声音，该方法使用用户界面(UI)线程播放，会导致用户界面的停顿
        }

        //构造方法
        public FormMain()
        {
            InitializeComponent();

            //获取项目.exe文件的所在目录和文件名(需要添加System.Diagnostics命名空间)
            string exePathFileName = Process.GetCurrentProcess().MainModule.FileName;
            //获取.exe文件所在的路径名
            _exePath = System.IO.Path.GetDirectoryName(exePathFileName) + "\\";

            //根据屏幕的分辨率设置棋盘格子的行高和列度
            _rowHeight = Screen.PrimaryScreen.Bounds.Size.Height / 14;
            _colWidth = _rowHeight;

            //设置象棋棋盘左上角坐标
            _leftTop.Y = 2 * _rowHeight;
            _leftTop.X = _leftTop.Y;

            //把象棋棋盘的棋子数组初始化为"无子"
            for (int row = 1; row <= 10; row++)
                for (int col = 1; col <= 9; col++)
                    _chess[row, col] = Piece.无子;

            //装载红蓝双方所有的棋子位图文件(_pieceBmp[0]舍弃不用)
            for (int i = 1; i <= 14; i++)
            {
                _pieceBmp[i] = new Bitmap(((Piece)i).ToString() + ".bmp");
                _pieceBmp[i].MakeTransparent(Color.White);
            }

            //设置红蓝方头像位图的透明色
            _redBmp.MakeTransparent(Color.White);
            _blueBmp.MakeTransparent(Color.White);
        }

        //Paint(窗口绘制)事件响应方法
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            //绘制棋盘
            DrawBoard(e.Graphics);

            //绘制棋子
            DrawPiece(e.Graphics);
        }

        //MouseDown(鼠标下压)事件响应方法
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            //如果是鼠标左键下压，则拾起棋子或落下棋子
            if (e.Button == MouseButtons.Left)
            {
                //把鼠标点击位置坐标转换为棋盘的行号和列号
                int row, col;
                bool valid = ConvertPointToRowCol(new Point(e.X, e.Y), out row, out col);

                //判断鼠标点击是否有效
                if (valid == true)
                {
                    //处理拾子动作(判断拾起的棋子值是否为"无子"，"无子"表示目前没有拾起棋子)
                    if (_pickChess == Piece.无子)
                    {
                        //判断该位置是否有棋子，且棋子属于当前的走棋方
                        if (_chess[row, col] != Piece.无子 && _chess[row, col].ToString().IndexOf(_curPlayer.ToString()) == 0)
                        {
                            //保存拾起的棋子值
                            _pickChess = _chess[row, col];
                            //保存拾子位置的行号和列号
                            _pickRow = row;
                            _pickCol = col;

                            //清空拾子位置的棋子值
                            _chess[_pickRow, _pickCol] = Piece.无子;

                            //强制刷新窗口(注意：Invalidate()会触发窗口的Paint事件)
                            Invalidate();
                        }
                    }
                    //处理落子动作
                    else
                    {
                        //判断落子位置是否为无子，或者为对方棋子
                        if (_chess[row, col] == Piece.无子 || _chess[row, col].ToString().IndexOf(_curPlayer.ToString()) == -1)
                        {
                            //定义落子标志，默认为false，表示不能落子
                            bool canDrop = false;

                            //根据拾起的棋子值，进行相应的走棋规则判定。如果通过规则判定，则canDrop为true，可以落子
                            //象的走棋规则判定
                            if (_pickChess == Piece.蓝象)
                            {
                                //如果走田字、不绊象脚且不过河，则可以落子
                                if (Math.Abs(_pickRow - row) == 2 && Math.Abs(_pickCol - col) == 2
                                     && _chess[(_pickRow + row) / 2, (_pickCol + col) / 2] == Piece.无子 && row <= 5)
                                    canDrop = true;
                            }
                            if (_pickChess == Piece.红相)
                            {
                                //如果走田字、中央无子且不越界时
                                if (Math.Abs(_pickRow - row) == 2 && Math.Abs(_pickCol - col) == 2
                                    && _chess[(_pickRow + row) / 2, (_pickCol + col) / 2] == Piece.无子 && row >= 6)
                                    canDrop = true;
                            }

                            //马的走棋规则判定
                            if (_pickChess == Piece.红马 || _pickChess == Piece.蓝马)
                            {
                                //如果横着走日字,且不绊马脚
                                if (Math.Abs(_pickRow - row) == 1 && Math.Abs(_pickCol - col) == 2 && 
                                    _chess[_pickRow, (_pickCol + col) / 2] == Piece.无子)
                                    canDrop = true;

                                //如果竖着走日字,且不绊马脚
                                if (Math.Abs(_pickRow - row) == 2 && Math.Abs(_pickCol - col) == 1 && 
                                    _chess[(_pickRow + row) / 2, _pickCol] == Piece.无子)
                                    canDrop = true;
                            }

                            //兵的走棋规则判定
                            if (_pickChess == Piece.蓝兵)
                            {
                                //兵没过界时
                                if (_pickRow <= 5)
                                {
                                    if (row == _pickRow + 1 && col == _pickCol)
                                        canDrop = true;
                                }
                                //兵已经过界时
                                else
                                {
                                    //如果兵横着走
                                    if (row == _pickRow && Math.Abs(col - _pickCol) == 1)
                                        canDrop = true;
                                    //如果兵竖着走(往下走)
                                    if (col == _pickCol && (row - _pickRow) == 1)
                                        canDrop = true;
                                }
                            }
                            if (_pickChess == Piece.红卒)
                            {
                                //兵没过界时
                                if (_pickRow >= 6)
                                {
                                    if (row == _pickRow - 1 && col == _pickCol)
                                        canDrop = true;
                                }
                                //兵已经过界时
                                else
                                {
                                    //如果兵横着走
                                    if (row == _pickRow && Math.Abs(col - _pickCol) == 1)
                                        canDrop = true;
                                    //如果兵竖着走(往上走)
                                    if (col == _pickCol && (row - _pickRow) == -1)
                                        canDrop = true;
                                }
                            }

                            //车的走棋规则判定                          
                            if (_pickChess == Piece.红车 || _pickChess == Piece.蓝车)
                            {
                                //如果车横着走
                                if (_pickRow == row)
                                {
                                    //比较起点列和落点列的大小
                                    int max = col > _pickCol ? col : _pickCol;
                                    int min = col > _pickCol ? _pickCol : col;

                                    //统计移动路径上(即起点列和落点列之间)的棋子个数
                                    int chessNum = 0;
                                    for (int i = min + 1; i <= max - 1; i++)
                                        if (_chess[row, i] != Piece.无子)
                                            chessNum++;
                                    //只有当移动路径上(即起点列和落点列之间)的棋子个数为0时，才允许落子
                                    if (chessNum == 0)
                                        canDrop = true;
                                }
                                //如果车竖着走
                                if (_pickCol == col)
                                {
                                    //比较起点行和落点行的大小
                                    int max = row > _pickRow ? row : _pickRow;
                                    int min = row > _pickRow ? _pickRow : row;

                                    //统计移动路径上(即起点行和落点行之间)的棋子个数
                                    int chessNum = 0;
                                    for (int i = min + 1; i <= max - 1; i++)
                                        if (_chess[i, col] != Piece.无子)
                                            chessNum++;
                                    //只有当移动路径上(即起点行和落点行之间)的棋子个数为0时，才允许落子
                                    if (chessNum == 0)
                                        canDrop = true;
                                }
                            }

                            //炮的走棋规则判定
                            if (_pickChess == Piece.红炮 || _pickChess == Piece.蓝炮)
                            {
                                //如果落点位置有棋子(吃子)，则要求移动路径上只有一颗棋子
                                if (_chess[row, col] != Piece.无子)
                                {
                                    //如果炮横着走
                                    if (_pickRow == row)
                                    {
                                        //判断起点列和落点列的大小
                                        int max = col > _pickCol ? col : _pickCol;
                                        int min = col < _pickCol ? col : _pickCol;

                                        //统计移动路径上(即起点列和落点列之间)的棋子个数
                                        int chessNum = 0;
                                        for (int i = min + 1; i <= max - 1; i++)
                                            if (_chess[row, i] != Piece.无子)
                                                chessNum++;
                                        //只有当移动路径上(即起点列和落点列之间)的棋子个数为1时，才允许落子
                                        if (chessNum == 1)
                                            canDrop = true;
                                    }
                                    //如果炮竖着走
                                    if (_pickCol == col)
                                    {
                                        //判断起点行和落点行的大小
                                        int max = row > _pickRow ? row : _pickRow;
                                        int min = row < _pickRow ? row : _pickRow;

                                        //统计移动路径上(即起点行和落点行之间)的棋子个数
                                        int chessNum = 0;
                                        for (int i = min + 1; i <= max - 1; i++)
                                            if (_chess[i, col] != Piece.无子)
                                                chessNum++;
                                        //只有当移动路径上(即起点行和落点行之间)的棋子个数为1时，才允许落子
                                        if (chessNum == 1)
                                            canDrop = true;
                                    }
                                }
                                //如果落点位置没有棋子(不吃子)，则要求移动路径上没有棋子
                                else if (_chess[row, col] == Piece.无子)
                                {
                                    //如果炮横着走
                                    if (_pickRow == row)
                                    {
                                        //判断起点列和落点列的大小
                                        int max = col > _pickCol ? col : _pickCol;
                                        int min = col < _pickCol ? col : _pickCol;

                                        //统计移动路径上(即起点列和落点列之间)的棋子个数
                                        int chessNum = 0;
                                        for (int i = min + 1; i <= max - 1; i++)
                                            if (_chess[row, i] != Piece.无子)
                                                chessNum++;
                                        //只有当移动路径上(即起点列和落点列之间)的棋子个数为0时，才允许落子
                                        if (chessNum == 0)
                                            canDrop = true;
                                    }
                                    //如果炮竖着走
                                    if (_pickCol == col)
                                    {
                                        //判断起点行和落点行的大小
                                        int max = row > _pickRow ? row : _pickRow;
                                        int min = row < _pickRow ? row : _pickRow;

                                        //统计移动路径上(即起点行和落点行之间)的棋子个数
                                        int chessNum = 0;
                                        for (int i = min + 1; i <= max - 1; i++)
                                            if (_chess[i, col] != Piece.无子)
                                                 chessNum++;
                                        //只有当移动路径上(即起点列和落点列之间)的棋子个数为0时，才允许落子
                                        if (chessNum == 0)
                                            canDrop = true;
                                    }
                                }
                            }

                            //士的走棋规则判定
                            if (_pickChess == Piece.蓝士)
                                if (Math.Abs(_pickRow - row) == 1 && Math.Abs(_pickCol - col) == 1 && row <= 3 && col >= 4 && col <= 6)
                                    canDrop = true;
                            if (_pickChess == Piece.红士)
                                if (Math.Abs(_pickRow - row) == 1 && Math.Abs(_pickCol - col) == 1 && row >= 8 && col >= 4 && col <= 6)
                                    canDrop = true;

                            //帅的走棋规则判定
                            if (_pickChess == Piece.蓝将)
                            {
                                //在九宫格内走
                                if ((Math.Abs(_pickRow - row) == 1 && _pickCol == col) || (_pickRow == row && Math.Abs(_pickCol - col) == 1))
                                {
                                    if (row <= 3 && col >= 4 && col <= 6)
                                        canDrop = true;
                                }
                                //面对面直接吃对方的红帅
                                else if(_chess[row,col] == Piece.红帅 && _pickCol== col)
                                {
                                    //统计蓝将与红帅之间存在的棋子个数
                                    int chessNum = 0;
                                    for (int i = _pickRow + 1; i < row; i++)
                                        if (_chess[i, col] != Piece.无子)
                                            chessNum++;
                                    if(chessNum == 0)
                                        canDrop = true;
                                }

                            }
                            if (_pickChess == Piece.红帅)
                            {
                                //在九宫格内走
                                if ((Math.Abs(_pickRow - row) == 1 && _pickCol == col) || (_pickRow == row && Math.Abs(_pickCol - col) == 1))
                                {
                                    if (row >= 8 && col >= 4 && col <= 6)
                                        canDrop = true;
                                }
                                //面对面直接吃对方的蓝将
                                else if (_chess[row, col] == Piece.蓝将 && _pickCol == col)
                                {
                                    int chessNum = 0;
                                    for (int i = row + 1; i < _pickRow; i++)
                                        if (_chess[i, col] != Piece.无子)
                                            chessNum++;
                                    if (chessNum == 0)
                                        canDrop = true;
                                }
                            }                            

                            //如果通过走棋规则判定，则可以落子
                            if (canDrop == true)
                            {
                                //保存走棋步骤到_stepList中 
                                Step tempStep = new Step();
                                tempStep._Player = _curPlayer;
                                tempStep._PickChess = _pickChess;
                                tempStep._PickRow = _pickRow;
                                tempStep._PickCol = _pickCol;
                                tempStep._DropChess = _chess[row, col];
                                tempStep._DropRow = row;
                                tempStep._DropCol = col;
                                _stepList.Add(tempStep);
                                
                                //判断被吃的棋子是否为"红帅"或者"蓝将"
                                if (_chess[row, col] == Piece.红帅 || _chess[row, col] == Piece.蓝将)
                                {
                                    //播放相应的声音文件
                                    PlaySound(_exePath + "Sounds\\over.wav");

                                    //显示获胜方信息
                                    MessageBox.Show(_curPlayer.ToString() + "方获胜!", "提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //禁止继续走棋
                                    _curPlayer = Player.无;
                                }
                                else
                                {
                                    //播放相应的声音文件
                                    if (tempStep._DropChess == Piece.无子)
                                        PlaySound(_exePath + "Sounds\\drop.wav");
                                    else
                                        PlaySound(_exePath + "Sounds\\eat.wav");

                                    //交换走棋方
                                    if (_curPlayer == Player.红)
                                        _curPlayer = Player.蓝;
                                    else
                                        _curPlayer = Player.红;
                                }

                                //设置落子位置的棋子值为拾起的棋子值
                                _chess[row, col] = _pickChess;
                                //清空_pickChess值
                                _pickChess = Piece.无子;
                                //保存落子位置的行号和列号
                                _dropRow = row;
                                _dropCol = col;

                                //强制刷新窗口(注意：Invalidate()会触发窗口的Paint事件)
                                Invalidate();
                            }
                        }
                    }
                }
            }
            //如果是鼠标右键下压，则取消拾起的棋子
            else if (e.Button == MouseButtons.Right)
            {
                //判断是否已经拾起了棋子
                if (_pickChess != Piece.无子)
                {
                    //把拾子位置设置为拾起棋子的值
                    _chess[_pickRow, _pickCol] = _pickChess;

                    //清空拾起的棋子值、拾子行号、拾子列号
                    _pickChess = Piece.无子;
                    _pickRow = 0;
                    _pickCol = 0;

                    //强制刷新窗口(注意：Invalidate()会触发窗口的Paint事件)
                    Invalidate();
                }
            }
        }

        //MouseMove(鼠标移动)事件响应方法
        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            //保存当前鼠标所在点的坐标
            _curMousePoint = e.Location;

            //判断是否已经拾起棋子，以决定是否需要强制刷新窗口
            if (_pickChess != Piece.无子)
            {
                //强制刷新窗口，以绘制出拾起的棋子随鼠标而动的效果
                Invalidate();
            }
        }   

        //"开局"菜单的Click事件响应方法
        private void MenuItemBegin_Click(object sender, EventArgs e)
        {
            //显示提示确认框
            if (MessageBox.Show("你是否需要挑战伟大的昊昊?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //清空_stepList中的走棋步骤。思考：如果开局时不清空原有的走棋步骤，会出现什么问题？
                _stepList.Clear();

                //设置走棋方(红方先走)
                _curPlayer = Player.红;

                //把象棋棋盘的棋子数组初始化为"无子"
                for (int row = 1; row <= 10; row++)
                    for (int col = 1; col <= 9; col++)
                        _chess[row, col] = Piece.无子;

                //初始化蓝方棋子(蓝方在上)
                _chess[1, 1] = Piece.蓝车; _chess[1, 2] = Piece.蓝马; _chess[1, 3] = Piece.蓝象;
                _chess[1, 4] = Piece.蓝士; _chess[1, 5] = Piece.蓝将; _chess[1, 6] = Piece.蓝士;
                _chess[1, 7] = Piece.蓝象; _chess[1, 8] = Piece.蓝马; _chess[1, 9] = Piece.蓝车;
                _chess[3, 2] = Piece.蓝炮; _chess[3, 8] = Piece.蓝炮;
                _chess[4, 1] = Piece.蓝兵; _chess[4, 3] = Piece.蓝兵; _chess[4, 5] = Piece.蓝兵;
                _chess[4, 7] = Piece.蓝兵; _chess[4, 9] = Piece.蓝兵;

                //初始化红方棋子(红方在下)
                _chess[10, 1] = Piece.红车; _chess[10, 2] = Piece.红马; _chess[10, 3] = Piece.红相;
                _chess[10, 4] = Piece.红士; _chess[10, 5] = Piece.红帅; _chess[10, 6] = Piece.红士;
                _chess[10, 7] = Piece.红相; _chess[10, 8] = Piece.红马; _chess[10, 9] = Piece.红车;
                _chess[8, 2] = Piece.红炮; _chess[8, 8] = Piece.红炮;
                _chess[7, 1] = Piece.红卒; _chess[7, 3] = Piece.红卒; _chess[7, 5] = Piece.红卒;
                _chess[7, 7] = Piece.红卒; _chess[7, 9] = Piece.红卒;

                //初始化拾起的棋子值为"无子"
                _pickChess = Piece.无子;
                //初始化拾起棋子的行号和列号为0
                _pickRow = 0;
                _pickCol = 0;
                //初始化落下棋子的行号和列号为0
                _dropRow = 0;
                _dropCol = 0;

                //使窗口失效，并发送Paint消息，从而触发Paint事件响应方法重绘棋盘和棋子
                Invalidate();

                //播放声音文件
                PlaySound(_exePath + "Sounds\\begin.wav");
            }
        }

        //"悔棋"菜单的Click事件响应方法
        private void MenuItemUndo_Click(object sender, EventArgs e)
        {
            //如果_stepList有走棋步骤，则可以悔棋
            if (_stepList.Count >= 1)
            {
                //显示提示确认框
                if (MessageBox.Show("你是否需要悔棋?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //取出_stepList的最后一步走棋步骤到lastStep中
                    Step lastStep = _stepList[_stepList.Count - 1];

                    //还原最后一步走棋步骤
                    _curPlayer = lastStep._Player;
                    _chess[lastStep._PickRow, lastStep._PickCol] = lastStep._PickChess;
                    _chess[lastStep._DropRow, lastStep._DropCol] = lastStep._DropChess;

                    //删除_stepList的最后一步走棋步骤
                    _stepList.RemoveAt(_stepList.Count - 1);

                    //清空拾起的棋子值、拾子行号、拾子列号、落子行号、落子列号
                    _pickChess = Piece.无子;
                    _pickRow = 0;
                    _pickCol = 0;
                    _dropRow = 0;
                    _dropCol = 0;

                    //如果_stepList还有走棋步骤，则需要显示上一步的拾子位置标记和落子位置标记
                    if (_stepList.Count >= 1)
                    {
                        //取出_stepList的最后一步走棋步骤到lastStep中
                        lastStep = _stepList[_stepList.Count - 1];
                        _pickRow = lastStep._PickRow;
                        _pickCol = lastStep._PickCol;
                        _dropRow = lastStep._DropRow;
                        _dropCol = lastStep._DropCol;
                    }

                    //强制刷新窗口(注意：Invalidate()会触发窗口的Paint事件)
                    Invalidate();
                }
            }
        }

        //"保存残局"菜单的Click事件响应方法
        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            //显示保存残局对话框
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //创建一个文件流对象，用于写文件(需要添加System.IO命名空间)
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                //创建一个与文件流对象相对应的二进制写入流对象
                BinaryWriter bw = new BinaryWriter(fs);

                //写入当前的走棋方
                bw.Write((int)_curPlayer);
                //逐一写入棋子值
                for (int row = 1; row <= 10; row++)
                    for (int col = 1; col <= 9; col++)
                        bw.Write((int)_chess[row, col]);

                //写入走棋步骤数
                bw.Write(_stepList.Count);
                //逐一写入走棋步骤
                for (int i = 0; i <= _stepList.Count - 1; i++)
                {
                    bw.Write((int)_stepList[i]._Player);   
                    bw.Write((int)_stepList[i]._PickChess);
                    bw.Write(_stepList[i]._PickRow);       
                    bw.Write(_stepList[i]._PickCol);
                    bw.Write((int)_stepList[i]._DropChess);
                    bw.Write(_stepList[i]._DropRow);       
                    bw.Write(_stepList[i]._DropCol);
                }                

                //关闭有关文件流对象
                bw.Close();
                fs.Close();
            }
        }

        //"打开残局"菜单的Click事件响应方法
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            //显示打开残局对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //创建一个文件流对象，用于读文件
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                //创建一个与文件流对象相对应的二进制读入流对象
                BinaryReader br = new BinaryReader(fs);

                //读取当前的走棋方
                _curPlayer = (Player)br.ReadInt32();

                //逐一读取棋子值
                for (int row = 1; row <= 10; row++)
                    for (int col = 1; col <= 9; col++)
                        _chess[row, col] = (Piece)br.ReadInt32();

                //读取走棋步骤数
                int count = br.ReadInt32();

                //清空原有的走棋步骤
                _stepList.Clear();
                //逐一读取走棋步骤
                for (int i = 0; i <= count - 1; i++)
                {
                    //读取走棋步骤到List中 
                    Step step = new Step();
                    step._Player = (Player)br.ReadInt32();
                    step._PickChess = (Piece)br.ReadInt32();
                    step._PickRow = br.ReadInt32();
                    step._PickCol = br.ReadInt32();
                    step._DropChess = (Piece)br.ReadInt32();
                    step._DropRow = br.ReadInt32();
                    step._DropCol = br.ReadInt32();
                    _stepList.Add(step);

                    //
                }

                //初始化拾起的棋子值为"无子"
                _pickChess = Piece.无子;
                //初始化拾起棋子的行号和列号为0
                _pickRow = 0;
                _pickCol = 0;
                //初始化落下棋子的行号和列号为0
                _dropRow = 0;
                _dropCol = 0;

                //如果_stepList还有走棋步骤，则需要显示上一步的拾子位置标记和落子位置标记
                if (_stepList.Count >= 1)
                {
                    //取出_stepList的最后一步走棋步骤到lastStep中
                    Step lastStep = _stepList[_stepList.Count - 1];
                    _pickRow = lastStep._PickRow;
                    _pickCol = lastStep._PickCol;
                    _dropRow = lastStep._DropRow;
                    _dropCol = lastStep._DropCol;
                }

                //关闭有关文件流对象
                br.Close();
                fs.Close();

                //强制刷新窗口(注意：Invalidate()会触发窗口的Paint事件)
                Invalidate();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
