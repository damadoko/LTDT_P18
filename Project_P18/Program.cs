using Project_P18;


namespace Project_P18
{
	class Program
	{
		static void Main(string[] args)
		{
            // Yeu cau 1
            Console.WriteLine("CAU 1: ");

            int[,] a = YeuCau1.KhoiTaoDT("test1.txt");// Ma tra ke
            int[,] kq = YeuCau1.XuatMaTran("test1.txt"); // Ma tra co trong so
            YeuCau1.XuatThongTinDoThi(a);

			//data
			//YeuCau 2 
			/*
			int[,] mock_co_huong =
			{
			{0, 0, 1, 0, 0, 0, 0, 0},
			{1, 0, 0, 0, 0, 0, 0, 0},
			{0, 1, 0, 1, 0, 0, 0, 0},
			{0, 0, 0, 0, 1, 1, 1, 0},
			{0, 0, 0, 0, 0, 1, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{1, 0, 0, 0, 0, 0, 1, 0},
			};
			/*
			// Khong euler
			int[,] mock_vo_huong =
			{
			{0, 0, 1, 1, 0, 0, 0, 0},
			{0, 0, 0, 1, 0, 1, 0, 0},
			{1, 0, 0, 0, 0, 0, 1, 0},
			{1, 1, 0, 0, 1, 0, 0, 1},
			{0, 0, 0, 1, 0, 0, 1, 1},
			{0, 1, 0, 0, 0, 0, 0, 1},
			{0, 0, 1, 0, 1, 0, 0, 0},
			{0, 0, 0, 1, 1, 1, 0, 0},
			};

			// Co euler
			int[,] mock_vo_huong_co_chu_trinh_euler =
			{
			{0, 0, 1, 1, 0, 0, 0, 0},
			{0, 0, 0, 1, 0, 1, 0, 0},
			{1, 0, 0, 0, 0, 0, 1, 0},
			{1, 1, 0, 0, 1, 0, 0, 1},
			{0, 0, 0, 1, 0, 0, 1, 0},
			{0, 1, 0, 0, 0, 0, 0, 1},
			{0, 0, 1, 0, 1, 0, 0, 0},
			{0, 0, 0, 1, 0, 1, 0, 0},
			};

			int[,] mock_vo_huong_co_duong_di_euler =
			{
			{0, 0, 0, 1, 0, 0, 0, 0},
			{0, 0, 0, 1, 0, 1, 0, 0},
			{0, 0, 0, 0, 1, 0, 0, 0},
			{1, 1, 0, 0, 1, 0, 0, 1},
			{0, 0, 1, 1, 0, 0, 1, 1},
			{0, 1, 0, 0, 0, 0, 0, 1},
			{0, 0, 0, 0, 1, 0, 0, 1},
			{0, 0, 0, 1, 1, 1, 1, 0},
			};

			int[,] mock_vo_huong_2_lien_thong =
			{
			{0, 0, 1, 0, 0, 1, 1, 0},
			{0, 0, 0, 0, 0, 1, 0, 0},
			{1, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 1},
			{0, 0, 0, 0, 0, 1, 0, 0},
			{1, 1, 0, 0, 1, 0, 0, 0},
			{1, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 1, 0, 0, 0, 0},
			};

			int[,] mock_vo_huong_2_lien_thong_test =
			{
			{0, 0, 1, 0, 0, 1, 1, 0},
			{0, 0, 0, 0, 0, 1, 0, 0},
			{1, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 1, 0, 0},
			{1, 1, 0, 0, 1, 0, 0, 0},
			{1, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0},
			};*/

			Console.WriteLine("----------------------------------------------------------------------------");
			Console.WriteLine("CAU 2: DUYET DO THI ");
			Console.Write("* Nhap dinh bat dau: ");

			int source = int.Parse(Console.ReadLine());
			bool isSourceValid = YeuCau2.KiemTraDinh(source, a);
			if (!isSourceValid) return;

			// Yeu cau 2: Chi chay khi source valid (dinh bat dau co ton tai)
			// 2.a
			YeuCau2.InDFS(a,source);
			Console.WriteLine();

			// 2.b
			YeuCau2.InBFS(a,source);
			Console.WriteLine();

			// 2.c
			if (YeuCau1.KiemTraDTVH(a))
			{
				YeuCau2.InLienThong(a);
			}
            /*
			int[,] moc_vo_huong_co_trong_so_1 =
			{
			{0, 3, 0, 0, 4, 7},
			{3, 0, 5, 0, 0, 8},
			{0, 5, 0, 4, 0, 6},
			{0, 0, 4, 0, 2, 8},
			{4, 0, 0, 2, 0, 5},
			{7, 8, 6, 8, 5, 0},
			};

			int[,] moc_vo_huong_co_trong_so_2 =
			{
			{0, 5, 3, 0, 0, 0, 0},
			{5, 0, 4, 6, 2, 0, 0},
			{3, 4, 0, 5, 0, 6, 0},
			{0, 6, 5, 0, 6, 0, 0},
			{0, 2, 0, 6, 0, 3, 5},
			{0, 0, 6, 0, 3, 0, 4},
			{0, 0, 0, 0, 5, 4, 0},
			};
			*/

			Console.WriteLine("-----------------------------------------------------------------------");
			Console.WriteLine("CÂU 3: TIM CAY KHUNG NHO NHAT: ");

            // Yeu cau 3: Chi chay khi source valid (dinh bat dau co ton tai) va do thi phai la do thi vo huong lien thong
            List<List<int>> Cac_tp_lien_thong = YeuCau2.TimThanhPhanLienThong(a);
			int So_TP_LienThong = Cac_tp_lien_thong.Count;

			bool KiemTra_VH_LienThong = false;

			if (YeuCau1.KiemTraDTVH(a) && So_TP_LienThong == 1)
			{
				KiemTra_VH_LienThong = true;
			}
            
			if (KiemTra_VH_LienThong)
			{
				Console.WriteLine("DO THI VO HUONG LIEN THONG");
				YeuCau3.Prim(kq, source);
				YeuCau3.Kruskal(kq);
			}
			else
			{
				Console.WriteLine("KHONG PHAI DO THI VO HUONG LIEN THONG");
			}


			Console.WriteLine("-----------------------------------------------------------------------");
			Console.WriteLine("CÂU 4: TIM DUONG DI NGAN NHAT");

            // Yeu cau 4: Chi chay khi source valid (dinh bat dau co ton tai)
			// 4.a: Dijkstra
			if (YeuCau4.TrongSoDuong(kq))
			{
				Console.WriteLine("Do thi co trong so duong");
				Console.WriteLine(" Giai thuat Dijsktra");
				YeuCau4.Dijkstra(kq, source); 
			}
			// 4.b: Bellman
			else
			{
				Console.WriteLine("Do thi co trong so am");
				Console.WriteLine("Giai thuat Bellman");
				YeuCau4.Bellman(kq, source);
			}

			Console.WriteLine("----------------------------------------------------------------------");
			Console.WriteLine("CAU 5: CHU TRINH EULER");

            // Yeu cau 5: Chi chay khi source valid (dinh bat dau co ton tai) va do thi la don do thi
			if (YeuCau5.KiemTraDonDoThi(kq))
			{
				Console.WriteLine("Do thi la Don Do Thi");
				YeuCau5.Euler(kq, source);
			}
			else
			{
				Console.WriteLine("Khong phai Don Do Thi");
			}
		}
	}
}