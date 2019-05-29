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
        //Self Instance
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
            ///LoadKatalog();
        }

        public void UpdateFocusRoomGUI(GameRoom room)
        {
            FocusRoom = room;
            W_Instance.lb_RoomID.Text = "Room: " + room.RoomID;
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
            var player = listBox1.SelectedItem as Player;
            if (player == null) return;
            toolStripFocus.Text = "Focus: " + player?.PlayerName;
            FocusRoom.FocusPlayer = player;
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
            if (FocusRoom == null) return;
            if (FocusRoom.PlayerList.Count < 1) return;
            if (FocusRoom.KabelType == KabelType.unknow) return;
            bt_OpenRoom.Enabled = false;
            bt_AddPlayer.Enabled = false;
            bt_deleteplayer.Enabled = false;
            bt_KabelType.Enabled = false;
            FocusRoom.DefaultHerstellerKatalog = new HerstellerKatalog(FocusRoom.KabelType);
            RenderDefultKatalogTable();
            FocusRoom.DefaultBetriebsmittelKatalog = new BetriebsmittelKatalog(FocusRoom.KabelType);
            RenderDefultBetriebsmittelKatalog();
            bt_StartGameP2.Enabled = false;
            MessageBox.Show("GameRoom: " + FocusRoom.RoomID 
                + "\nStart with " + FocusRoom.PlayerList.Count + " Players\n" 
                + "KabelType: " + FocusRoom.KabelType
                + "\nPlease Extract ZielKarte");
            InitialDataGridViewZielKarte();
        }
        
        private void RenderDefultKatalogTable()
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
                if (m_type == MaschinenType.Schirmmaschine)
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

        private void SetZielKarte(GameRoom room, string id)
        {
            //check a Resource dictinary/Datenbank
            switch (id)
            {
                case "Zi-01":
                    room.ZielKarte = new ZielKarte(31000000, 2500, new Gewichtung(2, 3, 1));
                    room.ZielKarte.SetID("Zi-01");
                    break;
                case "Zi-02":
                    break;
                case "Zi-03":
                    break;
                case "Zi-04":
                    break;
                default:
                    break;
            }
        }

        private void bt_zielKarte_Click(object sender, EventArgs e)
        {
            if (FocusRoom == null) return;
            Random ran = new Random();
            int cardNumber = ran.Next(1, 6);
            cardNumber = 1;
            string CardID = "Zi-" + cardNumber.ToString().PadLeft(2, '0');
            SetZielKarte(FocusRoom, CardID);
            // Karte Animation messagebox:
            //string content = RenderZielKarte(FocusRoom.ZielKarte);
            MessageBox.Show(RenderZielKarte(FocusRoom.ZielKarte), "ZielKarte");
            UpdateZielKarteToTabel(FocusRoom.ZielKarte);
            foreach (Player player in FocusRoom.PlayerList)
            {
                UpdateZielKarteToPlayer(FocusRoom.ZielKarte, player);
            }
        }

        // GUI[Simulation]
        private void UpdateZielKarteToTabel(ZielKarte zielKarte)
        {
            dataGridView1.Rows[0].Cells[1].Value = zielKarte.ID;
            dataGridView1.Rows[1].Cells[1].Value = zielKarte.StartBudget;
            dataGridView1.Rows[2].Cells[1].Value = zielKarte.Produktionsmenge;
            dataGridView1.Rows[3].Cells[1].Value = zielKarte.Gewichtung.MaterialflussGewichtung;
            dataGridView1.Rows[4].Cells[1].Value = zielKarte.Gewichtung.ErweiterbarkeitGewichtung;
            dataGridView1.Rows[5].Cells[1].Value = zielKarte.Gewichtung.BudgetGewichtung;
        }

        private static void UpdateZielKarteToPlayer(ZielKarte zielKarte, Player player)
        {
            //player1 accept card:
            //player.KalkulationManager.AddBudget(zielKarte.StartBudget);
            player.Zielkarte = zielKarte;
            //Update new Content
            //lb_PM_1.Content = zielKarte.Produktionsmenge.ToString() + " m/Tag";
            //lb_Budget_1.Content = player1.KalkulationManager.Budget.ToString("N0") + "€";
            //lb_kosten_1.Content = player1.KalkulationManager.Kosten.ToString("N0") + "€";
            //lb_balance_1.Content = player1.KalkulationManager.Balance.ToString("N0") + "€";
            //tx_Gewichtung.Text = zielKarte.Gewichtung.ToString();
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


    }
}
