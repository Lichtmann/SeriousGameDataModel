using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class KostenRecord : KalkulationRecord
    {
        //private Phases _phase;
        //private string _eventName;
        private KostenType _kostenType;
        //private int _amount;

        public KostenRecord()
        {
            this.Phase = Phases.Phase2_1;
            this.EventName = "Empty";
            this.MoneyAmount = 0;
        }


        public KostenRecord(Phases currentPhase, KostenType kostenType, int MoneyAmount = 0)
        {
            this.Phase = currentPhase;
            this.KostenType = kostenType;
            this.MoneyAmount = MoneyAmount;
        }

        public KostenType KostenType { get => _kostenType; set => _kostenType = value; }

        public override string ToString()
        {
            if (this.EventName == "LayoutUnitKosten")
            {

            return this.Phase + "## " + this.EventName + "####" + this.MoneyAmount + " ##" + this.Description;
            }
            else if (this.EventName == "MaschinenKosten")
            {
                return this.Phase + "## " + this.EventName + "####" + this.MoneyAmount + " ##" + this.Description;
            }

            return this.Phase + "## " + this.EventName + "####" + this.MoneyAmount;
        }
    }
}
