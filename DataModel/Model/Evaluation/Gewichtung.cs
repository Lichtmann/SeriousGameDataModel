using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.Evaluation
{
    public class Gewichtung
    {
        public Gewichtung()
        {
            MaterialflussGewichtung = 1;
            ErweiterbarkeitGewichtung = 1;
            BudgetGewichtung = 1;
        }

        public Gewichtung(int m_g, int e_g, int b_g)
        {
            MaterialflussGewichtung = m_g;
            ErweiterbarkeitGewichtung = e_g;
            BudgetGewichtung = b_g;
        }

        private int _materialflussGewichtung;
        private int _erweiterbarkeitGewichtung;
        private int _budgetGewichtung;

        public int MaterialflussGewichtung { get => _materialflussGewichtung; set => _materialflussGewichtung = value; }
        public int ErweiterbarkeitGewichtung { get => _erweiterbarkeitGewichtung; set => _erweiterbarkeitGewichtung = value; }
        public int BudgetGewichtung { get => _budgetGewichtung; set => _budgetGewichtung = value; }

        public override string ToString()
        {
            return "M: " + MaterialflussGewichtung + "; E: " + ErweiterbarkeitGewichtung + "; B: " + BudgetGewichtung;
        }
    }
}

