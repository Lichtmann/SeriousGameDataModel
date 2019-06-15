using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class HerstellerKatalog
    {
        private KabelType  _kabelType;
        private List<HerstellerType> _herstellerDimension = new List<HerstellerType>();
        private List<MaschinenType> _maschinenDimension = new List<MaschinenType>();
        
        private Tuple<MaschinenType, HerstellerType> _key;
        private int _preisValue;
        private Dictionary<Tuple<MaschinenType, HerstellerType>, int> _preisTable;
        private Dictionary<Tuple<MaschinenType, HerstellerType>, LieferungGrad> _lieferungGradTable;

        public HerstellerKatalog(KabelType _kabelType )
        {
            this.KabelType = _kabelType;
            HerstellerDimension = new List<HerstellerType>()
            {
                HerstellerType.Cablemachines,
                HerstellerType.Voltmaster,
                HerstellerType.Zeus_Machine
            };
            PreisTable = new Dictionary<Tuple<MaschinenType, HerstellerType>, int>();
            LieferungGradTable = new Dictionary<Tuple<MaschinenType, HerstellerType>, LieferungGrad>();

            if (this.KabelType == KabelType.VPE)
            {
                MaschinenDimension = new List<MaschinenType>()
                {
                    MaschinenType.Grobdrahtzugmaschine1,
                    MaschinenType.Grobdrahtzugmaschine2,
                    MaschinenType.Korbverseilmaschine,
                    MaschinenType.Vernetzungsanlage1,   //
                    MaschinenType.Vernetzungsanlage2,   //
                    MaschinenType.Temperkammer,         //
                    MaschinenType.Schirmmaschine,       
                    MaschinenType.Mantelmaschine
                };
                FillDefaultLieferungGradTable();
                FillDefaultPreisTable_VPE();
            }
            else if (this.KabelType == KabelType.MI)
            {
                MaschinenDimension = new List<MaschinenType>()
                {
                    MaschinenType.Grobdrahtzugmaschine1,
                    MaschinenType.Grobdrahtzugmaschine2,
                    MaschinenType.Korbverseilmaschine,
                    MaschinenType.Isolierungsanlage,    //
                    MaschinenType.Vakuumkessel,         //
                    MaschinenType.Schirmmaschine,
                    MaschinenType.Mantelmaschine
                };
                FillDefaultLieferungGradTable();
                //Todo new Table
                FillDefaultPreisTable_MI();
            }

        }

        private void FillDefaultPreisTable_VPE()
        {
            foreach (HerstellerType hersteller in HerstellerDimension)
            {
                if (hersteller == HerstellerType.Cablemachines)
                {
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine1, hersteller),   180000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine2, hersteller),   270000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Korbverseilmaschine, hersteller),     4000000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage1, hersteller),      4500000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage2, hersteller),      2100000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Temperkammer, hersteller),            900000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Schirmmaschine, hersteller),          700000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Mantelmaschine, hersteller),          1250000);
                }
                else if (hersteller == HerstellerType.Voltmaster)
                {
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine1, hersteller),   200000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine2, hersteller),   300000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Korbverseilmaschine, hersteller),     4500000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage1, hersteller),      5000000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage2, hersteller),      2500000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Temperkammer, hersteller),            1000000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Schirmmaschine, hersteller),          750000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Mantelmaschine, hersteller),          1500000);
                }
                else if (hersteller == HerstellerType.Zeus_Machine)
                {
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine1, hersteller),   220000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine2, hersteller),   330000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Korbverseilmaschine, hersteller),     5000000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage1, hersteller),      5500000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage2, hersteller),      2900000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Temperkammer, hersteller),            1100000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Schirmmaschine, hersteller),          800000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Mantelmaschine, hersteller),          1750000);
                }
            }
        }

        private void FillDefaultPreisTable_MI()
        {
            foreach (HerstellerType hersteller in HerstellerDimension)
            {
                if (hersteller == HerstellerType.Cablemachines)
                {
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine1, hersteller), 180000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine2, hersteller), 270000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Korbverseilmaschine, hersteller), 4000000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage1, hersteller), 4500000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage2, hersteller), 2100000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Temperkammer, hersteller), 900000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Isolierungsanlage, hersteller), 900000);     //#
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vakuumkessel, hersteller), 900000);          //#
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Schirmmaschine, hersteller), 700000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Mantelmaschine, hersteller), 1250000);
                }
                else if (hersteller == HerstellerType.Voltmaster)
                {
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine1, hersteller), 200000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine2, hersteller), 300000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Korbverseilmaschine, hersteller), 4500000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage1, hersteller), 5000000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage2, hersteller), 2500000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Temperkammer, hersteller), 1000000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Isolierungsanlage, hersteller), 900000);  //#
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vakuumkessel, hersteller), 900000);       //#
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Schirmmaschine, hersteller), 750000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Mantelmaschine, hersteller), 1500000);
                }
                else if (hersteller == HerstellerType.Zeus_Machine)
                {
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine1, hersteller), 220000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Grobdrahtzugmaschine2, hersteller), 330000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Korbverseilmaschine, hersteller), 5000000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage1, hersteller), 5500000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vernetzungsanlage2, hersteller), 2900000);
                    //PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Temperkammer, hersteller), 1100000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Isolierungsanlage, hersteller), 900000);  //#
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Vakuumkessel, hersteller), 900000);       //#
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Schirmmaschine, hersteller), 800000);
                    PreisTable.Add(new Tuple<MaschinenType, HerstellerType>(MaschinenType.Mantelmaschine, hersteller), 1750000);
                }
            }
        }

        private void FillDefaultLieferungGradTable()
        {
            foreach (HerstellerType hersteller in HerstellerDimension)
            {
                foreach (MaschinenType maschine in MaschinenDimension)
                {
                    var key = new Tuple<MaschinenType, HerstellerType>(maschine, hersteller);
                    if (hersteller == HerstellerType.Cablemachines)
                    {
                        LieferungGradTable.Add(key, LieferungGrad.Schlecht);
                    }
                    else if (hersteller == HerstellerType.Voltmaster)
                    {
                        LieferungGradTable.Add(key, LieferungGrad.Mittel);
                    }
                    else if (hersteller == HerstellerType.Zeus_Machine)
                    {
                        LieferungGradTable.Add(key, LieferungGrad.Gut);
                    }
                }
            }
        }

        public List<MaschinenType> MaschinenDimension { get => _maschinenDimension; set => _maschinenDimension = value; }
        public List<HerstellerType> HerstellerDimension { get => _herstellerDimension; set => _herstellerDimension = value; }
        public KabelType KabelType { get => _kabelType; set => _kabelType = value; }
        public Tuple<MaschinenType, HerstellerType> Key { get => _key; set => _key = value; }
        public int PreisValue { get => _preisValue; set => _preisValue = value; }
        public Dictionary<Tuple<MaschinenType, HerstellerType>, int> PreisTable { get => _preisTable; set => _preisTable = value; }
        public Dictionary<Tuple<MaschinenType, HerstellerType>, LieferungGrad> LieferungGradTable { get => _lieferungGradTable; set => _lieferungGradTable = value; }

        public LieferungGrad GetLieferungGrad(MaschinenType maschine, HerstellerType hersteller)
        {
            var key = new Tuple<MaschinenType, HerstellerType>(maschine, hersteller);
            LieferungGrad grad = new LieferungGrad();
            if (LieferungGradTable.TryGetValue(key, out grad))
                return grad;
            return LieferungGrad.Mittel;
        }
        public int GetPreis(MaschinenType maschine, HerstellerType hersteller )
        {
            var key = new Tuple<MaschinenType, HerstellerType>(maschine, hersteller);
            int preis = 0;
            if (PreisTable.TryGetValue(key, out preis))
                return preis;   
            return 0;
        }

        public Dictionary<Tuple<MaschinenType, HerstellerType>, int>  CloneDictionary()
        {
            return new Dictionary<Tuple<MaschinenType, HerstellerType>, int>(PreisTable);
        }

        #region InforEvent
        public void SetHerstellerLieferung(MaschinenType m_type, HerstellerType hersteller, LieferungGrad lg)
        {
            LieferungGrad val;
            var key = new Tuple<MaschinenType, HerstellerType>(m_type, hersteller);
            if (LieferungGradTable.TryGetValue(key, out val))
            {
                LieferungGradTable[key] = lg;
            }
            else
            {
                LieferungGradTable.Add(key, lg);
            }
        }

        //public LieferungGrad GetHerstellerLieferung(MaschinenType m_type, HerstellerType hersteller, LieferungGrad lg)
        //{
        //    LieferungGrad val;
        //    var key = new Tuple<MaschinenType, HerstellerType>(m_type, hersteller);
        //    LieferungGradTable.TryGetValue(key, out val);
        //    return val;

        //}

        public void SetHerstellerPreis(MaschinenType m_type, HerstellerType hersteller, int preis)
        {
            int val;
            var key = new Tuple<MaschinenType, HerstellerType>(m_type, hersteller);
            if (PreisTable.TryGetValue(key, out val))
            {
                PreisTable[key] = preis;
            }
            else
            {
                PreisTable.Add(key, preis);
            }
        }
        public int GetHerstellerPreis(MaschinenType m_type, HerstellerType hersteller)
        {
            int val;
            var key = new Tuple<MaschinenType, HerstellerType>(m_type, hersteller);
            if (PreisTable.TryGetValue(key, out val))
            {
                return val;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }

    


}
