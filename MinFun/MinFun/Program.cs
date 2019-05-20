using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// Горюнов Евгений
/// Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
///а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке 
///	  находить минимум.Использовать массив(или список) делегатов, в котором хранятся различные функции.
///
/// б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум
///	  через параметр(с использованием модификатора out). 
/// </summary>

namespace MinFun
{

	public delegate double MyDel (double x);

	class Program
	{
		static void Main(string[] args)
		{
			int count = 0;
			int min = 0;
			int max = 0;
			//коллекция делегатов
			List<MyDel> listOfFun = new List<MyDel>();
			listOfFun.Add(F1);
			listOfFun.Add(F2);
			listOfFun.Add(F3);

			//выбираем функцию и отрезок где искать минимум, парсим.
			Console.WriteLine("Введите отрезок функции");
			min = Int32.Parse(Console.ReadLine());
			max = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Введите 1 что бы получить минимум функции: x * x - 50 * x + 10 \n" +
							  "Введите 2 что бы получить минимум функции: x * x \n" +
							  "Введите 3 что бы получить минимум функции: Sin(x)");
			count = Int32.Parse(Console.ReadLine());

			//логика выбора функции
			if (count == 1)
			{
				SaveFunc(listOfFun[0], "data.bin", min, max, 0.5);
			}
			if (count == 2)
			{
				SaveFunc(listOfFun[1], "data.bin", min, max, 0.5);
			}
			if (count == 3)
			{
				SaveFunc(listOfFun[2], "data.bin", min, max, 0.5);
			}

		}

		//функции
		public static double F1(double x)
		{
				return x * x - 50 * x + 10;
		}

		public static double F2(double x)
		{
			return x * x;
		}

		public static double F3(double x)
		{
			return Math.Sin(x);
		}

		//запись данных работы функции в файл
		public static void SaveFunc(MyDel F, string fileName, double a, double b, double h)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(fs);
			double x = a;
			while (x <= b)
			{
				bw.Write(F(x));
				x += h;  //x=x+h;
			}
			bw.Close();
			fs.Close();

			Console.WriteLine(Load("data.bin"));
			Console.ReadKey();
		}

		//чтение данных работы функции из файла и нахождение минимум функции
		//public static double Load(string fileName)
		//{

		//	FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
		//	BinaryReader bw = new BinaryReader(fs);
		//	double min = double.MaxValue;
		//	double d;
		//	//нахождение минимума
		//	for (int i = 0; i < fs.Length / sizeof(double); i++)
		//	{
		//		//Считываем значение и переходим к следующему
		//		d = bw.ReadDouble();
		//		if (d < min) min = d;
		//	}
		//	bw.Close();
		//	fs.Close();
		//	return min;
		//}

		public static double Load(string fileName)
		{
			List<double> minimumList = new List<double>();
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryReader bw = new BinaryReader(fs);
			double min = double.MaxValue;
			double d;
			//нахождение минимума
			for (int i = 0; i < fs.Length / sizeof(double); i++)
			{
				minimumList.Add(bw.ReadDouble());
				//Считываем значение и переходим к следующему
				d = bw.ReadDouble();
				if (d < min) min = d;
			}
			foreach (var e in minimumList)
			{
				Console.WriteLine(e);
			}
			bw.Close();
			fs.Close();
			return min;
		}
	}
}
