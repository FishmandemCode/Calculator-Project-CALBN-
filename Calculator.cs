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
    public partial class Calculator : Form
    {
        List<string> storage = new List<string> { };
        double final_Num_value = new double(), percentage_value = new double(), square_root_value = new double(), power_value = new double(), inverse_value = new double(), Sep_value = new double();
        string value_1 = "", value_2 = "", final_value = "", unit_choice = "", clear_counter = "", copy_value = "", negate_value ="";
        int choice_num = 0, dot_counter = 0, output_counter = 0;
        string[] converter_unit = { "+", "-", "*", "/" };
        bool input = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_information info = new About_information();
            info.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
            copy_value = Clipboard.GetText();
            storage.Clear(); value_1 = ""; value_2 = ""; final_value = ""; listBox1.Items.Clear(); storage.Add(copy_value);
            nani();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "0";
            ActiveControl = button24;
        }

        ///Deleters
        private void deleter()
        {
            listBox1.Items.Clear(); storage.Clear();
            value_1 = ""; value_2 = ""; final_value = "";
            richTextBox1.Text = "0";
            output_counter = 0;
        }
        private void Delete_All_Sign(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "0" || final_value == "0" || inverse_value == 0 || percentage_value == 0 || square_root_value == 0 || power_value == 0)
            {
                deleter();
            }
            nani();
        }
        private void Back_Space_Sign(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 1 && final_value != "")
                richTextBox1.Text = "0";
            if (richTextBox1.Text != "0" || final_value == "0")
            {
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1, 1);
                storage.RemoveAt(storage.Count - 1);
            }
            nani();
        }
        private void Delete_Text_Sign(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "0" || final_value == "0")
            { 
                storage.Clear();
                richTextBox1.Clear();
            }
            nani();
        }
        ///
        private void nani()
        {
            if (richTextBox1.Text == "NaN" || richTextBox1.Text == "∞")
                deleter();
        }

        ///Value Inputs
        private void button_smasher(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "0")
                richTextBox1.Clear();
            if (clear_counter == "need_clearing")
                richTextBox1.Clear(); clear_counter = "";
            if (final_value != "")
            { listBox1.Items.Clear(); richTextBox1.Clear(); final_value = ""; value_1 = ""; value_2 = ""; }
            if(richTextBox1.Text == Convert.ToString(percentage_value) || richTextBox1.Text == Convert.ToString(square_root_value) || richTextBox1.Text == Convert.ToString(power_value) || richTextBox1.Text == Convert.ToString(inverse_value))
            { storage.Clear(); listBox1.Items.Clear(); richTextBox1.Clear(); final_value = ""; value_1 = ""; value_2 = ""; }
            Button button = (Button)sender;
            storage.Add(button.Text);
            richTextBox1.Text += button.Text;
            nani();
        }
        ///

        ///Changes value to negative vice versa
        private void Negate_Plus_Sign(object sender, EventArgs e)
        {
            nani();
            if (richTextBox1.Text.Contains("-"))
            {
                richTextBox1.Text = richTextBox1.Text.Remove(0, 1);
                negate_value = richTextBox1.Text;
                storage.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Clear(); final_value = ""; storage.Add(negate_value);
            }
            else
            {
                richTextBox1.Text = "-" + richTextBox1.Text;
                negate_value = richTextBox1.Text;
                storage.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Clear(); final_value = ""; storage.Add(negate_value);
            }

        }
        ///Inverse Function
        private void Inverse_Sign(object sender, EventArgs e)
        {
            nani();
            double original_value = new double();
            if (value_1 == "" || value_2 == "")
            {
                inverse_value = Convert.ToDouble(richTextBox1.Text);
                original_value = inverse_value;
                inverse_value = (1 / inverse_value);
                if (value_1 == "")
                {
                    richTextBox1.Text = Convert.ToString(inverse_value);
                    storage.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Clear(); listBox1.Items.Add(Convert.ToString("1/(" + original_value + ")")); final_value = ""; storage.Add(Convert.ToString(inverse_value));
                }
                else if (value_2 == "")
                {
                    richTextBox1.Text = Convert.ToString(inverse_value);
                    storage.Clear(); listBox1.Items.Clear(); listBox1.Items.Add(value_1 + unit_choice[choice_num] + Convert.ToString(inverse_value)); value_2 = ""; final_value = ""; storage.Add(Convert.ToString(inverse_value));
                }
            }
            if (final_value != "")
            {
                inverse_value = Convert.ToDouble(final_value); final_value = "";
                inverse_value = 1 / inverse_value;
                storage.Clear(); listBox1.Items.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Add(inverse_value); richTextBox1.Text = Convert.ToString(inverse_value); storage.Add(Convert.ToString(inverse_value));
            }
        }
        ///
        
        ///Square Function
        private void Square_Root_Sign(object sender, EventArgs e)
        {
            nani();
            double original_value = new double();
            if(value_1 == "" || value_2 == "")
            {
                square_root_value = Convert.ToDouble(richTextBox1.Text);
                original_value = square_root_value;
                square_root_value = Math.Sqrt(square_root_value);
                if(value_1 =="")
                {
                    richTextBox1.Text = Convert.ToString(square_root_value);
                    storage.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Clear();  listBox1.Items.Add(Convert.ToString("√(" + original_value + ")")); final_value = ""; storage.Add(Convert.ToString(square_root_value));
                }
                else if (value_2 == "")
                {
                    richTextBox1.Text = Convert.ToString(square_root_value);
                    storage.Clear(); listBox1.Items.Clear(); listBox1.Items.Add(value_1 + unit_choice[choice_num] + Convert.ToString(square_root_value)); value_2 = ""; final_value = ""; storage.Add(Convert.ToString(square_root_value));
                }
            }
            if (final_value != "")
            {
                square_root_value = Convert.ToDouble(final_value); final_value = "";
                square_root_value = Math.Sqrt(square_root_value);
                storage.Clear(); listBox1.Items.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Add(square_root_value); richTextBox1.Text = Convert.ToString(square_root_value); storage.Add(Convert.ToString(square_root_value));
            }
        }
        ///

        ///Power Function
        private void Power_Sign(object sender, EventArgs e)
        {
            nani();
            double original_value = new double();
            if (value_1 == "" || value_2 == "")
            {
                power_value = Convert.ToDouble(richTextBox1.Text);
                original_value = power_value;

                power_value = Math.Pow(power_value, 2);
                if (value_1 == "")
                {
                    richTextBox1.Text = Convert.ToString(power_value);
                    storage.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Clear(); listBox1.Items.Add(Convert.ToString("sqr(" + original_value + ")")); final_value = ""; storage.Add(Convert.ToString(power_value));
                }
                else if (value_2 == "")
                {
                    richTextBox1.Text = Convert.ToString(power_value);
                    storage.Clear(); listBox1.Items.Clear(); listBox1.Items.Add(value_1 + unit_choice[choice_num] + Convert.ToString(power_value)); value_2 = ""; final_value = ""; storage.Add(Convert.ToString(power_value));
                }
            }
            if (final_value != "")
            {
                power_value = Convert.ToDouble(final_value); final_value = "";
                power_value = Math.Pow(power_value, 2);
                storage.Clear(); listBox1.Items.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Add(power_value); richTextBox1.Text = Convert.ToString(power_value); storage.Add(Convert.ToString(power_value));
            }

        }
        ///

        ///Percentage Function
        private void Percentage_Sign(object sender, EventArgs e)
        {
            nani();
            if (value_1 == "" || value_2 == "")
            {
                percentage_value = Convert.ToDouble(richTextBox1.Text);
                percentage_value = (percentage_value / 100);
                if (value_1 == "")
                {
                    richTextBox1.Text = Convert.ToString(percentage_value);
                    storage.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Clear(); listBox1.Items.Add(Convert.ToString(percentage_value));  final_value = ""; storage.Add(Convert.ToString(percentage_value));
                }
                else if(value_2 == "")
                {
                    richTextBox1.Text = Convert.ToString(percentage_value);
                    storage.Clear();listBox1.Items.Clear(); listBox1.Items.Add(value_1 + unit_choice[choice_num] + Convert.ToString(percentage_value)); value_2 = ""; final_value = ""; storage.Add(Convert.ToString(percentage_value));
                }
            }
            if (final_value != "")
            {
                percentage_value = Convert.ToDouble(final_value); final_value = "";
                percentage_value = (percentage_value / 100);
                storage.Clear(); listBox1.Items.Clear(); value_1 = ""; value_2 = ""; listBox1.Items.Add(percentage_value); richTextBox1.Text = Convert.ToString(percentage_value); storage.Add(Convert.ToString(percentage_value));
            }  
        }
        ///

        ///Calculation Choice
        private void Plus_Sign(object sender, EventArgs e)
        {
            nani();
            if (output_counter == 1)
                output(); output_counter = 0;
            output_counter++;
            unit_choice = "+"; choice_num = 0; Unit_choice();
        }
        private void Minus_Sign(object sender, EventArgs e)
        {
            nani();
            if (output_counter == 1)
                output(); output_counter = 0;
            output_counter++;
            unit_choice = "-"; choice_num = 1; Unit_choice();
        }
        private void Multiply_Sign(object sender, EventArgs e)
        {
            nani();
            if (output_counter == 1)
                output(); output_counter = 0;
            output_counter++;
            unit_choice = "*"; choice_num = 2; Unit_choice();
            
        }
        private void Divide_Sign(object sender, EventArgs e)
        {
            nani();
            if (output_counter == 1)
                output(); output_counter = 0;
            output_counter++;
            unit_choice = "/"; choice_num = 3; Unit_choice();
        }
        ///

        ///Final Output
        private void Equal_Sign(object sender, EventArgs e)
        {
            output();
        }
        ///

        ///called when any unit is choosen
        private void Unit_choice()
        {
            if (storage.Count == 0)
                 storage.Add("0");
            if (unit_choice == "+" || unit_choice == "-" || unit_choice == "*"|| unit_choice == "/")
            {
                if (final_value != "")
                {
                    value_1 = final_value; Sep_value = Convert.ToDouble(final_value); final_value = ""; clear_counter = "need_clearing"; value_2 = "";
                    listBox1.Items.Clear(); listBox1.Items.Add(value_1 + unit_choice); storage.Clear(); richTextBox1.Text = value_1;
                }

                if (value_1 == "")
                {
                    richTextBox1.Clear();
                    for (int i = 0; i < storage.Count; i++)
                    {
                        value_1 += storage[i];
                        if (value_1.Count() == storage.Count || value_1 == copy_value || value_1 == negate_value || value_1 == Convert.ToString(percentage_value) || value_1 == Convert.ToString(square_root_value) || value_1 == Convert.ToString(power_value) || value_1 == Convert.ToString(inverse_value))
                        { listBox1.Items.Clear(); listBox1.Items.Add(value_1 + unit_choice); storage.Clear(); richTextBox1.Text = value_1; }
                    }
                    clear_counter = "need_clearing";
                }
            }
        }
        ///


        ///Final Output function
        private void output()
        {
            nani();
            if (value_2 == "" && value_1 != "")
            {
                if(storage.Count == 0 )
                    storage.Add(Convert.ToString(Sep_value));
                richTextBox1.Clear();
                for (int i = 0; i < storage.Count; i++)
                {
                    value_2 += storage[i];
                    if (value_2.Count() == storage.Count || value_2 == Convert.ToString(percentage_value) || value_2 == Convert.ToString(square_root_value) || value_2 == Convert.ToString(power_value) || value_2 == Convert.ToString(inverse_value))
                    { listBox1.Items.Clear(); listBox1.Items.Add(value_1 + converter_unit[choice_num] + value_2 + " = "); storage.Clear(); }
                }

                if (choice_num == 0)
                    final_Num_value = Convert.ToDouble(value_1) + Convert.ToDouble(value_2);
                if (choice_num == 1)
                    final_Num_value = Convert.ToDouble(value_1) - Convert.ToDouble(value_2);
                if (choice_num == 2)
                    final_Num_value = Convert.ToDouble(value_1) * Convert.ToDouble(value_2);
                if (choice_num == 3)
                    final_Num_value = Convert.ToDouble(value_1) / Convert.ToDouble(value_2);

                final_value = Convert.ToString(final_Num_value);
                richTextBox1.Text = final_value;

            }
            else if (value_1 != "" && value_2 != "" && final_value != "")
            {
                value_1 = final_value;
                final_value = "";
                listBox1.Items.Clear(); listBox1.Items.Add(value_1 + converter_unit[choice_num] + value_2); storage.Clear();
                if (choice_num == 0)
                    final_Num_value = Convert.ToDouble(value_1) + Convert.ToDouble(value_2);
                if (choice_num == 1)
                    final_Num_value = Convert.ToDouble(value_1) - Convert.ToDouble(value_2);
                if (choice_num == 2)
                    final_Num_value = Convert.ToDouble(value_1) * Convert.ToDouble(value_2);
                if (choice_num == 3)
                    final_Num_value = Convert.ToDouble(value_1) / Convert.ToDouble(value_2);
                final_value = Convert.ToString(final_Num_value);
                richTextBox1.Text = final_value;

            }
            if (richTextBox1.Text == "Invalid Input")
                deleter();
            output_counter = 0;
        }
        ///
        
        ///dot limiter to 1
        private void dot_Sign(object sender, EventArgs e)
        {
            nani();
            if (richTextBox1.Text.Contains("."))
                dot_counter = 1;
            else
                dot_counter = 0;
            if (dot_counter == 0 || final_value != "")
            {

                Button D_count = (Button)sender;
                storage.Add(D_count.Text);
                if (final_value != "")
                {
                    listBox1.Items.Clear(); richTextBox1.Clear(); final_value = ""; value_1 = ""; value_2 = "";
                }
                richTextBox1.Text += D_count.Text;
            }
        }
        ///
    }

     
}
























































