using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model//.EnumAndAttribute
{
    public enum MaterialflussRanks
    {
        //Teilnahmeurkunde
        Teilnahmeurkunde = 0,
        //Dritter Platz
        DritterPlatz = 2,        //Zweiter Platz
        ZweiterPlatz = 4,
        //Spieler/in mit dem kürzesten Weg
        ErsterPlatz = 6
    }

    public enum KostenRanks
    {
        //Teilnahmeurkunde
        Teilnahmeurkunde = 0,
        //Dritter Platz
        DritterPlatz = 2,        //Zweiter Platz
        ZweiterPlatz = 4,
        //Preiswertester Planer: Spieler/in mit den geringsten Ausgaben
        ErsterPlatz = 6
    }

    public enum ErweiterbarkeitRanks
    {
        //Teilnahmeurkunde
        Teilnahmeurkunde = 0,
        //Dritter Platz
        DritterPlatz = 2,        //Zweiter Platz
        ZweiterPlatz = 4,
        //Spieler/in mit den meisten freien Feldern
        ErsterPlatz = 6
    }

    public enum ZuganglichkeitRanks
    {
        //Mehr als zwei Maschinen sind nicht mit einem Transportweg verbunden.
        MoreConflictOrDefault = 0,
        //Maximal zwei Maschinen sind nicht mit einem Transportweg verbunden.
        OneOrTwoConflict = 2,
        //Jede Maschine ist mit einem Transportweg verbunden.
        Allright = 4
    }

    public enum ProduzierbareRanks
    {
        //Die geforderte produzierbare Menge (Zielkarte) wurde nicht erreicht.
        NotReachGoal = 0,
        //Die geforderte produzierbare Menge (Zielkarte) wurde erreicht.
        ReachGoal = 7
    }

    public enum BudgetRanks
    {
        normal = 0,
        Overspending = -5
    }

}
