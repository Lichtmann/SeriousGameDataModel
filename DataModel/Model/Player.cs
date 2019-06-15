using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Model.Karten;

namespace DataModel.Model
{
    public class Player
    {
        private string _playerName;
        private GameRoom _atRomm;
        private ZielKarte _zielkarte;
        // BetriebmittelKatalog // HerstellerKatalog
        private HerstellerKatalog _myHerstellerKatalog;         // KabelType
        private BetriebsmittelKatalog _myBetriebsmittelKatalog; // KabelType
        // Maschinen, Layout EinkaufList
        private List<Maschine> _maschinenList = new List<Maschine>();
        private List<LayoutUnit> _layoutUnitList = new List<LayoutUnit>();
        private List<Decide> _herstellerDecideList = new List<Decide>();
        // 1 MaterialflussManager 

        // 2 KostenManager + 6 BudgetManager => KalkulationUnit
        private KalkulationUnit _kalkulationUnit;
        // 3 Erweiterbarkeit + 4 Zuganglichkeit => LayoutManager

        // 5 ProduktionManager
        private ProduktionManager _myProduktionManager;
        // EventRegister

        // End Evaluation
        private Evaluation _evaluation;


        public Player(string name )
        {
            PlayerName = name;
            Zielkarte = new ZielKarte();
            Evaluation = new Evaluation() { Weights = new Gewichtung(1, 1, 1) };
            KalkulationUnit = new KalkulationUnit();
            LayoutUnitList = new List<LayoutUnit>();
            MaschinenList = new List<Maschine>();
            //1
            //2 6
            //3 4
            //5
            //
            MyProduktionManager = new ProduktionManager();
        }

        public Player(string name, GameRoom room) : this(name)
        {
            this.AtRomm = room;
        }
        public GameRoom AtRomm { get => _atRomm; set => _atRomm = value; }
        public string PlayerName { get => _playerName; set => _playerName = value; }
        public ZielKarte Zielkarte { get => _zielkarte; set => _zielkarte = value; }

        #region LayoutUnit
        public List<LayoutUnit> LayoutUnitList { get => _layoutUnitList; set => _layoutUnitList = value; }
        public List<LayoutUnit> NewLayoutUnitList { get => LayoutUnitList.Where(l => l.Type == LayoutUnitType.NewLayout).ToList();/* set => _layoutUnitList = value;*/ }
        public List<LayoutUnit> OldLayoutUnitList { get => LayoutUnitList.Where(l => l.Type == LayoutUnitType.OldLayout).ToList(); /*set => _layoutUnitList = value;*/ }

        #endregion
        #region Maschinen 
        //Maschinen Kosten, Anzahl, Kapazitat,
        public ProduktionManager MyProduktionManager { get => _myProduktionManager; set => _myProduktionManager = value; }
        public List<Maschine> MaschinenList { get => _maschinenList; set => _maschinenList = value; }
        public List<Decide> HerstellerDecideList { get => _herstellerDecideList; set => _herstellerDecideList = value; }
        public int MaschinenAnzahl => MaschinenList.Count;
        public int MaschinenEinkaufKosten => MaschinenList.Select(m => m.KalkulationPreis).Sum();
        #endregion

        #region Evaluation Result
        public Evaluation Evaluation { get => _evaluation; set => _evaluation = value; }
        public int MatrialflussPunkt => Evaluation.MaterialflussPunkt;
        public int GetMatrialflussPunkt(MaterialflussRanks rank)
        {
            Evaluation.MaterialflussRank = rank;
            return Evaluation.MaterialflussPunkt;
        }

        public int GetEndScroe => Evaluation.EndScroe;
        public int UpdateSingleRankAndGetEndScroe(Enum rank)
        {
            switch (rank.GetType().Name)
            {
                case "MaterialflussRanks":
                    Evaluation.MaterialflussRank = (MaterialflussRanks)rank;
                    break;
                case "KostenRanks":
                    Evaluation.KostenRank = (KostenRanks)rank;
                    break;
                case "ErweiterbarkeitRanks":
                    Evaluation.ErweiterbarkeitRank = (ErweiterbarkeitRanks)rank;
                    break;
                case "ZuganglichkeitRanks":
                    Evaluation.ZuganglichkeitRank = (ZuganglichkeitRanks)rank;
                    break;
                case "ProduzierbareRanks":
                    Evaluation.ProduzierbareRank = (ProduzierbareRanks)rank;
                    break;
                case "BudgetRanks":
                    Evaluation.BudgetRank = (BudgetRanks)rank;
                    break;
                default:
                    //
                    break;
            }
            return Evaluation.EndScroe;

        }
        public int UpdateMultiRankAndGetEndScroe(List<Enum> ranks)
        {
            foreach (Enum rank in ranks)
            {
                UpdateSingleRankAndGetEndScroe(rank);
            }
            return Evaluation.EndScroe;
        }

        public string ScroeToString => Evaluation.ScroeToString();

        #endregion

        #region Kalkulation
        public KalkulationUnit KalkulationUnit { get => _kalkulationUnit; set => _kalkulationUnit = value; }

        #endregion

        #region Katalog
        public HerstellerKatalog MyHerstellerKatalog { get => _myHerstellerKatalog; set => _myHerstellerKatalog = value; }
        public BetriebsmittelKatalog MyBetriebsmittelKatalog { get => _myBetriebsmittelKatalog; set => _myBetriebsmittelKatalog = value; }


        #endregion

        public override string ToString()
        {
            return PlayerName;
        }
    }
}

