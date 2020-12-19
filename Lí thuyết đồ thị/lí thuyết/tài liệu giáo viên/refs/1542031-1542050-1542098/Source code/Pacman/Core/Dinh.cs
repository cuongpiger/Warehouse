using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Dinh : ICloneable
    {
        // Giá trị Key
        // 0 -> Pacman
        // 1 -> Mẫu thức ăn nhỏ
        // 2 -> Mẫu thức ăn lớn
        // 10 -> Bóng ma
        private int _Value;
        public int Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }

        private int _Vertex; // Tên đỉnh (Đỉnh số thứ mấy)
        public int Vertex
        {
            get { return this._Vertex; }
            set { this._Vertex = value; }
        }


        private int _x;      // Tọa độ x
        public int X
        {
            get { return this._x; }
            set { this._x = value; }
        }

        private int _y;      // Tọa độ y
        public int Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        private double _cost; // Chi phí từ Start tới đỉnh hiện tại
        public double Cost
        {
            get { return this._cost; }
            set { this._cost = value; }
        }

        private int _previous; // Đỉnh cha
        public int Previous
        {
            get { return this._previous; }
            set { this._previous = value; }
        }

        public Dinh(int value, int vertext, int x, int y, int pre, double cost)
        {
            this._Value = value;
            this._Vertex = vertext;
            this._x = x;
            this._y = y;
            this._previous = pre;
            this._cost = cost;
        }
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
