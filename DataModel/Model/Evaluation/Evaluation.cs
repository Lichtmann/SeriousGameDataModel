using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.Evaluation
{
    public class Evaluation
    {
        private int _endScroe;

        private int _materialflussPunkt;
        private int _kostenPunkt;
        private int _erweiterbarkeitPunkt;
        private int _zuganglichkeitPunkt;
        private int _produzierbarPunkt;
        private int _budgetPunkt;

        private int _extraScroe;

        private Gewichtung _gewichtung;

        private MaterialflussRanks _materialflussRank;
        private KostenRanks _kostenRank;
        private ErweiterbarkeitRanks _erweiterbarkeitRank;
        private ZuganglichkeitRanks _zuganglichkeitRank;
        private ProduzierbareRanks _produzierbareRank;
        private BudgetRanks _budgetRank;


        public Evaluation()
        {
            Weights = new Gewichtung();
            MaterialflussRank = MaterialflussRanks.Teilnahmeurkunde;         //0
            KostenRank = KostenRanks.Teilnahmeurkunde;                       //0
            ErweiterbarkeitRank = ErweiterbarkeitRanks.Teilnahmeurkunde;     //0
            ZuganglichkeitRank = ZuganglichkeitRanks.MoreConflictOrDefault;  //0
            ProduzierbareRank = ProduzierbareRanks.NotReachGoal;             //0
            BudgetRank = BudgetRanks.normal;                                 //0
            ExtraScroe = 0;
        }

        /// <summary>
        /// Summary Scroe
        /// </summary>
        public int EndScroe
        {
            get
            {
                _endScroe = MaterialflussPunkt + KostenPunkt + ErweiterbarkeitPunkt + ZuganglichkeitPunkt + ProduzierbarPunkt + BudgetPunkt + ExtraScroe;
                return _endScroe;
            }
            //set { _endScroe = value; }
        }

        public string ScroeToString()
        {
            string l;
            l = "End Scroe = MaterialflussPunkt*Weights + KostenPunkt + ErweiterbarkeitPunkt*Weights + ZuganglichkeitPunkt + ProduzierbarPunkt + BudgetPunkt*Weights + ExtraScroe\n"
              + "          = " + (int)MaterialflussRank + "*" + Weights.MaterialflussGewichtung + " + "
              + (int)KostenRank + " + " + (int)ErweiterbarkeitRank + "*" + Weights.ErweiterbarkeitGewichtung + " + "
              + (int)ZuganglichkeitRank + " + " + (int)ProduzierbareRank + " + " + (int)BudgetRank + "*" + Weights.BudgetGewichtung
              + " + " +ExtraScroe
              + "\n= " + EndScroe;

            return l;
        }

        //Punkt of each Aspekt
        public int MaterialflussPunkt
        {
            get => (int)MaterialflussRank * Weights.MaterialflussGewichtung;
            set => _materialflussPunkt = value;
        }
        public int KostenPunkt
        {
            get => (int)KostenRank * 1;
            set => _kostenPunkt = value;
        }
        public int ErweiterbarkeitPunkt
        {
            get => (int)ErweiterbarkeitRank * Weights.ErweiterbarkeitGewichtung;
            set => _erweiterbarkeitPunkt = value;
        }
        public int ZuganglichkeitPunkt
        {
            get => (int)ZuganglichkeitRank * 1;
            set => _zuganglichkeitPunkt = value;
        }
        public int ProduzierbarPunkt
        {
            get => (int)ProduzierbareRank * 1;
            set => _produzierbarPunkt = value;
        }
        public int BudgetPunkt
        {
            get => (int)BudgetRank * Weights.BudgetGewichtung;
            set => _budgetPunkt = value;
        }
        public int ExtraScroe { get => _extraScroe; set => _extraScroe = value; }

        //Gewicht
        public Gewichtung Weights { get => _gewichtung; set => _gewichtung = value; }

        //Rank Ergebniss
        public MaterialflussRanks MaterialflussRank
        {
            get => _materialflussRank;
            set
            {
                _materialflussRank = value;
                //MaterialflussPunkt = (int)_materialflussRank * Gewichtung.MaterialflussGewichtung;
            }
        }
        public KostenRanks KostenRank { get => _kostenRank; set => _kostenRank = value; }
        public ErweiterbarkeitRanks ErweiterbarkeitRank { get => _erweiterbarkeitRank; set => _erweiterbarkeitRank = value; }
        public ZuganglichkeitRanks ZuganglichkeitRank { get => _zuganglichkeitRank; set => _zuganglichkeitRank = value; }
        public ProduzierbareRanks ProduzierbareRank { get => _produzierbareRank; set => _produzierbareRank = value; }
        public BudgetRanks BudgetRank { get => _budgetRank; set => _budgetRank = value; }
    }
}

