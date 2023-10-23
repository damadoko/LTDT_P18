using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P18
{
	public class YeuCau1
	{
		public static int[,] KhoiTaoDT(string filename)
		{
			StreamReader file = new StreamReader(filename);
			string s = file.ReadLine();
			int n = int.Parse(s);
			int[,] a = new int[n, n];
			int vitri;
			for (int i = 0; i < n; i++)
			{
				s = file.ReadLine();
				string[] m = s.Split(' ');
				int k = int.Parse(m[0]);
				if (k != 0)
				{
					for (int j = 1; j < 2 * k; j += 2)
					{
						vitri = int.Parse(m[j]);
                        if (a[i, vitri] == 1)
                        {
                            a[i, vitri] += 1;
                        }
                        else
                        {
                            a[i, vitri] = 1;
                        }
                    }
				}
			}
			return a;
		}
		public static int[,] XuatMaTran(string filename)
		{
			StreamReader file = new StreamReader(filename);
			string s = file.ReadLine();
			int n = int.Parse(s);
			int[,] a = new int[n, n];
			int vitri;
			for (int i = 0; i < n; i++)
			{
				s = file.ReadLine();
				string[] m = s.Split(' ');
				int k = int.Parse(m[0]);
				if (k != 0)
				{
					for (int j = 1; j < 2 * k; j += 2)
					{
						vitri = int.Parse(m[j]);
						a[i, vitri] = int.Parse(m[j + 1]);
					}
				}
			}
			return a;
		}
		public static void DocDT(int[,] a)
		{
			for (int i = 0; i < a.GetLength(0); i++)
			{
				Console.WriteLine("");
				for (int j = 0; j < a.GetLength(1); j++)
				{
					Console.Write(a[i, j]);
				}
			}
			Console.WriteLine("");
		}
		public static bool KiemTraDTVH(int[,] a)
		{
			bool DTVH = true;
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					if (a[i, j] != a[j, i])
					{
						DTVH = false;
					}
				}
			}
			return DTVH;
		}
		public static int DemCanhKhuyen(int[,] a)
		{
			int count = 0;
			for (int i = 0; i < a.GetLength(0); i++)
			{
				if (a[i, i] == 1)
				{
					count++;
				}
			}
			return count;
		}
		public static int DemCanh(int[,] a)
		{
			int count = 0;
			if (KiemTraDTVH(a))
			{
				for (int i = 1; i < a.GetLength(0); i++)
				{
					for (int j = 0; j < i; j++)
					{

						count += a[i, j];
					}
				}
				if (DemCanhKhuyen(a) > 0)
				{
					count += DemCanhKhuyen(a);
				}
			}
			else
			{
				for (int i = 0; i < a.GetLength(0); i++)
				{
					for (int j = 0; j < a.GetLength(1); j++)
					{

						count += a[i, j];
					}
				}
			}
			return count;
		}
		public static int[] BacDinhVoHuong(int[,] a)
		{
			int[] b = new int[a.GetLength(0)];

			for (int i = 0; i < a.GetLength(0); i++)
			{
				int sum = 0;
				for (int j = 0; j < a.GetLength(1); j++)
				{
					sum = sum + a[i, j];
				}
				b[i] = sum;
			}
			return b;
		}
		public static int[] TongBacDinhCoHuong(int[,] a)
		{
			int[] inDinh = new int[a.GetLength(0)];
			int[] outDinh = new int[a.GetLength(0)];
			int[] tongDinh = new int[a.GetLength(0)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				int insum = 0;
				int outsum = 0;
				for (int j = 0; j < a.GetLength(1); j++)
				{
					insum = insum + a[j, i];
					outsum = outsum + a[i, j];
				}
				inDinh[i] = insum;
				outDinh[i] = outsum;
				tongDinh[i] = inDinh[i] + outDinh[i];
			}
			return tongDinh;
		}

		public static int DemDinhTreo(int[,] a)
		{
			int count = 0;
			int[] b = new int[a.GetLength(0)];
			if (KiemTraDTVH(a))
			{
				b = BacDinhVoHuong(a);

			}
			else
			{
				b = TongBacDinhCoHuong(a);

			}
			for (int i = 0; i < a.GetLength(0); i++)
			{
				if (b[i] == 1)
				{
					count++;
				}
			}
			return count;
		}
		public static int DemDinhCoLap(int[,] a)
		{
			int count = 0;
			int[] b = new int[a.GetLength(0)];
			if (KiemTraDTVH(a))
			{
				b = BacDinhVoHuong(a);

			}
			else
			{
				b = TongBacDinhCoHuong(a);

			}
			for (int i = 0; i < a.GetLength(0); i++)
			{
				if (b[i] == 0)
				{
					count++;
				}
			}
			return count;
		}
		public static void BacDinh(int[,] a)
		{
			if (KiemTraDTVH(a))
			{
				int[] b = new int[a.GetLength(0)];

				for (int i = 0; i < a.GetLength(0); i++)
				{
					int sum = 0;
					for (int j = 0; j < a.GetLength(1); j++)
					{
						if (a[i, j] > 0 && i == j)
						{
							a[i, j] = a[i, j] * 2;
						}
						sum = sum + a[i, j];
					}
					b[i] = sum;
					Console.WriteLine($"bac cua dinh {i}:" + b[i]);
				}
			}
			else
			{
				int[] inDinh = new int[a.GetLength(0)];
				int[] outDinh = new int[a.GetLength(0)];
				for (int i = 0; i < a.GetLength(0); i++)
				{
					int insum = 0;
					int outsum = 0;
					for (int j = 0; j < a.GetLength(1); j++)
					{
						insum = insum + a[j, i];
						outsum = outsum + a[i, j];
					}
					inDinh[i] = insum;
					outDinh[i] = outsum;
					Console.WriteLine($"bac cua dinh {i} (" + inDinh[i] + "-" + outDinh[i] + ")");
				}
			}
		}
		public static void KiemTraDT(int[,] a)
		{
			if (KiemTraDTVH(a))
			{
				Console.WriteLine("Do thi vo huong");
			}
			else
			{
				Console.WriteLine("Do thi co huong");
			}
		}
		public static int DemCanhBoi(int[,] a)
		{
			int count = 0;
			if (KiemTraDTVH(a))
			{
				for (int i = 1; i < a.GetLength(0); i++)
				{
					for (int j = 0; j < i; j++)
					{

						if (a[i, j] == 2)
						{
							count++;
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < a.GetLength(0); i++)
				{
					for (int j = 0; j < a.GetLength(1); j++)
					{
						if (a[i, j] == 2)
							count++;
					}
				}
			}
			return count;
		}
	}
}
