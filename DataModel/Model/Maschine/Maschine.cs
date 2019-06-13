using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.Maschine
{
    public class Maschine
    {
        //Identify [Fest][Initial]
        private string _name;
        private string _id;
        //Player
        private Player _owner = new Player("who");
        //Type [Fest][Initial]
        private MaschinenType _type;
        //Area Require [Fest][Initial]
        private int _area;
        //Preis [Initial][EventChange]
        private int _kalkulationPreis;  //aktuell Preis zu kalkelieren
        private int _marktPreis;        // Defaultpreise;
        private int _herstellerPreis;
        private int _aufPreis;
        private double _aufPreisRate = 1.0;
        private bool _isNachKauf = false;
        //Hersteller [Initial][EventChange]
        private HerstellerType _hersteller;
        private LieferungGrad _lieferungGrad;
        private bool hasRoll = false;
        private LieferungErgebnis _lieferungErgebnis;
        //Produktion [Initial][EventChange]
        private List<Produktion> _outputProdukts;

        //constructur
        public Maschine()
        {
            Name = "DefaultMaschine";
            ID = GenerateID();
            Area = 0;
            MarktPreis = 0;
            IsNachKauf = false;
            HerstellerPreis = MarktPreis;
            Hersteller = HerstellerType.Voltmaster;
            LieferungGrad = LieferungGrad.Mittel;
            LieferungErgebnis = LieferungErgebnis.Allright;  //Update, AufPreisRate Update
            UpdateKalkulationPreis();
            OutputProdukts = new List<Produktion>();
        }


        public MaschinenType Type { get => _type; set => _type = value; }
        public string Name { get => _name; set => _name = value; }
        public string ID { get => _id; set => _id = value; }
        public Player Owner { get => _owner; set => _owner = value; }
        public int Area { get => _area; set => _area = value; }
        public int KalkulationPreis { get => _kalkulationPreis; set => _kalkulationPreis = value; }
        public int MarktPreis
        {
            get => _marktPreis;
            set
            {
                _marktPreis = value;
                //Do something
                UpdateKalkulationPreis();
            } 
        }
        public int HerstellerPreis
        {
            get => _herstellerPreis;
            set
            {
                _herstellerPreis = value;
                UpdateKalkulationPreis();
            }
        }
        public double AufPreisRate { get => _aufPreisRate; set => _aufPreisRate = value; }  // 1.0 ~1.5~ 1.2*1.5
        //public int AufPreis { get => _aufPreis; set => _aufPreis = value; }
        public bool IsNachKauf { get => _isNachKauf; set => _isNachKauf = value; }
        public HerstellerType Hersteller
        {
            get => _hersteller;
            set
            {
                _hersteller = value;
                //UpdateHersteller(_hersteller);
            }
        }
        public LieferungGrad LieferungGrad { get => _lieferungGrad; set => _lieferungGrad = value; }
        public LieferungErgebnis LieferungErgebnis
        {
            get => _lieferungErgebnis;
            set
            {
                _lieferungErgebnis = value;
                UpdateLieferungErgebnis();
            }
        }
        public List<Produktion> OutputProdukts { get => _outputProdukts; set => _outputProdukts = value; }
        public bool HasRoll { get => hasRoll; set => hasRoll = value; }


        #region Public Methode
        public string GenerateID()
        {
            //Todo
            //ID = 
            return "DefaultID";
        }
        public void UpdateKalkulationPreis()
        {
            if (Owner.PlayerName == "who")
            {
                KalkulationPreis = (int)(MarktPreis * AufPreisRate);
                return;
            }
            if (Owner.AtRomm.CurrentPhase < Phases.Phase5_1)
            {
                KalkulationPreis = (int)(MarktPreis * AufPreisRate);
            }
            else 
            {
                KalkulationPreis = (int)(HerstellerPreis * AufPreisRate);
            }

        }
        public void UpdateMarktPreis(int neuPreis)
        {
            MarktPreis = neuPreis;
            //Do something
            UpdateKalkulationPreis();
        }
        public void UpdateHerstellerPreis(int neuPreis)
        {
            HerstellerPreis = neuPreis;
            //Do something
            UpdateKalkulationPreis();
        }
        public void UpdateHersteller(HerstellerType neuHersteller)
        {
            bool dictionaryisbuild = false;
            if (dictionaryisbuild == false)
            {
                //Default Grad
                switch ((int)neuHersteller)
                {
                    case 0:  // Voltmaster -Default - Mittel
                        LieferungGrad = LieferungGrad.Mittel;
                        break;
                    case 1:  // Cablemachines -Default - Schlecht
                        LieferungGrad = LieferungGrad.Schlecht;
                        break;
                    case 2:  // Zeus_Machine -Default - Gut
                        LieferungGrad = LieferungGrad.Gut;
                        break;
                    default:
                        break;
                }
            }
            else if (dictionaryisbuild == true)
            {
                //Todo
                //LieferungGrad = CheckHerstellerkatalog(neuHersteller, this.Type, true);
            }

        }
        public void UpdateLieferungErgebnis()
        {
            if (!IsNachKauf)
            {
                //AufPreisRate = AufPreisRate <= 0.0 ? LieferungErgebnis.AufpreisRate() : AufPreisRate + LieferungErgebnis.AufpreisRate();
                AufPreisRate = 1.0 + LieferungErgebnis.AufpreisRate();
            }
            else if (IsNachKauf)  // 20% AufPreis fuer Nachkaufen
            {
                AufPreisRate = 1.2 * (1.0 + LieferungErgebnis.AufpreisRate());
            }
        }

        #endregion
    }
}

