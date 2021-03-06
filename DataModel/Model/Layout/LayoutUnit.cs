﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.Layout
{
    public class LayoutUnit
    {
        //Identify [Fest][Initial]
        private string _name; // Ln-01, La-01~La-10;
        private string _id;   // 00
        //Player
        private Player _owner;
        //Type [Fest][Initial]
        private LayoutUnitType _type;
        //Preis [Initial][EventChange]
        private int _endKosten;  // Endkosten = UnitPreis + Saeulenkosten;
        private int _unitPreis;  // unitPreis = defaultpreis - discountUnitpreis + (int)isNachKauf *nachkaufUnitPreis
        private int _UnitPreisChange;
        private int _nachkaufUnitPreis = 500000;
        private int _saeulenUnitPreis = 650000;
        private int _saeulenKosten;
        private bool _isNachKauf = false;
        //Area [Initial][EventChange]
        public const int UnitArea = 100;
        private int _availableUnit; //81
        private int _availableArea; //8100

        //layoutStatus [Initial][EventChange] : 1: Frei , 0 Besitzt
        int[,] _layoutStatus;   // = new int[9, 9];

        //

        public LayoutUnit()
        {
            this.Type = LayoutUnitType.NewLayout;
            this.UnitPreisChange = 0;
            this.IsNachKauf = false;
            this.SaeulenKosten = 0;
            this.LayoutStatus = new int[9, 9];
            SetMatrixAllTo(LayoutStatus, 0);
            //this.AvailableUnit = GetAvailableUnit(LayoutStatus);
            //this.AvailableArea = AvailableUnit * UnitArea;
        }

        public LayoutUnit(LayoutUnitType type, bool isnachkauf = false, int nachkaufpreis = 500000) : this()
        {
            this.Type = type;
            this.Name = Type.ToString();
            this.IsNachKauf = isnachkauf;
            this.NachkaufUnitPreis = nachkaufpreis;
            this.UnitPreis = Type.DefaultPreis() + UnitPreisChange + (IsNachKauf ? 1 : 0) * NachkaufUnitPreis;
            this.EndKosten = UnitPreis + SaeulenKosten;
            //Set Saulen()  // Todo
            //this.AvailableUnit = GetAvailableUnit(LayoutStatus);
            //this.AvailableArea = AvailableUnit * UnitArea;
        }

        public string Name { get => _name; set => _name = value; }
        public string ID { get => _id; set => _id = value; }
        public LayoutUnitType Type { get => _type; set => _type = value; }
        public int EndKosten { get => _endKosten; set => _endKosten = value; }
        public int UnitPreis { get => _unitPreis; set => _unitPreis = value; }
        public int UnitPreisChange { get => _UnitPreisChange; set => _UnitPreisChange = value; }
        public int NachkaufUnitPreis { get => _nachkaufUnitPreis; set => _nachkaufUnitPreis = value; }
        public int SaeulenUnitPreis { get => _saeulenUnitPreis; set => _saeulenUnitPreis = value; }
        public int SaeulenKosten { get => _saeulenKosten; set => _saeulenKosten = value; }
        public bool IsNachKauf { get => _isNachKauf; set => _isNachKauf = value; }
        public int[,] LayoutStatus { get => _layoutStatus; set => _layoutStatus = value; }
        public int AvailableUnit { get => GetAvailableUnit(LayoutStatus); /*set => _availableUnit = value;*/ }
        public int AvailableArea { get => AvailableUnit * UnitArea; /*set => _availableArea = value;*/ }
        public Player Owner { get => _owner; set => _owner = value; }

        public void SetMatrixAllTo(int[,] matrix, int number)
        {
            for (int i = 0; i < matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1); j++)
                {
                    matrix[i, j] = number;
                }
            }
        }

        public int GetAvailableUnit(int[,] matrix)
        {
            int sum = 0;
            foreach (int cell in matrix)
            {
                // cell == 0: cell is free
                if (cell == 0 ) sum += 1;
            }
            return sum;
        }


    }

}

