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
                    Incard.DescriptionText = "die Vernetzungsanlage 1 Die Produktionsgeschwindigkeit steigt um 500 m / Tag.";  
                    Incard.IsActive = true;
                    break;
                case "In-02":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.MI, KabelType.VPE };
                    Incard.BroadcastPhase = Phases.Phase3_6;
                    Incard.DescriptionText = "Empty";
                    Incard.IsActive = true;
                    break;
                case "In-03":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.MI, KabelType.VPE };
                    Incard.BroadcastPhase = Phases.Phase5_2;
                    Incard.DescriptionText = "Empty";
                    Incard.IsActive = true;
                    break;
                case "In-04":
                    Incard.SetID(In_id);
                    Incard.TypeSet = new List<KabelType>() { KabelType.MI};
                    Incard.BroadcastPhase = Phases.Phase4_1;
                    Incard.DescriptionText = "Empty";
                    Incard.IsActive = true;
                    break;
                case "In-05":
                    break;
                case "In-06":
                    break;
                case "In-07":
                    break;
                case "In-08":
                    break;
                case "In-09":
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
                    break;
                case "In-16":
                    break;
                case "In-17":
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
                + "kosten: 130000" + "\n"
                + "Information: " + inforKarte.DescriptionText + "\n"
                + "Wird am Phase" + inforKarte.BroadcastPhase.GetPhaseValue().ToString() + "laut vorgelesen";
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
                    break;
                case "In-06":
                    break;
                case "In-07":
                    break;
                case "In-08":
                    break;
                case "In-09":
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
                    break;
                case "In-16":
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
                MessageBox.Show("Inforcard In-001 implement to owner.\n" + card.DescriptionText);
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
                MessageBox.Show("Inforcard In-001 implement to all players.");
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
            }

        }

        private static void DoKarte05(InformationKarte card)
        {
            /*Das Kontrollsystem bei einigen Maschinen von Zeus Machine weist erhebliche Mängel auf.             * Die Lieferzuverlässigkeit der Vernetzungsanlage 1, Mantelmaschine und Grobdrahtzugmaschine sinkt auf „schlecht“.            */
        }
        private static void DoKarte06(InformationKarte card)
        {
            /*Du hast erfahren, dass der Hersteller Cablemachines für die Temperkammer einen neuen Produktmanager hat              * und in letzter Zeit alle Liefertermine einhält.            Die Lieferzuverlässigkeit des Herstellers steigt auf „gut“.*/
        }
        private static void DoKarte07(InformationKarte card)
        {

        }
        private static void DoKarte08(InformationKarte card)
        {

        }
        private static void DoKarte09(InformationKarte card)
        {

        }
        private static void DoKarte10(InformationKarte card)
        {

        }
        private static void DoKarte11(InformationKarte card)
        {

        }
        private static void DoKarte12(InformationKarte card)
        {

        }
        private static void DoKarte13(InformationKarte card)
        {

        }
        private static void DoKarte14(InformationKarte card)
        {

        }
        private static void DoKarte15(InformationKarte card)
        {

        }
        private static void DoKarte16(InformationKarte card)
        {

        }
        private static void DoKarte17(InformationKarte card)
        {

        }
        #endregion

    }
}
