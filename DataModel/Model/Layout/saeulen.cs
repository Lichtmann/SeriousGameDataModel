using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class saeulen
    {
        int preis = 650000 ;


        public void SetPreisAufhalb()
        {
            Preis = 650000 / 2;
        }
        /// <summary>
        /// Kost von Entfernen von Säulen 
        /// </summary>
        public int Preis { get => preis; set => preis = value; }
    }
}
