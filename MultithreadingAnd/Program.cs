using System;
using System.Threading;


namespace MultithreadingAnd
{
    public enum Choice {Continue, Cancel, ContinueEver};

	class Program
	{
		private static int resultF, resultG;

		private static void f(object x)
        {
            resultF = (int)Math.Pow((int)x, 2);
		}

		private static void g(object x)
		{
			resultG = (int) Math.Pow((int)x, 3);
		}

		static void Main(string[] args)
		{
			Console.Write("int x = ");
			int x = Convert.ToInt32(Char.ConvertFromUtf32(Console.Read()));
			Thread fThread = new Thread(f);
			Thread gThread = new Thread(g);
			fThread.Start(x);
			gThread.Start(x);
            while (fThread.ThreadState == ThreadState.Running || gThread.ThreadState == ThreadState.Running)
            {
	            if (fThread.ThreadState != ThreadState.Running && !Convert.ToBoolean(resultF))
	            {
					gThread.Abort();
					Console.WriteLine("f(x) && g(x) == false");
	            }
				else if (gThread.ThreadState != ThreadState.Running && !Convert.ToBoolean(resultG))
				{
					fThread.Abort();
					Console.WriteLine("f(x) && g(x) == false");
				}

	            Thread.Sleep(2000);
                DialogForm form = new DialogForm();
                form.ShowDialog();
                if (form.choice == Choice.ContinueEver)
                {
                    fThread.Join();
                    gThread.Join(); 
                }
                else if (form.choice == Choice.Cancel)
                {
                    fThread.Abort();
                    gThread.Abort();
                }
            }
            if (fThread.ThreadState == ThreadState.Stopped && gThread.ThreadState == ThreadState.Stopped)
            {
                Console.WriteLine("f(x) && g(x) == " + (Convert.ToBoolean(resultF) && Convert.ToBoolean(resultG)));
            }
            else
            {
                Console.WriteLine("Calculations were not finished");
            }
            Console.ReadKey();
		}
	}
}