/*
        private void button_magic()
        {
            List<Button> button_adder = new List<Button>();
            for (int i = 0; i < 24; i++)
            {
                int[] location = { 0, 119, 238, 357 };
                int[] button_value = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24};
                string button_name = "Button" + Convert.ToString(button_value[i]);
                button_adder.Add(new Button());
                groupBox1.Controls.Add(button_adder[i]);
                button_adder[i].AutoSize = true;
                if(i >= 4 && i <= 7)  
                {
                    int temp = 0;
                    if (i == 4) { temp = 0; }
                    if (i == 5) { temp = 1; }
                    if (i == 6) { temp = 2; }
                    if (i == 7) { temp = 3; }
                    button_adder[i].Location = new Point(location[temp], 89);
                }
                else if(i >= 8 && i <= 11)
                {
                    int temp = 0;
                    if (i == 8)  { temp = 0; }
                    if (i == 9) { temp = 1; }
                    if (i == 10) { temp = 2; }
                    if (i == 11) { temp = 3; }
                    button_adder[i].Location = new Point(location[temp], 159);
                }
                else if (i >= 12 && i <= 15)
                {
                    int temp = 0;
                    if (i == 12) { temp = 0; }
                    if (i == 13) { temp = 1; }
                    if (i == 14) { temp = 2; }
                    if (i == 15) { temp = 3; }
                    button_adder[i].Location = new Point(location[temp], 229);
                }
                else if (i >= 16 && i <= 19)
                {
                    int temp = 0;
                    if (i == 16) { temp = 0; }
                    if (i == 17) { temp = 1; }
                    if (i == 18) { temp = 2; }
                    if (i == 19) { temp = 3; }
                    button_adder[i].Location = new Point(location[temp], 299);
                }
                else if (i >= 20 && i <= 23)
                {
                    int temp = 0;
                    if (i == 20) { temp = 0; }
                    if (i == 21) { temp = 1; }
                    if (i == 22) { temp = 2; }
                    if (i == 23) { temp = 3; }
                    button_adder[i].Location = new Point(location[temp], 369);
                }
                else if (i == 20)
                {
                    int temp = 3;
                    button_adder[i].Location = new Point(location[temp], 369);
                }
                else
                    button_adder[i].Location = new Point(location[i], 19);

                button_adder[i].Size = new Size(120, 70);
                button_adder[i].Name = button_name;
                button_adder[i].Text = Convert.ToString("button_num" + button_value[i]);
                button_adder[i].TabIndex = i;
                button_adder[i].TabStop = true;
                button_adder[i].UseVisualStyleBackColor = true;
                button_adder[i].Click += new EventHandler(button_calculator);
            }
        }*/