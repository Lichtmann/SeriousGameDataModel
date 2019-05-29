using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.EnumAndAttribute
{
    public enum Material
    {
        KupferCoil,
        Leiterdraht,
        Schirmdraht,
        Leiter,
        Ader,               //VPE        
        IsolierterLeiter,   //MI
        GetemperteAder,     //VPE
        GetrockneteAder,    //MI
        GeschirmteAder,
        Kabel
    }

    public enum KabelType
    {
        unknow = 0,
        MI = 1,
        VPE = 2,
    }
}
