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
			string path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            StreamReader file = new StreamReader(path);
			int so_dinh = int.Parse(file.ReadLine());

			int[,] ma_tran = new int[so_dinh, so_dinh];
			int vitri;
			for (int i = 0; i < so_dinh; i++)
			{
				string line = file.ReadLine()!;
				string[] m = line.Split(' ');
				int so_canh_cua_dinh_i = int.Parse(m[0]);
				if (so_canh_cua_dinh_i == 0) continue;

				for (int j = 1; j < 2 * so_canh_cua_dinh_i; j += 2)
				{
					vitri = int.Parse(m[j]);
                    if (ma_tran[i, vitri] == 1)
                    {
                        ma_tran[i, vitri] += 1;
                    }
                    else
                    {
                        ma_tran[i, vitri] = 1;
                    }
				}
			}
			return ma_tran;
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
                int so_canh_cua_dinh_i = int.Parse(m[0]);
                if (so_canh_cua_dinh_i == 0) continue;

                for (int j = 1; j < 2 * so_canh_cua_dinh_i; j += 2)
				{
					vitri = int.Parse(m[j]);
					a[i, vitri] = int.Parse(m[j + 1]);
				}
			}
			return a;
		}

		// Cau 1: Phan tich thong tin do thi
		public static void XuatThongTinDoThi(int[,] a)
		{ 
			Console.WriteLine("- Xuat ma tran: ");
            // 1.a Ma tran ke cua do thi:
            XuatMaTranKe(a);

			// 1.b Xac dinh tinh co huong cua do thi:
			bool aLaDoThiVoHuong = KiemTraDTVH(a);
			if (aLaDoThiVoHuong)
			{
				Console.WriteLine("Do thi vo huong ");
			}
			else
			{
				Console.WriteLine("Do thi co huong");
			}
			
            // 1.c
            Console.WriteLine("- So dinh cua do thi: " + a.GetLength(0));

			// 1.d
			Console.WriteLine("- So canh cua do thi:" + DemCanh(a));

			// 1.e
			Console.WriteLine("- So cap dinh xuat hien canh boi:" + DemCanhBoi(a));
			Console.WriteLine("- So canh khuyen:" + DemCanhKhuyen(a));

			// 1.f
			Console.WriteLine("- So dinh treo:" + DemDinhTreo(a));
			Console.WriteLine("- So dinh co lap:" + DemDinhCoLap(a));

            // 1.g
            XuatBacDinh(a);
		}

		public static bool KiemTraDTVH(int[,] ma_tran_ke)
		{
			for (int i = 0; i < ma_tran_ke.GetLength(0); i++)
			{
				for (int j = 0; j < ma_tran_ke.GetLength(1); j++)
				{
					// Neu co 1 phan tu co gia tri khong doi xung, ket luan do thi khong vo huong
					if (ma_tran_ke[i, j] != ma_tran_ke[j, i]) return false;
				}
			}
			return true;
		}

		static void XuatMaTranKe(int[,] ma_tran_ke)
		{
			for (int i = 0; i < ma_tran_ke.GetLength(0); i++)
			{
				for (int j = 0; j < ma_tran_ke.GetLength(1); j++)
				{
					Console.Write($"{ma_tran_ke[i, j]} ");
				}
				Console.WriteLine("");
			}
			Console.WriteLine("");
		}

		static int DemCanhKhuyen(int[,] a)
		{
			int count = 0;
            // Vi du: {
            //	{x,1,0}
            //	{1,x,1}
            //	{0,1,x}
            // }
            // Trong vi du tren, dau x la nhung phan tu dung de xet canh khuyen (a[i,i]) -> dung 1 vong loop
            for (int i = 0; i < a.GetLength(0); i++)
			{
				if (a[i, i] == 1)
				{
					count++;
				}
			}
			return count;
		}

		static int DemCanh(int[,] a)
		{
			int count = 0;
			if (KiemTraDTVH(a))
			{
				for (int i = 0; i < a.GetLength(0); i++)
				{
					// Chi xet 1/2 ma tran doi voi do thi vo huong:
					// Vi du: {
					//	{1,1,0}
					//	{x,0,1}
					//	{x,x,0}
					// }
					// Trong vi du tren, dau x la nhung phan tu khong xet, tranh bi lap lai do do thi vo huong co tinh doi xung
					for (int j = 0; j <= i; j++)
					{
						count += a[i, j];
					}
				}
			}
			else
			{
				// Xet toan bo ma tran doi voi do thi co huong
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
					// i la thu tu dinh a[i, j] la so canh noi dinh a den dinh j
					// sum la tong cac bac dinh cua dinh i
					// Khong xet a[j, i] vi ma tran do thi vo huong co tinh doi xung
					sum += a[i, j];
				}
				b[i] = sum;
			}
			return b;
		}

		static int[] TongBacDinhCoHuong(int[,] a)
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
                    // i la thu tu dinh
                    // insum la tong cac canh di den dinh i -> cong them a[j, i] qua moi lan duyet
                    // outsum la tong cac canh di ra tu dinh i -> cong them a[i, j] qua moi lan duyet
                    insum += a[j, i];
					outsum += a[i, j];
				}
				inDinh[i] = insum;
				outDinh[i] = outsum;
				// Bac dinh i bang tong cac canh canh vao va canh ra dinh i
				tongDinh[i] = inDinh[i] + outDinh[i];
			}
			return tongDinh;
		}

		static int DemDinhTreo(int[,] a)
		{
			int count = 0;
			int[] b = new int[a.GetLength(0)];
			// Tim so bac cua cac dinh tuy theo loai do thi vo huong hay co huong
			if (KiemTraDTVH(a))
			{
				b = BacDinhVoHuong(a);
			}
			else
			{
				b = TongBacDinhCoHuong(a);
			}
			// Loop qua cac bac dinh, neu co dinh nao bac dinh la 1 thi chinh la dinh treo
			for (int i = 0; i < a.GetLength(0); i++)
			{
				if (b[i] == 1)
				{
					count++;
				}
			}
			return count;
		}

		static int DemDinhCoLap(int[,] a)
		{
			int count = 0;
			int[] b = new int[a.GetLength(0)];
            // Tim so bac cua cac dinh tuy theo loai do thi vo huong hay co huong
            if (KiemTraDTVH(a))
			{
				b = BacDinhVoHuong(a);
			}
			else
			{
				b = TongBacDinhCoHuong(a);

			}
            // Loop qua cac bac dinh, neu co dinh nao bac dinh la 0 thi chinh la dinh co lap
            for (int i = 0; i < a.GetLength(0); i++)
			{
				if (b[i] == 0)
				{
					count++;
				}
			}
			return count;
		}

		static void XuatBacDinh(int[,] a)
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
						sum += a[i, j];
					}
					b[i] = sum;
					Console.WriteLine($"- Bac cua dinh {i}:" + b[i]);
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
						insum += a[j, i];
						outsum += a[i, j];
					}
					inDinh[i] = insum;
					outDinh[i] = outsum;
					Console.WriteLine($"- Bac cua dinh {i} (" + inDinh[i] + "-" + outDinh[i] + ")");
				}
			}
		}

		static int DemCanhBoi(int[,] a)
		{
			int count = 0;
			if (KiemTraDTVH(a))
			{
				for (int i = 0; i < a.GetLength(0); i++)
				{
                    // Chi xet 1/2 ma tran doi voi do thi vo huong:
                    // Vi du: {
                    //	{1,1,0}
                    //	{x,0,1}
                    //	{x,x,0}
                    // }
                    // Trong vi du tren, dau x la nhung phan tu khong xet, tranh bi lap lai do do thi vo huong co tinh doi xung
                    for (int j = 0; j <= i; j++)
					{
						// Cap dinh xuat hien canh boi khi co tu 2 canh tro len noi 2 dinh
						if (a[i, j] >= 2)
						{
							count++;
						}
					}
				}
			}
			else
			{
                // Xet toan bo ma tran doi voi do thi co huong
				for (int i = 0; i < a.GetLength(0); i++)
				{
                    for (int j = 0; j < a.GetLength(1); j++)
					{
                        // Cap dinh xuat hien canh boi khi co tu 2 canh tro len noi 2 dinh
                        if (a[i, j] >= 2)
							count++;
					}
				}
			}
			return count;
		}
	}
}
