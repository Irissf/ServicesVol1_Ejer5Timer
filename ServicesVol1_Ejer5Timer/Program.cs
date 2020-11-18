using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesVol1_Ejer5Timer
{
    class Program
    {
        static int counter = 0;
        static void increment()
        {
            //Esta función nos incrementará el valor de counter y lo imprimira en pantalla
            counter++;
            Console.WriteLine(counter);
        }
        static void Main(string[] args)
        {
            MyTimer t = new MyTimer(increment);//le pasamos la función a MyTimer
            t.interval = 1000;//Y los milisegundos

            string op = "";

            do
            {
                Console.WriteLine("Press any key to start.");
                Console.ReadKey();
                t.runPause = true;
                Console.WriteLine("Press any key to pause.");
                Console.ReadKey();
                t.pause();
                Console.WriteLine("Press 1 to restart or Enter to end.");
                op = Console.ReadLine();
            } while (op == "1");
        }
    }
}
