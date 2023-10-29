using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P18
{
	public class YeuCau3
	{
		// Giai thuat Prim tim cay khung nho nhat
		public static void Prim(int[,] a, int diem_dau)
		{
			int so_dinh = a.GetLength(0);
			Console.WriteLine("- Giai thuat Prim");
			Console.WriteLine(" + Tap canh cua cay khung");

			// Khoi tao cac dinh chua xet
			List<int> cac_dinh_chua_xet = new List<int>();
			// Duyet qua tat ca cac dinh de them vao cac_dinh_chua_xet
			for (int dinh = 0; dinh < so_dinh; dinh++)
			{
				cac_dinh_chua_xet.Add(dinh);
			}

			// Khoi tao cac dinh da xet, default co gia tri dau tien la diem_dau (source do user nhap)
			List<int> cac_dinh_da_xet = new List<int>
			{
				diem_dau
			};
			// Loai diem_dau khoi cac_dinh_chua_xet
			cac_dinh_chua_xet.Remove(diem_dau);

			// Khoi tao so_lan_lap dung de count
			int so_lan_lap = 0;
			// Khoi tao trong_so_cay_khung dung de cong don trong qua trinh lap
			int trong_so_cay_khung = 0;

            // Logic la chia cac dinh lam 2 nhom (cac_dinh_da_xet va cac_dinh_chua_xet)
            // tim cap dinh noi cac_dinh_da_xet den cac_dinh_chua_xet co trong so nho nhat
            // Lap lai neu so lan lap lai nho hon so_dinh - 1 (do default ben cac_dinh_chua_xet se mat 1 dinh la source)
            while (so_lan_lap < so_dinh - 1)
			{
				// Khoi tao mang 2 phan tu chua 2 dinh, dung de track xem canh nao dang nho nhat
				int[] canh_nho_nhat = new int[2];
				// Khoi tao trong_so_nho_nhat, gia tri default la -1 co nghia la chua duyet qua canh nao
				int trong_so_nho_nhat = -1;
				// Duyet qua cac_dinh_da_xet va cac_dinh_chua_xet
				for (int i = 0; i < cac_dinh_da_xet.Count; i++)
				{
					for (int j = 0; j < cac_dinh_chua_xet.Count; j++)
					{
						int dinh_da_xet = cac_dinh_da_xet[i];
						int dinh_chua_xet = cac_dinh_chua_xet[j];
						int trong_so_canh_dang_xet = a[dinh_da_xet, dinh_chua_xet];
						// Neu trong_so_canh_dang_xet != 0 (co nghia la ton tai canh noi dinh_da_xet voi dinh_chua_xet)
						// Va trong_so_nho_nhat == -1 (chua duyet qua canh nao) hoac trong_so_canh_dang_xet <= trong_so_nho_nhat (canh dang xet co trong so nho hon canh da xet truoc do)
						if (trong_so_canh_dang_xet != 0 && (trong_so_canh_dang_xet <= trong_so_nho_nhat || trong_so_nho_nhat == -1))
						{
							// Thay doi gia tri cua canh_nho_nhat, va trong_so_nho_nhat
							canh_nho_nhat[0] = dinh_da_xet;
							canh_nho_nhat[1] = dinh_chua_xet;
							trong_so_nho_nhat = trong_so_canh_dang_xet;
						}
					}
				}

				// Sau khi duyet cac_dinh_da_xet va cac_dinh_chua_xet de tim canh co trong so nho nhat
				// Loai bo dinh vua tim duoc (canh_nho_nhat[1]) khoi cac_dinh_chua_xet
				cac_dinh_chua_xet.Remove(canh_nho_nhat[1]);
				// Them dinh vua tim duoc (canh_nho_nhat[1]) khoi cac_dinh_da_xet
				cac_dinh_da_xet.Add(canh_nho_nhat[1]);
				// Tang trong_so_cay_khung
				trong_so_cay_khung += trong_so_nho_nhat;
				// Tang so_lan_lap
				so_lan_lap++;

				// Log ra canh va trong so vua tim duoc
				Console.WriteLine($"   {canh_nho_nhat[0]}-{canh_nho_nhat[1]}: {trong_so_nho_nhat}");
			}
			// Log tong trong so cau khung
			Console.WriteLine($" + Trong so cua cay khung: {trong_so_cay_khung}");
		}

		// Giai thuat Kruskal tim cay khung nho nhat
		public static void Kruskal(int[,] a)
		{
			//Khoi tao cac canh cua do thi
			List<int[]> cac_canh = new List<int[]>();
            // Duyet qua tat ca cac dinh de them vao cac_dinh_chua_xet
            // Chi xet 1/2 ma tran doi voi do thi vo huong:
            // Vi du: {
            //	{1,1,0}
            //	{x,0,1}
            //	{x,x,0}
            // }
            // Trong vi du tren, dau x la nhung phan tu khong xet, tranh bi lap lai do do thi vo huong co tinh doi xung
            for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j <= i; j++)
				{
					// Neu ton tai canh, thi them vao cac_canh
					if (a[i, j] != 0)
					{
						cac_canh.Add(new int[] { i, j });
					}
				}
			}

            // Sap xep cac canh theo trong so tang dan (Bubble sort)
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

			// Tao mang int dung de danh dau cac dinh cung thanh phan lien thong
			int[] mask = new int[a.GetLength(0)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				mask[i] = i;
			}

			Console.WriteLine("- Giai thuat Kruskal");
			Console.WriteLine(" + Tap canh cua cay khung");

			int trong_so_cay_khung = 0;
			int so_lan_lap = 0;

			// Duyet qua tat ca cac_canh
			for (int i = 0; i < cac_canh.Count; i++)
			{
				bool co_tao_chu_trinh = false;
				// Retrieve diem_dau, diem_cuoi, trong_so cua canh dang xet
				int diem_dau = cac_canh[i][0];
				int diem_cuoi = cac_canh[i][1];
				int trong_so = a[diem_dau, diem_cuoi];

				// Neu da lap qua het tat ca cac dinh -> stop
				if (so_lan_lap == a.GetLength(0) - 1)
				{
					break;
				}

				// Neu diem_dau va diem_cuoi nam chung 1 thanh phan lien thong
				// Nghia la neu noi 2 diem nay voi nhau se tao thanh 1 chu trinh
				if (mask[diem_dau] == mask[diem_cuoi])
				{
                    co_tao_chu_trinh = true;
				}

				// Neu khong tao chi trinh
				if (!co_tao_chu_trinh)
				{
					// Tang trong so cay khung
					trong_so_cay_khung += trong_so;

                    // Log ra canh va trong so vua tim duoc
                    Console.WriteLine($"   {diem_dau}-{diem_cuoi}: {trong_so}");

					// Duyet qua tat ca cac phan tu cua mask
					// Update gia tri cua mask, ve mask nho nhat
					// Vi du:
					// mask: {1, 3, 4, 5, 5} co canh dang xet la {1,5}
					// Updated mask: {1, 3, 4, 1, 1}
					for (int k = 0; k < mask.Length; k++)
					{
						// Neu mask tai dinh k dang chung voi mask diem_dau va diem_cuoi nho hon diem_dau
						// Thi updated mask tai dinh k voi gia tri cua mask tai diem_cuoi (update theo mask nho hon)
						if (mask[k] == mask[diem_dau] && diem_cuoi < diem_dau)
						{
							mask[k] = mask[diem_cuoi];
						}
						// Neu mask tai dinh k dang chung voi mask diem_cuoi va diem_cuoi lon hon diem_dau
						// Thi updated mask tai dinh k voi gia tri cua mask tai diem_dau (update theo mask nho hon)
						else if (mask[k] == mask[diem_cuoi] && diem_cuoi > diem_dau)
						{
							mask[k] = mask[diem_dau];
						}
					}

					so_lan_lap++;
				}
			}
			
			// Log trong so cay khung
			Console.WriteLine($" + Trong so cua cay khung: {trong_so_cay_khung}");
		}
	}
}
