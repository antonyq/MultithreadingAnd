using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MultithreadingAnd
{
    public partial class DialogForm : Form
    {
        public Choice choice;

        public DialogForm ()
        {
            InitializeComponent();
        }

        private void button1_Click (object sender, EventArgs e)
        {
            choice = Choice.Continue;
            this.Close();
        }

        private void button2_Click (object sender, EventArgs e)
        {
            choice = Choice.Cancel;
            this.Close();
        }

        private void button3_Click (object sender, EventArgs e)
        {
            choice = Choice.ContinueEver;
            this.Close();
        }

    }
}
