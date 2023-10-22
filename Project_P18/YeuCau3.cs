using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P18
{
	public class YeuCau3
	{
		public static void Prim(int[,] a, int diem_dau)
		{
			int so_dinh = a.GetLength(0);
			Console.WriteLine("Giai thuat Prim");
			Console.WriteLine("Tap canh cua cay khung");

			List<int> cac_dinh_chua_xet = new List<int>();
			// Fullfil cac dinh chua xet
			for (int dinh = 0; dinh < so_dinh; dinh++)
			{
				cac_dinh_chua_xet.Add(dinh);
			}

			// Khoi tao
			List<int> cac_dinh_da_xet = new List<int>
			{
				diem_dau
			};
			cac_dinh_chua_xet.Remove(diem_dau);

			// Lap
			int so_lan_lap = 0;
			int trong_so_cay_khung = 0;

			while (so_lan_lap < so_dinh - 1)
			{
				int[] canh_nho_nhat = new int[2];
				int trong_so_nho_nhat = -1;
				for (int i = 0; i < cac_dinh_da_xet.Count; i++)
				{
					for (int j = 0; j < cac_dinh_chua_xet.Count; j++)
					{
						int dinh_da_xet = cac_dinh_da_xet[i];
						int dinh_chua_xet = cac_dinh_chua_xet[j];
						int trong_so_canh_dang_xet = a[dinh_da_xet, dinh_chua_xet];
						if (trong_so_canh_dang_xet != 0 && (trong_so_canh_dang_xet <= trong_so_nho_nhat || trong_so_nho_nhat == -1))
						{
							canh_nho_nhat[0] = dinh_da_xet;
							canh_nho_nhat[1] = dinh_chua_xet;
							trong_so_nho_nhat = trong_so_canh_dang_xet;
						}
					}
				}
				cac_dinh_chua_xet.Remove(canh_nho_nhat[1]);
				cac_dinh_da_xet.Add(canh_nho_nhat[1]);
				trong_so_cay_khung += trong_so_nho_nhat;
				so_lan_lap++;

				Console.WriteLine($"{canh_nho_nhat[0]}-{canh_nho_nhat[1]}: {trong_so_nho_nhat}");
			}
			Console.WriteLine($"Trong so cua cay khung: {trong_so_cay_khung}");
		}

		public static void Kruskal(int[,] a)
		{
			List<int[]> cac_canh = new List<int[]>();
			//Khoi tao cac canh cua do thi
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j <= i; j++)
				{
					if (a[i, j] != 0)
					{
						cac_canh.Add(new int[] { i, j });
					}
				}
			}

			//Sort cac canh
			for (int i = 0; i < cac_canh.Count; i++)
			{
				for (int j = cac_canh.Count - 1; j > i; j--)
				{
					int trong_so_1 = a[cac_canh[j][0], cac_canh[j][1]];
					int trong_so_2 = a[cac_canh[j - 1][0], cac_canh[j - 1][1]];

					if (trong_so_1 < trong_so_2)
					{
						(cac_canh[j - 1], cac_canh[j]) = (cac_canh[j], cac_canh[j - 1]);
					}
				}
			}

			// Tao bang danh dau
			int[] mask = new int[a.GetLength(0)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				mask[i] = i;
			}

			Console.WriteLine("Giai thuat Kruskal");
			Console.WriteLine("Tap canh cua cay khung");

			int trong_so_cay_khung = 0;
			int so_lan_lap = 0;

			for (int i = 0; i < cac_canh.Count; i++)
			{
				bool co_tao_vong_lap = false;
				int diem_dau = cac_canh[i][0];
				int diem_cuoi = cac_canh[i][1];
				int trong_so = a[diem_dau, diem_cuoi];

				if (so_lan_lap == a.GetLength(0) - 1)
				{
					break;
				}

				if (mask[diem_dau] == mask[diem_cuoi])
				{
					co_tao_vong_lap = true;
				}

				if (!co_tao_vong_lap)
				{
					trong_so_cay_khung += trong_so;
					Console.WriteLine($"{diem_dau}-{diem_cuoi}: {trong_so}");

					for (int k = 0; k < mask.Length; k++)
					{
						if (mask[k] == mask[diem_dau] && diem_cuoi < diem_dau)
						{
							mask[k] = mask[diem_cuoi];
						}
						else if (mask[k] == mask[diem_cuoi] && diem_cuoi > diem_dau)
						{
							mask[k] = mask[diem_dau];
						}
					}

					so_lan_lap++;
				}
			}
			Console.WriteLine($"Trong so cua cay khung: {trong_so_cay_khung}");
		}
	}
}
