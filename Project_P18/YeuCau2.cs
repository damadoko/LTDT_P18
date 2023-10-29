using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P18
{
	public class YeuCau2
	{
		// Kiem tra dinh source co ton tai trong ma tran a hay khong	
		// Vi du: do thi co 3 dinh, ma tra a la mang 2 chieu co kich thuoc 3
		// Neu nhap souce la 4 -> log "Đo thi nay khong co dinh 4", return false
		// Neu nhap souce la 1/2/3 -> return true
		public static bool KiemTraDinh(int source, int[,] a)
		{
			bool isValid = source <= a.GetLength(0);
			if (!isValid)
			{
				Console.WriteLine($"Đo thi nay khong co dinh {source}");
			}
			return isValid;
		}

		// In cac dinh trong mang int, reuse cho DFS va BFS
		// input: [1,2,3,4,5]
		// output: 1 2 3 4 5
		public static void InCacDinh(List<int> cac_dinh)
		{
			for (int x = 0; x < cac_dinh.Count; x++)
			{
				Console.Write($"{cac_dinh[x]} ");
			}
		}

		// In danh sach dinh theo "giai thuat do thi theo chieu sau" (DFS)
		public static void InDFS(int[,] a,int source)
		{
			// Neu dinh nhap vao khong ton tai trong ma tran -> dung 
			if (!KiemTraDinh(source, a)) return;

			// Khoi tao danh sach dinh da tham theo DFS
			List<int> dinh_da_tham = new List<int>();
			// Khoi tao mang cac dinh da xet, gia tri default la false cho tat ca cac dinh
			bool[] dinh_da_xet = new bool[a.GetLength(1)];

			// Truyen param dinh_da_tham va da_xet theo kieu ref de method DFS co the thay doi gia tri cac bien nay
			DFS(a, source, ref dinh_da_tham, ref dinh_da_xet);

			// In cac dinh da tham
			Console.WriteLine("- Giai thuat DFS");
			InCacDinh(dinh_da_tham);
		}

		// Dung phuong phap hoi quy de giai DFS
		// Lan chay dau tien, argument dinh_hien_tai la source (user nhap vao)
		public static void DFS(int[,] a, int dinh_hien_tai, ref List<int> dinh_da_tham, ref bool[] dinh_da_xet)
		{
            // Moi lan chay se danh dau da xet dinh_hien_tai
            dinh_da_xet[dinh_hien_tai] = true;
			// Moi lan chay se them dinh_hien_tai vao danh sach dinh da tham
			dinh_da_tham.Add(dinh_hien_tai);

			// duyet qua tung dinh tiep theo trong do thi 
			for (int dinh_tiep_theo = 0; dinh_tiep_theo < a.GetLength(1); dinh_tiep_theo++)
			{
				// Neu dinh hien tai va dinh tiep theo (dinh dang duyet) co ton tai canh noi
				// Va dinh tiep theo khong nam trong danh sach dinh da xet;
				if (a[dinh_hien_tai, dinh_tiep_theo] == 1 && !dinh_da_xet[dinh_tiep_theo])
				{
                    // Tiep tuc chay recursive, cac tham so a, dinh_da_tham, dinh_da_xet van giu nhu cu 
                    // Params dinh_hien_tai se la dinh_tiep_theo
                    DFS(a, dinh_tiep_theo, ref dinh_da_tham, ref dinh_da_xet);
				}
			}
		}

		// In danh sach dinh theo "giai thuat do thi theo chieu rong" (BFS)
		public static void InBFS(int[,] a, int dinh_dang_xet)
		{
			// Neu dinh nhap vao khong ton tai trong ma tran -> dung 
			if (!KiemTraDinh(dinh_dang_xet, a)) return;

			// Thuc thi DuyetBFS de tao ra danh sach cac dinh da tham theo giai thuat BFS
			List<int> dinh_da_tham = DuyetBFS(a, dinh_dang_xet);
			Console.WriteLine("- Giai thuat BFS");
			InCacDinh(dinh_da_tham);
		}

		// Dung phuong queue de giai BFS
		// Lan chay dau tien, argument dinh_dang_xet la source (user nhap vao)
		public static List<int> DuyetBFS(int[,] a, int dinh_dang_xet)
		{
			// Khoi tao dinh da tham
			List<int> dinh_da_tham = new List<int>();
			// Khoi tao hang doi (queue)
			List<int> hang_doi = new List<int>();
			// Khoi tao mang cac dinh da xet, gia tri default la false cho tat ca cac dinh
			bool[] dinh_da_xet = new bool[a.GetLength(1)];

			// Step 1: them dinh_dang_xet vao hang_doi va danh dau da xet dinh_dang_xet
			hang_doi.Add(dinh_dang_xet);
            dinh_da_xet[dinh_dang_xet] = true;

			// Step 2: 
			// Logic la duyet dinh dau tien trong hang doi
			// sau do tim cac dinh co canh xuat phat tu dinh dang xet de them vao hang doi.
			// Lap lai cho den khi nao hang_doi empty
			while (hang_doi.Count != 0)
			{
				// dinh_dang_xet la gia tri dau tien trong hang_doi
				dinh_dang_xet = hang_doi.First();
				// Tien hanh lay dinh_dang_xet ra khoi hang_doi va them vao dinh_da_tham (dinh_dang_xet da duoc duyet qua)
				hang_doi.Remove(dinh_dang_xet);
				dinh_da_tham.Add(dinh_dang_xet);

				// Duyet qua tat ca cac dinh
				for (int dinh_tiep_theo = 0; dinh_tiep_theo < a.GetLength(1); dinh_tiep_theo++)
				{
					// Tim dinh nao chua xet va co canh noi den dinh dang xet
					if (!dinh_da_xet[dinh_tiep_theo] && a[dinh_dang_xet, dinh_tiep_theo] == 1)
					{
						// them dinhh moi vao hang doi
						hang_doi.Add(dinh_tiep_theo);
                        // Danh dau dinh moi them la da xet de tranh them nhieu lan (khi xet dinh khac co canh den dinh nay)
                        dinh_da_xet[dinh_tiep_theo] = true;
					}
				}
			}
			return dinh_da_tham;
		}

		// Tim cac thanh phan lien thong trong ma tran
		public static List<List<int>> TimThanhPhanLienThong(int[,] a)
		{
			// Khoi tao danh sanh cac thanh phan lien thong
			List<List<int>> cac_lien_thong = new List<List<int>>();
			// Khoi tao danh sanh cac dinh chua xet
			List<int> cac_dinh_chua_xet = new List<int>();
			for (int i = 0; i < a.GetLength(1); i++)
			{
                // Duyet qua tat ca canh dinh va them vao danh sach cac_dinh_chua_xet
                cac_dinh_chua_xet.Add(i);
			}

            // Logic la dung giai thuat BFS de them cac dinh trong 1 thanh phan lien thong,
            // sau do loai bo cac dinh moi tim duoc khoi cac_dinh_chua_xet,
			// neu cac_dinh_chua_xet van con gia tri, co nghia la van con thanh phan lien khong khac.
            // lap lai cho den khi cac_dinh_chua_xet empty (tat ca cac dinh da nam trong nhung thanh phan lien thong)
            while (cac_dinh_chua_xet.Count != 0)
			{
                // Dung giai thuat BFS de tim cac dinh nam trong 1 thanh phan lien thong
                // Dinh bat dau duyet la dinh dau tien trong danh sach cac_dinh_chua_xet
                List<int> cac_dinh_da_tham = DuyetBFS(a, cac_dinh_chua_xet.First());
				// Them thanh phan lien thong vao danh sach cac thanh phan lien thong
				cac_lien_thong.Add(cac_dinh_da_tham);

				// Duyet qua cac dinh cua thanh phan lien thong vua tim duoc
				for (int j = 0; j < cac_dinh_da_tham.Count; j++)
				{
                    // Loai bo cac dinh nay khoi cac_dinh_chua_xet
                    cac_dinh_chua_xet.Remove(cac_dinh_da_tham[j]);
				}
			}

			return cac_lien_thong;
		}

        // Tim va in cac thanh phan lien thong trong ma tran
		// Vi du:
        // So thanh phan lien thong: 2
		// Thanh phan lien thong thu 1: 0 2 5 1 4 6
		// Thanh phan lien thong thu 2: 3 7
		public static void InLienThong(int[,] a)
		{
			List<List<int>> cac_lien_thong = TimThanhPhanLienThong(a);

			// Dem so lien thong va log ra man hinh
			Console.WriteLine($"- So thanh phan lien thong: {cac_lien_thong.Count}");
			// Duyet qua cac lien thong va log ra man hinh cac dinh cua thanh phan lien thong (theo format cua de)
			for (int k = 0; k < cac_lien_thong.Count; k++)
			{
				Console.WriteLine($" + Thanh phan lien thong thu {k + 1}:");
				InCacDinh(cac_lien_thong[k]);
				Console.WriteLine();
			}

		}
	}
}
