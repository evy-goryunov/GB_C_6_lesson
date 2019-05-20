using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Горюнов Евгений
/// Изменить программу вывода таблицы функции так, 
/// чтобы можно было передавать функции типа double (double, double). 
/// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
/// </summary>

namespace FunTable
{
	// добавил второй параметр в сигнатуру делегата
	public delegate double Fun(double x, double a);

	class Program
	{
		//добавил третий параметр в сигнатуру и поменял F(x) на F(x,a)
		public static void Table(Fun F, double x, double b, double a)
		{
			Console.WriteLine("----- X ----- Y -----");
			while (x <= b)
			{
				Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |" ,x, F(x,a));
				x += 1;
			}
			Console.WriteLine("---------------------");
		}

		// функция a*x^2
		public static double fun1(double x, double a)
		{
			return a * (x * x);
		}

		// функция a*sin(x)
		public static double fun2(double x, double a)
		{
			return a * Math.Sin(x);
		}

		static void Main()
		{
			// проверка первой функции
			Table(fun1, -5, 5, 2);
			Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
			// проверка второй функции
			Table(fun2, -5, 5, 2);

		}
	}
}
