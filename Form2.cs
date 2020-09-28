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
 
    public partial class Form2 : Form
    {
       public static List<MemoryLocation> memoryList = new List<MemoryLocation>();
       public static List<MemoryLocation> processesList = new List<MemoryLocation>();
        TableLayoutPanel pnlContent = new TableLayoutPanel();
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            pnlContent.Controls.Clear();
            pnlContent.RowStyles.Clear();
            pnlContent.ColumnStyles.Clear();
            Button next = new Button();
            Button back = new Button();

            int nholes = Convert.ToInt32(Form1.inputHolesNum);
            int nprocesses = Convert.ToInt32(Form1.inputProcessesNum);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.AutoScroll = true;
            pnlContent.AutoScrollMargin = new Size(1, 1);
            pnlContent.AutoScrollMinSize = new Size(1, 1);
            int COUNT = Math.Max(nholes, nprocesses);
            pnlContent.RowCount = COUNT + 2;
            pnlContent.ColumnCount = 8;

            for (int i = 0; i < pnlContent.ColumnCount; i++)
            {
                pnlContent.ColumnStyles.Add(new ColumnStyle());
            }

            for (int i = 0; i < pnlContent.ColumnCount; i++)
            {   
                pnlContent.ColumnStyles[i].Width = 20;
            }

            this.Controls.Add(pnlContent);

            pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            Label lblhole = new Label();
            lblhole.Text = string.Format("Hole");  
            lblhole.Margin = new Padding(5, 25, 0, 0);
            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(lblhole, 0, 0);

            Label lblholesize = new Label();
            lblholesize.Text = string.Format("Size");
            lblholesize.Margin = new Padding(25, 25, 0, 0);
            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(lblholesize, 2, 0);

            Label lblStartaddress = new Label();
            lblStartaddress.Text = string.Format("Start address");
            lblStartaddress.Margin = new Padding(25, 25, 0, 0);
            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(lblStartaddress, 1, 0);

            Label lblprocess = new Label();
            lblprocess.Text = string.Format("Process");
            lblprocess.Margin = new Padding(5, 25, 0, 0);
            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(lblprocess, 6, 0);

            Label lblprocesssize = new Label();
            lblprocesssize.Text = string.Format("Process Size");
            lblprocesssize.Margin = new Padding(25, 25, 0, 0);
            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(lblprocesssize, 7, 0);

            for (int i = 0; i < nholes; i++)
            {
                pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

                Label Hname = new Label();
                Hname.Text = string.Format(" {0}", i);
               // Hname.TabIndex = i * pnlContent.ColumnCount;
                Hname.Margin = new Padding(5, 25, 0, 0);
                Hname.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(Hname, 0, i+1);

                TextBox holeStartadress = new TextBox();
                holeStartadress.TabIndex = i ;
                holeStartadress.Left = 0;
                holeStartadress.Margin = new Padding(25);
                holeStartadress.Dock = DockStyle.Fill;
                holeStartadress.KeyDown += new KeyEventHandler(holeStartadress_KeyDown);
                pnlContent.Controls.Add(holeStartadress, 1, i+1);

                TextBox holeSize = new TextBox();
                holeSize.TabIndex = i+1;
                holeSize.Left = 0;
                holeSize.Margin = new Padding(25);
                holeSize.Dock = DockStyle.Fill;
                holeSize.KeyDown += new KeyEventHandler(holeSize_KeyDown);
                pnlContent.Controls.Add(holeSize, 2, i + 1);

            }
            for (int i = 0; i < nprocesses; i++)
            {

                pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                
                

                Label space2 = new Label();
                space2.Text = string.Format("    ");
                //space2.TabIndex = (i * pnlContent.ColumnCount);
                space2.Margin = new Padding(5, 25, 0, 0);
                space2.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(space2, 3, i + 1);

                Label space3 = new Label();
                space3.Text = string.Format("    ");
                //space3.TabIndex = (i * pnlContent.ColumnCount);
                space3.Margin = new Padding(5, 25, 0, 0);
                space3.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(space3, 4, i + 1);

                Label space4 = new Label();
                space4.Text = string.Format("    ");
                //space4.TabIndex = (i * pnlContent.ColumnCount);
                space4.Margin = new Padding(5, 25, 0, 0);
                space4.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(space4, 5, i + 1);

                Label Pname = new Label();
                Pname.Text = string.Format(" {0}", i);
                //Pname.TabIndex = (i * pnlContent.ColumnCount);
                Pname.Margin = new Padding(5, 25, 0, 0);
                Pname.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(Pname, 6, i+1);

                TextBox processSize = new TextBox();
                processSize.TabIndex = (nholes*2)+i;
                processSize.Left = 0;
                processSize.Margin = new Padding(25);
                //Pburst.Dock = DockStyle.Fill;
                processSize.KeyDown += new KeyEventHandler(processSize_KeyDown);
                pnlContent.Controls.Add(processSize, 7, i+1);
            }
            pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            pnlContent.ColumnCount++;
            pnlContent.ColumnStyles.Add(new ColumnStyle());
            pnlContent.ColumnStyles[pnlContent.ColumnCount - 1].Width = 20;

            next.Name = " next";
            next.Text = string.Format("Next>");
            next.TabIndex = COUNT * pnlContent.ColumnCount;
            next.Margin = new Padding(25);
            next.Click += new EventHandler(next_Click);


            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(back, 1, COUNT + 1);
            back.Name = "back";
            back.Text = string.Format("<Back");
            back.TabIndex = COUNT * pnlContent.ColumnCount + 3;
            back.Margin = new Padding(25);
            back.Click += new EventHandler(back_Click);


            pnlContent.Controls.Add(next, pnlContent.ColumnCount - 1, COUNT + 2);
            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(back, 0, COUNT + 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void back_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        void next_Click(object sender, EventArgs e)
        {
            bool flag=false;
            for (int i = 0; i < Form1.inputHolesNum; i++)
            {

                MemoryLocation nextlocation = new MemoryLocation();

                int size;
                bool issize = Int32.TryParse(pnlContent.GetControlFromPosition(2, i + 1).Text, out size);
                if (issize&&size>=0)
                    nextlocation.size = size;
                else
                { 
                    MessageBox.Show("Please enter a correct size.", "Error!", MessageBoxButtons.OK);
                    flag = true;
                }

                nextlocation.isUsed = false;
                int startaddress;
                bool isstartaddress = Int32.TryParse(pnlContent.GetControlFromPosition(1, i + 1).Text, out startaddress);
                if (isstartaddress && startaddress >= 0)
                    nextlocation.startAddress = startaddress;
                else
                { 
                    MessageBox.Show("Please enter a correct starting address.", "Error!", MessageBoxButtons.OK);
                    flag = true;
                }
                nextlocation.id = -1;
                memoryList.Add(nextlocation);
            }
            for (int i = 0; i < Form1.inputProcessesNum; i++)
            {
                MemoryLocation nextprocess = new MemoryLocation();

                int size;
                bool issize = Int32.TryParse(pnlContent.GetControlFromPosition(7, i + 1).Text, out size);
                if (issize && size >= 0)
                    nextprocess.size = size;
                else
                {
                    MessageBox.Show("Please enter a correct size.", "Error!", MessageBoxButtons.OK);
                    flag = true;
                }
                
                nextprocess.id = i;
                nextprocess.isUsed = true;
                processesList.Add(nextprocess);
            }
            if (!flag)
            {
                Form3 f = new Form3();
                f.ShowDialog();
            }
        }
            void holeSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        void processSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        void holeStartadress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
    public class MemoryLocation
    {
        public int startAddress, size, id;
        public bool isUsed,isBlocked;
    }


}
