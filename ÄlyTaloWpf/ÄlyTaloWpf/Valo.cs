using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ÄlyTaloWpf
{
    internal class Valo
    {
       public bool kytkin { get; set; }
  



        public void Start()
        {
            kytkin = true;
        }

        public void Stop()
        {
            kytkin = false;

        }
           
    }
}