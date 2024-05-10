using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] a = textBox1.Text.Split('/');
                DateTime dateWill = new DateTime(Convert.ToInt32(a[2]), Convert.ToInt32(a[1]), Convert.ToInt32(a[0]));
                DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                if(radioButton2.Checked)
                {
                    label2.Text = (dateWill.Subtract(dateNow).TotalSeconds/3600/24).ToString() + " days";
                }
                else if (radioButton1.Checked) 
                {
                    label2.Text = $"{(int)(dateWill.Subtract(dateNow).Days / 365)} years/ {(int)(dateWill.Subtract(dateNow).Days % 365 / 30.4)} month/ {Convert.ToInt32(dateWill.Subtract(dateNow).Days - (((int)(dateWill.Subtract(dateNow).Days % 365 / 30.4)*30.4) + (365*((int)(dateWill.Subtract(dateNow).Days / 365)))))} days/ {dateWill.Subtract(dateNow).Hours.ToString()} hours/ {dateWill.Subtract(dateNow).Minutes.ToString()} minutes/ {dateWill.Subtract(dateNow).Seconds.ToString()} seconds";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
