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
        public Deleg leaderDeleg; //Deleg leaderDeleg = new Deleg(increment);
        public int interval;
        public MyTimer(Deleg leaderDeleg)
        {
            this.leaderDeleg = leaderDeleg;
            Thread secondThread = new Thread(run);
            secondThread.Start();
        }

        public void run()
        {
            bool pause = false;
            while (!pause)
            {
            leaderDeleg(); // llamamos a increment función
            }
        }

        public void pause()
        {

        }
    }

}
