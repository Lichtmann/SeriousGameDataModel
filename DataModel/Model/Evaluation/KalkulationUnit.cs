using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class KalkulationUnit
    {
        private int _budget;
        private int _kosten;
        private int _balance;

        public KalkulationUnit()
        {
        }


        public int Budget { get => _budget; set => _budget = value; }
        public int Kosten { get => _kosten; set => _kosten = value; }
        public int Balance { get => Budget - Kosten; /*set => _balance = value;*/ }

        public void AddBudget(int money)
        {
            if (money > 0)
            {
                Budget += money;
            }
        }

        public void AddKosten(int kost)
        {
            Kosten += kost;
        }
    }
}

