using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.Karten //.Interface
{
    public class ZielKarte : BaseKarte
    {
        //BaseKarte: ID, KarteType, KarteAbkurz, KarteKategorie, Number
        
        //Budget
        private int _startBudget;        
        //Menge
        private int _produktionsmenge;
        //Gewichtung
        private Gewichtung _gewichtung;
        //
        //private bool _isActive;

        public ZielKarte()
        {
            /*Basekarte
            ID = 
            KarteAbkurz
            KarteKategorie
            Number
            IsActive            
            */
            KarteAbkurz = KartenTypeAbkurz.Zi;    
            IsActive = false;
            StartBudget = 0;
            Produktionsmenge = 0;
            Gewichtung = new Gewichtung(1,1,1);
        }

        public ZielKarte(int startbudget, int produktionsmenge, Gewichtung gewichtung) :this()
        {
            StartBudget = startbudget;
            Produktionsmenge = produktionsmenge;
            Gewichtung = gewichtung;
            IsActive = true;
        }

        public int StartBudget { get => _startBudget; set => _startBudget = value; }
        public int Produktionsmenge { get => _produktionsmenge; set => _produktionsmenge = value; }
        public Gewichtung Gewichtung { get => _gewichtung; set => _gewichtung = value; }
        
        //public bool IsActive { get => _isActive; set => _isActive = value; }

        public void UpdateKarte(ZielKarte neuKarte)
        {
            System.Reflection.PropertyInfo[] thisps = this.GetType().GetProperties();
            System.Reflection.PropertyInfo[] newps = this.GetType().GetProperties();
            for (int i = 0; i < thisps.Length; i++)
            {
                //thisps[i].Name
            }
        }
    }
}
