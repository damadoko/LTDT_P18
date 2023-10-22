using Project_P18;
namespace Project_P18
{
	class Program
	{
		static void Main(string[] args)
		{
			//Yeu Cau 1
			/*
			int[,] a = YeuCau1.KhoiTaoDT(@"D://LTDT/DSKe.txt");
			YeuCau1.DocDT(a);
			YeuCau1.KiemTraDT(a);
			Console.WriteLine("so dinh cua do thi:" + a.GetLength(0));
			int count = 0;
			count = YeuCau1.DemCanh(a);
			Console.WriteLine("so canh cua do thi:" + count);
			count = YeuCau1.DemCanhBoi(a);
			Console.WriteLine("so cap dinh xuat hien canh boi:" + count);
			count = YeuCau1.DemCanhKhuyen(a);
			Console.WriteLine("So canh khuyen:" + count);
			count = YeuCau1.DemDinhTreo(a);
			Console.WriteLine("So dinh treo:" + count);
			count = YeuCau1.DemDinhCoLap(a);
			Console.WriteLine("So dinh co lap:" + count);
			YeuCau1.BacDinh(a);
			*/

			//YeuCau 2
			
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
			};

			// A
			YeuCau2.InDPS(mock_co_huong);
			Console.WriteLine();
			//YeuCau2.InDPS(mock_vo_huong);

			// B
			YeuCau2.InBFS(mock_co_huong);
			//YeuCau2.InBFS(mock_vo_huong);

			// C
			YeuCau2.InLienThong(mock_vo_huong_2_lien_thong_test);

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

			YeuCau3.Prim(moc_vo_huong_co_trong_so_2, 0);
			YeuCau3.Kruskal(moc_vo_huong_co_trong_so_2);
			
			Console.ReadLine();
			

			//Yeu cau 4
			int[,] kq = YeuCau4.ReadMatrix("D:/LTDT/BT03_bellman.txt");
			YeuCau4.PrintMatrix(kq);
			Console.WriteLine("Input Source: ");

			int source = int.Parse(Console.ReadLine());
			
			//Câu a:Dijkstra
			if (YeuCau4.TrongSoDuong(kq))
			{
				Console.WriteLine("Ma tran co trong so duong");
				YeuCau4.Dijkstra(kq, source);
			}
			else
			{
				Console.WriteLine("Ma tran co trong so am");
			}
			//Cau b : Bellman
			YeuCau4.Bellman(kq, source);

			//Cau 5
			YeuCau5.Euler(mock_vo_huong_co_duong_di_euler);
		}
	}
}