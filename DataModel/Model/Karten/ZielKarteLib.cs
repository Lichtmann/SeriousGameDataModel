using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModel.Model.Karten
{
    /// <summary>
    /// Extension von Zielkarte
    /// </summary>
    public static class ZielKarteLib
    {
        /// <summary>
        /// 
        /// </summary>
        static int karteMenge  = 6;

        /// <summary>
        /// Automatisch generieren ein Karetn Nach Lib Definierte Menge und Inhalte.
        /// </summary>
        /// <returns></returns>
        public static ZielKarte GetRandomZielKarte()
        {
            return GetRandomID().GetZielKarteWithID();
        }

        /// <summary>
        /// Lib of Karten, Stellen hier die Inhalt und Activitaet von Karten
        /// </summary>
        /// <param name="Zi_id"></param>
        /// <returns></returns>
        public static ZielKarte GetZielKarteWithID(this string Zi_id)
        {
            ZielKarte zcard;
            //check a Resource dictinary/Datenbank
            switch (Zi_id)
            {
                case "Zi-01":
                    zcard = new ZielKarte(31000000, 2500, new Gewichtung(2, 3, 1));
                    zcard.SetID("Zi-01");
                    zcard.IsActive = true;
                    break;
                case "Zi-02":
                    zcard = new ZielKarte(27000000, 1400, new Gewichtung(1, 3, 2));
                    zcard.SetID("Zi-02");
                    zcard.IsActive = true;
                    break;
                case "Zi-03":
                    zcard = new ZielKarte(24000000, 750, new Gewichtung(3, 1, 2));
                    zcard.SetID("Zi-03");
                    zcard.IsActive = true;
                    break;
                case "Zi-04":
                    zcard = new ZielKarte(24000000, 750, new Gewichtung(1, 2, 3));
                    zcard.SetID("Zi-04");
                    zcard.IsActive = true;
                    break;
                case "Zi-05":
                    zcard = new ZielKarte(27000000, 1500, new Gewichtung(3, 2, 1));
                    zcard.SetID("Zi-05");
                    zcard.IsActive = true;
                    break;
                case "Zi-06":
                    zcard = new ZielKarte(38000000, 3000, new Gewichtung(2, 1, 3));
                    zcard.SetID("Zi-06");
                    zcard.IsActive = true;
                    break;
                default:
                    zcard = new ZielKarte();
                    zcard.SetID("Zi-00");
                    break;
            }
            return zcard;
        }

        /// <summary>
        /// Get a Random ID of ZielKarte
        /// </summary>
        /// <returns></returns>
        public static string GetRandomID()
        {
            return "Zi-" + GetRandomNumber().ToString().PadLeft(2, '0');
        }

        public static int GetRandomNumber()
        {
            Random ran = new Random();
            return ran.Next(1, karteMenge);
        }

        public static string RenderAsString(this ZielKarte zielKarte)
        {
            return "ZielKarte: " + zielKarte.ID + "\n" + "Vorgaben" + "\n" +
                            "Budget: " + zielKarte.StartBudget.ToString("N0") + "€" + "\n" +
                            "Menge:  " + zielKarte.Produktionsmenge.ToString() + " m/Tag" + "\n" +
                            "Bewertungskriterien:\n" +
                            zielKarte.Gewichtung.MaterialflussGewichtung + "x Materialfluss\n" +
                            zielKarte.Gewichtung.ErweiterbarkeitGewichtung + "x Erweiterbarkeit\n" +
                            zielKarte.Gewichtung.BudgetGewichtung + "x Budget\n";
        }

        public static void ShowAsMessageBox(this ZielKarte zielKarte)
        {
            MessageBox.Show(zielKarte.RenderAsString(), "ZielKarte");
        }

        public static void ShowInDataGridView(this ZielKarte zielKarte, DataGridView view)
        {
            view.Rows[0].Cells[1].Value = zielKarte.ID;
            view.Rows[1].Cells[1].Value = zielKarte.StartBudget;
            view.Rows[2].Cells[1].Value = zielKarte.Produktionsmenge;
            view.Rows[3].Cells[1].Value = zielKarte.Gewichtung.MaterialflussGewichtung;
            view.Rows[4].Cells[1].Value = zielKarte.Gewichtung.ErweiterbarkeitGewichtung;
            view.Rows[5].Cells[1].Value = zielKarte.Gewichtung.BudgetGewichtung;
        }


    }
}
