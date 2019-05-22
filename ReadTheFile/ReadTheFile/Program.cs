using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Горюнов Евгений
/// **Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
/// Создайте методы, которые возвращают массив byte (FileStream), 
/// </summary>
namespace ReadTheFile
{
	class Program
	{
		static void Main(string[] args)
		{
			long kbyte = 1024;
			long mbyte = 1024 * kbyte;
			long gbyte = 1024 * mbyte;
			long size = mbyte;
			//Write FileStream

			List<byte> myByte = FileStreamSample("D:\\temp\\bigdata0.bin", size);
			foreach (var e in myByte)
			{
				Console.WriteLine(e);
			}

			Console.ReadKey();
		}

		static List<byte> FileStreamSample(string filename, long size)
		{
			List<byte> streamByte = new List<byte>();

			FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
			//FileStream fs = new FileStream("D:\\temp\\bigdata.bin", FileMode.CreateNew, FileAccess.Write);
			for (int i = 0; i < size; i++)
			fs.WriteByte(0);
			streamByte.Add((byte)fs.ReadByte());
			fs.Close();
			return streamByte;
		}

		

	}
}
