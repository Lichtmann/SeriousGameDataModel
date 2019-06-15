using DataModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModel.ViewPage
{
    public partial class PageRollLieferung : Form
    {
        int number = 0;
        LieferungErgebnis result;
        Maschine Maschine;

        public PageRollLieferung()
        {
            InitializeComponent();
        }

        public PageRollLieferung(Maschine _maschine) : this()
        {
            Maschine = _maschine;
            richTextBox1.Text = "Maschine: " + Maschine.Type + " wait to Roll\n"
                + "LieferungGrad: " + Maschine.LieferungGrad + "\n";
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (number != 0)
            {
                Maschine.LieferungErgebnis = result;
                Maschine.HasRoll = true;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            return;
        }

        private void bt_roll_Click(object sender, EventArgs e)
        {
            number = HerstellerExtension.RollNumber1To6();
            result = HerstellerExtension.GetLieferungErgebnis(Maschine.LieferungGrad, number);
            richTextBox1.Text += "####\nRoll, Get Number: " + number
                + "\n Get a LieferungErgebnis: " + result.ToString()
                + "\n Kosten " + (int)result + "% Aufpreis";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            number = 1;
            result = HerstellerExtension.GetLieferungErgebnis(Maschine.LieferungGrad, number);
            richTextBox1.Text += "####\nManuell set Number: " + number
                + "\n Get a LieferungErgebnis: " + result.ToString()
                + "\n Kosten " + (int)result + "% Aufpreis";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number = 2;
            result = HerstellerExtension.GetLieferungErgebnis(Maschine.LieferungGrad, number);
            richTextBox1.Text += "####\nManuell set Number: " + number
                + "\n Get a LieferungErgebnis: " + result.ToString()
                + "\n Kosten " + (int)result + "% Aufpreis";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            number = 3;
            result = HerstellerExtension.GetLieferungErgebnis(Maschine.LieferungGrad, number);
            richTextBox1.Text += "####\nManuell set Number: " + number
                + "\n Get a LieferungErgebnis: " + result.ToString()
                + "\n Kosten " + (int)result + "% Aufpreis";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            number = 4;
            result = HerstellerExtension.GetLieferungErgebnis(Maschine.LieferungGrad, number);
            richTextBox1.Text += "####\nManuell set Number: " + number
                + "\n Get a LieferungErgebnis: " + result.ToString()
                + "\n Kosten " + (int)result + "% Aufpreis";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            number = 5;
            result = HerstellerExtension.GetLieferungErgebnis(Maschine.LieferungGrad, number);
            richTextBox1.Text += "####\nManuell set Number: " + number
                + "\n Get a LieferungErgebnis: " + result.ToString()
                + "\n Kosten " + (int)result + "% Aufpreis";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            number = 6;
            result = HerstellerExtension.GetLieferungErgebnis(Maschine.LieferungGrad, number);
            richTextBox1.Text += "####\nManuell set Number: " + number
                + "\n Get a LieferungErgebnis: " + result.ToString()
                + "\n Kosten " + (int)result + "% Aufpreis";
        }
    }
}
