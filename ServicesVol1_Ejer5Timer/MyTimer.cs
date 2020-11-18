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
        public bool runRun = false;
        public bool notEnding = false;

        public MyTimer(Deleg leaderDeleg)
        {
            this.leaderDeleg = leaderDeleg;
            Thread secondThread = new Thread(start);//inicio start
            secondThread.IsBackground = true;
            secondThread.Start();
        }
        public void run()
        {

            while (runRun)
            {
                leaderDeleg();
                Thread.Sleep(interval);
            }
        }

        public void pause()
        {
            runRun = false;
        }

        public void start()
        {
            while (!notEnding)
            {
                if (runRun)
                {
                    lock (key)
                    {
                        run();
                    }
                }
            }


        }

    }

}
