using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingAnd
{
	class Program
	{
		private static int x = 10, resultF, resultG;

		public static void f()
		{
			resultF = (int) Math.Pow(x, 2);
		}

		public static void g()
		{
			resultG = (int) Math.Pow(x, 3);
		}

		static void Main(string[] args)
		{
			Console.Write("int x = ");
			x = Console.Read();
			Thread fThread = new Thread(f);
			Thread gThread = new Thread(g);
			fThread.Start();
			gThread.Start();
			Console.WriteLine(Convert.ToBoolean(resultF) && Convert.ToBoolean(resultG));
			Console.Read();
		}
	}
}
