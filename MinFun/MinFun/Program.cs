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

	public delegate double MyDel (double x, double a);

	class Program
	{
		static void Main(string[] args)
		{
			List<MyDel> listOfFun = new List<MyDel>();
			listOfFun.Add(F1);
			listOfFun.Add(F2);


			SaveFunc("data.bin", -100, 100, 0.5);
			Console.WriteLine(Load("data.bin"));
			Console.ReadKey();
		}

		// функции
		public static double F1(double x)
		{
				return x * x - 50 * x + 10;
		}

		public static double F2(double x, double a)
		{
			return a * (x * x);
		}

		public static double F3(double x, double a)
		{
			return a * Math.Sin(x);
		}

		// запись данных работы функции в файл
		public static void SaveFunc(string fileName, double a, double b, double h)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(fs);
			double x = a;
			while (x <= b)
			{
				bw.Write(F1(x));
				x += h;  // x=x+h;
			}
			bw.Close();
			fs.Close();
		}

		// чтение данных работы функции из файла и нахождение минимум функции
		public static double Load(string fileName)
		{

			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryReader bw = new BinaryReader(fs);
			double min = double.MaxValue;
			double d;
			// нахождение минимума
			for (int i = 0; i < fs.Length / sizeof(double); i++)
			{
				// Считываем значение и переходим к следующему
				d = bw.ReadDouble();
				if (d < min) min = d;
			}
			bw.Close();
			fs.Close();
			return min;
		}
				
		

				
			
	}
}
