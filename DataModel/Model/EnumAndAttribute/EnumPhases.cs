using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public enum Phases
    {
        [PhaseValue(0)]
        unkonw = 0,
        /// <summary>
        /// Set Kabel Type
        /// </summary>
        [PhaseValue(1)]
        Phase1_1 = 11,
        /// <summary>
        /// new ZielKarte ()
        /// </summary>
        [PhaseValue(1)]
        Phase1_2 = 12,
        /// <summary>
        /// Update ZielKarte to AllPlayer
        /// </summary>
        [PhaseValue(1)]
        Phase1_3 = 13,
        /// <summary>
        /// Zeigen InformationBlatt()
        /// </summary>
        [PhaseValue(2)]
        Phase2_1 = 21,
        /// <summary>
        /// Zeigen () Dimensionierung der Betriebsmittel
        /// </summary>
        [PhaseValue(2)]
        Phase2_2 = 22,
        /// <summary>
        /// New InformationKarten(), Update Data() To Self 
        /// </summary>
        [PhaseValue(2)]
        Phase2_3 = 23,

        /// <summary>
        /// Player berechne Bedarf der Maschinen nach ProduktionMenge
        /// </summary>
        [PhaseValue(3)]
        Phase3_1 = 31,
        /// <summary>
        /// Einkauflist der Maschinen (), und Summe() => BedarfRaum() => Anzahl der LayoutKarte() 
        /// </summary>
        [PhaseValue(3)]
        Phase3_2 = 32,
        /// <summary>
        /// Einkauf der Layoutkarten(Alte und Neue)
        /// </summary>
        [PhaseValue(3)]
        Phase3_3 = 33,
        /// <summary>
        /// Configurieren der Maschienen() => Materialfluss, Raum--, 
        /// </summary>
        [PhaseValue(3)]
        Phase3_4 = 34,
        /// <summary>
        /// Nachkaufen der Layoutkarten und Maschinen.
        /// </summary>
        [PhaseValue(3)]
        Phase3_5 = 35,
        /// <summary>
        /// Broadcast InformationKarte(EffectivePhase == 3), update Table()
        /// </summary>
        [PhaseValue(3)]
        Phase3_6 = 36,
        /// <summary>
        /// 2 EventKarten(pahse == 3)
        /// </summary>
        [PhaseValue(3)]
        Phase3_7 = 37,

        /// <summary>
        /// Broadcast InformationKarte(EffectivePhase == 4); update Table()
        /// </summary>
        [PhaseValue(4)]
        Phase4_1 = 41,
        /// <summary>
        /// 2 EventKarten(pahse == 4)
        /// </summary>
        [PhaseValue(4)]
        Phase4_2 = 42,
        /// <summary>
        /// Hersteller Bestimmung () => Herstellerpreis
        /// </summary>
        [PhaseValue(5)]
        Phase5_1 = 51,
        /// <summary>
        /// Broadcast InformationKarte(EffectivePhase == 5); update Table() => HerstellerPreis, LieferungGrad...
        /// </summary>
        [PhaseValue(5)]
        Phase5_2 = 52,
        /// <summary>
        /// 2 EventKarten(pahse == 5)
        /// </summary>
        [PhaseValue(5)]
        Phase5_3 = 53,
        /// <summary>
        /// Wuerfel!  => Aufpreis 
        /// </summary>
        [PhaseValue(6)]
        Phase6_1 = 61,
        /// <summary>
        /// 2 EventKarten(pahse == 6)
        /// </summary>
        [PhaseValue(6)]
        Phase6_2 = 62,
        /// <summary>
        /// Broadcast InformationKarte(EffectivePhase == 7) & 
        /// EventKarten(pahse == 7)
        /// </summary>
        [PhaseValue(7)]
        Phase7_1 = 71,
        /// <summary>
        /// Evaluation, Winner
        /// </summary>
        [PhaseValue(7)]
        Phase7_2 = 72,
    }

    public static partial class EnumExtensions
    {
        //phse
        public static int GetPhaseValue(this Phases enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            PhaseValueAttribute[] attrs =
                fieldInfo.GetCustomAttributes(typeof(PhaseValueAttribute), false) as PhaseValueAttribute[];

            return attrs.Length > 0 ? attrs[0].PhaseValue : 0;
        }
    }

    public class PhaseValueAttribute : Attribute
    {
        public PhaseValueAttribute(int value)
        {
            this.PhaseValue = value;
        }

        public int PhaseValue
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            set;
        }
    }
}
