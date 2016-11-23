using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÄlyTaloWpf
{
   internal class Thermostat
    {
        public bool asetus { get; set; }




        public void Start()
        {
            asetus = true;
        }




        public void Stop()
        {
            asetus = false;
        }
    }
}
