using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.Model;
using DataModel.Model.Karten;
using DataModel.ViewPage;

namespace DataModel
{
    public partial class MainWindows : Form
    {
        //Self Instance of APP
        public static MainWindows W_Instance;
        //Game Romm Object / Manager
        private GameRoom _focusRoom;
        private List<GameRoom> _roomList;
        //Resource Manager // Todo

        //APP[Simulation]
        public MainWindows()
        {
            InitializeComponent();
            //Resource Todo: Load GameInhalte from XML File;
            //LoadGameInhalt();
            //
            W_Instance = this;
            RoomList = new  List<GameRoom>();
            FocusRoom = null;
            //InitialDataGridViewZielKarte();           
        }

        #region GameRoom Open, Update
        public GameRoom FocusRoom { get => _focusRoom; set => _focusRoom = value; }
        public List<GameRoom> RoomList { get => _roomList; set => _roomList = value; }

        private void bt_OpenRoom_Click(object sender, EventArgs e)
        {
            //Todo : GenerateRoomID();
            int neuRoomID = 100;
            GameRoom room = new GameRoom(neuRoomID);            
            RoomList.Add(room);
            UpdateFocusRoomGUI(room);
            MessageBox.Show("Phase1 Schritt1: Add Player and Select KabelType.");
            ///LoadKatalog();
        }

        public void UpdateFocusRoomGUI(GameRoom room)
        {
            FocusRoom = room;
            W_Instance.lb_RoomID.Text = "Room: " + room.RoomID;
            this.ShowCurrentPhase(room.CurrentPhase);
            ///UpdateKabelType();
        }
        #endregion

