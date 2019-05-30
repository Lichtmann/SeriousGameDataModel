using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public static class ProduktionExtension
    {
        public static Produktion SingleInputProduktion(this  Material _outputMaterial)
        {
            if (_outputMaterial == Material.Leiterdraht)
            {
                return new Produktion()
                {
                    OutputProdukt = Material.Leiterdraht,
                    InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.KupferCoil, Rate=1}
                            },
                    MinMenge = 0,
                    MaxMenge = 130000,
                    ZielMenge = 0,
                    RealMenge = 0
                };
            }
            else if (_outputMaterial == Material.Schirmdraht)
            {
                return new Produktion()
                {
                    OutputProdukt = Material.Schirmdraht,
                    InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.KupferCoil, Rate=1}
                            },
                    MinMenge = 0,
                    MaxMenge = 130000,
                    ZielMenge = 0,
                    RealMenge = 0
                };
            }
            else if (_outputMaterial == Material.Leiter)
            {
                return new Produktion()
                {
                    OutputProdukt = Material.Leiter,
                    InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.Leiterdraht, Rate=100}
                            },
                    MinMenge = 0,
                    MaxMenge = 50000,
                    ZielMenge = 0,
                    RealMenge = 0
                };
            }
            else if (_outputMaterial == Material.IsolierterLeiter)
            {
                return new Produktion()
                {
                    OutputProdukt = Material.IsolierterLeiter,
                    InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.Leiter, Rate=1}
                            },
                    MinMenge = 0,
                    MaxMenge = 500,
                    ZielMenge = 0,
                    RealMenge = 0
                };
            }
            else if (_outputMaterial == Material.GetrockneteAder)
            {
                return new Produktion()
                {
                    OutputProdukt = Material.GetrockneteAder,
                    InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.IsolierterLeiter, Rate=1}
                            },
                    MinMenge = 0,
                    MaxMenge = 400,
                    ZielMenge = 0,
                    RealMenge = 0
                };
            }
            else if (_outputMaterial == Material.Kabel)
            {
                return new Produktion()
                {
                    OutputProdukt = Material.Kabel,
                    InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.GeschirmteAder, Rate=1}
                            },
                    MinMenge = 0,
                    MaxMenge = 20000,
                    ZielMenge = 0,
                    RealMenge = 0
                };
            }
            else if (_outputMaterial == Material.Ader)
            {
                return new Produktion()
                {
                    OutputProdukt = Material.Ader,
                    InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.Leiter, Rate=1}
                            },
                    MinMenge = 1500,
                    MaxMenge = 2500,
                    ZielMenge = 0,
                    RealMenge = 0
                };
            }
            else if (_outputMaterial == Material.GetemperteAder)
            {
                return new Produktion()
                {
                    OutputProdukt = Material.GetemperteAder,
                    InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.Ader, Rate=1}
                            },
                    MinMenge = 0,
                    MaxMenge = 400,
                    ZielMenge = 0,
                    RealMenge = 0
                };
            }
            return null;
        }

        public static Produktion GeschirmteAder_VPE(this Material _outputmaterial)
        {
            if (_outputmaterial != Material.GeschirmteAder) return null;

            return new Produktion()
            {
                OutputProdukt = Material.GeschirmteAder,
                InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.GetemperteAder, Rate=1},
                                new InputRequire(){InputProdukt=Material.Schirmdraht, Rate=50}
                            },
                MinMenge = 0,
                MaxMenge = 20000,
                ZielMenge = 0,
                RealMenge = 0
            };            
        }

        public static Produktion GeschirmteAder_MI(this Material _outputmaterial)
        {

            if (_outputmaterial != Material.GeschirmteAder) return null;

            return new Produktion()
            {
                OutputProdukt = Material.GeschirmteAder,
                InputProdukts = new List<InputRequire>()
                            {
                                new InputRequire(){InputProdukt=Material.GetrockneteAder, Rate=1}
                                //,
                                //new InputRequire(){InputProdukt=Material.Schirmdraht, Rate=50}
                            },
                MinMenge = 0,
                MaxMenge = 20000,
                ZielMenge = 0,
                RealMenge = 0
            };
        }
    }
}
