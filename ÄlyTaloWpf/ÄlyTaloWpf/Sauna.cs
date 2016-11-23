using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ÄlyTaloWpf
{
    public class Sauna
    {

        public double Aste { get; set; }
        public bool running { get; set; }



        public void Start()
        {
            running = true;
        }


        public void Stop()
        {
            running = false;
            Aste = 24.03;
        }
    }
}