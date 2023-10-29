using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P18
{
	public class YeuCau5
	{
		public static bool KiemTraDonDoThi(int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (YeuCau1.KiemTraDTVH(matrix) && matrix[i, j] != matrix[j, i] || matrix[i, i] != 0)
					{
						return false;
					}
					else { break; };
				}
			}
			return true;
		}

		public static bool KiemTraCoPhaiDoThiEuler(int[,] a)
		{
			int so_bac_chan = 0;
			int so_bac_le = 0;

			for (int i = 0; i < a.GetLength(0); i++)
			{
				int so_bac = 0;
				for (int j = 0; j < a.GetLength(1); j++)
				{
					if (a[i, j] == 1)
					{
						so_bac++;
					}
					if (j != a.GetLength(1) - 1) continue;
				}
				if (so_bac % 2 == 0)
				{
					so_bac_chan++;
				}
				else
				{
					so_bac_le++;
				}
			}

			if (so_bac_le > 2)
			{
				Console.WriteLine("Do thi khong Euler");
				return false;
			}
			if (so_bac_le == 0)
			{
				Console.WriteLine("Do thi Euler");
			}
			else
			{
				Console.WriteLine("Do thi nua Euler");
			}
			return true;
		}

		public static bool KiemTraCanhCau(int[,] a, int x, int y)
		{
			int so_thanh_phan_lien_thong_hien_tai = YeuCau2.TimThanhPhanLienThong(a).Count;
			int[,] b = (int[,])a.Clone();
			b[x, y] = 0;
			b[y, x] = 0;
			int so_thanh_phan_lien_thong_sau_khi_bo_canh = YeuCau2.TimThanhPhanLienThong(b).Count;
			return so_thanh_phan_lien_thong_hien_tai < so_thanh_phan_lien_thong_sau_khi_bo_canh;
		}

		static int DemSoCanh(int[,] a)
		{
			int so_canh = 0;
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j <= i; j++)
				{
					if (a[i, j] != 0)
					{
						so_canh++;
					}
				}
			}
			return so_canh;
		}

		public static List<int> TimChuoiDinhEuler(int[,] a, int diem_dau)
		{
			List<int> cac_dinh_da_xet = new List<int>
			{
				diem_dau
			};
			int so_canh_da_xet = 0;
			int tong_so_canh = DemSoCanh(a);

			while (so_canh_da_xet < tong_so_canh)
			{
				int dinh_dang_xet = cac_dinh_da_xet[cac_dinh_da_xet.Count - 1];
				List<int> cac_dinh_co_canh_cau = new List<int>();
				bool da_chon_duoc_dinh = false;

				for (int i = 0; i < a.GetLength(0); i++)
				{
					if (da_chon_duoc_dinh) continue;
					if (a[dinh_dang_xet, i] == 1)
					{
						if (!KiemTraCanhCau(a, dinh_dang_xet, i))
						{
							a[dinh_dang_xet, i] = 0;
							a[i, dinh_dang_xet] = 0;
							cac_dinh_da_xet.Add(i);
							so_canh_da_xet++;
							da_chon_duoc_dinh = true;
						}
						else
						{
							cac_dinh_co_canh_cau.Add(i);
						}
					}
				}
				if (da_chon_duoc_dinh) continue;

				if (cac_dinh_co_canh_cau.Count != 0)
				{
					// Chon dinh co canh cau nho nhat
					int dinh_co_canh_cau_nho_nhat = cac_dinh_co_canh_cau.First();
					a[dinh_dang_xet, dinh_co_canh_cau_nho_nhat] = 0;
					a[dinh_co_canh_cau_nho_nhat, dinh_dang_xet] = 0;
					cac_dinh_da_xet.Add(dinh_co_canh_cau_nho_nhat);
					so_canh_da_xet++;
				}
				else
				{
					// Het duong di
					return new List<int>();

				}
			}

			return cac_dinh_da_xet;
		}

		public static void Euler(int[,] a, int source)
		{
			bool co_phai_do_thi_Euler = KiemTraCoPhaiDoThiEuler(a);

			if (!co_phai_do_thi_Euler) return;
			List<int> chuoi_dinh_euler = TimChuoiDinhEuler(a, source);

			// In
			if (chuoi_dinh_euler.Count == 0)
			{
				Console.WriteLine("Khong co loi giai");
				return;
			}
			for (int i = 0; i < chuoi_dinh_euler.Count; i++)
			{
				Console.Write($"{chuoi_dinh_euler[i]} ");
			}
		}
	}
}
