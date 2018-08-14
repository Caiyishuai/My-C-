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
    //线宽对话框类
    public partial class DlgPenWidth : Form
    {
        //类属性
        public int _PenWidth  //画笔宽度
        {
            get { return (int)numericUpDownWidth.Value; }
            set { numericUpDownWidth.Value = value; }
        }

        public DlgPenWidth()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

        }

        private void DlgPenWidth_Load(object sender, EventArgs e)
        {

        }
    }
}
