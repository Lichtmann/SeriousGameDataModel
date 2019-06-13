using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class KalkulationRecord
    {
        private Phases _phase;
        private string _eventName;
        private string _description;
        //private  Type
        private int _amount;
        private object _recordObject;


        public Phases Phase { get => _phase; set => _phase = value; }
        public string EventName { get => _eventName; set => _eventName = value; }
        public int MoneyAmount { get => _amount; set => _amount = value; }
        public string Description { get => _description; set => _description = value; }
        public object RecordObject { get => _recordObject; set => _recordObject = value; }
    }

}
