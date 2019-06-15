using DataModel.Model.Karten;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public static class RecordLib
    {
        public static string ToEuro(this int money, int padWidth =20, int decWidth = 0)
        {
            CultureInfo de = new CultureInfo("de-DE");
            string form = "C" + decWidth.ToString();
            return money.ToString("C0", de).PadLeft(padWidth);
        }

        public static string ToNum(this int money, int padWidth = 15, int decWidth = 0)
        {
            CultureInfo de = new CultureInfo("de-DE");
            string form = "C" + decWidth.ToString();
            return money.ToString("N0", de).PadLeft(padWidth);
        }

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
            if (player.KalkulationUnit.KostenRecordList.Any(r => r.EventName == "LayoutUnitKosten"))
            {
                var record = player.KalkulationUnit.KostenRecordList.First(r => r.EventName == "LayoutUnitKosten");
                record.MoneyAmount = player.LayoutUnitList.Sum(l => l.EndKosten);
                int newL = player.LayoutUnitList.Where(l => l.Type == LayoutUnitType.NewLayout).Count();
                int oldL = player.LayoutUnitList.Where(l => l.Type == LayoutUnitType.OldLayout).Count();
                record.Description = "" + newL + "[New]/" + oldL + "[Old]";
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

        public static void BuyMaschinenRecord(this Player player/*, LayoutUnit layoutUnit*/)
        {
            if (player.KalkulationUnit.KostenRecordList.Any(r => r.EventName == "MaschinenKosten"))
            {
                var record = player.KalkulationUnit.KostenRecordList.First(r => r.EventName == "MaschinenKosten");
                record.MoneyAmount = player.MaschinenList.Sum(m => m.KalkulationPreis);
                player.KalkulationUnit.DoKostenCount();
                return;
            }
            int currentkosten = player.MaschinenList.Sum(m => m.KalkulationPreis);
            KostenRecord k_event = new KostenRecord(player.AtRomm.CurrentPhase, KostenType.BuyMaschinen, currentkosten);
            k_event.EventName = "MaschinenKosten";
            k_event.Description = "";
            player.KalkulationUnit.KostenRecordList.Add(k_event);
            player.KalkulationUnit.DoKostenCount();
        }
          
        public static void ZeitStrafeRecord(this Player player)
        {
            if (player.AtRomm.CurrentPhase <= Phases.Phase3_2)
            {
                if (player.KalkulationUnit.KostenRecordList.Any(r => r.EventName == "ZeitStrafe1"))
                {
                    var record = player.KalkulationUnit.KostenRecordList.First(r => r.EventName == "ZeitStrafe1");
                    record.MoneyAmount += 200000;
                    record.Description = (record.MoneyAmount / 200000).ToString() + "min";
                    player.KalkulationUnit.DoKostenCount();
                    return;
                }
                int currentkosten = 200000;
                KostenRecord k_event = new KostenRecord(player.AtRomm.CurrentPhase, KostenType.TimeoutFee, currentkosten);
                k_event.EventName = "ZeitStrafe1";
                k_event.Description = "1 min";
                player.KalkulationUnit.KostenRecordList.Add(k_event);
                player.KalkulationUnit.DoKostenCount();
            }
            else if (player.AtRomm.CurrentPhase <= Phases.Phase3_5)
            {
                if (player.KalkulationUnit.KostenRecordList.Any(r => r.EventName == "ZeitStrafe2"))
                {
                    var record = player.KalkulationUnit.KostenRecordList.First(r => r.EventName == "ZeitStrafe2");
                    record.MoneyAmount += 200000;
                    record.Description = (record.MoneyAmount / 200000).ToString() + "min";
                    player.KalkulationUnit.DoKostenCount();
                    return;
                }
                int currentkosten = 200000;
                KostenRecord k_event = new KostenRecord(player.AtRomm.CurrentPhase, KostenType.TimeoutFee, currentkosten);
                k_event.EventName = "ZeitStrafe2";
                k_event.Description = "1 min";
                player.KalkulationUnit.KostenRecordList.Add(k_event);
                player.KalkulationUnit.DoKostenCount();
            }




        }

    }

}
