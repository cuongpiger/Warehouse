using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PQueue
    {
        private List<Dinh> q = new List<Dinh>();

        public List<Dinh> getQueue()
        {
            return this.q.ToList();
        }

        public int Size
        {
            get { return this.q.Count; }
        }

        public List<Dinh> Queue
        {
            get { return this.q.ToList(); }
            set { this.q = value.ToList(); }
        }

        public void SetCost(int vertex, double cost, int pre)
        {
            for (int i = 0; i < this.q.Count; i++)
            {
                if (this.q[i].Vertex == vertex)
                {
                    this.q[i].Cost = cost;
                    this.q[i].Previous = pre;
                }
            }

            // Sắp xếp lại theo thứ tự
            this.SapXep();
        }

        public void RemoveItemByVertex(int vertex)
        {
            for (int i = 0; i < this.q.Count; i++)
            {
                if (this.q[i].Vertex == vertex)
                {
                    this.q.RemoveAt(i);
                }
            }

            // Sắp xếp lại theo thứ tự
            this.SapXep();
        }

        // Kiểm tra tồn tại trong hàng đợi ưu tiên
        public int CheckExist(int vertex)
        {
            for (int i = 0; i < this.q.Count; i++)
            {
                if (this.q[i].Vertex == vertex)
                {
                    return 1;
                }
            }
            return 0;
        }

        public void EnQueue(Dinh d)
        {
            this.q.Add(d);

            // Sắp xếp lại theo thứ tự
            this.SapXep();
        }

        public Dinh DeQueue()
        {
            if (this.q.Count > 0)
            {
                Dinh result = this.q[0];
                this.q.RemoveAt(0);
                return result;
            }
            return null;
        }

        public void SapXep()
        {
            this.q = this.q.OrderBy(o => o.Cost).ToList();
        }
    }
}
