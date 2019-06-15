using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class Decide
    {
        public string Type_Maschinen { get; set; }
        public HerstellerType Hersteller { get; set; }
    }

    public static class HerstellerExtension
    {
        /// <summary>
        /// /Entscheidung der Herrsteller;
        /// </summary>
        public static List<Decide> CreatDecideList(this Player player)
        {
            List<Decide> Typelist = new List<Decide>();
            if (player.AtRomm.KabelType == KabelType.MI)
            {
                Typelist.Add(new Decide() { Type_Maschinen = "Grobdrahtzugmaschine", Hersteller = HerstellerType.Voltmaster }); //1+2
                Typelist.Add(new Decide() { Type_Maschinen = "Korbverseilmaschine", Hersteller = HerstellerType.Voltmaster });
                Typelist.Add(new Decide() { Type_Maschinen = "Temperkammer", Hersteller = HerstellerType.Voltmaster });
                Typelist.Add(new Decide() { Type_Maschinen = "Isolierungsanlage", Hersteller = HerstellerType.Voltmaster });    //MI
                Typelist.Add(new Decide() { Type_Maschinen = "Vakuumkessel", Hersteller = HerstellerType.Voltmaster });         //MI
                Typelist.Add(new Decide() { Type_Maschinen = "Schirmmaschine", Hersteller = HerstellerType.Voltmaster });
                Typelist.Add(new Decide() { Type_Maschinen = "Mantelmaschine", Hersteller = HerstellerType.Voltmaster });
            }
            else if (player.AtRomm.KabelType == KabelType.VPE)
            {
                Typelist.Add(new Decide() { Type_Maschinen = "Grobdrahtzugmaschine", Hersteller = HerstellerType.Voltmaster }); //1+2
                Typelist.Add(new Decide() { Type_Maschinen = "Korbverseilmaschine", Hersteller = HerstellerType.Voltmaster });
                Typelist.Add(new Decide() { Type_Maschinen = "Vernetzungsanlage", Hersteller = HerstellerType.Voltmaster });    //1+2 //VPE
                Typelist.Add(new Decide() { Type_Maschinen = "Temperkammer", Hersteller = HerstellerType.Voltmaster });                 //VPE
                Typelist.Add(new Decide() { Type_Maschinen = "Schirmmaschine", Hersteller = HerstellerType.Voltmaster });
                Typelist.Add(new Decide() { Type_Maschinen = "Mantelmaschine", Hersteller = HerstellerType.Voltmaster });
            }

            return Typelist;
        }

        public static void  SetHerstellerType(this Player player, MaschinenType m_type, HerstellerType h_type)
        {
            //Check
            if (player.AtRomm.KabelType == KabelType.MI)
            {
                if (m_type == MaschinenType.Vernetzungsanlage1
                    || m_type == MaschinenType.Vernetzungsanlage2
                    || m_type == MaschinenType.Temperkammer) return;
            }
            else if (player.AtRomm.KabelType == KabelType.VPE)
            {
                if (m_type == MaschinenType.Isolierungsanlage
                    || m_type == MaschinenType.Vakuumkessel) return;

            }
            //Get Name
            string typestring = m_type.ToString();
            if (m_type == MaschinenType.Grobdrahtzugmaschine1 || m_type == MaschinenType.Grobdrahtzugmaschine2)
            {
                typestring = "Grobdrahtzugmaschine";
            }
            if (m_type == MaschinenType.Vernetzungsanlage1 || m_type == MaschinenType.Vernetzungsanlage2)
            {
                typestring = "Vernetzungsanlage";
            }
            //Do
            if (player.HerstellerDecideList.Any(m => m.Type_Maschinen == typestring))
            {
                player.HerstellerDecideList.First(m => m.Type_Maschinen == typestring).Hersteller = h_type;
            }
        }

        public static void UpdateDecideListToMaschinenList(this Player player)
        {
            foreach (Decide decide in player.HerstellerDecideList)
            {
                foreach (Maschine maschine in player.MaschinenList.Where(m=>m.Type.ToString().Contains(decide.Type_Maschinen)).ToList())
                {
                    maschine.Hersteller = decide.Hersteller;
                }
            }
        }

        public static void UpdateHerstellerofEachMaschinen(this Player player)
        {
            var katalog = player.MyHerstellerKatalog;
            foreach (Maschine maschine in player.MaschinenList)
            {
                maschine.LieferungGrad = katalog.GetLieferungGrad(maschine.Type, maschine.Hersteller);
                int h_preis = katalog.GetHerstellerPreis(maschine.Type, maschine.Hersteller);
                if (h_preis == 0) continue;
                maschine.HerstellerPreis = h_preis;
            }
        }

        public static LieferungErgebnis GetLieferungErgebnis(LieferungGrad grad, int number)
        {
            if (grad == LieferungGrad.Gut)
            {
                if (number == 1)
                {
                    return LieferungErgebnis.GutLate;
                }else
                    return LieferungErgebnis.Allright;
            }
            else if (grad == LieferungGrad.Mittel)
            {
                if (number == 1 || number == 2)
                {
                    return LieferungErgebnis.MittelLate;
                }
                else if (number == 3)
                {
                    return LieferungErgebnis.MittelRepair;
                }
                return LieferungErgebnis.Allright;
            }
            else if (grad == LieferungGrad.Schlecht)
            {
                if (number == 1 || number == 2)
                {
                    return LieferungErgebnis.SchlechtLate;
                }
                else if (number == 3 || number == 4)
                {
                    return LieferungErgebnis.SchlechtRepair;
                }
                return LieferungErgebnis.Allright;
            }  
                return LieferungErgebnis.Allright;
        }

        public static int RollNumber1To6()
        {
            Random ran = new Random();
            int number = (ran.Next(1, 100) % 6) + 1;
            return number;
        }
    }
}
