using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Graph
    {
        private int SoDinh;
        private List<List<double>> Matrix = new List<List<double>>();
        private List<int> ChiPhi = new List<int>();
        private List<Dinh> Nhan = new List<Dinh>();
        private List<int> T = new List<int>();

        private List<Dinh> DSDinh = new List<Dinh>(); // Danh sách đỉnh trong đồ thị
        private PQueue DSEnd = new PQueue(); // Danh sách các trạng thái kết thúc
        private Dinh Start;
        private Dinh End;
        private List<List<Dinh>> Nhans = new List<List<Dinh>>(); // Mảng chứa danh sách các đường đi
        private List<List<Dinh>> PathPos = new List<List<Dinh>>(); // Mảng chưa lần lượt start và end;
        private string _HType; // Quy định Kiểu Heuristic

        // Set chi phí
        private int _ThucAnNho = 0;
        public int ThucAnNho
        {
            get { return this._ThucAnNho; }
            set { this._ThucAnNho = value; }
        }

        private int _ThucAnLon = 0;
        public int ThucAnLon
        {
            get { return this._ThucAnLon; }
            set { this._ThucAnLon = value; }
        }


        private int _BongMa = 0;
        public int BongMa
        {
            get { return this._BongMa; }
            set { this._BongMa = value; }
        }
        

        // New
        private List<List<Dinh>> d = new List<List<Dinh>>();
        public string HType
        {
            get { return this._HType; }
            set { this._HType = value; }
        }


        private string _opThuatToan;
        public string ThuatToan
        {
            get { return this._opThuatToan; }
            set { this._opThuatToan = value; }
        }

        private int _countStep = 0;
        public int CountStep
        {
            get { return this._countStep; }
            set { this._countStep = value; }
        }


        public const int MAX = 999999;

        public void ReadFile(string FileName)
        {
            int countLine = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(FileName);

            // Đếm số đỉnh
            int nDinhCount = 0;

            // Đọc số đỉnh
            while ((line = file.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if ((char)line[i] == '%')
                    {
                    }
                    else if ((char)line[i] == 'P')
                    {
                        Dinh d = new Dinh(0, nDinhCount, i, countLine, -1, 0);

                        // Add vào danh sách đỉnh
                        this.DSDinh.Add(d);

                        // Gán đỉnh bắt đầu
                        this.Start = d;

                        nDinhCount++;
                    }
                    else if ((char)line[i] == '.')
                    {
                        Dinh d = new Dinh(this._ThucAnNho, nDinhCount, i, countLine, -1, this._ThucAnNho);

                        // Add vào danh sách đỉnh
                        this.DSDinh.Add(d);

                        // Add vào danh sách trạng thái đích
                        DSEnd.EnQueue(d);

                        nDinhCount++;
                    }
                    else if ((char)line[i] == 'o')
                    {
                        Dinh d = new Dinh(this._ThucAnLon, nDinhCount, i, countLine, -1, this._ThucAnLon);

                        // Add vào danh sách đỉnh
                        this.DSDinh.Add(d);

                        // Add vào danh sách trạng thái đích
                        DSEnd.EnQueue(d);

                        nDinhCount++;
                    }
                    // Nếu là Ghost => Ký hiệu: 10 (Chi phí: 10)
                    else if ((char)line[i] == 'G')
                    {
                        Dinh d = new Dinh(this._BongMa, nDinhCount, i, countLine, -1, this._BongMa);

                        // Add vào danh sách đỉnh
                        this.DSDinh.Add(d);

                        nDinhCount++;
                    }
                    // Nếu là ' ' => Ký hiệu: 3 (Chi phí: 3)
                    else if ((char)line[i] == ' ')
                    {
                        Dinh d = new Dinh(3, nDinhCount, i, countLine, -1, 3);

                        // Add vào danh sách đỉnh
                        this.DSDinh.Add(d);

                        nDinhCount++;
                    }
                }
                countLine++;
            }

            // Gán số đỉnh của đồ thị
            this.SoDinh = this.DSDinh.Count;

            // Xây dựng đồ thị g
            for (int i = 0; i < this.SoDinh; i++)
            {
                List<double> Temp = new List<double>();
                for (int j = 0; j < this.SoDinh; j++)
                {
                    Temp.Add(-1);    // Tại điểm = -1 => Ko thể đi tới	
                }
                this.Matrix.Add(Temp);
            }

            for (int i = 0; i < this.SoDinh; i++)
            {
                for (int j = 0; j < this.SoDinh; j++)
                {
                    //Tọa độ cố định
                    int x1 = this.DSDinh[i].X; // mygraph.GetArrDinhN(i).GetX();
                    int y1 = this.DSDinh[i].Y; // mygraph.GetArrDinhN(i).GetY();

                    //Lấy tọa độ điểm cần tới
                    int x2 = this.DSDinh[j].X; // mygraph.GetArrDinhN(j).GetX();
                    int y2 = this.DSDinh[j].Y; // mygraph.GetArrDinhN(j).GetY();

                    if ((x1 + 1 == x2 && y1 == y2) || (x1 - 1 == x2 && y1 == y2) ||
                        (x1 == x2 && y1 + 1 == y2) || (x1 == x2 && y1 - 1 == y2))
                    {
                        // mygraph.SetMATRIX(i, j, mygraph.GetArrDinhN(j).GetCost());
                        this.Matrix[i][j] = this.DSDinh[j].Cost;
                    }
                }
            }

            file.Close();
        }

        public void CalcHDSEnd(Dinh Start)
        {
            // Tính ChiPhi = Cost + H tại mảng lưu trạng thái kết thúc
            List<Dinh> dE = this.DSEnd.getQueue().ToList();
            for (int i = 0; i < dE.Count; i++)
            {
                int vertex = dE[i].Vertex;
                double curCost = dE[i].Cost;
                double h = this.HeuristicCost(dE[i], Start);
                double newCost = h;
                this.DSEnd.SetCost(vertex, newCost, -1);
            }
        }

        public double HeuristicCost(Dinh start, Dinh end)
        {
            if (this.HType == "Manhattan")
            {
                return (Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y));
            }
            else if (this.HType == "Euclidean")
            {
                double a = (start.X - end.X) * (start.X - end.X) + (start.Y - end.Y) * (start.Y - end.Y);
                double x = Math.Sqrt(a);
                return x;
            }
            else if (this.HType == "MaxDXDY")
            {
                return (Math.Max(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y)));
            }
            else if (this.HType == "DiagonalShortCut")
            {
                int h_diagonal = Math.Min(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                int h_straight = (Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y));
                return 2 * h_diagonal + (h_straight - 2 * h_diagonal);
            }
            else if (this.HType == "EuclideanNoSQR")
            {
                return (Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            }
            else
            {
                return (Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y));
            }
        }

        public List<Dinh> AStar(Dinh Start, Dinh End)
        {
            // Khởi tạo giá trị
            // List<Dinh> mDSDinh = new List<Dinh>(this.DSDinh).ToList();
            List<Dinh> mDSDinh = new List<Dinh>();
            for (int j = 0; j < this.DSDinh.Count; j++)
            {
                Dinh d = new Dinh(this.DSDinh[j].Value, this.DSDinh[j].Vertex, this.DSDinh[j].X, this.DSDinh[j].Y, this.DSDinh[j].Previous, this.DSDinh[j].Cost);
                mDSDinh.Add(d);
            }

            // Đưa S vào hàng đợi
            PQueue PQ = new PQueue();
            PQ.EnQueue(Start);

            while (PQ.Size > 0)
            {
                Dinh v = PQ.DeQueue();

                this.CountStep++;

                if (v.Vertex == End.Vertex)
                {
                    // Nếu đỉnh đi qua vô tình là trạng thái đích
                    // Loại bỏ chúng ra khỏi trạng thái đích
                    List<Dinh> path = new List<Dinh>();
                    End = mDSDinh[End.Vertex];
                    while (End.Vertex != Start.Vertex)
                    {
                        path.Add(End);
                        End = mDSDinh[End.Previous];
                    }
                    path.Add(Start);
                    path.Reverse();

                    for (int i = 0; i < path.Count; i++)
                    {
                        this.DSEnd.RemoveItemByVertex(path[i].Vertex);
                        if (this.DSEnd.Queue.Exists(element => element == path[i]))
                        {
                            this.DSEnd.RemoveItemByVertex(path[i].Vertex);
                        }
                    }

                    // Tìm thấy đường đi
                    return mDSDinh.ToList();
                }
                else
                {
                    // Với mỗi u
                    for (int u = 0; u < mDSDinh.Count; u++)
                    {
                        // Nếu u kề với v
                        // Kiểm tra có cạnh nối từ v -> v
                        if (this.Matrix[v.Vertex][mDSDinh[u].Vertex] != -1 ||
                            this.Matrix[mDSDinh[u].Vertex][v.Vertex] != -1)
                        {
                            // Nếu u chưa duyệt
                            if (mDSDinh[u].Previous == -1)
                            {
                                // Tính chi phí và add vào hàng đợi ưu tiên
                                if (mDSDinh[u].Cost > mDSDinh[v.Vertex].Cost + this.Matrix[v.Vertex][mDSDinh[u].Vertex] + this.HeuristicCost(v, mDSDinh[u]))
                                {
                                    double newCost = mDSDinh[v.Vertex].Cost + this.Matrix[v.Vertex][mDSDinh[u].Vertex] + this.HeuristicCost(v, mDSDinh[u]);
                                    mDSDinh[u].Previous = v.Vertex;
                                    mDSDinh[u].Cost = newCost;

                                    // Nếu thuộc hàng đợi ưu tiên
                                    // Cập nhật lại chi phí nếu chi phí tốt hơn
                                    if (PQ.CheckExist(v.Vertex) == 1)
                                    {
                                        // Cập nhật chi phí, pre
                                        PQ.SetCost(mDSDinh[u].Vertex, newCost, v.Vertex);
                                    }
                                    else
                                    {
                                        PQ.EnQueue(mDSDinh[u]);
                                    }
                                }
                                else
                                {
                                    double newCost = mDSDinh[v.Vertex].Cost + this.Matrix[v.Vertex][u] + this.HeuristicCost(v, mDSDinh[u]);
                                    mDSDinh[u].Previous = v.Vertex;
                                    mDSDinh[u].Cost = newCost;
                                    PQ.EnQueue(mDSDinh[u]);
                                }
                            }
                        }
                    }
                }
            }


            // Không tìm thấy đường đi
            List<Dinh> result = new List<Dinh>();
            return result.ToList();
        }

        public List<Dinh> Dijkstra(Dinh Start, Dinh End)
        {
            // Khởi tạo giá trị
            // List<Dinh> mDSDinh = new List<Dinh>(this.DSDinh).ToList();
            List<Dinh> mDSDinh = new List<Dinh>();
            for (int j = 0; j < this.DSDinh.Count; j++)
            {
                Dinh d = new Dinh(this.DSDinh[j].Value, this.DSDinh[j].Vertex, this.DSDinh[j].X, this.DSDinh[j].Y, this.DSDinh[j].Previous, this.DSDinh[j].Cost);
                mDSDinh.Add(d);
            }

            // Đưa S vào hàng đợi
            PQueue PQ = new PQueue();
            PQ.EnQueue(Start);

            while (PQ.Size > 0)
            {
                Dinh v = PQ.DeQueue();
                this.CountStep++;
                if (v.Vertex == End.Vertex)
                {
                    // Nếu đỉnh đi qua vô tình là trạng thái đích
                    // Loại bỏ chúng ra khỏi trạng thái đích
                    List<Dinh> path = new List<Dinh>();
                    End = mDSDinh[End.Vertex];
                    while (End.Vertex != Start.Vertex)
                    {
                        path.Add(End);
                        End = mDSDinh[End.Previous];
                    }
                    path.Add(Start);
                    path.Reverse();

                    for (int i = 0; i < path.Count; i++)
                    {
                        this.DSEnd.RemoveItemByVertex(path[i].Vertex);
                        if (this.DSEnd.Queue.Exists(element => element == path[i]))
                        {
                            this.DSEnd.RemoveItemByVertex(path[i].Vertex);
                        }
                    }
                    
                    // Tìm thấy đường đi
                    return mDSDinh.ToList();
                } else
                {
                    // Với mỗi u
                    for (int u = 0; u < mDSDinh.Count; u++)
                    {
                        // Nếu u kề với v
                        // Kiểm tra có cạnh nối từ v -> v
                        if (this.Matrix[v.Vertex][mDSDinh[u].Vertex] != -1 ||
                            this.Matrix[mDSDinh[u].Vertex][v.Vertex] != -1)
                        {
                            // Nếu u chưa duyệt
                            if (mDSDinh[u].Previous == -1)
                            {
                                // Tính chi phí và add vào hàng đợi ưu tiên
                                if (mDSDinh[u].Cost > mDSDinh[v.Vertex].Cost + this.Matrix[v.Vertex][mDSDinh[u].Vertex])
                                {
                                    double newCost = mDSDinh[v.Vertex].Cost + this.Matrix[v.Vertex][mDSDinh[u].Vertex];
                                    mDSDinh[u].Previous = v.Vertex;
                                    mDSDinh[u].Cost = newCost;

                                    // Nếu thuộc hàng đợi ưu tiên
                                    // Cập nhật lại chi phí nếu chi phí tốt hơn
                                    if (PQ.CheckExist(v.Vertex) == 1)
                                    {
                                        // Cập nhật chi phí, pre
                                        PQ.SetCost(mDSDinh[u].Vertex, newCost, v.Vertex);
                                    }
                                    else
                                    {
                                        PQ.EnQueue(mDSDinh[u]);
                                    }
                                } else
                                {
                                    double newCost = mDSDinh[v.Vertex].Cost + this.Matrix[v.Vertex][u];
                                    mDSDinh[u].Previous = v.Vertex;
                                    mDSDinh[u].Cost = newCost;
                                    PQ.EnQueue(mDSDinh[u]);
                                }
                            }
                        }
                    }
                }
            }


            // Không tìm thấy đường đi
            List<Dinh> result = new List<Dinh>();
            return result.ToList();
        }
        

        public void RunPacman()
        {
            List<List<Dinh>> temp = new List<List<Dinh>>().ToList();
            Dinh s = this.Start;
            //Dinh s = (Dinh)s_o.Clone();

            while (this.DSEnd.Size > 0)
            {
                // Tính toán H + Cost cho mảng trạng thái đích
                this.CalcHDSEnd(s);

                Dinh end = this.DSEnd.DeQueue();
                // Dinh end = (Dinh)end_o.Clone();

                // Lưu s và g
                List<Dinh> t = new List<Dinh>();
                t.Add(s);
                t.Add(end);
                this.PathPos.Add(t);
                
                // List temp
                List<Dinh> p = new List<Dinh>();

                // Xác định thuật toán
                if (this.ThuatToan == "AStar(A*)")
                {
                    p = this.AStar(s, end);
                }
                else if (this.ThuatToan == "Dijkstra")
                {
                    p = this.Dijkstra(s, end);
                }

                // Nếu không có đường đi thì bỏ qua
                if (p.Count > 0)
                {
                    List<Dinh> eD = new List<Dinh>();
                    for (int j = 0; j < p.Count; j++)
                    {
                        Dinh d = new Dinh(p[j].Value, p[j].Vertex, p[j].X, p[j].Y, p[j].Previous, p[j].Cost);
                        eD.Add(d);
                    }
                    this.d.Add(eD);

                    // Khởi tạo lại đỉnh S để bắt đầu lần tiếp theo, 
                    end.Cost = 0;
                    end.Previous = -1;
                    s = end;
                }
            }
        }

        public void WriteFile(string FileName)
        {
            using (StreamWriter writer = new StreamWriter(FileName))
            {
                // Ghi đường đi
                List<List<int>> DuongDi = this.GetPaths();

                // Ghi đường đi
                for (int i = 0; i < DuongDi.Count; i++)
                {
                    writer.WriteLine(DuongDi[i][0] + " " + DuongDi[i][1]);
                }
            }
        }


        public List<List<int>> GetPaths()
        {
            // Ghi đường đi
            // Xử lý lấy danh sách đường đi
            List<List<Dinh>> DuongDi = new List<List<Dinh>>();
            for (int i = 0; i < this.d.Count; i++)
            {
                List<Dinh> path = new List<Dinh>();
                Dinh end = this.d[i][this.PathPos[i][1].Vertex];
                Dinh start = this.PathPos[i][0];
                while (end.Vertex != start.Vertex)
                {
                    path.Add(end);
                    end = this.d[i][end.Previous];
                }
                path.Add(start);
                path.Reverse();
                DuongDi.Add(path);
            }

            // Ghi đường đi
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < DuongDi.Count; i++)
            {
                for (int j = 0; j < DuongDi[i].Count; j++)
                {
                    List<int> t = new List<int>();
                    t.Add(DuongDi[i][j].Y);
                    t.Add(DuongDi[i][j].X);
                    result.Add(t);
                }
            }

            // Kiểm tra đường đi tại chỗ
            int y_pre = result[0][0];
            int x_pre = result[0][1];
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i][0] == y_pre && result[i][1] == x_pre)
                {
                    result.Remove(result[i]);
                    i--;
                }
                else
                {
                    y_pre = result[i][0];
                    x_pre = result[i][1];
                }
            }
            return result;
        }

        public List<List<int>> GetPaths1()
        {
            // Ghi đường đi
            // Xử lý lấy danh sách đường đi
            List<List<Dinh>> DuongDi = new List<List<Dinh>>();
            for (int i = 0; i < this.Nhans.Count; i++)
            {
                List<Dinh> path = new List<Dinh>();
                Dinh end = this.PathPos[i][1];
                Dinh start = this.PathPos[i][0];
                while (end.Vertex != start.Vertex)
                {
                    path.Add(end);
                    end = this.Nhans[i][end.Vertex];
                }
                path.Add(start);
                path.Reverse();
                DuongDi.Add(path);
            }

            // Ghi đường đi
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < DuongDi.Count; i++)
            {
                for (int j = 0; j < DuongDi[i].Count; j++)
                {
                    List<int> t = new List<int>();
                    t.Add(DuongDi[i][j].Y);
                    t.Add(DuongDi[i][j].X);
                    result.Add(t);
                }
            }

            // Kiểm tra đường đi tại chỗ
            int y_pre = result[0][0];
            int x_pre = result[0][1];
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i][0] == y_pre && result[i][1] == x_pre)
                {
                    result.Remove(result[i]);
                    i--;
                }
                else
                {
                    y_pre = result[i][0];
                    x_pre = result[i][1];
                }
            }
            return result;
        }
    }
}
