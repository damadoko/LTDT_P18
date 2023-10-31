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
			bool DTT = true;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					// Neu do thi la do thi co huong  
					// hoac co canh khuyen (matrix[i, i] != 0)
					// hoac co canh boi (matrix [i,j]==2)
					// Thi do thi khong phai la don do thi
					if (YeuCau1.KiemTraDTVH(matrix)==false || matrix[i, i] != 0 || matrix[i,j]==2)
					{
						return DTT= false;
					}
				}
			}
			return DTT;
		}
		
		public static bool KiemTraCoPhaiDoThiEuler(int[,] a)
		{
			int so_bac_chan = 0;
			int so_bac_le = 0;

			// Duyet qua cac dinh cua do thi
			for (int i = 0; i < a.GetLength(0); i++)
			{
				int so_bac = 0;
				// Duyet qua cac dinh lan 2 (de thim canh noi giua 2 dinh i,j)
				for (int j = 0; j < a.GetLength(1); j++)
				{
					// Neu co canh noi 2 dinh i,j, tang so bac cua dinh i
					if (a[i, j] == 1)
					{
						so_bac++;
					}
					if (j != a.GetLength(1) - 1) continue;
				}
				// Neu dinh i co bac chang (so_bac % 2 == 0),
				// Thi tang so_bac_chan va nguoc lai
				if (so_bac % 2 == 0)
				{
					so_bac_chan++;
				}
				else
				{
					so_bac_le++;
				}
			}

			// Neu so so_bac_le > 2, log "Do thi khong Euler" va return ra ket qua false
			if (so_bac_le > 2)
			{
				Console.WriteLine("Do thi khong Euler");
				return false;
			}
            // Neu khong co bac le, in "Do thi Euler"
            if (so_bac_le == 0)
			{
				Console.WriteLine("Do thi Euler");
			}
			// nguoc lai, in "Do thi nua Euler"
			else
			{
				Console.WriteLine("Do thi nua Euler");
			}
			return true;
		}

		// Kiem tra so thanh phan lien thong sau khi xoa canh {x,y} co tang len hay khong
		// Neu so thanh phan lien thong tang len -> la canh cau
		// Neu so thanh phan lien thong khong tang len -> khong la canh cau
		public static bool KiemTraCanhCau(int[,] a, int x, int y)
		{
			int so_thanh_phan_lien_thong_hien_tai = YeuCau2.TimThanhPhanLienThong(a).Count;
			int[,] b = (int[,])a.Clone();
			b[x, y] = 0;
			b[y, x] = 0;
			int so_thanh_phan_lien_thong_sau_khi_xoa_canh_x_y = YeuCau2.TimThanhPhanLienThong(b).Count;
			return so_thanh_phan_lien_thong_hien_tai < so_thanh_phan_lien_thong_sau_khi_xoa_canh_x_y;
		}

		// Dem so canh trong ma tran
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

			// Lap lai den khi xet het tat ca cac canh
			while (so_canh_da_xet < tong_so_canh)
			{
				// Xet dinh cuoi cung trong danh sach cac_dinh_da_xet
				int dinh_dang_xet = cac_dinh_da_xet[cac_dinh_da_xet.Count - 1];
				// Khoi tao cac_dinh_co_canh_cau
				List<int> cac_dinh_co_canh_cau = new List<int>();
				// Khoi tao bien da_chon_duoc_dinh: da chon duoc 1 dinh khong phai la canh cau
				bool da_chon_duoc_dinh = false;

				for (int i = 0; i < a.GetLength(0); i++)
				{
					// Neu da_chon_duoc_dinh bo qua logic ben duoi
					if (da_chon_duoc_dinh) continue;
					
					// Neu co canh noi giua dinh dang xet va i
					if (a[dinh_dang_xet, i] == 1)
					{
						// Neu khong co canh cau, them dinh vao ket qua
						if (!KiemTraCanhCau(a, dinh_dang_xet, i))
						{
							// Xoa canh noi dinh i va dinh_dang_xet (xoa ca 2 chieu)
							a[dinh_dang_xet, i] = 0;
							a[i, dinh_dang_xet] = 0;
							// Them dinh i vao cac_dinh_da_xet
							cac_dinh_da_xet.Add(i);
							so_canh_da_xet++;
							// Danh dau da chon duoc dinh, dung de skip cac step phia sau
							da_chon_duoc_dinh = true;
						}
						// Neu co canh cau, tam thoi them dinh i vao cac_dinh_co_canh_cau de xet cac dinh khacx
						else
						{
							cac_dinh_co_canh_cau.Add(i);
						}
					}
				}
				// Neu da chon duoc dinh binh thuong, bo qua logic ben duoi
				if (da_chon_duoc_dinh) continue;

				// Khong chon duoc dinh binh thuong, chi co cac dinh tao thanh canh cau
				if (cac_dinh_co_canh_cau.Count != 0)
				{
					// Chon dinh co canh cau nho nhat
					int dinh_co_canh_cau_nho_nhat = cac_dinh_co_canh_cau.First();
					// Xoa canh noi dinh_dang_xet va dinh_co_canh_cau_nho_nhat (xoa ca 2 chieu)
					a[dinh_dang_xet, dinh_co_canh_cau_nho_nhat] = 0;
					a[dinh_co_canh_cau_nho_nhat, dinh_dang_xet] = 0;
					// Them dinh_co_canh_cau_nho_nhat vao ket qua
					cac_dinh_da_xet.Add(dinh_co_canh_cau_nho_nhat);
					so_canh_da_xet++;
				}
				// Het duong di: Khong chon duoc dinh binh thuong, cung khong co dinh co canh cau
				// Return ra ket qua rong, nghia la khong co loi giai
				else
				{
					return new List<int>();
				}
			}

			return cac_dinh_da_xet;
		}

		// Kiem tra do thi Euler
		// Tim chuoi dinh Euler
		// In chuoi dinh Euler
		public static void Euler(int[,] a, int source)
		{
			bool co_phai_do_thi_Euler = KiemTraCoPhaiDoThiEuler(a);

			// Neu khong phai do thi Euler, dung
			if (!co_phai_do_thi_Euler) return;

			// Tim chuoi dinh Euler
			List<int> chuoi_dinh_euler = TimChuoiDinhEuler(a, source);

            // Neu khong tim ra chuoi dinh, in "Khong co loi giai" va dung
            if (chuoi_dinh_euler.Count == 0)
			{
				Console.WriteLine("Khong co loi giai");
				return;
			}
			// In chuoi dinh Euler
			for (int i = 0; i < chuoi_dinh_euler.Count; i++)
			{
				Console.Write($"{chuoi_dinh_euler[i]} ");
			}
		}
	}
}
