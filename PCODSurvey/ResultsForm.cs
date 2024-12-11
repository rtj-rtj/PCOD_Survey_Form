using System;
using System.Windows.Forms;

namespace PCODSurvey
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(int totalScore)
        {
            InitializeComponent();

            if (totalScore > 25)
            {
                lblResult.Text = "You have PCOD.";
            }
            else
            {
                lblResult.Text = "You don't have PCOD.";
            }

            lblScore.Text = "Your total score is: " + totalScore.ToString();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            // Any additional logic when the results form is loaded (if necessary)
        }
    }

}
