using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project_P18
{
	public class YeuCau4
	{
		/*public static int[,] ReadMatrix(string filename)
		{
			if (!File.Exists(filename))
			{
				Console.WriteLine("This file dose not exist.");
			}

			StreamReader file = new StreamReader(filename);
			int n = int.Parse(file.ReadLine());
			//int[,] mt = new int[n,n];
			int[,] kq = new int[n, n];
			for (int i = 0; i < kq.GetLength(0); i++)
			{
				string s = file.ReadLine();
				string[] m = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				for (int j = 0; j < kq.GetLength(1); j++)
				{
					kq[i, j] = int.Parse(m[j]);
				}
			}
			return kq;
		}
		public static void PrintMatrix(int[,] matrix)
		{
			Console.WriteLine("- Xuat ma tran trong so :");
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					Console.Write($"{matrix[i, j]} ");
				}
				Console.WriteLine();
			}
		}*/

		// Hàm kiểm tra trọng số dương để kiểm tra đồ thị sẽ thực hiện giải thuật Dijkstra hay Bellman
		public static bool TrongSoDuong(int[,] matrix)
		{
			bool kq = true;
			//Kiểm tra xem trong ma trận có trọng số âm không,
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					// nếu có 1 trọng số âm trong ma trận thì kết quả sẽ false
					if (matrix[i, j] < 0)
					{
						kq = false;
					}
				}
			}
			return kq;
		}

		//Hàm tìm vị trí có giá trị nhỏ nhất trong Mảng L,
		//và chỉ kiểm tra những vị trí đỉnh chưa xét nên truyền vào thêm tham số bool []T
		public static int TimMin(int[] L, bool[] T)
		{
			//Khởi tạo 
			int min = int.MaxValue; // min là giá trị nhỏ nhất trong mảng L, gán min = vô cực
			int min_index = -1;     // min_index là vị trí của min, bán min =-1
			// Bắt đầu vòng lặp trong mảng L để tìm giá trị nhỏ nhất.
			for (int i = 0; i < L.Length; i++)
			{
				//Nếu đỉnh i chưa xét(bool T là true) và giá trị L đỉnh i nhỏ hơn min 
				if (T[i] == true && L[i] <= min) 
				{
					min = L[i]; //thì gán min là giá trị của đỉnh L 
					min_index = i; //vị trí nhỏ nhất hiện tại là i 
					// min & min_index đã thay đổi là giá trị nhỏ nhất khi xét ở i
				}
				// và tiếp tục tìm các đỉnh chưa xét khác. nếu có đỉnh nào nhỏ hơn min thì lại gán đỉnh đó là min.
			}
			// Kết thúc vòng lặp sẽ tìm ra vị trí có giá trị nhỏ nhất trong mảng L với điều kiện là đỉnh đó chưa xét 
			return min_index;
		}

		//Giải thuật Dijkstra
		public static void Dijkstra(int[,] matrix, int source)
		{
			int n = matrix.GetLength(0); // n = số đỉnh của đồ thị
			bool[] T = new bool[n]; //Mảng đánh dấu đỉnh T đã xét hay chưa
			int[] L = new int[n]; // Mảng giá trị nhỏ nhất cost của các đỉnh
			const int vocuc = int.MaxValue; //giá trị cộng vô cực
			int[] Pre = new int[n]; //Mảng đỉnh kề trước 

			//Khởi tạo giá trị của các biến
			for (int i = 0; i < n; i++)
			{
				T[i] = true; //Tất cả các đỉnh đều chưa xét (true là chưa xét) 
				L[i] = vocuc; //Chi phí cost để đi đến các đỉnh đều là vô cực
				Pre[i] =-1; //Tất cả các đỉnh kề trước là -1
			}
			//Nhập đỉnh bắt đầu để bắt đầu tìm đường đi nhỏ nhất đến các đỉnh còn lại
			L[source] = 0; // Chi phí của đỉnh bắt đầu = 0. 
			Pre[source] = source; //Đỉnh kề trước của đỉnh bắt đầu là chính nó.

			// Bắt đầu vòng lặp i các đỉnh
			for (int i = 0; i < n; ++i)
			{
				int v = TimMin(L, T); //Gọi hàm Tìm vị trí nhỏ nhất trong mảng chi phí (L) với các đỉnh chưa xét. => v là vị trí đỉnh có giá trị nhỏ nhất ở vòng lập thứ i
				int min = L[v]; // Gán min = giá trị của đỉnh có chi phí nhỏ nhất
				T[v] = false; // Gán đỉnh v đã xét rồi	(false)
				
				// Tìm cạnh kề của đỉnh v
				for (int k = 0; k < n; ++k) //duyệt ma trận ở dòng v xem có đỉnh k nào kề không (có giá trị là kề) 
				{
					//Nếu đỉnh k chưa xét
					//và chi phí nhỏ nhất -min của đỉnh v khác vô cực, vì nếu giá trị nhỏ nhất L là vô cực thì không có đường đi đến v nên không cần tìm thêm đường đi từ v đến cạnh kề của v  
					//và đỉnh k nào có cạnh kề với v và chi phi [v ,k] + chi phí hiện tại v < chi phí hiện tại của đỉnh k,

					if (T[k] == true && min != vocuc &&  matrix[v, k] != 0 &&
						matrix[v, k] + min < L[k]) 
					{
						L[k] = matrix[v, k] + min; // Gán chi phí hiện tại của đỉnh k = (chi phi [v ,k] + chi phí hiện tại v), 
						Pre[k] = v; // Gán đỉnh kề trước của đỉnh k là v, do lúc này chi phí đi từ đỉnh v đến k tối ưu hơn
					}
				}
				//Xuất kết quả 
				//Nếu chi phí nhỏ nhất -min của đỉnh v khác vô cực, tức là min đang nhỏ nhất trong mảng L hiện tại
				if (min != vocuc) 
				{
					Console.Write($"- Duong di ngan nhat tu {source} den {v} :Cost ={min} Path: "); 
					int t = v; 
					Console.Write($"{v}");
					while (t!=source) // khi đỉnh kề trước vẫn còn khác source thì vẫn chạy  
					{
						Console.Write($"<-{Pre[t]}"); //Ở vòng lặp đầu tiên thì in đỉnh kề trước của đỉnh v đang là đỉnh có giá trị nhỏ nhất trong mảng L,
													  //sau đó sẽ in ra lần lượt giá trị của các đỉnh kề trước 
						t = Pre[t]; // Gán t = đỉnh kề trước của đỉnh vừa mới in ra 
					}
					Console.WriteLine();
				}
				//Ngược lại nếu cost của đỉnh v là vô cực, tức là có đường đi từ đỉnh bắt đầu đến v 
				else
				{
					Console.WriteLine($"- Khong co duong di tu {source} den {v}");				
				}
			}
		}
		//Giải thuật Bellman
		public static void Bellman(int[,] matrix, int source)
		{
			//Khởi tạo các biến
			int n = matrix.GetLength(0); // Gán n là số đỉnh của đồ thị
			// Do step =0 để gán giá trị khởi tạo của đỉnh bắt đầu và các đỉnh khác, nên phải có n+1 để xét được hết các đỉnh  
			int[,] Cost = new int[n + 1, n]; // mảng 2 chiều chi phí (đường đi ngắn nhất) để lưu chi phí hiện tại step hiện tại và truy lại được chi phí của lần trước 
			int[,] Prev = new int[n + 1, n];// mảng 2 chiều đỉnh kề trước: để lưu lạ đỉnh kề trước hiện tại và xem lại được đỉnh kề trước của lần trước 
			int step = 1; // Bắt đầu giải thuật ở step 1 vì step 0 lưu lại các giá trị khởi tạo. và step 1 sẽ truy lại giá trị ở step 0 để so sánh. 
			const int vocuc = int.MaxValue;

			//Khởi tạo giá trị của các biến
			for (int i = 0; i < n; ++i)
			{
				//step 0:
				Cost[0, i] = vocuc; // Gán cost của các đỉnh là vô cực
				Prev[0, i] = i;	//Gán đỉnh kề trước của các đỉnh là chính nó. 
			}
			Cost[0, source] = 0;// Nhập đỉnh bắt đầu -source, và gán cost là 0;
			// đỉnh kề trước của -souce cũng là chính nó, đã gán rồi nên không gán lại
			
			// Thực hiện giải thuật
			for (step = 1; step <= n; ++step) //dừng ở <=n, vì bắt đầu từ step =1, không phải step=0, để qua tất cả các đỉnh thì phải càn xét tới bước n 
			{
				for (int k = 0; k < n; ++k)  // bắt đầu xét giá trị các đỉnh ở step
				{
					Cost[step, k] = Cost[step - 1, k]; // Gán giá trị cost step hiện tại là giá trị cost step trước đó  
					Prev[step, k] = Prev[step - 1, k]; // Gán đỉnh kề trước ở step hiện tại là giá trị chi phi step trước đó  
					int min = Cost[step - 1, k]; // Gán giá trị min là giá trị cost step trước đó. Để làm giá trị cố định khi so sánh, tránh làm mất giá trị của Cost step-1
					int previous = Prev[step - 1, k]; //Gán đỉnh kề trước step hiện tại là đỉnh kề trước ở step trước. Để làm giá trị cố định khi so sánh, tránh làm mất giá trị của Cost step-1

					//Tìm đỉnh v có đường nối v->k 
					for (int v = 0; v < n; v++) 
					{
						// Nếu cost v ở step-1 (chi phí nhỏ nhất để đi đến v) khác vô cực và có đường đi đến k 
						// và chi phí (trọng số) v->k + cost v ở step-1 < cost k ở step -1 (chi phí nhỏ nhất đi đến k ở bước step -1)     
						if (matrix[v, k] != 0 && Cost[step - 1, v] != vocuc &&
							matrix[v, k] + Cost[step - 1, v] < Cost[step - 1, k])
						{
							Cost[step, k] = matrix[v, k] + Cost[step - 1, v]; // Gán cost k(chi phí nhỏ nhất đến k) = chi phí (trọng số) v->k + cost v ở step-1 (chi phí nhỏ nhất để đi đến v)
							Prev[step, k] = v; // Gán đỉnh kề trước k = đỉnh v do đi từ v tối ưu hơn
							
							// Để kiểm tra xem Cost k có phải là tối ưu nhất hay chưa, do Cost k sẽ thay đổi khi có đường đi và thỏa yêu cầu trên,
							// nên khi có nhiều đường đi đến k sẽ lấy giá trị ở lần chạy cuối chứ không lấy giá trị tối ưu nhất đến k.
							//Nếu cost k step <=min  
							if (Cost[step, k] <= min) 
							{
								min = Cost[step, k]; // min = cost k step hiện tại là tối ưu nhất. 
								previous = v; // đỉnh kề trước k là đỉnh v là đường đi tối ưu nhất
							}
							//Ngược lạ cost k ở step > cost k ở step-1  => giữ lại Cost k ở step hiện tại = Cost step -1 = min 
							else
							{
								Cost[step, k] = min;
								Prev[step, k] = previous;
							}
						}
					}
				}
				//Điều kiện dừng giải thuật 
				bool same = true; //same =true các Cost của các đỉnh qua các step giống nhau 
				for (int k = 0; k < n; ++k)
				{
					//Nếu Cost các đỉnh còn khác Step-1 
					if (Cost[step, k] != Cost[step - 1, k])
					{
						same = false; break; // => còn đường đi tối ưu hơn nên Cost còn cập nhật => same = false 
					}
				}
				//Nếu không còn cập nhât Cost so với lần trước thì dừng => kết thức giải thuật
				if (same) { break; } 
				//Có mạch âm : khi ở bước = n mà Cost vẫn khác nhau => có mạch âm 
				else if (step >= n && same == false)
				{
					Console.WriteLine("Do thi co mach am;");
					break;
				}
			}
			//Xuất kết quả
			Console.Write($"- Duong di ngan nhat tu {source} den {source}: "); //In đỉnh bắt đầu trước
			Console.Write($"Cost = 0   Path = {source}"); //Với chi phí là 0 và Path là chính nó
			Console.WriteLine();
			//In các đỉnh khác
			for (int j = 0; j < n; ++j) 
			{
				//Nếu Cost đỉnh j ở step = vô cực 
				if (Cost[step, j] == vocuc)
				{
					Console.WriteLine($"- Khong co duong di tu {source} den {j}"); //Không có đường đi từ soure đến đỉnh j
				}
				//Nếu đỉnh j khác source
				else if (j != source) 
				{
					int dest = j; //gán đỉnh kết thúc dest = đỉnh j
					Console.Write($"- Duong di ngan nhat tu {source} den {dest}: "); 
					Console.Write($"Cost = {Cost[step, j]} "); //In chi phí ở đỉnh j
					Console.Write($"  Path = {dest}"); 
					int flag = -1; //flag là đỉnh dest 
					//In đỉnh kề trước 
					for (int i = step - 1; i > 0; --i)
					{
						dest = Prev[i, dest]; //Gán dest = đỉnh kề trước 
						if (flag != dest) //Chạy Lần đầu thì sẽ flag sẽ khác dest nên sẽ in được đỉnh dest kết thúc.
						{
							Console.Write($"<- {dest}");  
						}
						flag = dest; //gán flag = dest để truy lại xem có In đỉnh đó hay không. Nếu khác thì mới in.
					}
					Console.WriteLine();
				}
			}
		}
	}
}
