using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.EnumAndAttribute
{
    public enum LieferungGrad
    {
        Mittel = 0,
        Schlecht = 1,
        Gut = 2
    }

    public enum LieferungErgebnis
    {        
        [RateValue(0.0)]
        Allright = 0,
        [RateValue(0.05)]
        GutLate = 5,
        [RateValue(0.10)]
        MittelLate = 10,
        [RateValue(0.20)]
        SchlechtLate = 20,
        [RateValue(0.25)]
        MittelRepair = 25,
        [RateValue(0.50)]
        SchlechtRepair = 50,
    }

    public static partial class EnumExtensions
    {
        //Lieferung
        public static double AufpreisRate(this LieferungErgebnis enumValue) => (int)enumValue / 100.0;
        public static double GetRateValue(this LieferungErgebnis enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            RateValueAttribute[] attrs =
                fieldInfo.GetCustomAttributes(typeof(RateValueAttribute), false) as RateValueAttribute[];

            return attrs.Length > 0 ? attrs[0].RateValue : 0.0;
        }
    }

    public class RateValueAttribute : Attribute
    {
        public RateValueAttribute(double value)
        {
            this.RateValue = value;
        }

        public double RateValue
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            set;
        }
    }

}
