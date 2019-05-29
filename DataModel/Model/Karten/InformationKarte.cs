using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.Karten //.Interface
{
    public class InformationKarte : BaseKarte, IPhase
    {
        private Phases _apperPhase = Phases.Phase2_3;
        private Phases _effectivePhase = Phases.unkonw;
        //private bool _isActive = false;
        private bool _isSeceret = true;
        //Inhalt
        private string _descriptionText="";
        //Event--


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

        //int IKosten.EinkaufPreis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void dosomething()
        {
            Console.WriteLine(ID);
        }
    }
}