        #region Player Add, Delete,..
        private void bt_AddPlayer_Click(object sender, EventArgs e)
        {
            if (FocusRoom == null) return; 
            string generateName = FocusRoom.GenerateNewName();
            //
            int playerCount = FocusRoom.PlayerList.Count;
            PageAddPlayer addPlayerDialog = new PageAddPlayer(FocusRoom, generateName);
            addPlayerDialog.ShowDialog();
            if (FocusRoom.PlayerList.Count != playerCount)
            {
                UpdateListBoxofPlayer();
            }
        }
        private void bt_deleteplayer_Click(object sender, EventArgs e)
        {
            var player = listBox1.SelectedItem as Player;
            if (player == null) return;

            if (MessageBox.Show("Delete " + player.PlayerName + " ?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //delete
                if (FocusRoom.PlayerList.Contains(player))
                {
                    FocusRoom.PlayerList.Remove(player);
                }

                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        /// <summary>
        /// GUI Darstellung
        /// </summary>
        private void UpdateListBoxofPlayer()
        {
            listBox1.Items.Clear();
            foreach (Player p in FocusRoom.PlayerList)
            {
                listBox1.Items.Add(p);
            }
        }
        
        /// <summary>
        /// Focus Player Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem as Player; 
            // Not 100% Convert into Player Class!!
            if (item == null) return;
            toolStripFocus.Text = "Focus: " + item.PlayerName;
            label10.Text = "Player: " + item.PlayerName;
            //With Name Select Player,
            FocusRoom.FocusPlayer = FocusRoom.PlayerList.Where(p => p.PlayerName == item?.PlayerName).First();
            ClearInformationofOldPlayer();
            ShowInformationofFocusPlayer();
            if (bt_showMenge.Enabled)
            {
                ShowProduktionRequir(dataGridView_showMenge);
            }
        }



        #endregion

        #region KabelType
        public void UpdateKabelTypeGUI()
        {
            if (FocusRoom == null) return;
            W_Instance.lb_type.Text = "Type: " + FocusRoom.KabelType;
            //FocusRoom.DefaultHerstellerKatalog = new HerstellerKatalog(FocusRoom.KabelType);
        }

        private void bt_KabelType_Click(object sender, EventArgs e)
        {
            if (FocusRoom == null) return;
            if (FocusRoom.KabelType == KabelType.MI)
            {
                FocusRoom.KabelType = KabelType.VPE;
            }
            else
            {
                FocusRoom.KabelType = KabelType.MI;
            }
            UpdateKabelTypeGUI();
        }
        #endregion

        #region Start, Load Game Inhalt: Katalog,..
        /// <summary>
        /// Start Game when GameRoom, Players and KabelType is ready.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_StartGameP2_Click(object sender, EventArgs e)
        {
            //Condition to Start Game
            if (FocusRoom == null) return;
            if (FocusRoom.PlayerList.Count < 1) return;
            if (FocusRoom.KabelType == KabelType.unknow) return;
            //Unable Button
            bt_OpenRoom.Enabled = false;
            bt_AddPlayer.Enabled = false;
            bt_deleteplayer.Enabled = false;
            bt_KabelType.Enabled = false;
            bt_StartGameP2.Enabled = false; ///#
            // #!# Initial Game with GameInhalt Ressource
            FocusRoom.StartGameWithKabelType();
            // GUI Show Katalog
            RenderDefultHerstellerKatalog();
            RenderDefultBetriebsmittelKatalog();
            // GUI Summary
            MessageBox.Show("GameRoom: " + FocusRoom.RoomID 
                + "\nStart with " + FocusRoom.PlayerList.Count + " Players\n" 
                + "KabelType: " + FocusRoom.KabelType);
            // GUI Ziel 
            FocusRoom.NextPhase();
            InitialDataGridViewZielKarte();
        }
        
        public void ShowCurrentPhase(Phases phase)
        {
            this.Lb_currentPhase.Text = "Current Phase: " + phase.ToString();
        }

        public void RefreshDefultKatalog()
        {
            //Clear
            dataGridView_DefaultHerstellerKatalog.Rows.Clear();
            dataGridView_DefaultHerstellerKatalog.Columns.Clear();
            dataGridView_DefaultMaschinenKatalog.Rows.Clear();
            dataGridView_DefaultMaschinenKatalog.Columns.Clear();
            // Render
            RenderDefultHerstellerKatalog();
            RenderDefultBetriebsmittelKatalog();
        }
        private void RenderDefultHerstellerKatalog()
        {
            dataGridView_DefaultHerstellerKatalog.Columns.Add("Maschine", "Maschinen Type");
            dataGridView_DefaultHerstellerKatalog.Columns.Add("Cablemachines", "Cablemachines");
            dataGridView_DefaultHerstellerKatalog.Columns.Add("Voltmaster", "Voltmaster");
            dataGridView_DefaultHerstellerKatalog.Columns.Add("Zeus", "Zeus Maschine");
            dataGridView_DefaultHerstellerKatalog.Rows.Add(FocusRoom.DefaultHerstellerKatalog.MaschinenDimension.Count);
            
            var katalog = FocusRoom.DefaultHerstellerKatalog;
            var mlist = katalog.MaschinenDimension;

            for (int i = 0; i < mlist.Count; i++)
            {

                dataGridView_DefaultHerstellerKatalog.Rows[i].Cells[0].Value = mlist[i].ToString();
                dataGridView_DefaultHerstellerKatalog.Rows[i].Cells[1].Value = katalog.GetPreis(mlist[i], HerstellerType.Cablemachines);
                dataGridView_DefaultHerstellerKatalog.Rows[i].Cells[1].Style.BackColor = LieferungColor(katalog.GetLieferungGrad(mlist[i], HerstellerType.Cablemachines));
                dataGridView_DefaultHerstellerKatalog.Rows[i].Cells[2].Value = katalog.GetPreis(mlist[i], HerstellerType.Voltmaster);
                dataGridView_DefaultHerstellerKatalog.Rows[i].Cells[2].Style.BackColor = LieferungColor(katalog.GetLieferungGrad(mlist[i], HerstellerType.Voltmaster));
                dataGridView_DefaultHerstellerKatalog.Rows[i].Cells[3].Value = katalog.GetPreis(mlist[i], HerstellerType.Zeus_Machine);
                dataGridView_DefaultHerstellerKatalog.Rows[i].Cells[3].Style.BackColor = LieferungColor(katalog.GetLieferungGrad(mlist[i], HerstellerType.Zeus_Machine));
            }
        }

        private void RenderDefultBetriebsmittelKatalog()
        {
            dataGridView_DefaultMaschinenKatalog.Columns.Add("Maschine", "Betriebsmittel");
            dataGridView_DefaultMaschinenKatalog.Columns.Add("InputM", "Input.Material");
            dataGridView_DefaultMaschinenKatalog.Columns.Add("InputRate", "InputRate(n:1)");
            dataGridView_DefaultMaschinenKatalog.Columns.Add("OutputM", "Output.Material");
            dataGridView_DefaultMaschinenKatalog.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_DefaultMaschinenKatalog.Columns.Add("MinMenge", "MinMenge");
            dataGridView_DefaultMaschinenKatalog.Columns.Add("MaxMenge", "MaxMenge");
            dataGridView_DefaultMaschinenKatalog.Columns.Add("MarktPreis", "Preis €\n(ungefaehrt)");
            dataGridView_DefaultMaschinenKatalog.Columns.Add("Area", "Groesse(m^2)");
            
            var katalog = FocusRoom.DefaultBetriebsmittelKatalog;
            var maschinenList = katalog.MaschineKatalog;
            for (int i = 0; i < maschinenList.Count; i++)
            {
                var m_type = maschinenList[i].Type;
                dataGridView_DefaultMaschinenKatalog.Rows.Add(1);
                var index = dataGridView_DefaultMaschinenKatalog.Rows.Count - 1;
                var row = dataGridView_DefaultMaschinenKatalog.Rows[index-1];
                row.Cells[0].Value = m_type.ToString();
                row.Cells[1].Value = maschinenList[i].OutputProdukts.First().InputProdukts.First().InputProdukt.ToString();
                row.Cells[2].Value = maschinenList[i].OutputProdukts.First().InputProdukts.First().Rate;
                if (m_type == MaschinenType.Grobdrahtzugmaschine1 || m_type == MaschinenType.Grobdrahtzugmaschine2)
                {
                    row.Cells[3].Value = maschinenList[i].OutputProdukts.First().OutputProdukt.ToString()
                        + "/ \n" + maschinenList[i].OutputProdukts.ElementAt(1).OutputProdukt.ToString();
                }
                else
                {
                    row.Cells[3].Value = maschinenList[i].OutputProdukts.First().OutputProdukt.ToString();
                }
                row.Cells[4].Value = maschinenList[i].OutputProdukts.First().MinMenge;
                row.Cells[5].Value = maschinenList[i].OutputProdukts.First().MaxMenge;
                row.Cells[6].Value = maschinenList[i].MarktPreis;
                row.Cells[7].Value = maschinenList[i].Area;
                if (m_type == MaschinenType.Schirmmaschine  && katalog.KabelType == KabelType.VPE)
                {
                    dataGridView_DefaultMaschinenKatalog.Rows.Add(1);
                    index = dataGridView_DefaultMaschinenKatalog.Rows.Count - 1;
                    row = dataGridView_DefaultMaschinenKatalog.Rows[index-1];
                    row.Cells[1].Value = maschinenList[maschinenList.Count - 2].OutputProdukts.First().InputProdukts.ElementAt(1).InputProdukt.ToString();
                    row.Cells[2].Value = maschinenList[maschinenList.Count - 2].OutputProdukts.First().InputProdukts.ElementAt(1).Rate;
                }
            }
            
        }

        private Color LieferungColor(LieferungGrad lf)
        {
            if (lf == LieferungGrad.Schlecht)
            {
                return Color.LightGray;
            }
            else if (lf == LieferungGrad.Mittel)
            {
                return Color.Yellow;
            }
            else if (lf == LieferungGrad.Gut)
            {
                return Color.LightGreen;
            }
            return Color.White;
        }

        #endregion

        #region ZielKarten
        private void bt_zielKarte_Click(object sender, EventArgs e)
        {
            if (FocusRoom == null) return;
            // # Generation Methodde
            ////string CardID = ZielKarteLib.GetRandomID();
            ////ZielKarte Card = ZielKarteLib.GetZielKarteWithID(CardID);
            ZielKarte Card = ZielKarteLib.GetRandomZielKarte();
            // # Set
            SetZielKarte(FocusRoom, Card);
            // # GUI Karte Animation messagebox:
            FocusRoom.ZielKarte.ShowAsMessageBox();
            FocusRoom.ZielKarte.ShowInDataGridView(dataGridView1);
            // # BroadcastZielKarteToPlayer
            foreach (Player player in FocusRoom.PlayerList)
            {
                BroadcastZielKarteToPlayer(FocusRoom.ZielKarte, player);
            }
        }

        //GUI[Simulation]
        private void InitialDataGridViewZielKarte()
        {
            dataGridView1.Columns.Add("Aspekt", "Aspekt");
            dataGridView1.Columns.Add("Value", "Value");
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Rows.Add(6);
            dataGridView1.Rows[0].Cells[0].Value = "Karte ID";
            dataGridView1.Rows[1].Cells[0].Value = "Start Budget:";
            dataGridView1.Rows[2].Cells[0].Value = "Mengen:";
            dataGridView1.Rows[3].Cells[0].Value = "GW: Materialflus";
            dataGridView1.Rows[4].Cells[0].Value = "GW: Erweitebarkeit";
            dataGridView1.Rows[5].Cells[0].Value = "GW: Budget:";
        }

        private void SetZielKarte(GameRoom room, ZielKarte card)
        {
            //check a Resource dictinary/Datenbank
            if (card.ID == "Zi-00" && card.IsActive == false) return;
            //
            
            room.ZielKarte = card;
        }

        /// <summary>
        /// Generate a Zielkarte in Range of 1-6 randomly and Broadcast to all players.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private static void BroadcastZielKarteToPlayer(ZielKarte zielKarte, Player player)
        {
            //Zielkarte
            player.Zielkarte = zielKarte;
        }

        private void bt_nextP14_Click(object sender, EventArgs e)
        {
            bt_zielKarte.Enabled = false;
            bt_showMenge.Enabled = true;
            bt_nextP14.Enabled = false;
            toolBt_NextPhase.Enabled = true;
            foreach (Player player in FocusRoom.PlayerList)
            {
                InterpretationZielKarten(player);
            }
            listBox1.SetSelected(0, true);
            //Next
            FocusRoom.NextPhase();

            //Show Zustand  
            ShowCurrentkalkulation(FocusRoom.FocusPlayer);

        }
        /// <summary>
        /// Set Start Budget und PMenge to all player, wenn "Next Phase" click.
        /// </summary>
        /// <param name="player"></param>
        private void InterpretationZielKarten(Player player)
        {
            //Ziel Menge jeder Material
            player.MyProduktionManager = new ProduktionManager(player, player.Zielkarte.Produktionsmenge);
            //creat KalkulationUnit
            player.KalkulationUnit = new KalkulationUnit(player);
            //Set StartBudget to KalkulationUnit
            player.SetStartBudget(player.Zielkarte.StartBudget);
        }

        private void ShowProduktionRequir(DataGridView view)
        {
            if (view.Columns.Count <2)
            {
                view.Columns.Add("material", "Material");
                view.Columns.Add("RequirMenge", "Ziel Menge");
                view.Columns.Add("CanMenge", "Theoretisch Menge");
                view.Columns.Add("onlineMenge", "Runtime Menge");
            }
            view.Rows.Clear();
            ProduktionManager manager = FocusRoom.FocusPlayer.MyProduktionManager;
            for (int i = 0; i < manager.ZielMengen.Count; i++)
            {
                view.Rows.Add(1);
                var index = view.Rows.Count - 1;
                var row = view.Rows[index - 1];
                row.Cells[0].Value = manager.ZielMengen[i].Produkt.ToString();
                row.Cells[1].Value = manager.ZielMengen[i].Menge;
            }
        }
        private void bt_showMenge_Click(object sender, EventArgs e)
        {
            if (FocusRoom.FocusPlayer == null) return;
            
            ShowProduktionRequir(dataGridView_showMenge);
        }
        //GUI[Simulation]
        private string RenderZielKarte(ZielKarte zielKarte)
        {
            return "ZielKarte: " + zielKarte.ID + "\n" + "Vorgaben" + "\n" +
                            "Budget: " + zielKarte.StartBudget.ToString("N0") + "€" + "\n" +
                            "Menge:  " + zielKarte.Produktionsmenge.ToString() + " m/Tag" + "\n" +
                            "Bewertungskriterien:\n" +
                            zielKarte.Gewichtung.MaterialflussGewichtung + "x Materialfluss\n" +
                            zielKarte.Gewichtung.ErweiterbarkeitGewichtung + "x Erweiterbarkeit\n" +
                            zielKarte.Gewichtung.BudgetGewichtung + "x Budget\n";
        }
        #endregion

        #region PlayerInfomation

        public void RefreshInformationOfPlayer()
        {
            ClearInformationofOldPlayer();
            ShowInformationofFocusPlayer();
        }
        private void ClearInformationofOldPlayer()
        {
            dataGridView_MyGoal.Rows.Clear();
            dataGridView_MyGoal.Columns.Clear();

            dataGridView_herstellerKatalog.Rows.Clear();
            dataGridView_herstellerKatalog.Columns.Clear();

            dataGridView_MyBetriebmittelKatalog.Rows.Clear();
            dataGridView_MyBetriebmittelKatalog.Columns.Clear();

            dataGridView_showMenge.Rows.Clear();
            dataGridView_showMenge.Columns.Clear();
        }
        private void ShowInformationofFocusPlayer()
        {
            ShowPlayerPlayerZielKarte(dataGridView_MyGoal, FocusRoom.FocusPlayer);
            ShowPlayerHerstellerKatalog(dataGridView_herstellerKatalog, FocusRoom.FocusPlayer);
            ShowPlayerBetriebsmittelKatalog(dataGridView_MyBetriebmittelKatalog, FocusRoom.FocusPlayer);
            //ShowPlayerBetriebsmittelKatalog();
        }

        private void ShowPlayerPlayerZielKarte(DataGridView view, Player focusPlayer)
        {
            if (focusPlayer.Zielkarte.IsActive)
            {
                view.Columns.Add("Aspekt", "Aspekt");
                view.Columns.Add("Value", "Value");
                view.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                view.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                view.Rows.Add(6);
                view.Rows[0].Cells[0].Value = "Karte ID";
                view.Rows[1].Cells[0].Value = "Start Budget:";
                view.Rows[2].Cells[0].Value = "Mengen:";
                view.Rows[3].Cells[0].Value = "GW: Materialflus";
                view.Rows[4].Cells[0].Value = "GW: Erweitebarkeit";
                view.Rows[5].Cells[0].Value = "GW: Budget:";
                view.Rows[0].Cells[1].Value = focusPlayer.Zielkarte.ID;
                view.Rows[1].Cells[1].Value = focusPlayer.Zielkarte.StartBudget;
                view.Rows[2].Cells[1].Value = focusPlayer.Zielkarte.Produktionsmenge;
                view.Rows[3].Cells[1].Value = focusPlayer.Zielkarte.Gewichtung.MaterialflussGewichtung;
                view.Rows[4].Cells[1].Value = focusPlayer.Zielkarte.Gewichtung.ErweiterbarkeitGewichtung;
                view.Rows[5].Cells[1].Value = focusPlayer.Zielkarte.Gewichtung.BudgetGewichtung;
            }
        }

        private void ShowPlayerHerstellerKatalog(DataGridView view, Player focusPlayer)
        {
            view.Columns.Add("Maschine", "Maschinen Type");
            view.Columns.Add("Cablemachines", "Cablemachines");
            view.Columns.Add("Voltmaster", "Voltmaster");
            view.Columns.Add("Zeus", "Zeus Maschine");

            var katalog = focusPlayer.MyHerstellerKatalog;
            if (katalog == null)
            {
                MessageBox.Show("Katalog is not Generate");
                return;
            }
            var mlist = katalog.MaschinenDimension;
            if (mlist.Count < 1)
            {
                MessageBox.Show("Katalog is not Generate");
                return;
            }

            view.Rows.Add(focusPlayer.MyHerstellerKatalog.MaschinenDimension.Count);           

            for (int i = 0; i < mlist.Count; i++)
            {
                view.Rows[i].Cells[0].Value = mlist[i].ToString();
                view.Rows[i].Cells[1].Value = katalog.GetPreis(mlist[i], HerstellerType.Cablemachines);
                view.Rows[i].Cells[1].Style.BackColor = LieferungColor(katalog.GetLieferungGrad(mlist[i], HerstellerType.Cablemachines));
                view.Rows[i].Cells[2].Value = katalog.GetPreis(mlist[i], HerstellerType.Voltmaster);
                view.Rows[i].Cells[2].Style.BackColor = LieferungColor(katalog.GetLieferungGrad(mlist[i], HerstellerType.Voltmaster));
                view.Rows[i].Cells[3].Value = katalog.GetPreis(mlist[i], HerstellerType.Zeus_Machine);
                view.Rows[i].Cells[3].Style.BackColor = LieferungColor(katalog.GetLieferungGrad(mlist[i], HerstellerType.Zeus_Machine));
            }
        }

        private void ShowPlayerBetriebsmittelKatalog(DataGridView view, Player focusPlayer)
        {
            view.Columns.Add("Maschine", "Betriebsmittel");
            view.Columns.Add("InputM", "Input.Material");
            view.Columns.Add("InputRate", "InputRate(n:1)");
            view.Columns.Add("OutputM", "Output.Material");
            view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            view.Columns.Add("MinMenge", "MinMenge");
            view.Columns.Add("MaxMenge", "MaxMenge");
            view.Columns.Add("MarktPreis", "Preis €\n(ungefaehrt)");
            view.Columns.Add("Area", "Groesse(m^2)");

            var katalog = focusPlayer.MyBetriebsmittelKatalog;
            if (katalog == null)
            {
                MessageBox.Show("Katalog is not Generate");
                return;
            }
            var maschinenList = katalog.MaschineKatalog;
            if (maschinenList.Count < 1)
            {
                MessageBox.Show("Katalog is not Generate");
                return;
            }


            for (int i = 0; i < maschinenList.Count; i++)
            {
                var m_type = maschinenList[i].Type;
                view.Rows.Add(1);
                var index = view.Rows.Count - 1;
                var row = view.Rows[index - 1];
                row.Cells[0].Value = m_type.ToString();
                row.Cells[1].Value = maschinenList[i].OutputProdukts.First().InputProdukts.First().InputProdukt.ToString();
                row.Cells[2].Value = maschinenList[i].OutputProdukts.First().InputProdukts.First().Rate;
                if (m_type == MaschinenType.Grobdrahtzugmaschine1 || m_type == MaschinenType.Grobdrahtzugmaschine2)
                {
                    row.Cells[3].Value = maschinenList[i].OutputProdukts.First().OutputProdukt.ToString()
                        + "/ \n" + maschinenList[i].OutputProdukts.ElementAt(1).OutputProdukt.ToString();
                }
                else
                {
                    row.Cells[3].Value = maschinenList[i].OutputProdukts.First().OutputProdukt.ToString();
                }
                row.Cells[4].Value = maschinenList[i].OutputProdukts.First().MinMenge;
                row.Cells[5].Value = maschinenList[i].OutputProdukts.First().MaxMenge;
                row.Cells[6].Value = maschinenList[i].MarktPreis;
                row.Cells[7].Value = maschinenList[i].Area;
                if (m_type == MaschinenType.Schirmmaschine && katalog.KabelType == KabelType.VPE)
                {
                    view.Rows.Add(1);
                    index = view.Rows.Count - 1;
                    row = view.Rows[index - 1];
                    row.Cells[1].Value = maschinenList[maschinenList.Count - 2].OutputProdukts.First().InputProdukts.ElementAt(1).InputProdukt.ToString();
                    row.Cells[2].Value = maschinenList[maschinenList.Count - 2].OutputProdukts.First().InputProdukts.ElementAt(1).Rate;
                }
            }
        }
        private void ShowPlayerLayoutList(DataGridView view, Player focusPlayer)
        {
            view.Rows.Clear();
            view.Columns.Clear();

            view.Columns.Add("ID", "ID");
            view.Columns.Add("Type", "Type");
            view.Columns.Add("DefaultPreis", "DefaultPreis");
            view.Columns.Add("NachKauf", "NachKauf");
            view.Columns.Add("UnitPreisChange", "UnitPreisChange");
            view.Columns.Add("SaeulenKosten", "SaeulenKosten");
            view.Columns.Add("EndKosten", "EndKosten");
            view.Columns.Add("AvailableUnit", "AvailableUnit");
            view.Columns.Add("AvailableArea", "AvailableArea");
            foreach (LayoutUnit newlayout in focusPlayer.NewLayoutUnitList)
            {
                view.Rows.Add(1);
                var index = view.Rows.Count - 1;
                var row = view.Rows[index - 1];
                row.Cells[0].Value = newlayout.ID;
                row.Cells[1].Value = newlayout.Type;
                row.Cells[2].Value = newlayout.Type.DefaultPreis();
                row.Cells[3].Value = newlayout.IsNachKauf;
                row.Cells[4].Value = newlayout.UnitPreisChange;
                row.Cells[5].Value = newlayout.SaeulenKosten;
                row.Cells[6].Value = newlayout.EndKosten;
                row.Cells[7].Value = newlayout.AvailableUnit;
                row.Cells[8].Value = newlayout.AvailableArea;
            }
            foreach (LayoutUnit ollayout in focusPlayer.OldLayoutUnitList)
            {
                view.Rows.Add(1);
                var index = view.Rows.Count - 1;
                var row = view.Rows[index - 1];
                row.Cells[0].Value = ollayout.ID;
                row.Cells[1].Value = ollayout.Type;
                row.Cells[2].Value = ollayout.Type.DefaultPreis();
                row.Cells[3].Value = ollayout.IsNachKauf;
                row.Cells[4].Value = ollayout.UnitPreisChange;
                row.Cells[5].Value = ollayout.SaeulenKosten;
                row.Cells[6].Value = ollayout.EndKosten;
                row.Cells[7].Value = ollayout.AvailableUnit;
                row.Cells[8].Value = ollayout.AvailableArea;
            }

        }
        //GUI Simulation

        public void ShowCurrentkalkulation(Player focusPlayer)
        {
            tb_budget.Text = focusPlayer.KalkulationUnit.Budget.ToString();
            tb_kosten.Text = focusPlayer.KalkulationUnit.Kosten.ToString();
            tb_balance.Text = focusPlayer.KalkulationUnit.Balance.ToString();
            lbox_Budget.Items.Clear();
            foreach (BudgetRecord b_record in focusPlayer.KalkulationUnit.BudgetRecordList)
            {
                lbox_Budget.Items.Add(b_record);
                //item.Text = b_record.EventName + "#"+b_record.MoneyAmount;
                //item.ToolTipText = b_record.Description;
                //lbox_Budget.Items.Add(item);
            }
            lbox_ksoten.Items.Clear();
            foreach (KostenRecord k_record in focusPlayer.KalkulationUnit.KostenRecordList)
            {
                lbox_ksoten.Items.Add(k_record);
                //item.Text = k_record.EventName + "/t#" + k_record.MoneyAmount;
                //item.ToolTipText = k_record.Description;
                //lbox_ksoten.Items.Add(item);
            }
        }

        #endregion

        #region InforKarten 
        private void bt_buyInforCard_Click(object sender, EventArgs e)
        {
            // #1#Wer hat diese Karten ziehen? Focusplayer!
            var _player = FocusRoom.FocusPlayer;
            // #2# Check, if you have enough money?
            if (_player.KalkulationUnit.Balance < 130000)
            {
                MessageBox.Show("You have no more money to buy Informationcard.");
                return;
            }
            // #3# Check, whether there are any available karte in kartepool
            var restkarten = FocusRoom.InforKartenPool.GetUnused_CardPool();
            if (restkarten.Count == 0 )
            {
                MessageBox.Show("There are no more rest card.");
                return;
            }
            // #4# Generate Methode; 
            InformationKarte newInforCard = restkarten.DrawCardRandomFromPool();
            // #5# Set FirstOwner to Card
            newInforCard.FirstOwner = _player;
            //_player
            // #6# GUI Show Card Content:
            newInforCard.ShowAsMessageBox();
            // #7# Do  Event Effect
            newInforCard.DoEffect();
            _player.AddInforCardCostRecord(newInforCard);
            // #8# Refresch GUI
            ShowCurrentkalkulation(_player);
            //RefreshDefultKatalog();
            //RefreshInformationOfPlayer();            
        }
        #endregion

        #region Buy Layoutkarte
        private void bt_neu_layout_Click(object sender, EventArgs e)
        {
            // #1#Wer wolle neue Layout kaufen? Focusplayer!
            var _player = FocusRoom.FocusPlayer;
            // #2# Check, if you have enough money?
            if (_player.KalkulationUnit.Balance < 3500000)
            {
                MessageBox.Show("You have no more money to buy Layoutkarte.");
                return;
            }
            //creat
            LayoutUnit unit = _player.DrawFirstHandUnit();
            _player.LayoutUnitList.Add(unit);
            _player.BuyLayoutUnitRecord();
            //GUI 
            ShowCurrentkalkulation(_player);
            ShowPlayerLayoutList(dataGridView_layoutList, _player);
        }

        private void bt_old_layout_Click(object sender, EventArgs e)
        {
            // #1#Wer wolle neue Layout kaufen? Focusplayer!
            var _player = FocusRoom.FocusPlayer;
            // #2# Check, if you have enough money?
            if (_player.KalkulationUnit.Balance < 2000000)
            {
                MessageBox.Show("You have no more money to buy Layoutkarte.");
                return;
            }
            //creat
            LayoutUnit unit = _player.DrawSecondHandUnit();
            _player.LayoutUnitList.Add(unit);
            _player.BuyLayoutUnitRecord();
            //GUI
            ShowCurrentkalkulation(_player);
            ShowPlayerLayoutList(dataGridView_layoutList, _player);
        }

        private void bt_nachkauf_neulayout_Click(object sender, EventArgs e)
        {
            // #1#Wer wolle neue Layout kaufen? Focusplayer!
            var _player = FocusRoom.FocusPlayer;
            // #2# Check, if you have enough money?
            if (_player.KalkulationUnit.Balance < 3500000 + 500000)
            {
                MessageBox.Show("You have no more money to buy Layoutkarte.");
                return;
            }
            //creat
            LayoutUnit unit = _player.DrawFirstHandUnit_Nachkauf();
            _player.LayoutUnitList.Add(unit);
            _player.BuyLayoutUnitRecord();
            //GUI
            ShowCurrentkalkulation(_player);
            ShowPlayerLayoutList(dataGridView_layoutList, _player);
        }

        private void bt_nachkauf_oldlayout_Click(object sender, EventArgs e)
        {
            // #1#Wer wolle neue Layout kaufen? Focusplayer!
            var _player = FocusRoom.FocusPlayer;
            // #2# Check, if you have enough money?
            if (_player.KalkulationUnit.Balance < 2000000 + 500000)
            {
                MessageBox.Show("You have no more money to buy Layoutkarte.");
                return;
            }
            //creat
            LayoutUnit unit = _player.DrawSecondHandUnit_Nachkauf();
            _player.LayoutUnitList.Add(unit);
            _player.BuyLayoutUnitRecord();
            //GUI
            ShowCurrentkalkulation(_player);
            ShowPlayerLayoutList(dataGridView_layoutList, _player);
        }
        #endregion

        private void toolBt_NextPhase_Click(object sender, EventArgs e)
        {
            FocusRoom.NextPhase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowCurrentkalkulation(FocusRoom.FocusPlayer);
        }
    }
}
