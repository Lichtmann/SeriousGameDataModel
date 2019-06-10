using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model //.EnumAndAttribute
{

    public enum BudgetType
    {
        StartBudget = 1,
        InforBudget =2,
        EventBudget =3, 

    }

    public enum KostenType
    {
        //Buy
        BuyInforCard = 1,
        BuyLayoutUnit = 2,
        BuyMaschinen = 3,
        //Strafen
        TimeoutFee = 4,
        //Einkauf Summe
        AllLayoutFee = 5,
        AllMaschinemFee =6,
        //Event
        OnetimeCost = 7,

    }
}
