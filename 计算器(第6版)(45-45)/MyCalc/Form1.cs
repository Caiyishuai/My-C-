using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCalc
{
    public partial class Form1 : Form
    {
        //类字段变量声明
        //类字段：第一个运算数、第二个运算数、运算结果
        private decimal _num1 = 0, _num2 = 0, _result = 0;
        //类字段：运算符号
        private string _operator = "";
        //类字段：运算符号的数量
        private int _operatorCount = 0;
        //类字段：首数字标志位
        private bool _firstNumberFlag =true;
        //类字段：进制标志位
        private string _NumberSystem = "dec";


        //类方法：把十进制转化为二进制
        public string DecToBin(int dec)
        {
            string bin="";
            while (dec > 1)
            {
                bin = Convert.ToChar(dec % 2 + '0') + bin;
                dec = dec / 2;
            } 
            bin = Convert.ToChar(dec + '0') + bin;

            return bin;
        }

        //类方法：把二进制转化为十进制
        public int BinToDec(string bin)
        {
            int dec = 0;
            for (int i = bin.Length; i >= 1; i--)
            {
                dec = dec + Convert.ToInt32(bin[i - 1] - '0') * (int)(Math.Pow(2, bin.Length - i));
            }

            return dec;
        }

        //类方法：把十进制转化为八进制
        public string DecToOct(int dec)
        {
            string oct = "";
            while (dec > 7)
            {
                oct = Convert.ToChar(dec % 8 + '0') + oct;
                dec = dec / 8;
            } 
            oct = Convert.ToChar(dec + '0') + oct;

            return oct;
        }

        //类方法：把八进制转化为十进制
        public int OctToDec(string oct)
        {
            int dec = 0;
            for (int i = oct.Length; i >= 1; i--)
            {
                dec = dec + Convert.ToInt32(oct[i - 1] - '0') * (int)(Math.Pow(8, oct.Length - i));
            }

            return dec;
        }

        //构造方法
        public Form1()
        {
            InitializeComponent();
        }

        //按钮"0"的Click事件响应方法
        private void buttonNum0_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"0"
                textBoxResult.Text = "0";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"0"
                textBoxResult.Text = textBoxResult.Text + "0";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"1"的Click事件响应方法
        private void buttonNum1_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"1"
                textBoxResult.Text = "1";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"1"
                textBoxResult.Text = textBoxResult.Text + "1";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"2"的Click事件响应方法
        private void buttonNum2_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"2"
                textBoxResult.Text = "2";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"2"
                textBoxResult.Text = textBoxResult.Text + "2";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"3"的Click事件响应方法
        private void buttonNum3_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"3"
                textBoxResult.Text = "3";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"3"
                textBoxResult.Text = textBoxResult.Text + "3";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"4"的Click事件响应方法
        private void buttonNum4_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"4"
                textBoxResult.Text = "4";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"4"
                textBoxResult.Text = textBoxResult.Text + "4";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"5"的Click事件响应方法
        private void buttonNum5_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"5"
                textBoxResult.Text = "5";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"5"
                textBoxResult.Text = textBoxResult.Text + "5";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"6"的Click事件响应方法
        private void buttonNum6_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"6"
                textBoxResult.Text = "6";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"6"
                textBoxResult.Text = textBoxResult.Text + "6";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"7"的Click事件响应方法
        private void buttonNum7_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"7"
                textBoxResult.Text = "7";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"7"
                textBoxResult.Text = textBoxResult.Text + "7";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"8"的Click事件响应方法
        private void buttonNum8_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"8"
                textBoxResult.Text = "8";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"8"
                textBoxResult.Text = textBoxResult.Text + "8";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"9"的Click事件响应方法
        private void buttonNum9_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"9"
                textBoxResult.Text = "9";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
                //编辑框文字中追加一个"9"
                textBoxResult.Text = textBoxResult.Text + "9";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }    

        //按钮"."的Click事件响应方法
        private void buttonDot_Click(object sender, EventArgs e)
        {
            //判断是否为首数字。如果是，则替换；如果否，则追加。
            if (_firstNumberFlag == true)
            {
                //编辑框文字替换为"."
                textBoxResult.Text = ".";
                //首数字标志位设为false
                _firstNumberFlag = false;
            }
            else
            {
                //判断现有数字中是否含有小数点
                if (textBoxResult.Text.IndexOf('.') == -1)
                    //编辑框文字中追加一个"."
                    textBoxResult.Text = textBoxResult.Text + ".";
            }

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }


        //按钮"+"的Click事件响应方法
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //首数字标志位设为true
            _firstNumberFlag = true;

            //运算符号数量加1
            _operatorCount = _operatorCount + 1 ;
            //判断是否为第一个运算符
            if (_operatorCount == 1)
            {
                //保存第一个运算数到类字段变量_num1中(注意进制转化问题)
                if(_NumberSystem=="dec")
                    _num1 = Convert.ToDecimal(textBoxResult.Text);
                else if (_NumberSystem == "bin")
                    _num1 = BinToDec(textBoxResult.Text);
                else if (_NumberSystem == "oct")
                    _num1 = OctToDec(textBoxResult.Text);
                //保存运算符号到类字段变量_operator中
                _operator = "+";
                //清空编辑框 
                textBoxResult.Text = "";
            }
            else
            {
                //保存第二个运算数到类字段变量_num2中(注意进制转化问题)
                if (_NumberSystem == "dec")
                    _num2 = Convert.ToDecimal(textBoxResult.Text);
                else if (_NumberSystem == "bin")
                    _num2 = BinToDec(textBoxResult.Text);
                else if (_NumberSystem == "oct")
                    _num2 = OctToDec(textBoxResult.Text);
                //进行运算
                if (_operator == "+")
                    _num1 = _num1 + _num2;
                else if (_operator == "-")
                    _num1 = _num1 - _num2;
                else if (_operator == "*")
                    _num1 = _num1 * _num2;
                else if (_operator == "/")
                    _num1 = _num1 / _num2;
                //保存运算符号到类字段变量_operator中
                _operator = "+";
                //在编辑框中显示前面数字的运算结果(注意进制转化问题)
                if (_NumberSystem == "dec")
                    textBoxResult.Text = _num1.ToString();
                else if (_NumberSystem == "bin")
                    textBoxResult.Text = DecToBin((int)_num1);
                else if (_NumberSystem == "oct")
                    textBoxResult.Text = DecToOct((int)_num1);                
            }

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"-"的Click事件响应方法
        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            //首数字标志位设为true
            _firstNumberFlag = true;

            //运算符号数量加1
            _operatorCount = _operatorCount + 1;
            //判断是否为第一个运算符
            if (_operatorCount == 1)
            {
                //保存第一个运算数到类字段变量_num1中(注意进制转化问题)
                if (_NumberSystem == "dec")
                    _num1 = Convert.ToDecimal(textBoxResult.Text);
                else if (_NumberSystem == "bin")
                    _num1 = BinToDec(textBoxResult.Text);
                else if (_NumberSystem == "oct")
                    _num1 = OctToDec(textBoxResult.Text);
                //保存运算符号到类字段变量_operator中
                _operator = "-";
                //清空编辑框 
                textBoxResult.Text = "";
            }
            else
            {
                //保存第二个运算数到类字段变量_num2中(注意进制转化问题)
                if (_NumberSystem == "dec")
                    _num2 = Convert.ToDecimal(textBoxResult.Text);
                else if (_NumberSystem == "bin")
                    _num2 = BinToDec(textBoxResult.Text);
                else if (_NumberSystem == "oct")
                    _num2 = OctToDec(textBoxResult.Text);
                //进行运算
                if (_operator == "+")
                    _num1 = _num1 + _num2;
                else if (_operator == "-")
                    _num1 = _num1 - _num2;
                else if (_operator == "*")
                    _num1 = _num1 * _num2;
                else if (_operator == "/")
                    _num1 = _num1 / _num2;
                //保存运算符号到类字段变量_operator中
                _operator = "-";
                //在编辑框中显示前面数字的运算结果(注意进制转化问题) 
                if (_NumberSystem == "dec")
                    textBoxResult.Text = _num1.ToString();
                else if (_NumberSystem == "bin")
                    textBoxResult.Text = DecToBin((int)_num1);
                else if (_NumberSystem == "oct")
                    textBoxResult.Text = DecToOct((int)_num1);                
            }

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"*"的Click事件响应方法
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            //首数字标志位设为true
            _firstNumberFlag = true;

            //运算符号数量加1
            _operatorCount = _operatorCount + 1;
            //判断是否为第一个运算符
            if (_operatorCount == 1)
            {
                //保存第一个运算数到类字段变量_num1中(注意进制转化问题)
                if (_NumberSystem == "dec")
                    _num1 = Convert.ToDecimal(textBoxResult.Text);
                else if (_NumberSystem == "bin")
                    _num1 = BinToDec(textBoxResult.Text);
                else if (_NumberSystem == "oct")
                    _num1 = OctToDec(textBoxResult.Text);
                //保存运算符号到类字段变量_operator中
                _operator = "*";
                //清空编辑框 
                textBoxResult.Text = "";
            }
            else
            {
                //保存第二个运算数到类字段变量_num2中(注意进制转化问题)
                if (_NumberSystem == "dec")
                    _num2 = Convert.ToDecimal(textBoxResult.Text);
                else if (_NumberSystem == "bin")
                    _num2 = BinToDec(textBoxResult.Text);
                else if (_NumberSystem == "oct")
                    _num2 = OctToDec(textBoxResult.Text);
                //进行运算
                if (_operator == "+")
                    _num1 = _num1 + _num2;
                else if (_operator == "-")
                    _num1 = _num1 - _num2;
                else if (_operator == "*")
                    _num1 = _num1 * _num2;
                else if (_operator == "/")
                    _num1 = _num1 / _num2;
                //保存运算符号到类字段变量_operator中
                _operator = "*";
                //在编辑框中显示前面数字的运算结果(注意进制转化问题) 
                if (_NumberSystem == "dec")
                    textBoxResult.Text = _num1.ToString();
                else if (_NumberSystem == "bin")
                    textBoxResult.Text = DecToBin((int)_num1);
                else if (_NumberSystem == "oct")
                    textBoxResult.Text = DecToOct((int)_num1);                
            }

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"/"的Click事件响应方法
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            //首数字标志位设为true
            _firstNumberFlag = true;

            //运算符号数量加1
            _operatorCount = _operatorCount + 1;
            //判断是否为第一个运算符
            if (_operatorCount == 1)
            {
                //保存第一个运算数到类字段变量_num1中(注意进制转化问题)
                if (_NumberSystem == "dec")
                    _num1 = Convert.ToDecimal(textBoxResult.Text);
                else if (_NumberSystem == "bin")
                    _num1 = BinToDec(textBoxResult.Text);
                else if (_NumberSystem == "oct")
                    _num1 = OctToDec(textBoxResult.Text);
                //保存运算符号到类字段变量_operator中
                _operator = "/";
                //清空编辑框 
                textBoxResult.Text = "";
            }
            else
            {
                //保存第二个运算数到类字段变量_num2中(注意进制转化问题)
                if (_NumberSystem == "dec")
                    _num2 = Convert.ToDecimal(textBoxResult.Text);
                else if (_NumberSystem == "bin")
                    _num2 = BinToDec(textBoxResult.Text);
                else if (_NumberSystem == "oct")
                    _num2 = OctToDec(textBoxResult.Text);
                //进行运算
                if (_operator == "+")
                    _num1 = _num1 + _num2;
                else if (_operator == "-")
                    _num1 = _num1 - _num2;
                else if (_operator == "*")
                    _num1 = _num1 * _num2;
                else if (_operator == "/")
                    _num1 = _num1 / _num2;
                //保存运算符号到类字段变量_operator中
                _operator = "/";
                //在编辑框中显示前面数字的运算结果(注意进制转化问题) 
                if (_NumberSystem == "dec")
                    textBoxResult.Text = _num1.ToString();
                else if (_NumberSystem == "bin")
                    textBoxResult.Text = DecToBin((int)_num1);
                else if (_NumberSystem == "oct")
                    textBoxResult.Text = DecToOct((int)_num1);                
            }

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"="的Click事件响应方法
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            //保存第二个运算数到类字段变量_num2中(注意进制转化问题)
            if (_NumberSystem == "dec")
                _num2 = Convert.ToDecimal(textBoxResult.Text);
            else if (_NumberSystem == "bin")
                _num2 = BinToDec(textBoxResult.Text);
            else if (_NumberSystem == "oct")
                _num2 = OctToDec(textBoxResult.Text);
            //进行运算
            if (_operator == "+")
                _result = _num1 + _num2;
            else if (_operator == "-")
                _result = _num1 - _num2;
            else if (_operator == "*")
                _result = _num1 * _num2;
            else if (_operator == "/")
                _result = _num1 / _num2;
            //在编辑框中显示运算结果(注意进制转化问题)
            if (_NumberSystem == "dec")
                textBoxResult.Text = _result.ToString();
            else if (_NumberSystem == "bin")
                textBoxResult.Text = DecToBin((int)_result);
            else if (_NumberSystem == "oct")
                textBoxResult.Text = DecToOct((int)_result);                

            //运算符号数量清零
            _operatorCount = 0;

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"<-"的Click事件响应方法
        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            //如果textBoxResult.Text不为空
            if (textBoxResult.Text.Length > 0)
                //去除textBoxResult.Text中的最后一个字符
                textBoxResult.Text = textBoxResult.Text.Substring(0, textBoxResult.Text.Length - 1);

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
        }

        //按钮"C"的Click事件响应方法
        private void buttonClear_Click(object sender, EventArgs e)
        {
            //初始化有关类字段变量
            _num1 = 0; 
            _num2 = 0; 
            _result = 0;
            _operator = "";
            _operatorCount = 0;
            _firstNumberFlag = false;
            //清空编辑框
            textBoxResult.Text = "";

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //按钮"+/-"的Click事件响应方法
        private void buttonSign_Click(object sender, EventArgs e)
        {
            //如果textBoxResult.Text非空
            if (textBoxResult.Text.Length >= 1)
            {
                //获取textBoxResult.Text的第一个字符
                string firstChar = textBoxResult.Text.Substring(0, 1);
                //判断第一个字符是正号还是负号
                if (firstChar == "-")
                    textBoxResult.Text = "+" + textBoxResult.Text.Substring(1, textBoxResult.Text.Length - 1);
                else if (firstChar == "+")
                    textBoxResult.Text = "-" + textBoxResult.Text.Substring(1, textBoxResult.Text.Length - 1);
                else
                    textBoxResult.Text = "-" + textBoxResult.Text;
            }

            //使输入焦点落到编辑框textBoxResult中
            textBoxResult.Focus();
            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //编辑框的KeyPress(键盘下压)事件的响应方法
        private void textBoxResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            //根据用户按下的键的值，调用相应的响应方法
            if (e.KeyChar == '0')
                buttonNum0_Click(sender, e);
            else if (e.KeyChar == '1')
                buttonNum1_Click(sender, e);
            else if (e.KeyChar == '2')
                buttonNum2_Click(sender, e);
            else if (e.KeyChar == '3')
                buttonNum3_Click(sender, e);
            else if (e.KeyChar == '4')
                buttonNum4_Click(sender, e);
            else if (e.KeyChar == '5')
                buttonNum5_Click(sender, e);
            else if (e.KeyChar == '6')
                buttonNum6_Click(sender, e);
            else if (e.KeyChar == '7')
                buttonNum7_Click(sender, e);
            else if (e.KeyChar == '8')
                buttonNum8_Click(sender, e);
            else if (e.KeyChar == '9')
                buttonNum9_Click(sender, e);

            else if (e.KeyChar == '+')
                buttonAdd_Click(sender, e);
            else if (e.KeyChar == '-')
                buttonSubtract_Click(sender, e);
            else if (e.KeyChar == '*')
                buttonMultiply_Click(sender, e);
            else if (e.KeyChar == '/')
                buttonDivide_Click(sender, e);
            else if (e.KeyChar == '=')
                buttonEqual_Click(sender, e);

            else if (e.KeyChar == 'c')
                buttonClear_Click(sender, e);
            else if (e.KeyChar == '.')
                buttonDot_Click(sender, e);

            else if (e.KeyChar == 8)             //或者 (e.KeyChar == '\b')   或者 (e.KeyChar == (char)Keys.Back)
                buttonBackSpace_Click(sender, e);

            //让光标落在编辑框textBoxResult的最后面
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        //单选按钮"二进制"的Click事件响应方法
        private void radioButtonBinary_Click(object sender, EventArgs e)
        {
            //进行进制转换
            if (textBoxResult.Text != "")
            {
                if (_NumberSystem == "dec")
                    textBoxResult.Text = DecToBin((int)Math.Round(Convert.ToDecimal(textBoxResult.Text)));
                else if (_NumberSystem == "oct")
                {
                    int dec = OctToDec(textBoxResult.Text);
                    textBoxResult.Text = DecToBin(dec);
                }
            }

            //启用或禁用有关按钮
            buttonNum2.Enabled = false;
            buttonNum3.Enabled = false;
            buttonNum4.Enabled = false;
            buttonNum5.Enabled = false;
            buttonNum6.Enabled = false;
            buttonNum7.Enabled = false;
            buttonNum8.Enabled = false;
            buttonNum9.Enabled = false;
            buttonDot.Enabled  = false;

            //保存进制标志
            _NumberSystem = "bin";
        }

        //单选按钮"十进制"的Click事件响应方法
        private void radioButtonDecimal_Click(object sender, EventArgs e)
        {
            //进行进制转换
            if (textBoxResult.Text != "")
            {
                if (_NumberSystem == "bin")
                    textBoxResult.Text = BinToDec(textBoxResult.Text).ToString();
                else if (_NumberSystem == "oct")
                    textBoxResult.Text = OctToDec(textBoxResult.Text).ToString();
            }

            //启用或禁用有关按钮
            buttonNum2.Enabled = true;
            buttonNum3.Enabled = true;
            buttonNum4.Enabled = true;
            buttonNum5.Enabled = true;
            buttonNum6.Enabled = true;
            buttonNum7.Enabled = true;
            buttonNum8.Enabled = true;
            buttonNum9.Enabled = true;
            buttonDot.Enabled  = true;
            
            //保存进制标志
            _NumberSystem = "dec";
        }

        //单选按钮"八进制"的Click事件响应方法
        private void radioButtonOctal_Click(object sender, EventArgs e)
        {
            //进行进制转换
            if (textBoxResult.Text != "")
            {
                if (_NumberSystem == "dec")
                    textBoxResult.Text = DecToOct((int)Math.Round(Convert.ToDecimal(textBoxResult.Text)));
                else if (_NumberSystem == "bin")
                {
                    int dec = BinToDec(textBoxResult.Text);
                    textBoxResult.Text = DecToOct(dec);
                }
            }

            //启用或禁用有关按钮
            buttonNum2.Enabled = true;
            buttonNum3.Enabled = true;
            buttonNum4.Enabled = true;
            buttonNum5.Enabled = true;
            buttonNum6.Enabled = true;
            buttonNum7.Enabled = true;
            buttonNum8.Enabled = false;
            buttonNum9.Enabled = false;
            buttonDot.Enabled = false;

            //保存进制标志
            _NumberSystem = "oct";
        }

        private void radioButtonOctal_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
