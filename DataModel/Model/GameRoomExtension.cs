using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModel.Model
{
    public static class GameRoomExtension
    {
        public static void NextPhase(this GameRoom room)
        {
            switch (room.CurrentPhase)
            {
                case Phases.Phase1_1:
                    room.CurrentPhase = Phases.Phase1_2;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase1 Schritt2 : Zieht eine Zielkarte");
                    break;
                case Phases.Phase1_2:
                    room.CurrentPhase = Phases.Phase1_3;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase1 Schritt3 : Show ZielKarten and Creat Kalkulationtabelle");
                    break;
                case Phases.Phase1_3:
                    room.CurrentPhase = Phases.Phase2_1;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase2 Schritt1 : Read Informationsblatt VPE/MI");
                    break;
                case Phases.Phase2_1:
                    room.CurrentPhase = Phases.Phase2_2;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase2 Schritt2 : Read Dimensionierung der Betriebsmittel");
                    break;
                case Phases.Phase2_2:
                    room.CurrentPhase = Phases.Phase2_3;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase2 Schritt3 : Kaufen der Informationskarten.");
                    break;
                case Phases.Phase2_3:
                    room.CurrentPhase = Phases.Phase3_1;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase3 Schritt1 : Berechnen die Anzahl der notwendigen Maschinen, und Kauflist erstellen.");
                    break;
                case Phases.Phase3_1:
                    room.CurrentPhase = Phases.Phase3_2;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase3 Schritt2 : Legen die MaschinenPlattchen in einem idealen Layout. \n Zeit: 10min");
                    break;
                case Phases.Phase3_2:
                    room.CurrentPhase = Phases.Phase3_3;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase3 Schritt3 : Kaufen der Layoutkarten");
                    break;
                case Phases.Phase3_3:
                    room.CurrentPhase = Phases.Phase3_4;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase3 Schritt4 : Layout Anpassen");
                    break;
                case Phases.Phase3_4:
                    room.CurrentPhase = Phases.Phase3_5;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase3 Schritt5 : Bei Bedarf, Nachkaufen der Layoutkarten und Maschinnen");
                    break;
                case Phases.Phase3_5:
                    room.CurrentPhase = Phases.Phase3_6;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase3 Schritt6 : Broadcast die Informationkarten fuer Phase 3");
                    break;
                case Phases.Phase3_6:
                    room.CurrentPhase = Phases.Phase3_7;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase3 Schritt7 : Ereigniskarten fuer Phase 3");
                    break;
                case Phases.Phase3_7:
                    room.CurrentPhase = Phases.Phase4_1;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase4 Schritt1 : Broadcast die Informationkarten fuer Phase 4");
                    break;
                case Phases.Phase4_1:
                    room.CurrentPhase = Phases.Phase4_2;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase4 Schritt2 : Ereigniskarten fuer Phase 4");
                    break;
                case Phases.Phase4_2:
                    room.CurrentPhase = Phases.Phase5_1;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase5 Schritt1 : Herstellen Auswahlen");
                    break;
                case Phases.Phase5_1:
                    room.CurrentPhase = Phases.Phase5_2;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase5 Schritt2 : Broadcast die Informationkarten fuer Phase 5");
                    break;
                case Phases.Phase5_2:
                    room.CurrentPhase = Phases.Phase5_3;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase5 Schritt : Ereigniskarten fuer Phase 5");
                    break;
                case Phases.Phase5_3:
                    room.CurrentPhase = Phases.Phase6_1;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase6 Schritt1 : Lieferungsergebnis Roll");
                    break;
                case Phases.Phase6_1:
                    room.CurrentPhase = Phases.Phase6_2;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase6 Schritt2 : Ereigniskarten fuer Phase 6");
                    break;
                case Phases.Phase6_2:
                    room.CurrentPhase = Phases.Phase7_1;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase7 Schritt1 : Broadcast die Informationkarten fuer Phase 7. \n Ereigniskarten fuer Phase 7");
                    break;
                case Phases.Phase7_1:
                    room.CurrentPhase = Phases.Phase7_2;
                    //GUI
                    MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("Phase7 Schritt2 : Berechne und Vergleichen die Punkt.");
                    break;
                case Phases.Phase7_2:
                    //room.CurrentPhase = Phases.Phase1_3;
                    //GUI
                    //MainWindows.W_Instance.ShowCurrentPhase(room.CurrentPhase);
                    MessageBox.Show("End Phase");
                    break;
                default:
                    break;
            }



        }

    }
}
