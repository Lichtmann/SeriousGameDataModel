using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class BudgetRecord : KalkulationRecord
    {
        //private Phases _phase;
        //private string _eventName;
        private BudgetType _budgetType;
        //private int _amount;

        public BudgetRecord()
        {
            this.Phase = Phases.Phase1_3;
            this.EventName = "Empty";
            this.MoneyAmount = 0;
        }


        public BudgetRecord(Phases currentPhase, BudgetType budgetType, int MoneyAmount)
        {
            this.Phase = currentPhase;
            this.BudgetType = budgetType;
            this.MoneyAmount = MoneyAmount;
        }

        public BudgetType BudgetType { get => _budgetType; set => _budgetType = value; }

        public override string ToString()
        {
            return this.Phase +"## "+  this.EventName + "####" + this.MoneyAmount;
        }
    }

}
