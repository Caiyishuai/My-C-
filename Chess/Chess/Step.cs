using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    //走棋步骤类
    public class Step
    {
        private Player _player;      //走棋方(红、蓝)
        public  Player _Player
        {
            get { return _player; }
            set
            {
                if (value == Player.无)
                    throw new ArgumentOutOfRangeException("走棋方不能为无。");
                else
                    _player = value;
            }
        }

        private Piece _pickChess;    //拾起位置的棋子值
        public  Piece _PickChess
        {
            get { return _pickChess; }
            set
            {
                if (value == Piece.无子)
                    throw new ArgumentOutOfRangeException("拾起位置的棋子值不能为无子。");
                else
                    _pickChess = value;
            }
        }

        private int _pickRow;        //拾起位置的行号
        public  int _PickRow
        {
            get { return _pickRow; }
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException("拾起位置的行号必须在1和10之间。");
                else
                    _pickRow = value;
            }
        }

        private int _pickCol;        //拾起位置的列号
        public  int _PickCol
        {
            get { return _pickCol; }
            set
            {
                if (value < 1 || value > 9)
                    throw new ArgumentOutOfRangeException("拾起位置的列号必须在1和9之间。");
                else
                    _pickCol = value;
            }
        }

        private Piece _dropChess;    //落下位置的棋子值(即被吃的棋子值,当然也可能为"无子")
        public Piece _DropChess
        {
            get { return _dropChess; }
            set { _dropChess = value; }
        }

        private int _dropRow;        //落下位置的行号
        public  int _DropRow
        {
            get { return _dropRow; }
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException("落下位置的行号必须在1和10之间。");
                else
                    _dropRow = value;
            }
        }

        private int _dropCol;        //落下位置的列号
        public  int _DropCol
        {
            get { return _dropCol; }
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException("落下位置的列号必须在1和9之间。");
                else
                    _dropCol = value;
            }
        }
    }
}
