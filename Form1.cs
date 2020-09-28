using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2
{
    public partial class Form1 : Form
    {
        static public int inputHolesNum;
        static public int inputProcessesNum;
        static public bool method;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void holesNumTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void form1NextBtn_Click(object sender, EventArgs e)
        {
            bool error = false;
            int num;
            bool isNum = Int32.TryParse(holesNumTxtBox.Text, out num);
            if (isNum && num >= 0)
                inputHolesNum = num;
            else
            {
                MessageBox.Show("Please enter a correct number of holes.", "Error!", MessageBoxButtons.OK);
                error = true;
            }

            int num1;
            bool isNum1 = Int32.TryParse(prosNumTxtBox.Text, out num1);
            if (isNum1&&num1>=0)
                inputProcessesNum = num1;
            else
            { 
                MessageBox.Show("Please enter a correct number of processes.", "Error!",  MessageBoxButtons.OK);
                error = true;
            }
            if (bestFitBtn.Checked)
                method = true;
            else if (firstFitBtn.Checked)
                method = false;
            else
            { 
                MessageBox.Show("Please choose a method.","Error!", MessageBoxButtons.OK);
                error = true;
            }
            if (!error)
            {
                Form2 f = new Form2();
                f.ShowDialog();
            }
        }

        private void bestFitBtn_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void firstFitBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void prosNumTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
