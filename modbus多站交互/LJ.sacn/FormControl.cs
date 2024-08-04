using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LJ.sacn
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }

        private void FormControl_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Legends.Clear(); 

        }
    }
}
