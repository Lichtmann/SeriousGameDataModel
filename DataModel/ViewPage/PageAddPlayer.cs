using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel;

namespace DataModel.ViewPage
{
    public partial class PageAddPlayer : Form
    {
        Model.GameRoom _focusRoom;        
        public PageAddPlayer(Model.GameRoom focusRoom, string newName)
        {
            InitializeComponent();
            _focusRoom = focusRoom;
            tb_Name.Text = newName;
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (tb_Name.Text.Length <3 )
            {
                MessageBox.Show("Name should be longer than 3 character");
                return;
            }
            else if (!_focusRoom.IsNewName(tb_Name.Text))
            {
                MessageBox.Show("Someone allready has this Name");
                return;
            } 
            else
            {
                _focusRoom.AddPlayerToRoom(tb_Name.Text);
                this.Close();
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
