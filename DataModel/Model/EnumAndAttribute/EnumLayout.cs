using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.EnumAndAttribute
{
    public enum LayoutUnitType
    {
        [DefaultPreisValue(3500000)]
        NewLayout = 0,
        [DefaultPreisValue(2000000)]
        OldLayout = 1
    }
    public static partial class EnumExtensions
    {
        //Layout Preis
        public static int DefaultPreis(this LayoutUnitType layoutType)
        {
            FieldInfo fieldInfo = layoutType.GetType().GetField(layoutType.ToString());
            DefaultPreisValueAttribute[] attrs =
                fieldInfo.GetCustomAttributes(typeof(DefaultPreisValueAttribute), false) as DefaultPreisValueAttribute[];

            return attrs.Length > 0 ? attrs[0].DefaultPreisValue : 0;
        }
    }

    //Layout
    public class DefaultPreisValueAttribute : Attribute
    {
        public DefaultPreisValueAttribute(int value)
        {
            this.DefaultPreisValue = value;
        }

        public int DefaultPreisValue
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            set;
        }
    }
}
