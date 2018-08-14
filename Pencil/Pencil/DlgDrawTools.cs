using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pencil
{
    //绘图工具箱窗口类
    public partial class DlgDrawTools : Form
    {
        //类属性：保存FormMain主窗口对象
        public FormMain _formMain;

        //构造方法
        public DlgDrawTools()
        {
            InitializeComponent();
        }

        //"直线"按钮的click事件响应方法
        private void buttonLine_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemLine_Click(null, null);
        }

        //"矩形"按钮的click事件响应方法
        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemRectangle_Click(null, null);
        }

        //"圆"按钮的click事件响应方法
        private void buttonCircle_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemCircle_Click(null, null);
        }

        //"徒手画"按钮的click事件响应方法
        private void buttonSketch_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemSketch_Click(null, null);
        }

        //"线宽"按钮的click事件响应方法
        private void buttonWidth_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemWidth_Click(null, null);
        }

        //"颜色"按钮的click事件响应方法
        private void buttonColor_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemColor_Click(null, null);
        }

        //"撤销"按钮的click事件响应方法
        private void buttonUndo_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemUndo_Click(null, null);
        }

        //"退出"按钮的click事件响应方法
        private void buttonExit_Click(object sender, EventArgs e)
        {
            //显示窗口所有界面(菜单、工具栏、面板、状态栏等)
            _formMain.menuStrip1.Visible = true;
            _formMain.toolStrip1.Visible = true;
            _formMain.statusStrip1.Visible = true;
            _formMain.FormBorderStyle = FormBorderStyle.Sizable;

            //主窗口最小化
            _formMain.WindowState = FormWindowState.Minimized;

            //关闭绘图工具箱窗口
            this.Close();
        }

        //FormClosed(窗口关闭)事件响应方法
        private void DlgDrawTools_FormClosed(object sender, FormClosedEventArgs e)
        {
            //调用"退出"按钮的click事件响应方法
            buttonExit_Click(null, null);
        }

        private void DlgDrawTools_Load(object sender, EventArgs e)
        {

        }
    }
}
