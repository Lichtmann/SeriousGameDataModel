using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.Model;

namespace DataModel.ViewPage
{
    public partial class PageBuyMaschine : Form
    {
        Player player;
        //List<Maschine> MaschnienKatalog;
        

        public PageBuyMaschine()
        {
            InitializeComponent();
        }

        public PageBuyMaschine(Player _player) :this()
        {
            Player = _player;
            //var kata = Player.MyBetriebsmittelKatalog.MaschineKatalog;
            //listBox1.
            listBox1.Items.Clear();
            foreach (Maschine maschine in MaschnienKatalog)
            {
                listBox1.Items.Add(maschine.Type);
            }
            if (listBox1.Items.Count >0)
            {
                listBox1.SelectedIndex = 0;
            }
            ShowKauflistMaschinen(dataGridView1, Player);
        }

        public Player Player { get => player; set => player = value; }
        public List<Maschine> MaschnienKatalog { get => Player.MyBetriebsmittelKatalog.MaschineKatalog; }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bt_addM_Click(object sender, EventArgs e)
        {
            MaschinenType m_type = (MaschinenType)listBox1.SelectedItem;

            Maschine newmaschine = MaschnienKatalog.First(m => m.Type == m_type).CloneInstance();
            //Set Name of Maschinen.
            Player.MaschinenList.Add(newmaschine);
            //Update Kosten 
            player.BuyMaschinenRecord();

            ShowKauflistMaschinen(dataGridView1, Player);
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            MaschinenType m_type = (MaschinenType)listBox1.SelectedItem;
            if (!Player.MaschinenList.Any(m => m.Type == m_type)) return;
            Maschine lastmaschine = Player.MaschinenList.Last(m => m.Type == m_type);

            Player.MaschinenList.Remove(lastmaschine);

            ShowKauflistMaschinen(dataGridView1, Player);
        }

        //GUI
        private void ShowKauflistMaschinen(DataGridView view, Player focusPlayer)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            view.Columns.Add("Maschine", "Betriebsmittel");
            view.Columns.Add("Num_current", "Kaufen Anzahl");
            view.Columns.Add("MarktPreis", "Preis €\n(ungefaehrt)");
            view.Columns.Add("Area", "Groesse(m^2)/jeder");
            view.Columns.Add("kosten", "Beschaffungskosten");
            view.Columns.Add("AreaSum", "Flaesch Bedarf");
            //view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            

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
                var listofthistype = Player.MaschinenList.Where(m => m.Type == m_type).ToList();
                view.Rows.Add(1);
                var index = view.Rows.Count - 1;
                var row = view.Rows[index - 1];
                row.Cells[0].Value = m_type.ToString();
                row.Cells[1].Value = listofthistype.Count().ToString();
                row.Cells[2].Value = maschinenList[i].KalkulationPreis;
                row.Cells[3].Value = maschinenList[i].Area;
                row.Cells[4].Value = listofthistype.Sum(m => m.KalkulationPreis);
                row.Cells[5].Value = listofthistype.Sum(m => m.Area);                
            }

            ShowSummary();
        }

        private void ShowSummary()
        {
            rtb_Summary.Text = "";
            int _budget = Player.KalkulationUnit.Budget;
            int _otherkosten = Player.KalkulationUnit.KostenRecordList.Where(k => k.EventName != "MaschinenKosten").Sum(k => k.MoneyAmount);
            CultureInfo de = new CultureInfo("de-DE");
            int _maschinenkosten = Player.MaschinenList.Sum(m => m.KalkulationPreis);
            int _areaSum = Player.MaschinenList.Sum(m => m.Area);
            rtb_Summary.Text += "Budget Summe:".PadRight(40) + " " + _budget.ToEuro() + "\n";
            rtb_Summary.Text += "Kosten Summe without Maschinen:".PadRight(40) + " "  + _otherkosten.ToEuro() + "\n";
            rtb_Summary.Text += "Beschaffung Summe:".PadRight(40) + " " + _maschinenkosten.ToEuro() + "\n";
            rtb_Summary.Text += "Balance :".PadRight(40) + " " + (_budget - _otherkosten-_maschinenkosten).ToEuro() + "\n"; ;
            rtb_Summary.Text += "\nArea Summe :".PadRight(40) + " " + _areaSum.ToNum(20) + "\n"; ;

        }

        private void bt_Buy_Click(object sender, EventArgs e)
        {

            if (Player.MaschinenList.Count < 1)
            {
                MessageBox.Show("There are no Maschine to buy", "Info");
                return;
            }

            if (MessageBox.Show("Confirm to Buy?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //delete
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
