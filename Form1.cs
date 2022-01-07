using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class calcForm : Form
    {
        public calcForm()
        {
            InitializeComponent();
        }

        bool equalsTriggered = false;
        private void btnClick(object sender, EventArgs e)
        {
            if(equalsTriggered == false)
            {
                //create button object & cast button variable to sender object
                Button btn = (Button)sender;
                //set text for textBox1 control to text associated with btn obj
                textBox1.Text = textBox1.Text + btn.Text;
                //testing message
                System.Diagnostics.Debug.WriteLine(textBox1.Text);
            }
            else
            {
                textBox1.Clear();
                System.Diagnostics.Debug.WriteLine("cache cleared");
                equalsTriggered = false;
                System.Diagnostics.Debug.WriteLine("new expression");
                Button btn = (Button)sender;
                textBox1.Text = textBox1.Text + btn.Text;
            }
        }

        private void clearClick(object sender, EventArgs e)
        {
            //use .Clear() to delete all text
            textBox1.Clear();
            //testing messages
            System.Diagnostics.Debug.WriteLine("all text has been cleared");
            System.Diagnostics.Debug.WriteLine("text box test " + textBox1.Text);
        }

        private void equalsBtn_Click(object sender, EventArgs e)
        {
            //store the user entries in a variable
            string storeExpression = textBox1.Text;
            //testing variable
            System.Diagnostics.Debug.WriteLine(storeExpression);   
            //create data table object & use .Compute() to calculate result
            DataTable solveExpression = new DataTable();
            //use var (base class of all classes) allows to solve without instantiating datatype
            var result = solveExpression.Compute(storeExpression, " ");
            //testing Compute method
            System.Diagnostics.Debug.WriteLine("result = " + result);
            textBox1.Text = result.ToString();
            //reset cache
            equalsTriggered = true;
        }
    }
}

//MVP
//calculator has basic functions and follows order of operations
//textbox / memory clears after hitting equals sign

//STRETCH GOALS
//striking new operation key allows continuation of expression using latest result
//delete / backspace button
//error messaging
//+/- numbers button? (calculator can actual handle this function as is)
//history panel/window