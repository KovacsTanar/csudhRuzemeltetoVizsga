using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    class Szerver
    {
        string domain,ip;
        

        public Szerver(string sor)
        {
            string[] feldaraboltSor = sor.Split(';');
            domain = feldaraboltSor[0];
            ip = feldaraboltSor[1];
        }

        public string Domain { get => domain; set => domain = value; }
        public string Ip { get => ip; set => ip = value; }
    }
}
