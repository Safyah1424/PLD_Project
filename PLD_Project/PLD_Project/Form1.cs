using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.goldparser;

namespace PLD_Project
{
    public partial class Form1 : Form
    {
        MyParser p;
        public Form1()
        {
            InitializeComponent();
            p = new MyParser("PLD_Project.cgt", lstBox1, lstBox2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtBox1_TextChanged(object sender, EventArgs e)
        {
            lstBox1.Items.Clear();
            lstBox2.Items.Clear();
            p.Parse(txtBox1.Text);
        }
    }
}
