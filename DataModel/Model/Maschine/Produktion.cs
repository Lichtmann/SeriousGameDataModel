using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.Maschine
{
    public struct InputRequire
    {
        private Material _inputProdukt;
        private int _rate;

        public Material InputProdukt { get => _inputProdukt; set => _inputProdukt = value; }
        public int Rate { get => _rate; set => _rate = value; }
    }

    public class Produktion
    {
        private Material _outputProdukt;
        private List<InputRequire> _inputProdukts;

        private int _minMenge;
        private int _maxMenge;
        private int _zielMenge;
        private int _realMenge;
        public Produktion()
        {
            //_inputProdukts.Add(new InputRequire() { InputProdukt = Material.Ader, Rate = 1 });
        }

        public Material OutputProdukt { get => _outputProdukt; set => _outputProdukt = value; }
        public List<InputRequire> InputProdukts { get => _inputProdukts; set => _inputProdukts = value; }
        public int MinMenge { get => _minMenge; set => _minMenge = value; }
        public int MaxMenge { get => _maxMenge; set => _maxMenge = value; }
        public int ZielMenge { get => _zielMenge; set => _zielMenge = value; }
        public int RealMenge { get => _realMenge; set => _realMenge = value; }
    }
}
