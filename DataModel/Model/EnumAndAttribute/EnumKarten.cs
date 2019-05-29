using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model //.EnumAndAttribute
{
    public enum KartenKategorie
    {
        unknow = 0,
        ZielKarte = 1,
        InformationKarte = 2,
        EreignisKarte = 3,
    }
    public enum KartenTypeAbkurz
    {
        unknow = 0,
        Zi = 1,
        In = 2,
        Ec = 3,
        Er = 4,
    }
}
