using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Question1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool quitflag = true;

            //convert input in textbox to string
            string childName = Convert.ToString(txtName.Text);
            string childToy = txtToy.Text;
            
            //parse date entered 
            DateTime childBirthday = DateTime.Parse(txtBirthDate.Text);

            //quitflad is value returned from method
            quitflag =ValidationCheck(childName);

            //get current date
            DateTime currentDate = DateTime.Now;

            //create christmas date
            DateTime christmas = new DateTime(2016, 12, 25);

            //numDays is days till christmas from current date
            TimeSpan numDays = christmas.Subtract(currentDate);
            int days = numDays.Days;

            //get total hours till christmas
            TimeSpan numHours = christmas.Subtract(currentDate);
            double h = numHours.TotalHours;
            double hours =Math.Round(h, 0);

            //get age of user - minus the childs birthday from the current date
            int ages = currentDate.Year- childBirthday.Year;
             
            //condition used to cheang the tense of the sentence
            string condition;
            
            //if birthday month is current month
            if(childBirthday.Month == currentDate.Month)
            {
                condition = "is";
            }
            else
                condition = "was";
            
            string month = childBirthday.ToString("MMMM");




            //if method has returned true
            if (quitflag==true)
            {
                MessageBox.Show(
                        "Hi " + childName + "\n\n" +

                        "\t" + "Only " + days + " days to Christmas that's only " + hours + " hours to " + "\n" +
                        "\t" + "go... wow your birthday " + condition + " in " + month + "...you are" + "\n" +
                        "\t" + ages + "... see you soon with your " + childToy + "\n\n"

                        + "See you soon ..." + "\n\n"

                        + "Santa"

                        );
            }
            
            
        }
        //method for form validation
        public bool ValidationCheck(string childName)
        {
            //if a toy is not entered
            if (txtToy.Text == "")
            {
                MessageBox.Show(
                "Toy is a required field.",
                "Entry Error");
                txtToy.Focus();
                return false;
            }
            //if name not entered
            if (txtName.Text == "")
            {
                MessageBox.Show(
                "Name a required field.",
                "Entry Error");
                txtName.Focus();
                return false;
            }
            //if birthdate is not entered
            if (txtBirthDate.Text == "")
            {
                MessageBox.Show(
                "Date of birth is a required field.",
                "Entry Error");
                txtBirthDate.Focus();
                return false;
            }
            //if a digit is entered in name field
            foreach (var letter in childName)
            {
                bool isDigit = char.IsDigit(letter);
                if (isDigit)
                {
                    MessageBox.Show("Name entered must be a character type."+"\n"+
                        "e.g. John Smith"+"\n"+
                    "Entry Error");
                    txtName.Focus();
                    return false;
                }
            }
          
            //default return value
            return true;
            

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
