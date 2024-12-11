using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCODSurvey.Module;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PCODSurvey
{
    public partial class Form1 : Form
    {

        List<QuestionViewModel> _questionlist = new List<QuestionViewModel>();
        List<OptionViewModel> _optionlist = new List<OptionViewModel>();
        int currentindex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connectionString = "server=localhost\\SQLEXPRESS;database=pcodsurvey;integrated Security=SSPI;";

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT  * FROM Questiontable";



                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    DataTable Questiontable = new DataTable();

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(Questiontable);
                    _con.Close();


                    foreach (DataRow row in Questiontable.Rows)
                    {
                        QuestionViewModel _temp = new QuestionViewModel();
                        _temp.questionname = row["questionname"].ToString();
                        _questionlist.Add(_temp);
                    }

                }
            }

            label2.Text = _questionlist[0].questionname;

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT  * FROM Optiontable";



                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    DataTable OptionTable = new DataTable();

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(OptionTable);
                    _con.Close();


                    foreach (DataRow row in OptionTable.Rows)
                    {
                        OptionViewModel _temp = new OptionViewModel();
                        _temp.optionname = row["optionname"].ToString();
                        _temp.optionid = Convert.ToInt32(row["optionid"]);
                        _temp.optionvalue = Convert.ToInt32(row["optionvalue"]);
                        _optionlist.Add(_temp);
                    }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentindex = currentindex - 1;

            label2.Text = _questionlist[currentindex].questionname;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bool isanswered = true;

            //get the answer

            if (radioButton1.Checked == true)
            {
                _questionlist[currentindex].optionvalue = 5;

            }
            else if (radioButton2.Checked == true)
            {
                _questionlist[currentindex].optionvalue = 4;

            }
            else if (radioButton3.Checked == true)
            {
                _questionlist[currentindex].optionvalue = 3;

            }
            else if (radioButton4.Checked == true)
            {
                _questionlist[currentindex].optionvalue = 2;

            }
            else if (radioButton5.Checked == true)
            {
                _questionlist[currentindex].optionvalue = 1;

            }

            else
            {
                isanswered = false;
                MessageBox.Show("Please answer");
            }


            if (isanswered == true)
            {
                currentindex = currentindex + 1;
                if (currentindex < _questionlist.Count)
                {
                    label2.Text = _questionlist[currentindex].questionname;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                }
                else
                {
                    button3.Visible = true;
                    button2.Visible = false;
                }
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int totalcount = 0;

            foreach (QuestionViewModel que in _questionlist)
            {
                totalcount += que.optionvalue;
            }

            MessageBox.Show("Your total score is " + totalcount.ToString());

      
            string connectionString = "server=localhost\\SQLEXPRESS;database=pcodsurvey;integrated Security=SSPI;";
            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO UserRespMaster (dateofRes, totalScore) VALUES (@dateofRes, @totalScore)";

                using (SqlCommand _cmd = new SqlCommand(insertQuery, _con))
                {
                    _cmd.Parameters.AddWithValue("@dateofRes", DateTime.Now); 
                    _cmd.Parameters.AddWithValue("@totalScore", totalcount);

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }
            }

          

       
            ResultsForm resultsForm = new ResultsForm(totalcount);
            resultsForm.Show();
        }






        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                currentindex = currentindex - 1;

                label2.Text = _questionlist[currentindex].questionname;

            }
        }
    }
}

