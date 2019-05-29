using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public static class MaschineExtension
    {
        /// <summary>
        /// Default Maschine is Korbverseilmaschine
        /// </summary>
        /// <returns></returns>
        public static Maschine GenerateMusterMaschine()
        {
            Maschine maschine = new Maschine()
            {
                Type = MaschinenType.Korbverseilmaschine,
                MarktPreis = 4500000,
                Area = 1600,
                OutputProdukts = new List<Produktion>()
                {
                    new Produktion()
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
                    }
                }
            };
            return maschine;
        }
        public static Maschine DefaultGrobdrahtzugmaschine1()
        {
            Maschine maschine = new Maschine()
            {
                Type = MaschinenType.Grobdrahtzugmaschine1,
                MarktPreis = 200000,
                Area = 200,
                OutputProdukts = new List<Produktion>()
                {
                    new Produktion()
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
                    },
                    new Produktion()
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
                    }
                }
            };
            return maschine;
        }
        public static Maschine DefaultGrobdrahtzugmaschine2()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Grobdrahtzugmaschine2;
            defaultMaschine.MarktPreis = 300000;
            defaultMaschine.Area = 300;
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.Leiterdraht.SingleInputProduktion();
            produktion.MaxMenge = 250000;
            defaultMaschine.OutputProdukts.Add(produktion);
            produktion = Material.Schirmdraht.SingleInputProduktion();
            produktion.MaxMenge = 200;
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultVakuumkessel()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Vakuumkessel;
            defaultMaschine.MarktPreis = 1000000;
            defaultMaschine.Area = 400;
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.GetrockneteAder.SingleInputProduktion();
            produktion.MaxMenge = 400;
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultIsolierungsanlage()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Isolierungsanlage;   //#
            defaultMaschine.MarktPreis = 4250000;                       //#
            defaultMaschine.Area = 700;                                //#
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.IsolierterLeiter.SingleInputProduktion();   //#
            produktion.MaxMenge = 500;                                //#
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultMantelmaschine()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Mantelmaschine;   //#
            defaultMaschine.MarktPreis = 1500000;                       //#
            defaultMaschine.Area = 700;                                //#
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.Kabel.SingleInputProduktion();   //#
            produktion.MaxMenge = 20000;                                //#
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultSchirmmaschine_MI()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Schirmmaschine;   //#
            defaultMaschine.MarktPreis = 750000;                       //#
            defaultMaschine.Area = 500;                                //#
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.GeschirmteAder.GeschirmteAder_MI();   //#
            produktion.MaxMenge = 20000;                                //#
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultSchirmmaschine_VPE()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Schirmmaschine;   //#
            defaultMaschine.MarktPreis = 750000;                       //#
            defaultMaschine.Area = 500;                                //#
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.GeschirmteAder.GeschirmteAder_VPE();   //#
            produktion.MaxMenge = 20000;                                //#
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultTemperkammer()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Temperkammer;   //#
            defaultMaschine.MarktPreis = 1000000;                       //#
            defaultMaschine.Area = 400;                                //#
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.GetemperteAder.SingleInputProduktion();   //#
            produktion.MaxMenge = 400;                                //#
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultVernetzungsanlage2()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Vernetzungsanlage2;    //#
            defaultMaschine.MarktPreis = 2500000;                       //#
            defaultMaschine.Area = 1200;                                //#
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.Ader.SingleInputProduktion();     //#
            produktion.MinMenge = 250;                                //#
            produktion.MaxMenge = 750;                                //#
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultVernetzungsanlage1()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Vernetzungsanlage1;    //#
            defaultMaschine.MarktPreis = 5000000;                       //#
            defaultMaschine.Area = 1500;                                //#
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.Ader.SingleInputProduktion();     //#
            produktion.MinMenge = 1500;                                //#
            produktion.MaxMenge = 2500;                                //#
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }
        private static Maschine DefaultKorbverseilmaschine()
        {
            Maschine defaultMaschine = GenerateMusterMaschine();
            defaultMaschine.Type = MaschinenType.Korbverseilmaschine;   //#
            defaultMaschine.MarktPreis = 4500000;                       //#
            defaultMaschine.Area = 1600;                                //#
            defaultMaschine.OutputProdukts.Clear();
            var produktion = Material.Leiter.SingleInputProduktion();   //#
            produktion.MaxMenge = 50000;                                //#
            defaultMaschine.OutputProdukts.Add(produktion);
            return defaultMaschine;
        }

        /// <summary>
        /// Generate a default Schirmmaschine with relevant MaschinenType and kableType
        /// </summary>
        /// <param name="m_type"></param>
        /// <param name="kabeltype"></param>
        /// <returns></returns>
        public static Maschine GetDefaultMaschine(this MaschinenType m_type, KabelType kabeltype)
        {
            if (kabeltype == KabelType.MI)
            {
                return DefaultSchirmmaschine_MI();
            }
            else if (kabeltype == KabelType.VPE)
            {
                return DefaultSchirmmaschine_VPE();
            }
            return null;
        }
        /// <summary>
        /// Generate a default Maschine with relevant MaschinenType
        /// </summary>
        /// <param name="m_type"></param>
        /// <returns></returns>
        public static Maschine GetDefaultMaschine(this MaschinenType m_type)
        {
            if (m_type == MaschinenType.Grobdrahtzugmaschine1)
            {
                return DefaultGrobdrahtzugmaschine1();
            }
            else if (m_type == MaschinenType.Grobdrahtzugmaschine2)
            {
                return DefaultGrobdrahtzugmaschine2();
            }
            else if (m_type == MaschinenType.Korbverseilmaschine)
            {
                return DefaultKorbverseilmaschine();
            }
            else if (m_type == MaschinenType.Vernetzungsanlage1)
            {
                return DefaultVernetzungsanlage1();
            }
            else if (m_type == MaschinenType.Vernetzungsanlage2)
            {
                return DefaultVernetzungsanlage2();
            }
            else if (m_type == MaschinenType.Temperkammer)
            {
                return DefaultTemperkammer();
            }            
            else if (m_type == MaschinenType.Mantelmaschine)
            {
                return DefaultMantelmaschine();
            }
            else if (m_type == MaschinenType.Isolierungsanlage)
            {
                return DefaultIsolierungsanlage();
            }
            else if (m_type == MaschinenType.Vakuumkessel)
            {
                return DefaultVakuumkessel();
            }
            return null;
        }

       
    }
}
