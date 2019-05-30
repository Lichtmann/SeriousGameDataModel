using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class BetriebsmittelKatalog
    {
        private KabelType _kabelType;        
        private List<MaschinenType> _maschinenDimension = new List<MaschinenType>();
        private List<Maschine> _maschineKatalog;
    public BetriebsmittelKatalog(KabelType k_type)
        {
            this.KabelType = k_type;
            MaschineKatalog = new List<Maschine>();
            if (KabelType == KabelType.VPE)
            {
                MaschinenDimension = GetDimension_VPE();

                MaschineKatalog = GetKatalog_VPE();
            }
            else if (KabelType == KabelType.MI)
            {
                MaschinenDimension = GetDimension_MI();

                MaschineKatalog = GetKatalog_MI();
            }
        }

        /// <summary>
        /// Generate MaschinenDimension with relevant Kabeltype
        /// </summary>
        /// <param name="type"> KabelType</param>
        /// <returns></returns>
        public List<MaschinenType> GetDimension( KabelType type)
        {
            if (type == KabelType.MI)
            {
                return GetDimension_MI();
            }
            else if (type == KabelType.VPE)
            {
                return GetDimension_VPE();
            }
            return new List<MaschinenType>();
        }
        /// <summary>
        /// Generate MaschinenDimension for VPE
        /// </summary>
        /// <returns></returns>
        private List<MaschinenType> GetDimension_VPE()
        {
            return new List<MaschinenType>()
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
        }
        /// <summary>
        /// Generate MaschinenDimension for MI
        /// </summary>
        /// <returns></returns>
        private List<MaschinenType> GetDimension_MI()
        {
            return new List<MaschinenType>()
                {
                    MaschinenType.Grobdrahtzugmaschine1,
                    MaschinenType.Grobdrahtzugmaschine2,
                    MaschinenType.Korbverseilmaschine,
                    MaschinenType.Isolierungsanlage,    //
                    MaschinenType.Vakuumkessel,         //
                    MaschinenType.Schirmmaschine,
                    MaschinenType.Mantelmaschine
                };
        }

        public List<Maschine> GetKatalog(KabelType type)
        {
            if (type == KabelType.MI)
            {
                return GetKatalog_MI();
            }
            else if (type == KabelType.VPE)
            {
                return GetKatalog_VPE();
            }
            return new List<Maschine>();
        }
        private List<Maschine> GetKatalog_VPE()
        {
            List<Maschine> newKatalog = new List<Maschine>();
            newKatalog.Add(MaschinenType.Grobdrahtzugmaschine1.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Grobdrahtzugmaschine2.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Korbverseilmaschine.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Vernetzungsanlage1.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Vernetzungsanlage2.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Temperkammer.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Schirmmaschine.GetDefaultMaschine(KabelType.VPE));
            newKatalog.Add(MaschinenType.Mantelmaschine.GetDefaultMaschine());
            return newKatalog;
        }
        private List<Maschine> GetKatalog_MI()
        {
            List<Maschine> newKatalog = new List<Maschine>();
            newKatalog.Add(MaschinenType.Grobdrahtzugmaschine1.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Grobdrahtzugmaschine2.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Korbverseilmaschine.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Isolierungsanlage.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Vakuumkessel.GetDefaultMaschine());
            newKatalog.Add(MaschinenType.Schirmmaschine.GetDefaultMaschine(KabelType.MI));
            newKatalog.Add(MaschinenType.Mantelmaschine.GetDefaultMaschine());
            return newKatalog;
        }

        public List<MaschinenType> MaschinenDimension { get => _maschinenDimension; set => _maschinenDimension = value; }
        public KabelType KabelType { get => _kabelType; set => _kabelType = value; }

        /// <summary>
        /// List of Maschine, Zeigen Preis, Area and Produktion Information.
        /// </summary>
        public List<Maschine> MaschineKatalog { get => _maschineKatalog; set => _maschineKatalog = value; }
        /// <summary>
        /// Set neu KabelType, Update MaschinenDimension and MaschineKatalog
        /// </summary>
        /// <param name="neuType"></param>
        public void SetKabelType(KabelType neuType)
        {
            if (neuType == this.KabelType) return;
            this.KabelType = neuType;
            MaschinenDimension.Clear();
            MaschinenDimension = GetDimension(this.KabelType);
            MaschineKatalog.Clear();
            MaschineKatalog = GetKatalog(this.KabelType);
        }
    }
}
