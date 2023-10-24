using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}*/

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
		}
		public static bool TrongSoDuong(int[,] matrix)
		{
			bool kq = true;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] < 0)
					{
						kq = false;
					}
				}
			}
			return kq;
		}
		public static int TimMin(int[] L, bool[] T)
		{
			int min = int.MaxValue;
			int min_index = -1;
			for (int i = 0; i < L.Length; i++)
			{
				if (T[i] == true && L[i] <= min)
				{
					min = L[i];
					min_index = i;
				}
			}
			return min_index;
		}
		public static void Dijkstra(int[,] matrix, int source)
		{
			int n = matrix.GetLength(0);
			bool[] T = new bool[n]; //mang danh dau dinh
			int[] L = new int[n]; // cost
			const int vocuc = int.MaxValue;
			int[] Pre = new int[n]; //dinh ke truoc
			for (int i = 0; i < n; i++)
			{
				T[i] = true; //cac dinh deu thuoc T
				L[i] = vocuc; //chieu dai = vocuc
				Pre[i] =-1; //Dinh ke truoc 
			}
			L[source] = 0;
			Pre[source] = source;

			for (int i = 0; i < n; ++i)
			{
				int v = TimMin(L, T);
				int min = L[v];
				T[v] = false; //loai dinh ra khiu tap T 	
				
				//tim canh ke
				for (int k = 0; k < n; ++k)
				{
					if (T[k] == true && matrix[v, k] != 0 &&
						matrix[v, k] + min < L[k] && min != vocuc)
					{
						L[k] = matrix[v, k] + min;
						Pre[k] = v;
					}
				}
				//Xuat ket qua
				if (min != vocuc)
				{
					Console.Write($"- Duong di ngan nhat tu {source} den {v} :Cost ={min} Path: ");
					int t = v;
					Console.Write($"{v}");
					while (t!=source)
					{
						Console.Write($"<-{Pre[t]}");
						t = Pre[t];

					}
					Console.WriteLine();
				}
				else
				{
					Console.WriteLine($"- Khong co duong di tu {source} den {v}");				
				}
			}
		}
		public static void Bellman(int[,] matrix, int source)
		{
			int n = matrix.GetLength(0);
			int[,] Cost = new int[n + 1, n];
			int[,] Prev = new int[n + 1, n];
			int step = 1;
			const int vocuc = int.MaxValue;

			for (int i = 0; i < n; ++i)
			{
				Cost[0, i] = vocuc;
				Prev[0, i] = i;
			}
			Cost[0, source] = 0;
			for (step = 1; step <= n; ++step)
			{
				for (int k = 0; k < n; ++k)
				{
					Cost[step, k] = Cost[step - 1, k];
					Prev[step, k] = Prev[step - 1, k];
					int min = Cost[step - 1, k];
					int previous = Prev[step - 1, k];
					for (int v = 0; v < n; v++)
					{
						if (matrix[v, k] != 0 && Cost[step - 1, v] != vocuc &&
							matrix[v, k] + Cost[step - 1, v] < Cost[step - 1, k])
						{
							Cost[step, k] = matrix[v, k] + Cost[step - 1, v];
							Prev[step, k] = v;
							if (Cost[step, k] <= min)
							{
								min = Cost[step, k];
								previous = v;
							}
							else
							{
								Cost[step, k] = min;
								Prev[step, k] = previous;
							}
						}
					}
				}
				bool same = true;
				for (int k = 0; k < n; ++k)
				{
					if (Cost[step, k] != Cost[step - 1, k])
					{
						same = false; break;
					}
				}
				if (same) { break; }
				else if (step >= n && same == false)
				{
					Console.WriteLine("Do thi co mach am;");
					break;
				}
			}
			Console.Write($"- Duong di ngan nhat tu {source} den {source}: ");
			Console.Write($"Cost = 0   Path = {source}");
			Console.WriteLine();
			for (int j = 0; j < n; ++j)
			{
				if (Cost[step, j] == vocuc)
				{
					Console.WriteLine($"- Khong co duong di tu {source} den {j}");
				}
				else if (j != source)
				{
					int dest = j; 
					Console.Write($"- Duong di ngan nhat tu {source} den {dest}: ");
					Console.Write($"Cost = {Cost[step, j]} ");
					Console.Write($"  Path = {dest}");
					int flag = -1;
					for (int i = step - 1; i > 0; --i)
					{
						dest = Prev[i, dest];
						if (flag != dest)
						{
							Console.Write($"<- {dest}");
						}
						flag = dest;
					}
					Console.WriteLine();
				}
			}
		}
	}
}
