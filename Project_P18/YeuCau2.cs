using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P18
{
	public class YeuCau2
	{
		// Todo: merge with yeu cau 1
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
						// Return?
					}
				}
			}
			return DTVH;
		}

		public static bool KiemTraDinh(int source, int[,] a)
		{
			bool isValid = source <= a.GetLength(0);
			if (!isValid)
			{
				Console.WriteLine($"Do thi khong co dinh so {source}");
			}
			return isValid;
		}

		public static void InCacDinh(List<int> cac_dinh)
		{
			for (int x = 0; x < cac_dinh.Count; x++)
			{
				Console.Write($"{cac_dinh[x]} ");
			}
		}

		public static void InDPS(int[,] a)
		{
			Console.WriteLine("Nhap dinh bat dau");
			int source = Convert.ToInt32(Console.ReadLine());
			if (!KiemTraDinh(source, a)) return;

			List<int> dinh_da_tham = new List<int>();
			bool[] da_xet = new bool[a.GetLength(1)];

			DPS(a, source, ref dinh_da_tham, ref da_xet);

			// In cac dinh da tham
			Console.WriteLine("Giai thuat DPS");
			InCacDinh(dinh_da_tham);
		}

		public static void DPS(int[,] a, int dinh_hien_tai, ref List<int> dinh_da_tham, ref bool[] da_xet)
		{
			da_xet[dinh_hien_tai] = true;
			dinh_da_tham.Add(dinh_hien_tai);

			for (int dinh_tiep_theo = 0; dinh_tiep_theo < a.GetLength(1); dinh_tiep_theo++)
			{
				if (a[dinh_hien_tai, dinh_tiep_theo] == 1 && !da_xet[dinh_tiep_theo])
				{
					DPS(a, dinh_tiep_theo, ref dinh_da_tham, ref da_xet);
				}
			}
		}

		public static List<int> DuyetBFS(int[,] a, int dinh_dang_xet)
		{

			List<int> dinh_da_tham = new List<int>();
			List<int> hang_doi = new List<int>();
			bool[] da_xet = new bool[a.GetLength(1)];

			hang_doi.Add(dinh_dang_xet);
			da_xet[dinh_dang_xet] = true;

			while (hang_doi.Count != 0)
			{
				dinh_dang_xet = hang_doi.First();
				hang_doi.Remove(dinh_dang_xet);
				dinh_da_tham.Add(dinh_dang_xet);

				for (int dinh_tiep_theo = 0; dinh_tiep_theo < a.GetLength(1); dinh_tiep_theo++)
				{
					if (!da_xet[dinh_tiep_theo] && a[dinh_dang_xet, dinh_tiep_theo] == 1)
					{
						hang_doi.Add(dinh_tiep_theo);
						da_xet[dinh_tiep_theo] = true;
					}
				}
			}
			return dinh_da_tham;
		}

		public static void InBFS(int[,] a)
		{
			Console.WriteLine("Nhap dinh bat dau");
			int dinh_dang_xet = Convert.ToInt32(Console.ReadLine());
			if (!KiemTraDinh(dinh_dang_xet, a)) return;

			List<int> dinh_da_tham = DuyetBFS(a, dinh_dang_xet);
			Console.WriteLine("Giai thuat BFS");
			InCacDinh(dinh_da_tham);
		}


		public static List<List<int>> TimThanhPhanLienThong(int[,] a)
		{
			List<List<int>> cac_lien_thong = new List<List<int>>();
			List<int> cac_dinh = new List<int>();
			for (int i = 0; i < a.GetLength(1); i++)
			{
				cac_dinh.Add(i);
			}

			while (cac_dinh.Count != 0)
			{
				List<int> cac_dinh_da_tham = DuyetBFS(a, cac_dinh.First());
				cac_lien_thong.Add(cac_dinh_da_tham);
				for (int j = 0; j < cac_dinh_da_tham.Count; j++)
				{
					cac_dinh.Remove(cac_dinh_da_tham[j]);
				}
			}

			return cac_lien_thong;
		}

		public static void InLienThong(int[,] a)
		{
			List<List<int>> cac_lien_thong = TimThanhPhanLienThong(a);

			Console.WriteLine($"So thanh phan lien thong: {cac_lien_thong.Count}");
			for (int k = 0; k < cac_lien_thong.Count; k++)
			{
				Console.WriteLine($"Thanh phan lien thong thu {k + 1}:");
				InCacDinh(cac_lien_thong[k]);
				Console.WriteLine();
			}

		}
	}
}
