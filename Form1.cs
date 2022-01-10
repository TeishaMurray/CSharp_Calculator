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
        bool contdOperation = false;
        bool exceptionThrown = false;
        private void btnClick(object sender, EventArgs e)
        {
            if(equalsTriggered == false && contdOperation == false)
            {
                //create button object & cast button variable to sender object
                Button btn = (Button)sender;
                //set text for textBox1 control to text associated with btn obj
                textBox1.Text = btn.Text;
                expressionCache.Text = expressionCache.Text + btn.Text;
                //testing message
                System.Diagnostics.Debug.WriteLine(textBox1.Text);
            }
            else if(equalsTriggered == true && contdOperation == true)
            {
                Button btn = (Button)sender;
                textBox1.Text = btn.Text;
                expressionCache.Text = expressionCache.Text + btn.Text;
            }
            else
            {
                textBox1.Clear();
                System.Diagnostics.Debug.WriteLine("cache cleared");
                equalsTriggered = false;
                System.Diagnostics.Debug.WriteLine("new expression");
                Button btn = (Button)sender;
                textBox1.Text = btn.Text;
                expressionCache.Text = expressionCache.Text + btn.Text;
            }
        }

        private void clearClick(object sender, EventArgs e)
        {
            if(exceptionThrown == false)
            {
                Button btn = (Button)sender;
                textBox1.Clear();
                expressionCache.Clear();
                System.Diagnostics.Debug.WriteLine("all input has been cleared");
            }
            else
            {
                Button btn = (Button)sender;
                //use .Clear() to delete all text
                textBox1.Clear();
                errorsDisplay.Clear();
                expressionCache.Clear();
                //testing messages
                System.Diagnostics.Debug.WriteLine("input & error message cleared");
            }
            
        }

        private void operationBtn_Click(object sender, EventArgs e)
        {
            if (equalsTriggered == false)
            {
                Button btn = (Button)sender;
                textBox1.Text = btn.Text;
                expressionCache.Text = expressionCache.Text + btn.Text;
            }
            else if (equalsTriggered == true)
            {
                Button btn = (Button)sender;
                textBox1.Text = btn.Text;
                expressionCache.Text = expressionCache.Text + btn.Text;
                contdOperation = true;
            }
        }

        private void equalsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //store the user entries in a variable
                string storeExpression = expressionCache.Text;
                //testing variable
                System.Diagnostics.Debug.WriteLine("temp cache for equation" + storeExpression);
                //create data table object & use .Compute() to calculate result
                DataTable solveExpression = new DataTable();
                //use var (base class of all classes) allows to solve without instantiating datatype
                var result = solveExpression.Compute(storeExpression, " ");
                //testing Compute method
                System.Diagnostics.Debug.WriteLine("result = " + result);
                textBox1.Text = result.ToString();
                expressionCache.Text = result.ToString();
                //reset cache
                equalsTriggered = true;
            }
            catch (Exception)
            {
                errorsDisplay.Text = "Error: Sorry, operation not permitted";
                exceptionThrown = true;
            }
            
        }

        private void backClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox1.Clear();
            expressionCache.Text = expressionCache.Text.Substring(0, expressionCache.Text.Length -1);
        }
    }
}

//MVP
//calculator has basic functions and follows order of operations
//textbox / memory clears after hitting equals sign

//STRETCH GOALS
//striking new operation key allows continuation of expression using latest result - COMPLETE
//delete / backspace button - COMPLETE
//error messaging - COMPLETE
//+/- numbers button? (calculator can actual handle this function as is)
//history panel/window