using DataModel.Model;
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

namespace DataModel.ViewPage
{
    public partial class PageSetHersteller : Form
    {
        Player Player;
        List<Decide> Typelist;       


        public PageSetHersteller()
        {
            InitializeComponent();
        }

        public PageSetHersteller(Player _player) : this()
        {
            Player = _player;
            Typelist = Player.HerstellerDecideList;

            //listBox1
            listBox1.Items.Clear();
            foreach (Decide decide in Typelist)
            {
                listBox1.Items.Add(decide.Type_Maschinen);
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }

            ShowMaschinenDecideList(dataGridView1, Player);
        }

        private void ShowMaschinenDecideList(DataGridView view, Player Player)
        {
            Player.UpdateHerstellerofEachMaschinen();
            view.Rows.Clear();
            view.Columns.Clear();
            view.Columns.Add("Maschine", "Betriebsmittel");
            view.Columns.Add("Hersteller", "Hersteller");
            view.Columns.Add("MarktPreis", "MarktPreis");
            view.Columns.Add("HerstellerPreis", "Preis");
            view.Columns.Add("LieferungGrad", "LieferungGrad");
            //view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            

            foreach (Maschine maschine in Player.MaschinenList)
            {
                view.Rows.Add(1);
                var index = view.Rows.Count - 1;
                var row = view.Rows[index - 1];
                row.Cells[0].Value = maschine.Type.ToString();
                row.Cells[1].Value = maschine.Hersteller;
                row.Cells[2].Value = maschine.MarktPreis;
                row.Cells[3].Value = maschine.HerstellerPreis;
                row.Cells[4].Value = maschine.LieferungGrad;
            }

        }

        private void ShowSummary()
        {            
            rtb_Summary.Text = "";
            int _budget = Player.KalkulationUnit.Budget;
            int _otherkosten = Player.KalkulationUnit.KostenRecordList.Where(k => k.EventName != "MaschinenKosten").Sum(k => k.MoneyAmount);
            CultureInfo de = new CultureInfo("de-DE");
            int _maschinenkosten = Player.MaschinenList.Sum(m => m.KalkulationPreis);
            //int _areaSum = Player.MaschinenList.Sum(m => m.Area);
            rtb_Summary.Text += "Budget Summe:".PadRight(40) + " " + _budget.ToEuro() + "\n";
            rtb_Summary.Text += "Kosten Summe without Maschinen:".PadRight(40) + " " + _otherkosten.ToEuro() + "\n";
            rtb_Summary.Text += "Beschaffung Summe:".PadRight(40) + " " + _maschinenkosten.ToEuro() + "\n";
            rtb_Summary.Text += "Balance :".PadRight(40) + " " + (_budget - _otherkosten - _maschinenkosten).ToEuro() + "\n"; ;
            //rtb_Summary.Text += "\nArea Summe :".PadRight(40) + " " + _areaSum.ToNum(20) + "\n"; ;

        }

        private void bt_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bt_Set_volt_Click(object sender, EventArgs e)
        {

            string typestring = listBox1.SelectedItem.ToString();

            MaschinenType m_type = Player.MyHerstellerKatalog.MaschinenDimension.First(mt => mt.ToString().Contains(typestring));

            Player.SetHerstellerType(m_type, HerstellerType.Voltmaster);
            Player.UpdateDecideListToMaschinenList();
            Player.UpdateHerstellerofEachMaschinen();
            ShowMaschinenDecideList(dataGridView1, Player);
            ShowSummary();
        }

        private void bt_Cabl_Click(object sender, EventArgs e)
        {
            //Decide decide = (Decide)listBox1.SelectedItem;
            //string typestring = decide.Type_Maschinen;
            string typestring = listBox1.SelectedItem.ToString();


            MaschinenType m_type = Player.MyHerstellerKatalog.MaschinenDimension.First(mt => mt.ToString().Contains(typestring));

            Player.SetHerstellerType(m_type, HerstellerType.Cablemachines);
            Player.UpdateDecideListToMaschinenList();
            Player.UpdateHerstellerofEachMaschinen();
            ShowMaschinenDecideList(dataGridView1, Player);
            ShowSummary();
        }

        private void bt_Zeus_Machine_Click(object sender, EventArgs e)
        {
            //Decide decide = (Decide)listBox1.SelectedItem;
            //string typestring = decide.Type_Maschinen;
            string typestring = listBox1.SelectedItem.ToString();


            MaschinenType m_type = Player.MyHerstellerKatalog.MaschinenDimension.First(mt => mt.ToString().Contains(typestring));

            Player.SetHerstellerType(m_type, HerstellerType.Zeus_Machine);
            Player.UpdateDecideListToMaschinenList();
            Player.UpdateHerstellerofEachMaschinen();
            ShowMaschinenDecideList(dataGridView1, Player);
            ShowSummary();
        }
    }
}
