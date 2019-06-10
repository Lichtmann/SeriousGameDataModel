using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public static class LayoutUnitLib
    {

        /// <summary>
        /// FirstHandHalle 
        /// </summary>
        /// <returns></returns>
        public static LayoutUnit DrawFirstHandUnit(this Player player)
        {
            // There only on variance of neulayout: Ln-01 
            string _name = "Ln-" + 1.ToString().PadLeft(2, '0');
            // Create a Layout
            LayoutUnit unit = new LayoutUnit(LayoutUnitType.NewLayout, false);
            unit.Name = _name;
            // Gererate number of unit for identify, denn ID for Unit
            int rank = player.NewLayoutUnitList.Count + 1;
            unit.ID = _name + "-" + rank.ToString().PadLeft(2, '0');
            // no Set Sauelen() 

            //Set Owner;
            unit.Owner = player;
            ////player.LayoutUnitList.Add(unit);
            //Send back
            return unit;
        }

        public static LayoutUnit DrawFirstHandUnit_Nachkauf(this Player player)
        {
            var unit = DrawFirstHandUnit(player);
            unit.IsNachKauf = true;
            return unit;
        }

        public static LayoutUnit DrawSecondHandUnit(this Player player)
        {
            //There are 10 variance of oldLayout: La-01 ~ La-10 
            Random ran = new Random();
            int number = ran.Next(1, 10); 
            string _name = "La-" + number.ToString().PadLeft(2, '0');
            // Gererate number of unit for identify, denn ID for Unit
            LayoutUnit unit = new LayoutUnit(LayoutUnitType.OldLayout,false);
            unit.Name = _name;
            int rank = player.OldLayoutUnitList.Where(l => l.Name == _name).Count() + 1;
            unit.ID = _name + "-" + rank.ToString().PadLeft(2, '0');
            // Set Saulen
            SetSaeulenToOldUnit(unit);
            //Set Owner;
            unit.Owner = player;
            //Send back
            return unit;
        }

        public static LayoutUnit DrawSecondHandUnit_Nachkauf(this Player player)
        {
            var unit = DrawSecondHandUnit(player);
            unit.IsNachKauf = true;
            return unit;
        }

        private static void SetSaeulenToOldUnit(LayoutUnit unit)
        {
            if (unit.Name == "Ln-01") return;
            switch (unit.Name)
            {
                case "La-01":
                    // Cell == 0 is free, cell == 1 is used by saeulen., cell == 2 others .
                    unit.LayoutStatus[2, 2] = 1; 
                    unit.LayoutStatus[2, 3] = 1;
                    unit.LayoutStatus[3, 2] = 1;
                    unit.LayoutStatus[3, 3] = 1;
                    break;
                case "La-02":
                    unit.LayoutStatus[2, 6] = 1;
                    unit.LayoutStatus[2, 7] = 1;
                    unit.LayoutStatus[3, 6] = 1;
                    unit.LayoutStatus[3, 7] = 1;
                    unit.LayoutStatus[4, 6] = 1;
                    unit.LayoutStatus[4, 7] = 1;
                    break;
                case "La-03":
                    unit.LayoutStatus[2, 4] = 1;
                    unit.LayoutStatus[2, 5] = 1;
                    unit.LayoutStatus[3, 4] = 1;
                    unit.LayoutStatus[4, 3] = 1;
                    unit.LayoutStatus[4, 4] = 1;
                    break;
                case "La-04":
                    unit.LayoutStatus[0, 5] = 1;
                    unit.LayoutStatus[1, 5] = 1;
                    unit.LayoutStatus[2, 5] = 1;
                    unit.LayoutStatus[3, 5] = 1;
                    break;
                case "La-05":
                    unit.LayoutStatus[0, 2] = 1;
                    unit.LayoutStatus[1, 2] = 1;
                    unit.LayoutStatus[2, 2] = 1;
                    unit.LayoutStatus[8, 2] = 1;
                    break;
                case "La-06":
                    unit.LayoutStatus[1, 4] = 1;
                    unit.LayoutStatus[2, 4] = 1;
                    unit.LayoutStatus[5, 4] = 1;
                    unit.LayoutStatus[6, 4] = 1;
                    break;
                case "La-07":
                    unit.LayoutStatus[0, 3] = 1;
                    unit.LayoutStatus[0, 4] = 1;
                    unit.LayoutStatus[0, 5] = 1;
                    unit.LayoutStatus[0, 6] = 1;
                    break;
                case "La-08":
                    unit.LayoutStatus[1, 1] = 1;
                    unit.LayoutStatus[1, 7] = 1;
                    unit.LayoutStatus[7, 1] = 1;
                    unit.LayoutStatus[7, 7] = 1;
                    break;
                case "La-09":
                    unit.LayoutStatus[3, 3] = 1;
                    unit.LayoutStatus[3, 4] = 1;
                    unit.LayoutStatus[3, 5] = 1;
                    unit.LayoutStatus[4, 3] = 1;
                    unit.LayoutStatus[4, 4] = 1;
                    unit.LayoutStatus[4, 5] = 1;
                    break;
                case "La-10":
                    unit.LayoutStatus[3, 3] = 1;
                    unit.LayoutStatus[3, 4] = 1;
                    unit.LayoutStatus[3, 5] = 1;
                    unit.LayoutStatus[4, 3] = 1;
                    unit.LayoutStatus[4, 4] = 1;
                    unit.LayoutStatus[4, 5] = 1;
                    break;
                default:
                    break;
            }
        }

    }
}
