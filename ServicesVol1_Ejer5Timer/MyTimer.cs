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
        Deleg leaderDeleg; //Deleg leaderDeleg = new Deleg(increment);
        public int interval;
        public bool runRun = true;
        public bool pauseCont = true;

        public MyTimer(Deleg leaderDeleg)
        {
            this.leaderDeleg = leaderDeleg;
            Thread secondThread = new Thread(start);//inicio start
            secondThread.IsBackground = true;
            secondThread.Start();

        }
        public void run()
        {

            lock (key)
            {
                Monitor.Pulse(key);
                pauseCont = false;
            }

        }

        public void pause()
        {
            lock (key)
            {
                pauseCont = true;
            }
        }

        public void start()
        {
            while (runRun)
            {
                lock (key)
                {
                    if (pauseCont)
                    {
                        Monitor.Wait(key);
                    }
                    leaderDeleg();
                    Thread.Sleep(interval);

                    //El if else puede dar fallos, si comprobamos primero la condición y lo metemos a pause ya no sigue lo demás
                    //y si no cumple pues hace lo de fuera del if

                    //if (!pauseCont)
                    //{
                    //    leaderDeleg();
                    //    Thread.Sleep(interval);
                    //}else
                    //{

                    //        Monitor.Wait(key);

                    //}
                }
            }

        }

    }

}
