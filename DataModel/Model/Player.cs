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
        private ZielKarte _zielkarte;
        private KalkulationUnit _kalkulationUnit;
        // MaschinenManager
        private List<Maschine> _maschinen;
        private Evaluation _evaluation;
        // Maschinen Dimension
        // HerstellerKatalog

        public Player(string name )
        {
            PlayerName = name;
            Zielkarte = new ZielKarte();
            Evaluation = new Evaluation() { Weights = new Gewichtung(1, 1, 1) };
            KalkulationUnit = new KalkulationUnit();
        }

        #region Maschinen 
        //Maschinen Kosten, Anzahl, Kapazitat,
        public string PlayerName { get => _playerName; set => _playerName = value; }
        public ZielKarte Zielkarte { get => _zielkarte; set => _zielkarte = value; }
        public List<Maschine> Maschinen { get => _maschinen; set => _maschinen = value; }
        public int MaschinenAnzahl => Maschinen.Count;
        public int MaschinenEinkaufKosten => Maschinen.Select(m => m.KalkulationPreis).Sum();
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

        public override string ToString()
        {
            return PlayerName;
        }
    }
}

