using DataModel.Model.Karten;
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

    public static class RecordLib
    {
        public static void SetStartBudget(this Player player, int startBudget)
        {
            BudgetRecord b_event = new BudgetRecord(Phases.Phase1_3, BudgetType.StartBudget, startBudget);
            b_event.EventName = player.Zielkarte.ID;
            b_event.Description = "Startbudget, set from Zielkarte";
            player.KalkulationUnit.BudgetRecordList.Add(b_event);
            player.KalkulationUnit.DoBudgetCount();
        }

        public static void AddInforCardCostRecord(this Player player, InformationKarte card)
        {
            KostenRecord k_event = new KostenRecord(player.AtRomm.CurrentPhase, KostenType.BuyInforCard, card.KarteKosten);
            k_event.EventName = card.ID;
            k_event.Description = "Buy a Inforcard.";
            k_event.RecordObject = card;
            player.KalkulationUnit.KostenRecordList.Add(k_event);
            player.KalkulationUnit.DoKostenCount();
        }

        public static void BuyLayoutUnitRecord(this Player player/*, LayoutUnit layoutUnit*/)
        {
            if(player.KalkulationUnit.KostenRecordList.Any(r => r.EventName == "LayoutUnitKosten"))
            {
                var record = player.KalkulationUnit.KostenRecordList.First(r => r.EventName == "LayoutUnitKosten");
                record.MoneyAmount = player.LayoutUnitList.Sum(l => l.EndKosten);
                int newL = player.LayoutUnitList.Where(l => l.Type == LayoutUnitType.NewLayout).Count();
                int oldL = player.LayoutUnitList.Where(l => l.Type == LayoutUnitType.OldLayout).Count();
                record.Description = "" + newL + "[New]/" + oldL+"[Old]";
                player.KalkulationUnit.DoKostenCount();
                return;
            }
            int currentkosten = player.LayoutUnitList.Sum(l => l.EndKosten);
            KostenRecord k_event = new KostenRecord(player.AtRomm.CurrentPhase, KostenType.BuyLayoutUnit, currentkosten);
            k_event.EventName = "LayoutUnitKosten";
            k_event.Description = "1";
            player.KalkulationUnit.KostenRecordList.Add(k_event);
            player.KalkulationUnit.DoKostenCount();
        }

    }
}
