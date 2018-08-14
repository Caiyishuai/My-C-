using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//添加以下命名空间
using System.IO;
using System.Reflection; 
using System.Resources;

namespace MyTimer
{
    public partial class Form1 : Form
    {
        //类字段变量声明

        //类字段：当前的时间计数值(以秒为单位)
        private int _nowSecond = 0;
        //类字段：冒号控制标志
        private Boolean _colonFlag = true;

        //数码管位图数组
        private Bitmap[] _bmpShow = new Bitmap[13];

        //自定义方法：由显示字符获取对应的数码管位图
        private Image GetResourceImage(string displayStr)
        {
            if (displayStr == "0")
                return _bmpShow[0];
            else if (displayStr == "1")
                return _bmpShow[1];
            else if (displayStr == "2")
                return _bmpShow[2];
            else if (displayStr == "3")
                return _bmpShow[3];
            else if (displayStr == "4")
                return _bmpShow[4];
            else if (displayStr == "5")
                return _bmpShow[5];
            else if (displayStr == "6")
                return _bmpShow[6];
            else if (displayStr == "7")
                return _bmpShow[7];
            else if (displayStr == "8")
                return _bmpShow[8];
            else if (displayStr == "9")
                return _bmpShow[9];
            else if (displayStr == ".")
                return _bmpShow[10];
            else if (displayStr == ":")
                return _bmpShow[11];
            else
                return _bmpShow[12];
        }

        //构造函数
        public Form1()
        {
            InitializeComponent();
            //初始化时间计数值(秒)
            _nowSecond = 0;
            //装载数码管位图文件(注意：要保证Debug目录下有images子目录及bmp文件，否则会报错)
            _bmpShow[0] = new Bitmap("images/0.bmp");
            _bmpShow[1] = new Bitmap("images/1.bmp");
            _bmpShow[2] = new Bitmap("images/2.bmp");
            _bmpShow[3] = new Bitmap("images/3.bmp");
            _bmpShow[4] = new Bitmap("images/4.bmp");
            _bmpShow[5] = new Bitmap("images/5.bmp");
            _bmpShow[6] = new Bitmap("images/6.bmp");
            _bmpShow[7] = new Bitmap("images/7.bmp");
            _bmpShow[8] = new Bitmap("images/8.bmp");
            _bmpShow[9] = new Bitmap("images/9.bmp");            
            _bmpShow[10] = new Bitmap("images/dot1.bmp");
            _bmpShow[11] = new Bitmap("images/dot2.bmp");
            _bmpShow[12] = new Bitmap("images/blank.bmp");
        }

        //窗口的Load事件响应方法
        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化所有ImageBox控件的初始位图
            pictureBoxHour1.Image = GetResourceImage("0");
            pictureBoxHour2.Image = GetResourceImage("0");
            pictureBoxMinute1.Image = GetResourceImage("0");
            pictureBoxMinute2.Image = GetResourceImage("0");
            pictureBoxSecond1.Image = GetResourceImage("0");
            pictureBoxSecond2.Image = GetResourceImage("0");
            pictureBoxColon1.Image = GetResourceImage(":");
            pictureBoxColon2.Image = GetResourceImage(":");
        }     

        //Timer1定时器的Tick事件响应方法
        private void timer1_Tick(object sender, EventArgs e)
        {
            //时间计数值(秒)加1
            _nowSecond++;
            //计算当前的小时、分、秒
            int hour = _nowSecond / 3600;
            int minute = (_nowSecond % 3600) / 60;
            int second = (_nowSecond % 3600) % 60;
            //显示当前的秒
            this.pictureBoxSecond1.Image = GetResourceImage((second / 10).ToString());
            this.pictureBoxSecond2.Image = GetResourceImage((second % 10).ToString());
            //显示当前的分
            this.pictureBoxMinute1.Image = GetResourceImage((minute / 10).ToString());
            this.pictureBoxMinute2.Image = GetResourceImage((minute % 10).ToString());
            //显示当前的小时
            this.pictureBoxHour1.Image = GetResourceImage((hour / 10).ToString());
            this.pictureBoxHour2.Image = GetResourceImage((hour % 10).ToString());
        }

        //Timer2定时器的Tick事件响应方法
        private void timer2_Tick(object sender, EventArgs e)
        {
            //切换冒号显示控制标志
            _colonFlag = !_colonFlag;

            //判断冒号控制标志是否为true
            if (_colonFlag == true)
            {
                pictureBoxColon1.Image = GetResourceImage(" ");
                pictureBoxColon2.Image = GetResourceImage(" ");
            }
            else
            {
                pictureBoxColon1.Image = GetResourceImage(":");
                pictureBoxColon2.Image = GetResourceImage(":");
            }
        }

        //按钮"开始"的Click事件响应方法
        private void buttonStart_Click(object sender, EventArgs e)
        {
            //启用定时器
            timer1.Enabled = true;
            timer2.Enabled = true;
            //启用或禁用有关按钮
            buttonStart.Enabled = false;
            buttonPause.Enabled = true;
            buttonStop.Enabled = true;
            //冒号控制标志设置为true
            _colonFlag = true;
            //隐藏冒号
            pictureBoxColon1.Image = GetResourceImage(" ");
            pictureBoxColon2.Image = GetResourceImage(" ");
        }

        //按钮"暂停"的Click事件响应方法
        private void buttonPause_Click(object sender, EventArgs e)
        {
            //禁用定时器
            timer1.Enabled = false;
            timer2.Enabled = false;
            //启用或禁用有关按钮
            buttonStart.Enabled = true;
            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            //冒号控制标志设置为true
            _colonFlag = true;
            //显示冒号
            pictureBoxColon1.Image = GetResourceImage(":");
            pictureBoxColon2.Image = GetResourceImage(":");
        }

        //按钮"停止"的Click事件响应方法
        private void buttonStop_Click(object sender, EventArgs e)
        {
            //禁用定时器
            timer1.Enabled = false;
            timer2.Enabled = false;
            //启用或禁用有关按钮
            buttonStart.Enabled = true;
            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            //冒号控制标志设置为true
            _colonFlag = true;
            //显示冒号
            pictureBoxColon1.Image = GetResourceImage(":");
            pictureBoxColon2.Image = GetResourceImage(":");

            //清空时间计数值(秒)
            _nowSecond = 0;
        }

        //窗口的Move(窗口移动)事件响应方法
        private void Form1_Move(object sender, EventArgs e)
        {
            //停靠屏幕左右边框
            int screenRight = Screen.PrimaryScreen.Bounds.Right;
            int formRight = this.Left + this.Size.Width;
            if (Math.Abs(screenRight - formRight) <= 100)
                this.Left = screenRight - this.Size.Width;
            if (Math.Abs(this.Left) <= 100)
                this.Left = 0;

            //停靠屏幕上下边框
            int screenBottom = Screen.PrimaryScreen.Bounds.Bottom;
            int formBottom = this.Top + this.Size.Height;
            if (Math.Abs(screenBottom - formBottom) <= 60)
                this.Top = screenBottom - this.Size.Height;
            if (Math.Abs(this.Top) <= 100)
                this.Top = 0;
        }

        private void pictureBoxHour1_Click(object sender, EventArgs e)
        {

        }           
    }
}
