using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class MaschinenManager
    {
        private KabelType _produktionType = KabelType.MI; //Default
        private List<Maschine> _maschinen;

        public MaschinenManager()
        {
        }
        public MaschinenManager(KabelType type)
        {
            ProduktionType = type;
        }

        //Public Property
        public KabelType ProduktionType { get => _produktionType; set => _produktionType = value; }
        public List<Maschine> MaschinenList { get => _maschinen ?? new List<Maschine>(); set => _maschinen = value; }
        public int MaschinenAnzahl { get => MaschinenList.Count; /* set;*/ }

        //Public Methode
        public void AddMaschine()
        {

        }

        public void DeleteMaschie()
        {

        }

        public int GetCostofALlMaschinenWithMarktPreis()
        {
            int summe = MaschinenList.Select(m => m.MarktPreis).Sum();
            return summe;
        }

        public void UpdateMarktPreis(MaschinenType type, int neuPreis)
        {
            //List<Maschine> maschinen = MaschinenList.Where(m => m.Type == type).ToList();

            foreach (var m in MaschinenList.Where(m => m.Type == type))
            {
                m.MarktPreis = neuPreis;
            }
        }

    }
}

