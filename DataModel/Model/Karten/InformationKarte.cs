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
        private bool _isSecret = true;
        private Phases _apperPhase = Phases.Phase2_3;
        private Phases _broadcastPhase = Phases.Phase2_3;
        private Player _firstOwner = new Player("who");
        private List<KabelType> _typeSet = new List<KabelType>() {};
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
            BroadcastPhase = effectivePhase;
            IsActive = true;
            IsSecret = true;
        }

        public Phases AppearPhase { get => _apperPhase; set => _apperPhase = value; }
        public Phases BroadcastPhase { get => _broadcastPhase; set => _broadcastPhase = value; }
        public bool IsSecret { get => _isSecret; set => _isSecret=value; }
        public string DescriptionText { get => _descriptionText; set => _descriptionText = value; }
        public int KarteKosten { get => karteKosten; set => karteKosten = value; }
        public Player FirstOwner { get => _firstOwner; set => _firstOwner = value; }
        /// <summary>
        /// For which KabelType is this Karte avaliable. 
        /// </summary>
        public List<KabelType> TypeSet { get => _typeSet; set => _typeSet = value; }

        //int IKosten.EinkaufPreis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
