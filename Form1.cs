using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Memory;

namespace MadMaxPracticeTool
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        decimal currentPlayerHealth = 2000;
        decimal maxPlayerHealth = 2000;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initiallize values


            if (!backgroundWorker1.IsBusy) //if background worker is not busy
            {
                backgroundWorker1.RunWorkerAsync(); //run the background worker
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void StoryMissionsTab_Click(object sender, EventArgs e)
        {

        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {

        }

        //Create Memory Object
        public Mem m = new Mem();
        public int pID = 0;

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool firstRun = true;

            while (true)
            {
                pID = m.GetProcIdFromName("MadMax"); //Get the process ID from the game              
                if (pID <= 0 || !m.OpenProcess(pID))
                {
                    firstRun = true;
                    continue;
                }


                if (firstRun)
                {
                    currentPlayerHealth = maxPlayerHealth;
                    numericUpDown1.Text = currentPlayerHealth.ToString();

                    firstRun = false;
                }

                //get max health value


                //set max health value in current health value text box



                //do code

                //Player Tab

                if (Form.ActiveForm == null)
                {
                    currentPlayerHealth = m.ReadMemory<decimal>("base+0x017F5228,0x20,0x1F0,0xC80,0x30,0x0,0x1C");
                    numericUpDown1.Value = currentPlayerHealth;
                }

                //Story Missions Tab
                if (checkedListBox1.GetItemChecked(0))
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pID <= 0 || !m.OpenProcess(pID))
            {
                return;
            }

            m.WriteMemory("base+0x017F5228,0x20,0x1F0,0xC80,0x30,0x0,0x1C", "float", numericUpDown1.Value.ToString()); //set health to value in health label
        }
    }
}
