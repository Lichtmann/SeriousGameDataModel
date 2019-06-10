using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class KalkulationUnit
    {
        private Player owner;
        private int _budget;
        private int _kosten;
        private int _balance;

        private List<BudgetRecord> _budgetRecordList = new List<BudgetRecord>();
        private List<KostenRecord> _kostenRecordList = new List<KostenRecord>();

        public KalkulationUnit()
        {

        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="startbudget"></param>
        public KalkulationUnit(Player owner/*, int startbudget*/)
        {
            Owner = owner;
            Budget = 0; ///
            Kosten = 0;            
        }

        public int Budget { get => _budget; set => _budget = value; }
        public int Kosten { get => _kosten; set => _kosten = value; }
        public int Balance { get => Budget - Kosten; /*set => _balance = value;*/ }
        public Player Owner { get => owner; set => owner = value; }
        public List<BudgetRecord> BudgetRecordList { get => _budgetRecordList; set => _budgetRecordList = value; }
        public List<KostenRecord> KostenRecordList { get => _kostenRecordList; set => _kostenRecordList = value; }

        public void DoBudgetCount()
        {
            if (BudgetRecordList.Count == 0) return;
            Budget = BudgetRecordList.Sum(b => b.MoneyAmount);
        }

        public void DoKostenCount()
        {
            if (KostenRecordList.Count == 0) return;
            Kosten = KostenRecordList.Sum(k => k.MoneyAmount);
        }
        //public void AddBudget(int money)
        //{
        //    if (money > 0)
        //    {
        //        Budget += money;
        //    }
        //}

        //public void AddKosten(int kost) 
        //{
        //    Kosten += kost;
        //}
    }
}

