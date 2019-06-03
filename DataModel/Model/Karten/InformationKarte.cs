using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.Karten //.Interface
{
    public class InformationKarte : BaseKarte, IPhase
    {
        private int karteKosten = 130000;
        //private bool _isActive = false;
        private bool _isSeceret = true;
        private Phases _apperPhase = Phases.Phase2_3;
        private Phases _effectivePhase = Phases.unkonw;
        //Inhalt
        private string _descriptionText="";
        //Event--
        //privete delegate DoEvent;


        public InformationKarte()
        {
            /*Basekarte
            ID => setID("In- ") {KarteAbkurz, KarteKategorie,  Number}
            IsActive            
            */
            ID = "In-00";
            IsActive = false;
            AppearPhase = Phases.Phase2_3;
        }

        public InformationKarte(string id, Phases effectivePhase ) : this()
        {
            SetID(id);
            EffectivePhase = effectivePhase;
            IsActive = true;
            IsSecret = true;
        }

        public Phases AppearPhase { get => _apperPhase; set => _apperPhase = value; }
        public Phases EffectivePhase { get => _effectivePhase; set => _effectivePhase = value; }
        public bool IsSecret { get => _isSeceret; set => _isSeceret=value; }
        public string DescriptionText { get => _descriptionText; set => _descriptionText = value; }
        public int KarteKosten { get => karteKosten; set => karteKosten = value; }

        //int IKosten.EinkaufPreis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DoKarteEffectToPlayer(Player player)
        {

            switch (this.ID)
            {
                case "In-01":
                    DoKarte01(player);
                    break;
                case "In-02":
                    break;
                case "In-03":
                    break;
                case "In-04":
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

        #region Karte Effect Set

        /// <summary>
        /// die Vernetzungsanlage 1 , Die Produktionsgeschwindigkeit steigt um 500 m/Tag.
        /// Nur bei KabelType == VPE 
        /// </summary>
        /// <param name="player"></param>
        private void DoKarte01(Player player)
        {
            player.MyBetriebsmittelKatalog.AddMaschineMaxMenge(MaschinenType.Vernetzungsanlage1, Material.Ader, 500);
            //Default\            
        }

        /// <summary>
        /// none    
        /// </summary>
        /// <param name="player"></param>
        private void DoKarte02(Player player)
        {
            //None, Du hast Dein Geld ergebnislos investiert
        }

        /// <summary>
        /// Der Hersteller Zeus Machine,
        /// Korbverseilmaschine
        /// Die Lieferzuverlässigkeit des Herstellers sinkt auf „mittel“.
        /// </summary>
        /// <param name="player"></param>
        private void DoKarte03(Player player)
        {            
            player.MyHerstellerKatalog.SetHerstellerLieferung(MaschinenType.Korbverseilmaschine, HerstellerType.Zeus_Machine, LieferungGrad.Mittel);
        }
        /// <summary>
        ///  Hersteller Zeus Machine 
        ///  Isolierungsanlagen
        ///  Preis auf 4.000.000 €  sink
        /// </summary>
        /// <param name="player"></param>
        private void DoKarte04(Player player)
        {
            player.MyHerstellerKatalog.SetHerstellerPreis(MaschinenType.Isolierungsanlage, HerstellerType.Zeus_Machine, 4000000);
        }

        private void DoKarte05(Player player)
        {
            /*Das Kontrollsystem bei einigen Maschinen von Zeus Machine weist erhebliche Mängel auf.             * Die Lieferzuverlässigkeit der Vernetzungsanlage 1, Mantelmaschine und Grobdrahtzugmaschine sinkt auf „schlecht“.            */
        }
        private void DoKarte06(Player player)
        {
            /*Du hast erfahren, dass der Hersteller Cablemachines für die Temperkammer einen neuen Produktmanager hat              * und in letzter Zeit alle Liefertermine einhält.            Die Lieferzuverlässigkeit des Herstellers steigt auf „gut“.*/
        }
        private void DoKarte07(Player player)
        {

        }
        private void DoKarte08(Player player)
        {

        }
        private void DoKarte09(Player player)
        {

        }
        private void DoKarte10(Player player)
        {

        }
        private void DoKarte11(Player player)
        {

        }
        private void DoKarte12(Player player)
        {

        }
        private void DoKarte13(Player player)
        {

        }
        private void DoKarte14(Player player)
        {

        }
        private void DoKarte15(Player player)
        {

        }
        private void DoKarte16(Player player)
        {

        }
        private void DoKarte17(Player player)
        {

        }
        #endregion

    }
}
