using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_BN__Calculator_
{
    public partial class About_information : Form
    {
        public About_information()
        {
            InitializeComponent();
        }
        private void Percentage_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Give the Percentage Value");
        }

        private void Delete_all_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Deletes Everyting");
        }

        private void Delete_text_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Deletes Only Inputed Value");
        }

        private void Back_Space_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Removes Enter Last Entered Text");
        }

        private void Inverse_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("1 divded by the enter value");
        }

        private void Power_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Power value by 2");
        }

        private void Sqr_root_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Square Roots the value");
        }

        private void Multiply_sign(object sender, EventArgs e)
        {
            MessageBox.Show("Multiplies the value");
        }

        private void Divide_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Divides the value");
        }
    

        private void Minus_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Subtracts the value");
        }

        private void Plus_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Adds the value");
        }

        private void Equal_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Gives Final Output");
        }

        private void Plus_Minus_Sign(object sender, EventArgs e)
        {
            MessageBox.Show("Changes value from Postive to Negative Vice Versa");
        }
    }
}
