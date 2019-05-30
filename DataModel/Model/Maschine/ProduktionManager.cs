using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{

    public class ProduktionMenge
    {
        private Material _produkt;
        private int _menge;
        public ProduktionMenge()
        {
        }
        public ProduktionMenge( Material p, int menge)
        {            
            Produkt = p;
            Menge = menge;
        }

        public int Menge { get => _menge; set => _menge = value; }
        public Material Produkt { get => _produkt; set => _produkt = value; }
    }

    public class ProduktionManager
    {
        private KabelType _kabelType;
        private Player owner;
        private List<Material> _produktsDimension;
        private List<ProduktionMenge> _zielMengen;

        public ProduktionManager()
        {
        }
        public ProduktionManager(Player owner, /*KabelType kabeltype,*/ int zielMengeOfKabel)
        {
            Owner = owner;
            KabelType = Owner.MyBetriebsmittelKatalog.KabelType;
            GenerateProduktsDimension();
            GenerateZielMengenList();
            SetZielMengen(zielMengeOfKabel);
        }

        private void GenerateZielMengenList()
        {
            ZielMengen = new List<ProduktionMenge>();
            foreach (Material material in ProduktsDimension)
            {
                if (material == Material.KupferCoil)
                {
                    ZielMengen.Add(new ProduktionMenge(material, 0));
                }
                else
                {
                    ZielMengen.Add(new ProduktionMenge(material, 1));
                }
            }
        }

        private void SetZielMengen(int zielMengeOfKabel)
        {
            if (KabelType == KabelType.MI)
            {
                // ZielMenge von MI Kabel
                int _RequiredMenge = zielMengeOfKabel;
                ZielMengen.First(p => p.Produkt == Material.Kabel).Menge = _RequiredMenge;
                // ZielMenge von Geschirmte Ader (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.GeschirmteAder, Material.Kabel);
                ZielMengen.First(p => p.Produkt == Material.GeschirmteAder).Menge = _RequiredMenge;
                //# ? MI Schirmmaschine need just one Input?
                // ZielMenge von Getrocknete Ader (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.GetrockneteAder, Material.GeschirmteAder);
                ZielMengen.First(p => p.Produkt == Material.GetrockneteAder).Menge = _RequiredMenge;
                // ZielMenge von Isolierter Leiter (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.IsolierterLeiter, Material.GetrockneteAder);
                ZielMengen.First(p => p.Produkt == Material.IsolierterLeiter).Menge = _RequiredMenge;
                // ZielMenge von  Leiter (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.Leiter, Material.IsolierterLeiter);
                ZielMengen.First(p => p.Produkt == Material.Leiter).Menge = _RequiredMenge;
                // ZielMenge von  Leiterdraht (100:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.Leiterdraht, Material.Leiter);
                ZielMengen.First(p => p.Produkt == Material.Leiterdraht).Menge = _RequiredMenge;
                // ZielMenge von  KupferCoil (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.KupferCoil, Material.Leiterdraht);
                ZielMengen.First(p => p.Produkt == Material.KupferCoil).Menge = _RequiredMenge;
            }
            else if (KabelType == KabelType.VPE)
            {
                // ZielMenge von MI Kabel
                int _RequiredMenge = zielMengeOfKabel;
                ZielMengen.First(p => p.Produkt == Material.Kabel).Menge = _RequiredMenge;
                // ZielMenge von Geschirmte Ader (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.GeschirmteAder, Material.Kabel);
                ZielMengen.First(p => p.Produkt == Material.GeschirmteAder).Menge = _RequiredMenge;
                //# VPE Schirmmaschine need Getemperte Ader and Schirmdraht.
                // ZielMenge von GetemperteAder (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.GetemperteAder, Material.GeschirmteAder);
                // ZielMenge von GetemperteAder (50:1)
                int _RequiredSchirmdraht = _RequiredMenge * GetInputOutputRate(Material.Schirmdraht, Material.GeschirmteAder);
                ZielMengen.First(p => p.Produkt == Material.GetemperteAder).Menge = _RequiredMenge;
                ZielMengen.First(p => p.Produkt == Material.Schirmdraht).Menge = _RequiredSchirmdraht;

                // ZielMenge von Ader (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.Ader, Material.GetemperteAder);
                ZielMengen.First(p => p.Produkt == Material.Ader).Menge = _RequiredMenge;
                // ZielMenge von  Leiter (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.Leiter, Material.Ader);
                ZielMengen.First(p => p.Produkt == Material.Leiter).Menge = _RequiredMenge;
                // ZielMenge von  Leiterdraht (100:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.Leiterdraht, Material.Leiter);
                ZielMengen.First(p => p.Produkt == Material.Leiterdraht).Menge = _RequiredMenge;
                // ZielMenge von  KupferCoil (1:1)
                _RequiredMenge = _RequiredMenge * GetInputOutputRate(Material.KupferCoil, Material.Leiterdraht);
                ZielMengen.First(p => p.Produkt == Material.KupferCoil).Menge = _RequiredMenge + _RequiredSchirmdraht * 1;
            }
        }

        private int GetInputOutputRate(Material InputMaterial, Material OutputMaterial )
        {
            //Katalog
            List<Maschine> maschinenKatalog = Owner.MyBetriebsmittelKatalog.MaschineKatalog;
            // Maschine, die OutputMaterial herstellen
            Maschine maschine = maschinenKatalog.First(m => m.OutputProdukts.Any( p => p.OutputProdukt == OutputMaterial));
            // 
            List<InputRequire> inputs =  maschine.OutputProdukts.First(p => p.OutputProdukt == OutputMaterial).InputProdukts;
            int rate = inputs.First(r => r.InputProdukt == InputMaterial).Rate;
            //.OutputProdukts.First().InputProdukts.First().Rate;
            // Check for Safety?
            return rate;
        }

        private void GenerateProduktsDimension()
        {
            if (KabelType == KabelType.MI)
            {
                ProduktsDimension = new List<Material>()
                {
                    Material.Kabel,
                    Material.GeschirmteAder,
                    Material.GetrockneteAder,
                    Material.IsolierterLeiter,
                    Material.Leiter,
                    Material.Leiterdraht,
                    Material.KupferCoil
                };
            }
            else if (KabelType == KabelType.VPE)
            {
                ProduktsDimension = new List<Material>()
                {
                    Material.Kabel,
                    Material.GeschirmteAder,
                    Material.GetemperteAder,
                    Material.Ader,
                    Material.Leiter,
                    Material.Schirmdraht,
                    Material.Leiterdraht,
                    Material.KupferCoil
                };
            }

        }

        public KabelType KabelType { get => _kabelType; set => _kabelType = value; }
        public List<Material> ProduktsDimension { get => _produktsDimension; set => _produktsDimension = value; }
        public List<ProduktionMenge> ZielMengen { get => _zielMengen; set => _zielMengen = value; }
        public Player Owner { get => owner; set => owner = value; }
    }
}
