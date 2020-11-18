using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesVol1_Ejer5Timer
{
    public delegate void Deleg();

    class MyTimer
    {
        static readonly object key = new object();
        public static Deleg del; //Deleg leaderDeleg = new Deleg(increment);
        public int interval;
        static Thread secondThread;
        public bool runPause = false;

        public MyTimer(Deleg leaderDeleg)
        {
            Deleg del = leaderDeleg;
            Thread secondThread = new Thread(start);//inicio start
            secondThread.Start();
        }

        public void run()
        {

            lock (key)
            {
                if (runPause)
                {
                    Monitor.Wait(key);
                }
                else
                {
                    Console.WriteLine("empiezo");
                    del();
                }
            }


        }

        public void pause()
        {
            runPause = true;
        }

        public void start()//para controlar el fregado
        {
            if (runPause)
            {
                Console.WriteLine("entro aqui");
                Monitor.Pulse(key);
                runPause = false;
            }
            
        }
    }

}
