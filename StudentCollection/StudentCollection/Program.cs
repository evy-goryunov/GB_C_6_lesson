using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

/// <summary>
/// Горюнов Евгений
/// Переделать программу Пример использования коллекций для решения следующих задач:
/// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
/// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
/// в) отсортировать список по возрасту студента;
/// г) * отсортировать список по курсу и возрасту студента;

/// </summary>

namespace StudentCollection
{
	class Program
	{
		static void Main(string[] args)
		{
			int bakalavr = 0;
			int magistr = 0;
			int studentOf_5_6_course = 0;

			// Создаём словарь
			Dictionary<int, int> studentOf_18_20_years = new Dictionary<int, int>();
			// Создадим необобщенный список
			ArrayList list = new ArrayList();
			// Запомним время в начале обработки данных
			DateTime dt = DateTime.Now;
			StreamReader sr = new StreamReader("D:\\distr\\geekbrains\\hometasks\\GB_C_6_lesson\\students_1.csv");
			while (!sr.EndOfStream)
			{
				try
				{
					string[] s = sr.ReadLine().Split(';');
					// Console.WriteLine("{0}", s[0], s[1], s[2], s[3], s[4]);
					list.Add(s[1] + " " + s[0]);// Добавляем склееные имя и фамилию
					if (int.Parse(s[6]) < 5)
					{
						bakalavr++;
					}
					else
					{
						magistr++;
						studentOf_5_6_course++;
					}
					// проверяем есть ли студент в заданной возрастной группе
					if (int.Parse(s[5]) < 21 && int.Parse(s[5]) > 17)
					{
						// если есть то ищем таких **Ключ** в словаре и увиличиваем **Значение** - кол-во таковых.
						if (studentOf_18_20_years.TryGetValue(int.Parse(s[5]), out int a))
						{
							studentOf_18_20_years[int.Parse(s[5])] = ++a;
						}
						else
						{
							studentOf_18_20_years.Add(int.Parse(s[5]), 1);
						}
					}




				}
				catch
				{
				}
			}
			sr.Close();
			list.Sort();
			Console.WriteLine("Всего студентов:{0}", list.Count);
			Console.WriteLine("Магистров:{0}", magistr);
			Console.WriteLine("Бакалавров:{0}", bakalavr);
			Console.WriteLine("На 5 и 6 курсах учится: " + studentOf_5_6_course + " человек.");
			foreach (var v in list) Console.WriteLine(v);
			// Вычислим время обработки данных
			Console.WriteLine(DateTime.Now - dt);

			//выведем словарь
			Console.WriteLine("+++++++++++++++++++++++++++++++++++");
			foreach (KeyValuePair<int, int> keyValue in studentOf_18_20_years)
			{
				Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
			}
			Console.ReadKey();
		}

	}
}
