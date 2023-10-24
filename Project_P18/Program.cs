﻿using Project_P18;


namespace Project_P18
{
	class Program
	{
		static void Main(string[] args)
		{
//Cau 1
			Console.WriteLine("CAU 1: ");
			int[,] a = YeuCau1.KhoiTaoDT(@"D:\\LTDT\test.txt");
			int[,] kq = YeuCau1.XuatMaTran(@"D:\\LTDT\test.txt");
			//YeuCau4.PrintMatrix(kq); //In ma tran co trong so; 
			Console.WriteLine("- Xuat ma tran: ");
			YeuCau1.DocDT(a);
			YeuCau1.KiemTraDT(a);
			Console.WriteLine("- So dinh cua do thi: " + a.GetLength(0));
			int count = 0;
			count = YeuCau1.DemCanh(a);
			Console.WriteLine("- So canh cua do thi:" + count);
			count = YeuCau1.DemCanhBoi(a);
			Console.WriteLine("- So cap dinh xuat hien canh boi:" + count);
			count = YeuCau1.DemCanhKhuyen(a);
			Console.WriteLine("- So canh khuyen:" + count);
			count = YeuCau1.DemDinhTreo(a);
			Console.WriteLine("- So dinh treo:" + count);
			count = YeuCau1.DemDinhCoLap(a);
			Console.WriteLine("- So dinh co lap:" + count);
			YeuCau1.BacDinh(a);

//			//data
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

//Cau 2
			Console.WriteLine("----------------------------------------------------------------------------");
			Console.WriteLine("CAU 2: DUYET DO THI ");
			Console.WriteLine("* Nhap dinh bat dau: ");
			int source = int.Parse(Console.ReadLine());
			// A
			YeuCau2.InDPS(a,source);
			Console.WriteLine();
			// B
			YeuCau2.InBFS(a,source);
			Console.WriteLine();

			// C
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
//Cau 3	
			Console.WriteLine("-----------------------------------------------------------------------");
			Console.WriteLine("CÂU 3: TIM CAY KHUNG NHO NHAT: ");
			YeuCau3.Prim(kq, source);
			YeuCau3.Kruskal(kq);

//Cau 4
			Console.WriteLine("-----------------------------------------------------------------------");
			Console.WriteLine("CÂU 4: TIM DUONG DI NGAN NHAT");
			//Câu a:Dijkstra
			if (YeuCau4.TrongSoDuong(kq))
			{
				Console.WriteLine("Do thi co trong so duong");
				Console.WriteLine(" Giai thuat Dijsktra");
				YeuCau4.Dijkstra(kq, source); 
			}
			else
			{
				Console.WriteLine("Do thi co trong so am");
				//Cau b : Bellman
				Console.WriteLine("Giai thuat Bellman");
				YeuCau4.Bellman(kq, source);
			}

//Cau 5
			Console.WriteLine("----------------------------------------------------------------------");
			Console.WriteLine("CAU 5: CHU TRINH EULER");
			if (YeuCau5.KiemTraDonDoThi(kq))
			{
				Console.WriteLine("Do thi la Don Do Thi");
				YeuCau5.Euler(kq);
			}
			else
			{
				Console.WriteLine("Khong phai Don Do Thi");
			}
		}
	}
}