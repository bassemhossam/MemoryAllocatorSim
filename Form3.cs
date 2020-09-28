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
    public partial class Form3 : Form
    {

        static public TableLayoutPanel chart = new TableLayoutPanel();
        int currentcolumn = 0;

        TextBox deallocatetxtbox = new TextBox();
        public Form3()
        {
            InitializeComponent();
        }
       
        public void Form3_Load(object sender, EventArgs e)
        {

            chart.Controls.Clear();
            chart.RowStyles.Clear();
            chart.ColumnStyles.Clear();
            chart.Dock = DockStyle.Fill;
            chart.AutoScroll = true;
            chart.AutoScrollMargin = new Size(1, 1);
            chart.AutoScrollMinSize = new Size(1, 1);

            chart.ColumnCount = 1000;
            for (int i = 0; i < 1000; i++)
            {
                chart.ColumnStyles.Add(new ColumnStyle());

                chart.ColumnStyles[i].Width = 20;

            }
            addblock();
            allocate(Form1.method);

            chart.RowCount++;
            chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));
            Button deallocate = new Button();
            deallocate.Name = "Deallocate";
            deallocate.Text = string.Format("Deallocate");
            deallocate.Margin = new Padding(25);
            deallocate.Click += new EventHandler(deallocate_Click);
            chart.Controls.Add(deallocate, 0, chart.RowCount );

            deallocatetxtbox.Name = "deallocatetxtbox";
            deallocatetxtbox.Margin = new Padding(25);
            deallocatetxtbox.Text = string.Format("Enter Process id");
            chart.Controls.Add(deallocatetxtbox,1 , chart.RowCount);



            chart.RowCount++;
            chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));
            Button back = new Button();
            back.Name = "back";
            back.Text = string.Format("<Back");
            back.Margin = new Padding(25);
            back.Click += new EventHandler(back_Click);
            chart.Controls.Add(back, 0, chart.RowCount + 1);

            chart.RowCount++;
            chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));
            Button finish = new Button();
            finish.Name = "finish";
            finish.Text = string.Format("Finish");
            finish.Margin = new Padding(25);
            finish.Click += new EventHandler(finish_Click);
            chart.Controls.Add(finish, chart.ColumnCount, chart.RowCount);

            this.Controls.Add(chart);

        }
        void back_Click(object sender, EventArgs e)
        {

            Form2.memoryList.Clear();

            Form2.processesList.Clear();

            this.Close();
        }
        void finish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void deallocate_Click(object sender, EventArgs e)
        {
            int num1;
            bool isNum1 = Int32.TryParse(deallocatetxtbox.Text, out num1);
            if (isNum1 && num1 >= 0)
            {
                deallocate(num1);
                this.Hide();
                print();
                this.Show();
            }
            else
                MessageBox.Show("Please enter a correct PID", "Error!", MessageBoxButtons.OK);


            
        }
        public class addressCompare : IComparer <MemoryLocation>
        {
            public int Compare(MemoryLocation x, MemoryLocation y)
            {
                if (x.startAddress > y.startAddress)
                    return 1;
                else if (x.startAddress < y.startAddress)
                    return -1;
                else
                {
                    if (x.size > y.size)
                        return 1;
                    else if (x.size < y.size)
                        return -1;
                    else
                        return 0;
                }
            }

        }
        public class sizeCompare : IComparer<MemoryLocation>
        {
            public int Compare(MemoryLocation x, MemoryLocation y)
            {
                if (x.size > y.size)
                    return 1;
                else if (x.size < y.size)
                    return -1;
                else
                {
                    if (x.startAddress > y.startAddress)
                        return 1;
                    else if (x.startAddress < y.startAddress)
                        return -1;
                    else
                    {
                        return 0;
                    }
                }
            }

        }

        public void addblock()
        {
            addressCompare a = new addressCompare();
            Form2.memoryList.Sort(a);
            addholes();
            int diff2=0;
            for (int i = 1; i < Form2.memoryList.Count(); i++)
            {
                diff2 = (Form2.memoryList[i - 1].startAddress + Form2.memoryList[i - 1].size);
                if (Form2.memoryList[i].startAddress > diff2)
                {
                    MemoryLocation block = new MemoryLocation();
                    block.startAddress = diff2;
                    block.size=Form2.memoryList[i].startAddress - diff2;
                    block.isBlocked = true;
                    block.id = -2;
                    Form2.memoryList.Insert(i, block);
                }
            }
        }
        public void addholes()
        {
            addressCompare a = new addressCompare();
            Form2.memoryList.Sort(a);
            for(int i= Form2.memoryList.Count()-1;i>0;i--)
                if((!Form2.memoryList[i].isBlocked)&&(!Form2.memoryList[i-1].isBlocked)&&(!Form2.memoryList[i].isUsed) && (!Form2.memoryList[i - 1].isUsed) && Form2.memoryList[i].startAddress<=(Form2.memoryList[i-1].startAddress+ Form2.memoryList[i - 1].size))
                {
                    Form2.memoryList[i - 1].size = Form2.memoryList[i].startAddress+ Form2.memoryList[i].size - Form2.memoryList[i - 1].startAddress;
                    Form2.memoryList.RemoveAt(i);
                }
        }
        public void print()
        {
            addressCompare a = new addressCompare();
            Form2.memoryList.Sort(a);
            //chart.RowCount ++;
            /*chart.ColumnStyles.Add(new ColumnStyle());
            chart.ColumnStyles[currentcolumn].Width = 10;
            chart.ColumnStyles.Add(new ColumnStyle());
            chart.ColumnStyles[currentcolumn+1].Width = 20;*/
            int currentrow = 0;
            foreach (MemoryLocation x in Form2.memoryList)
            {
                chart.RowCount ++;
                chart.RowStyles.Add(new RowStyle());

                Label addresslbl = new Label();
                addresslbl.Text = x.startAddress.ToString();
                if(currentrow==0)
                    addresslbl.Margin = new Padding(0, 25, 0, 0);
                else
                    addresslbl.Margin = new Padding(0, 0, 0, 0);
                addresslbl.TextAlign = ContentAlignment.TopRight;
                //addresslbl.Dock = DockStyle.Fill;
                chart.Controls.Add(addresslbl, currentcolumn,currentrow);

                Label idlbl = new Label();
                idlbl.BorderStyle = BorderStyle.FixedSingle;
                //idlbl.Dock = DockStyle.Fill;
                if (x.isBlocked)
                {
                    idlbl.Text = "";
                    idlbl.BackColor = Color.Black;
                }
                else if(x.isUsed)
                {

                    idlbl.BackColor =SystemColors.Window;
                    idlbl.Text = "Process"+x.id.ToString();
                    idlbl.TextAlign = ContentAlignment.TopCenter;

                }
                else
                {
                    idlbl.Text = x.size.ToString();

                    idlbl.BackColor = Color.LightGray;
                    idlbl.TextAlign = ContentAlignment.TopCenter;
                    idlbl.BorderStyle = BorderStyle.Fixed3D;
                }
                if (currentrow == 0)
                    idlbl.Margin = new Padding(0, 25, 0, 0);
                else

                    idlbl.Margin = new Padding(0, 0, 0, 0);
                chart.Controls.Add(idlbl, currentcolumn+1, currentrow);
                currentrow++;
            }

            int endaddress=Form2.memoryList[Form2.memoryList.Count() - 1].startAddress + Form2.memoryList[Form2.memoryList.Count() - 1].size;
            chart.RowCount++;
            chart.RowStyles.Add(new RowStyle());
            Label endaddresslbl = new Label();
            endaddresslbl.Text =endaddress.ToString();
            endaddresslbl.TextAlign = ContentAlignment.TopRight;
           // endaddresslbl.Margin = new Padding(40, 25, 0, 0);
            chart.Controls.Add(endaddresslbl, currentcolumn, currentrow);

            currentcolumn += 4;
        }
        public void deallocate(int pid)
        {
            for(int i=0;i<Form2.memoryList.Count();i++)
            {
               if( Form2.memoryList[i].id==pid)
                {
                    Form2.memoryList[i].isUsed = false;
                }
            }
            addholes();
            addressCompare a = new addressCompare();
            Form2.memoryList.Sort(a);
        }

        public void allocate( bool method)
        {
            print();
            if (method)
            {
                sizeCompare a = new sizeCompare();
                Form2.memoryList.Sort(a);
            }
            else
            {

                addressCompare a = new addressCompare();
                Form2.memoryList.Sort(a);
            }

            for (int j = 0; j < Form2.processesList.Count(); j++)
            {
                if (method)
                {
                    sizeCompare b = new sizeCompare();
                    Form2.memoryList.Sort(b);
                }
                for (int i = 0; i < Form2.memoryList.Count(); i++)
                {
                    
                    if ((!Form2.memoryList[i].isBlocked)&&!Form2.memoryList[i].isUsed && Form2.memoryList[i].size >= Form2.processesList[j].size)
                    {

                        int diff = Form2.memoryList[i].size - Form2.processesList[j].size;
                        Form2.memoryList[i].isUsed = true;
                        Form2.memoryList[i].size = Form2.processesList[j].size;
                        Form2.memoryList[i].id = Form2.processesList[j].id;

                        if (diff > 0)
                        {
                            MemoryLocation newlocation = new MemoryLocation();
                            newlocation.isUsed = false;
                            newlocation.size = diff;
                            newlocation.id = -1;
                            newlocation.startAddress = Form2.memoryList[i].startAddress + Form2.memoryList[i].size;
                            Form2.memoryList.Insert(i + 1, newlocation);
                            

                        }
                        
                        break;
                    
                    }
                }
                print();
            }
        }

    }
}
