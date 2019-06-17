using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModel.Model.Karten
{
    public static class InforKarteLib
    {
        /// <summary>
        /// 
        /// </summary>
        static int karteMenge = 17;

        //static List<KabelType> bothKabelType = new List<KabelType>();

        /// <summary>
        /// Get a Random ID of ZielKarte
        /// </summary>
        /// <returns></returns>
        public static string GetRandomID()
        {
            return "In-" + GetRandomNumber().ToString().PadLeft(2, '0');
        }

        public static string GetKarteID(int n)
        {
            return "In-" + n.ToString().PadLeft(2, '0');
        }

        public static int GetRandomNumber()
        {
            Random ran = new Random();
            return ran.Next(1, karteMenge);
        }

        /// <summary>
        /// if card is not active, it means, that this card is't fot this GameApp right developed.
        /// </summary>
        /// <returns></returns>
        public static List<InformationKarte> GetAllActiveKarte()
        {
            List<InformationKarte> pool = new List<InformationKarte>();
            for (int i = 1; i <= karteMenge; i++)
            {
                pool.Add(GetKarteID(i).CreatInforKarteWithID());
            }
            return pool.Where(i => i.IsActive).ToList();
        }

        public static List<InformationKarte> GetKartenForVPE()
        {
            List<InformationKarte> pool = GetAllActiveKarte();
            return pool.Where(i => i.TypeSet.Contains(KabelType.VPE)).ToList();
        }

        public static List<InformationKarte> GetKartenForMI()
        {
            List<InformationKarte> pool = GetAllActiveKarte();
            return pool.Where(i => i.TypeSet.Contains(KabelType.MI)).ToList();
        }

        public static List<InformationKarte> GetUnused_CardPool(this List<InformationKarte> pool)
        {
            return pool.Where(i => i.FirstOwner.PlayerName == "who").ToList();
        }

        /// <summary>
        /// Randomly darw card form cardpool 
        /// Count must > 0
        /// </summary>
        /// <param name="pool"></param>
        /// <returns></returns>
        public static InformationKarte DrawCardRandomFromPool(this List<InformationKarte> pool)
        {
            int count = pool.Count;
            Random ran = new Random();
            int index = ran.Next(0, count);
            return pool[index];
        }

        public static InformationKarte DrawCardFormPool(this List<InformationKarte> wholepool)
        {
            return wholepool.GetUnused_CardPool().DrawCardRandomFromPool();
        }
        /// <summary>
        /// Generation InforKarte mit Inhalt und #Event#
        /// </summary>
        /// <param name="In_id"></param>
        /// <returns></returns>
        public static InformationKarte CreatInforKarteWithID(this string In_id)
        {
            var Incard = new InformationKarte();
            Incard.KarteKosten = 130000;
            Incard.AppearPhase = Phases.Phase2_1;
            Incard.BroadcastPhase = Phases.Phase2_1; // Default, not active
            Incard.IsSecret = true;
            //Incard.FirstOwner = new Player("who");
            Incard.DescriptionText = "Empty";
            switch (In_id)
            {
                case "In-01":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.VPE};
                    Incard.BroadcastPhase = Phases.Phase3_6;
                    Incard.DescriptionText = "Es wurde ein neues Extrusionsverfahren entwickelt, mit dem die Vernetzungsanlage 1 verbessert werden kann. Die Produktionsgeschwindigkeit steigt um 500 m / Tag.";  
                    Incard.IsActive = true;
                    break;
                case "In-02":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.MI, KabelType.VPE };
                    Incard.BroadcastPhase = Phases.Phase3_6;
                    Incard.DescriptionText = "Deine Suche nach effizienteren Vakuumkammern verlief nicht zufriedenstellend. Du hast Dein Geld ergebnislos investiert.";
                    Incard.IsActive = true;
                    break;
                case "In-03":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.MI, KabelType.VPE };
                    Incard.BroadcastPhase = Phases.Phase5_2;
                    Incard.DescriptionText = "Der Hersteller Zeus Machine konnte in letzter Zeit für die Korbverseilmaschine mehrere Liefertermine nicht einhalten. Die Lieferzuverlässigkeit des Herstellers sinkt auf „mittel“.";
                    Incard.IsActive = true;
                    break;
                case "In-04":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.MI};
                    Incard.BroadcastPhase = Phases.Phase4_1;
                    Incard.DescriptionText = "Der Hersteller Zeus Machine für Isolierungsanlagen muss dringend einen höheren Umsatz erzielen. Der Hersteller kann auf 4.000.000 € herunter - gehandelt werden.";
                    Incard.IsActive = true;
                    break;
                case "In-05":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.MI, KabelType.VPE };
                    Incard.BroadcastPhase = Phases.Phase5_2;
                    Incard.DescriptionText = "Das Kontrollsystem bei einigen Maschinen von Zeus Machine weist erhebliche Mängel auf. Die Lieferzuverlässigkeit der Mantelmaschine und der Grobdrahtzugmaschine sinkt auf „schlecht“.";
                    Incard.IsActive = true;
                    //Im Vergleich zur physischen Karte wird Vernetzungsanlage 1 entfernt, damit diese Karte für beide Kabeltypen gelten kann. Karte gilt für Grobdrahtzugmaschine 1 und 2.
                    break;
                case "In-06":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() {KabelType.VPE};
                    Incard.BroadcastPhase = Phases.Phase5_2;
                    Incard.DescriptionText = "Du hast erfahren, dass der Hersteller Cablemachines für die Temperkammer einen neuen Produktmanager hat und in letzter Zeit alle Liefertermine einhält. Die Lieferzuverlässigkeit des Herstellers steigt auf „gut“.";
                    Incard.IsActive = true;
                    break;
                case "In-07":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.VPE, KabelType.MI};
                    Incard.BroadcastPhase = Phases.Phase5_2;
                    Incard.DescriptionText = "Das Sicherheitskonzept der Mantelmaschine von Hersteller Voltmaster weist Mägnel auf. Die Maschine muss reklamiert werden. Es gibt eine Verzögerung, die 230.000 € kostet.";
                    Incard.IsActive = true;
                    break;
                case "In-08":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.VPE};
                    Incard.BroadcastPhase = Phases.Phase3_6;
                    Incard.DescriptionText = "Ein neuartiges Temperverfahren senkt die benötigte Lagerdauer. Die maximale Produktionsgeschwindigkeit der Temperkammern steigt auf 600 m/Tag.";
                    Incard.IsActive = true;
                    break;
                case "In-09":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.MI, KabelType.VPE };
                    Incard.BroadcastPhase = Phases.Phase3_6;
                    Incard.DescriptionText = "Deine Recherchen zu einer platzsparenden Maschinenplatzierung ergaben keine zufriedenstellenden Ergebnisse. Du hast Dein Geld ergebnislos investiert.";
                    Incard.IsActive = true;
                    break;
                case "In-10":
                    //ToDo
                    break;
                case "In-11":
                    //ToDo
                    break;
                case "In-12":
                    //ToDo
                    break;
                case "In-13":
                    //ToDo oder Weglassen?
                    break;
                case "In-14":
                    //ToDo
                    break;
                case "In-15":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.VPE, KabelType.MI};
                    Incard.BroadcastPhase = Phases.Phase3_6;
                    Incard.DescriptionText = "Es wurden falsche Annahmen zur Produktionsmenge des Grobdrahtzugs getroffen. Die tatsächliche Produktionsmenge liegt 10 % unter der erwarteten. Runde auf die letzte Zehnerstelle.";
                    Incard.IsActive = true;
                    break;
                case "In-16":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.VPE, KabelType.MI };
                    Incard.BroadcastPhase = Phases.Phase4_1;
                    Incard.DescriptionText = "Deine Recherchen zu Elektrogabelstaplern ergaben keine zufriedenstellenden Ergebnisse. Du hast dein Geld ergebnislos investiert.";
                    Incard.IsActive = true;
                    break;
                case "In-17":
                    //ToDo
                    break;
                default:
                    break;
            }
            return Incard;
        }

        public static string RenderAsString(this InformationKarte inforKarte)
        {
            return "Player: "+ inforKarte.FirstOwner.PlayerName + "\n"
                +  "Informationkarte: " + inforKarte.ID + "\n"
                + "Kosten: 130000" + "\n"
                + "Information: " + inforKarte.DescriptionText + "\n"
                + "Wird am Ende von Phase " + inforKarte.BroadcastPhase.GetPhaseValue().ToString() + " laut vorgelesen.";
        }

        public static void ShowAsMessageBox(this InformationKarte inforKarte)
        {
            MessageBox.Show(inforKarte.RenderAsString(), "InforKarte");
        }


        public static void DoEffect(this InformationKarte Card)
        {
            if (Card.FirstOwner.PlayerName == "who") return;

            switch (Card.ID)
            {
                case "In-01":
                    DoKarte01(Card);
                    //DoKarte01(focusroom);
                    break;
                case "In-02":
                    DoKarte02(Card);
                    break;
                case "In-03":
                    DoKarte03(Card);
                    break;
                case "In-04":
                    DoKarte04(Card);
                    break;
                case "In-05":
                    DoKarte05(Card);
                    break;
                case "In-06":
                    DoKarte06(Card);
                    break;
                case "In-07":
                    DoKarte07(Card);
                    break;
                case "In-08":
                    DoKarte08(Card);
                    break;
                case "In-09":
                    DoKarte09(Card);
                    break;
                case "In-10":
                    break;
                case "In-11":
                    break;
                case "In-12":
                    break;
                case "In-13":
                    break;
                case "In-14":
                    break;
                case "In-15":
                    DoKarte15(Card);
                    break;
                case "In-16":
                    DoKarte16(Card);
                    break;
                case "In-17":
                    break;
                default:
                    break;
            }
        }

        public static void DoBroadcast(this InformationKarte Card)
        {
            Card.IsSecret = false;
            Card.DoEffect();
        }

        #region Karte Effect

        /// <summary>
        /// die Vernetzungsanlage 1 , Die Produktionsgeschwindigkeit steigt um 500 m/Tag.
        /// Nur bei KabelType == VPE 
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte01(InformationKarte card)
        {
            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (! card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;
            // Check 3 Secret / Broadcast
            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                card.FirstOwner.MyBetriebsmittelKatalog.AddMaschineMaxMenge(MaschinenType.Vernetzungsanlage1, Material.Ader, 500);
                card.FirstOwner.AtRomm.DefaultBetriebsmittelKatalog.AddMaschineMaxMenge(MaschinenType.Vernetzungsanlage1, Material.Ader, 500);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
                MessageBox.Show("Inforcard In-01 implement to owner.\n" + card.DescriptionText);
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p=> p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    player.MyBetriebsmittelKatalog.AddMaschineMaxMenge(MaschinenType.Vernetzungsanlage1, Material.Ader, 500);
                }
                MainWindows.W_Instance.RefreshDefultKatalog();
                MessageBox.Show("Inforcard In-01 implement to all players.");
            }

        }

        /// <summary>
        /// none    
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte02(InformationKarte card)
        {
            //None, Du hast Dein Geld ergebnislos investiert
        }

        /// <summary>
        /// Der Hersteller Zeus Machine,
        /// Korbverseilmaschine ()
        /// Die Lieferzuverlässigkeit des Herstellers sinkt auf „mittel“.
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte03(InformationKarte card)
        {
            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (! card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;

            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                card.FirstOwner.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Korbverseilmaschine, HerstellerType.Zeus_Machine, LieferungGrad.Mittel);
                card.FirstOwner.AtRomm.DefaultHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Korbverseilmaschine, HerstellerType.Zeus_Machine, LieferungGrad.Mittel);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p => p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    player.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Korbverseilmaschine, HerstellerType.Zeus_Machine, LieferungGrad.Mittel);                  
                }
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
        }

        /// <summary>
        ///  Hersteller Zeus Machine 
        ///  Isolierungsanlage Nur MI
        ///  Preis auf 4.000.000 €  sink
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte04(InformationKarte card)
        {
            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (!card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;

            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                card.FirstOwner.MyHerstellerKatalog.SetHerstellerPreis(MaschinenType.Isolierungsanlage, HerstellerType.Zeus_Machine, 4000000);
                card.FirstOwner.AtRomm.DefaultHerstellerKatalog.SetHerstellerPreis(MaschinenType.Isolierungsanlage, HerstellerType.Zeus_Machine, 4000000);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p => p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    player.MyHerstellerKatalog.SetHerstellerPreis(MaschinenType.Isolierungsanlage, HerstellerType.Zeus_Machine, 4000000);                    
                }
                MainWindows.W_Instance.RefreshDefultKatalog();
            }

        }

        /// <summary>
        ///  Hersteller Zeus Machine; 
        ///  Mantelmaschine, Grobdrahtzugmaschine;
        ///  Kabeltyp VPE, MI;
        ///  Lieferzuverlässigkeit schlecht;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte05(InformationKarte card)
        {
            //Im Vergleich zur physischen Karte wird Vernetzungsanlage 1 entfernt, damit diese Karte für beide Kabeltypen gelten kann. Karte gilt für Grobdrahtzugmaschine 1 und 2.
            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (!card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;

            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                card.FirstOwner.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Grobdrahtzugmaschine1, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                card.FirstOwner.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Grobdrahtzugmaschine2, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                card.FirstOwner.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Mantelmaschine, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                card.FirstOwner.AtRomm.DefaultHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Grobdrahtzugmaschine1, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                card.FirstOwner.AtRomm.DefaultHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Grobdrahtzugmaschine2, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                card.FirstOwner.AtRomm.DefaultHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Mantelmaschine, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p => p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    player.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Grobdrahtzugmaschine1, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                    player.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Grobdrahtzugmaschine2, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                    player.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Mantelmaschine, HerstellerType.Zeus_Machine, LieferungGrad.Schlecht);
                }
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
        }

        /// <summary>
        ///  Hersteller Cablemachines; 
        ///  Temperkammer;
        ///  Lieferzuverlässigkeit gut;
        ///  Kabeltyp VPE;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte06(InformationKarte card)
        {
            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (!card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;

            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                card.FirstOwner.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Temperkammer, HerstellerType.Cablemachines, LieferungGrad.Gut);
                card.FirstOwner.AtRomm.DefaultHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Temperkammer, HerstellerType.Cablemachines, LieferungGrad.Gut);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p => p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    player.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Temperkammer, HerstellerType.Cablemachines, LieferungGrad.Gut);
                }
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
        }
        
        /// <summary>
        ///  Hersteller Voltmaster; 
        ///  Mantelmaschine;
        ///  Preis + 230000;
        ///  Kabeltyp VPE, MI;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte07(InformationKarte card)
        {
            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (!card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;

            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                card.FirstOwner.MyHerstellerKatalog.SetHerstellerPreis(MaschinenType.Mantelmaschine, HerstellerType.Voltmaster, 1730000);
                card.FirstOwner.AtRomm.DefaultHerstellerKatalog.SetHerstellerPreis(MaschinenType.Mantelmaschine, HerstellerType.Voltmaster, 1730000);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p => p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    player.MyHerstellerKatalog.SetHerstellerPreis(MaschinenType.Mantelmaschine, HerstellerType.Voltmaster, 1730000);
                }
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
        }

        /// <summary>
        ///  Temperkammer;
        ///  Produktionsgeschwindigkeit 600 m/Tag;
        ///  Kabeltyp VPE;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte08(InformationKarte card)
        {
            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (!card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;

            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                card.FirstOwner.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Temperkammer, Material.GetemperteAder, 600);
                card.FirstOwner.AtRomm.DefaultBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Temperkammer, Material.GetemperteAder, 600);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p => p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    player.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Temperkammer, Material.GetemperteAder, 600);
                }
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
        }

        /// <summary>
        ///  keine Information
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte09(InformationKarte card)
        {
            /*Deine Recherchen zu einer platzsparenden Maschinenplatzierung ergaben keine
             * zufriedenstellenden Ergebnisse.
             * Du hast Dein Geld ergebnislos investiert.
             */
        }

        /// <summary>
        ///  ToDo;
        ///  neue Layoutkarten;
        ///  Kosten: 4.000.000;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte10(InformationKarte card)
        {
            /*Die Immobilienpreise für Neubauten steigen und steigen.
             * Die Kosten für neue Layoutkarten steigen auf 4.000.000 €.
             */

            //ToDo
            //LayoutUnit.defaultpreis(4000000); oder so ähnlich
        }

        /// <summary>
        ///  ToDo;
        ///  AddBudget;
        ///  1000000;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte11(InformationKarte card)
        {
            //KalkulaitonsUnit.AddBudget ist noch nicht implementiert

            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (!card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;

            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                //*card.FirstOwner.KalkulationUnit.AddBudget(1000000);
                //*card.FirstOwner.AtRomm.KalkulationsUnit.AddBudget(1000000);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p => p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    //*player.KalkulationUnit.AddBudget(1000000);
                }
            }
        }

        /// <summary>
        ///  ToDo;
        ///  Strafkosten aus Phase 4 entfallen;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte12(InformationKarte card)
        {
            /*Die Firmenversicherung feiert Jubiläum.
             * Alle Strafkosten, die in der Phase 4 entstehen, werden von der Versicherung übernommen.
             */
            //ToDo
        }

        /// <summary>
        ///  ToDo bzw. Weglassen:
        ///  Strukturkarten entfernen;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte13(InformationKarte card)
        {
            /*Deine Recherchen in platzsparende Layouts haben sich gelohnt.
             * Alle Strukturkarten, die während der Phase 6 auf das Layout gelegt wurden,
             * können entfernt werden.
             */

            //ToDo? Oder Weglassen?
        }

        /// <summary>
        ///  ToDo:
        ///  Säulen entfernen kostet nur noch die Hälfte
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte14(InformationKarte card)
        {
            /*Durch deine ausführlichen Recherchen zu Gebäudestrukturen hast du ein neues Verfahren entdeckt,
             * um kostengünstig störende Säulen zu entfernen.
             * Das Entfernen von Säulen kostet nur noch die Hälfte des Normalpreises.
             */

            //ToDo
            //LayoutUnit.SaeulenUnitPreis(325000); oder so ähnlich
        }

        /// <summary>
        ///  Grobdrahtzug 1 + 2;
        ///  Produktionsmenge - 10 %
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte15(InformationKarte card)
        {
            //Produktionsmenge wird auf 90 % der ursprünglichen Produktionsmenge gesetzt. Andere Änderungen werden nicht berücksichtigt.
            // Check 1 
            if (card.IsActive == false) return;
            // Check 2, if this karte for both/specifish Kabeltype avaliable.
            if (!card.TypeSet.Contains(card.FirstOwner.AtRomm.KabelType)) return;

            if (card.IsSecret /*&& Now Phase < card.BroadcastPhase*/)
            {
                // Change Datebase
                card.FirstOwner.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine1, Material.Leiterdraht, 117000);
                card.FirstOwner.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine2, Material.Leiterdraht, 225000);
                card.FirstOwner.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine1, Material.Schirmdraht, 117000);
                card.FirstOwner.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine2, Material.Schirmdraht, 225000);
                card.FirstOwner.AtRomm.DefaultBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine1, Material.Leiterdraht, 117000);
                card.FirstOwner.AtRomm.DefaultBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine2, Material.Leiterdraht, 225000);
                card.FirstOwner.AtRomm.DefaultBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine1, Material.Schirmdraht, 117000);
                card.FirstOwner.AtRomm.DefaultBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine2, Material.Schirmdraht, 225000);
                // GUI Update Render  
                MainWindows.W_Instance.RefreshInformationOfPlayer();
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
            else  // Time to Broadcast informationkarte to other player
            {
                // Get other Player 
                var allplayers = card.FirstOwner.AtRomm.PlayerList;
                List<Player> otherPlayers = allplayers.Where(p => p.PlayerName != card.FirstOwner.PlayerName).ToList();
                if (otherPlayers.Count() < 1) return;
                // Change Datebase 
                foreach (Player player in otherPlayers)
                {
                    player.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine1, Material.Leiterdraht, 117000);
                    player.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine2, Material.Leiterdraht, 225000);
                    player.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine1, Material.Schirmdraht, 117000);
                    player.MyBetriebsmittelKatalog.SetMaschineMaxMenge(MaschinenType.Grobdrahtzugmaschine2, Material.Schirmdraht, 225000);
                }
                MainWindows.W_Instance.RefreshDefultKatalog();
            }
        }

        /// <summary>
        ///  keine Information
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte16(InformationKarte card)
        {
            /*Deine Recherchen zu Elektrogabelstaplern ergaben keine zufriedenstellenden Ergebnisse.
             * Du hast dein Geld ergebnislos investiert.
             */
        }

        /// <summary>
        ///  ToDo:
        ///  Zielmenge - 15 %;
        /// </summary>
        /// <param name="player"></param>
        private static void DoKarte17(InformationKarte card)
        {
            /*Euer Vater schwebt auf Wolke Sieben mit seiner neuen Flamme, daher ist er besonders großzügig und senkt
             * die erwartete Produktionsmenge um 15 %.
             * Dementsprechend erfolgt auch die Punktevergabe. Man bekommt mit Erreichen des geringeren Outputs bereits
             * die volle Punktzahl für die produzierte Menge.
             */

            //ToDo
        }
        #endregion

    }
}
