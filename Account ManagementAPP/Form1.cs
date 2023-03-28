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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Account_ManagementAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Account Management APP";
            label1.Show();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            dataGridView1.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Account Management APP";
            label1.Show();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            dataGridView1.Hide();

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Register Account";
            label1.Hide();
            label2.Hide();
            label3.Show();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox1.Hide();
            textBox2.Show();
            textBox2.Text = "";
            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.Black;
            textBox2.ReadOnly = false;
            textBox3.Hide();
            textBox3.Text = "";
            textBox4.Hide();
            textBox4.Text = "";
            button1.Show();
            button2.Hide();
            button3.Hide();
            button3.Text = "REGISTER";
            button4.Hide();
            button5.Hide();
            button6.Hide();
            dataGridView1.Hide();
            button1.Text = "Enter username";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox2.Text.Trim().ToString();
            string passWord = textBox3.Text.Trim().ToString();
            string confirmPass = textBox4.Text.Trim().ToString();
            if (!string.IsNullOrEmpty(userName))
            {
                string connectionString;
                SqlConnection con;
                connectionString = @"Data Source=MARKPINEDA\SQLEXPRESS;Initial Catalog=GroupProjectABM;User Id=sa;Password=mark28";
                con = new SqlConnection(connectionString);
                con.Open();
                bool exist = false;
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*)  AS Username FROM [tblgroupABM] WHERE Username = @Username", con);
                cmd.Parameters.AddWithValue("@Username", userName);
                exist = (int)cmd.ExecuteScalar() > 0;
                if (exist)
                {
                    MessageBox.Show($"Username already Exist!\nTry another Username");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    return;
                }
                else
                {
                    label4.Show();
                    textBox3.Show();
                    button2.Show();
                    textBox2.ReadOnly = true;
                    if (textBox2.ReadOnly == true)
                    {
                        textBox2.BackColor = Color.LightGray;
                        textBox2.ForeColor = Color.Maroon;
                        textBox2.Font = new Font(textBox2.Font, FontStyle.Bold);
                        return;
                    }
                    else
                    {
                        textBox2.BackColor = Color.White;
                        textBox2.ForeColor = Color.Black;
                        return;
                    }
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button3.Text == "REGISTER")
            {
                textBox3.Text = "";
                textBox4.Text = "";
            }
            if(button3.Text == "UPDATE")
            {
                textBox3.Text = "";
                textBox4.Text = "";
            }
            if(button3.Text =="DELETE ACCOUNT")
            {
                textBox3.Text = "";
                textBox4.Text = "";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userID = textBox1.Text.Trim().ToString();
            string userName = textBox2.Text.Trim().ToString();
            string passWord = textBox3.Text.Trim().ToString();
            string confirmPass = textBox4.Text.Trim().ToString();
            SqlConnection con;
            string connectionString = @"Data Source=MARKPINEDA\SQLEXPRESS;Initial Catalog=GroupProjectABM;User Id=sa;Password=mark28"; ;
            con = new SqlConnection(connectionString);
            con.Open();
            if (button3.Text == "REGISTER")
            {
                SqlCommand goregister = new SqlCommand("insert into tblgroupABM(Username,Password,isActive) Values(@Username,@Password,@isActive)", con);
                goregister.Parameters.AddWithValue("@Username", userName);
                goregister.Parameters.AddWithValue("@Password", passWord);
                goregister.Parameters.AddWithValue("@isActive", true);
                goregister.ExecuteNonQuery();
                MessageBox.Show($"You Have Registered your Account:\n\t\t{userName.ToUpper()}");
                textBox2.Text = "";
                textBox2.BackColor = Color.White;
                textBox2.ForeColor = Color.Black;
                label4.Hide();
                textBox3.Text = "";
                textBox3.Hide();
                label5.Hide();
                textBox4.Text = "";
                textBox4.Hide();

                return;
            }
            if(button3.Text == "UPDATE")
            {
                SqlCommand goupdate = new SqlCommand("Update tblgroupABM set Password=@Password where UserID = @UserID", con);
                goupdate.Parameters.AddWithValue("@Password", confirmPass);
                goupdate.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter da = new SqlDataAdapter();
                goupdate.ExecuteNonQuery();
                MessageBox.Show($"You sucessfully updated your password:\n\t\t{userName.ToUpper()}");
                textBox1.Text = "";
                textBox1.ReadOnly = false;
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                label3.Hide();
                textBox2.Hide();
                textBox2.Text = "";
                textBox2.BackColor = Color.White;
                textBox2.ForeColor = Color.Black;
                label4.Hide();
                textBox3.Hide();
                textBox3.Text = "";
                textBox4.Text = "";
                return;

            }
            if(button3.Text =="DELETE ACCOUNT")
            {
               bool passWordCheck = false;
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*)  AS Password FROM [tblgroupABM] WHERE Password = @Password", con);
                cmd.Parameters.AddWithValue("@Password", confirmPass);
                passWordCheck = (int)cmd.ExecuteScalar() == 0;
                if (passWordCheck)
                {

                    MessageBox.Show($"{userName}:  You have entered incorrect password.\n\tTry again!");
                    textBox3.Text = "";
                    textBox4.Text = "";
                    return;
                }
                else
                {
                        SqlCommand godelete = new SqlCommand("delete from tblgroupABM where UserID=@UserID", con);
                        godelete.Parameters.AddWithValue("@UserID", userID);
                    DialogResult deleteDialog = MessageBox.Show($"Are you sure you want to delete your Account?\n\t{userName}", "", MessageBoxButtons.YesNo);
                    if (deleteDialog == DialogResult.Yes)
                    {
                        MessageBox.Show($"You have deleted your account:\n\t{userName.ToUpper()}");
                        textBox1.Text = "";
                        textBox1.ReadOnly = false;
                        textBox1.BackColor = Color.White;
                        textBox1.ForeColor = Color.Black;
                        label3.Hide();
                        textBox2.Hide();
                        textBox2.Text = "";
                        textBox2.BackColor = Color.White;
                        textBox2.ForeColor = Color.Black;
                        label4.Hide();
                        textBox3.Hide();
                        textBox3.Text = "";
                        textBox4.Text = "";
                        godelete.ExecuteNonQuery();
                        return;
                    }
                    else
                    {
                        return;
                    }
                    
                }
            }
            
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                button3.Hide();
                label5.Hide();
                textBox4.Hide();
            }
            else
            {
                button2.Show();
                button3.Show();
                button3.Enabled = false;
                label5.Show();
                textBox4.Show();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                button3.Enabled = false;
                label6.Show();
                label7.Show();
            }
            else
            {
                button3.Enabled = true;
                label6.Hide();
                label7.Hide();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Exit";
            DialogResult exitDialog = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo);
            if (exitDialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Update Account";
            label1.Hide();
            label2.Show();
            label3.Hide();
            label4.Hide();
            label4.Text = "New Password";
            label5.Hide();
            label5.Text = "Confirm new Password";
            label6.Hide();
            label7.Hide();
            textBox1.Show();
            textBox1.Text = "";
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.Black;
            textBox1.ReadOnly = false;
            textBox2.Hide();
            textBox2.Text = "";
            textBox2.ReadOnly = false;
            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.Black;
            textBox3.Hide();
            textBox3.Text = "";
            textBox4.Hide();
            textBox4.Text = "";
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button3.Text = "UPDATE";
            button4.Show();
            button5.Hide();
            button6.Hide();
            dataGridView1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string UserId = textBox1.Text.Trim().ToString();

            string connectionString;
            SqlConnection con;
            connectionString = @"Data Source=MARKPINEDA\SQLEXPRESS;Initial Catalog=GroupProjectABM;User Id=sa;Password=mark28";
            con = new SqlConnection(connectionString);
            bool userIdCheck = false;
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT COUNT(*)  AS Username FROM [tblgroupABM] WHERE UserId = @UserID", con);
            cmd.Parameters.AddWithValue("@UserID", UserId);
            userIdCheck = (int)cmd.ExecuteScalar() == 0;
            if (userIdCheck)
            {
                MessageBox.Show($"This User ID does not exist!\nTry again");
                textBox1.Text = "";
                return;
            }
            else
            {
                label3.Show();
                textBox2.Show();
                SqlCommand command = new SqlCommand("select UserID,UserName,Password,isActive from tblgroupABM where UserID='" + int.Parse(textBox1.Text) + "'", con);
                SqlDataReader da = command.ExecuteReader();
                while (da.Read())
                {
                    textBox2.Text = da.GetValue(1).ToString();
                    textBox1.ReadOnly = true;
                    textBox1.BackColor = Color.LightGray;
                    textBox1.ForeColor = Color.Maroon;
                    textBox1.Font = new Font(textBox2.Font, FontStyle.Bold);
                    textBox2.ReadOnly = true;
                    textBox2.BackColor = Color.LightGray;
                    textBox2.ForeColor = Color.Maroon;
                    textBox2.Font = new Font(textBox2.Font, FontStyle.Bold);
                }
                con.Close();
                label4.Show();
                textBox3.Show();
            }
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Delete Account";
            label1.Hide();
            label2.Show();
            label3.Hide();
            label4.Hide();
            label4.Text = "Password";
            label5.Hide();
            label5.Text = "Confrim Password";
            label6.Hide();
            label7.Hide();
            textBox1.Show();
            textBox1.Text = "";
            textBox1.ReadOnly = false;
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.Black;
            textBox2.Hide();
            textBox2.Text = "";
            textBox2.ReadOnly = false;
            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.Black;
            textBox3.Hide();
            textBox3.Text = "";
            textBox4.Hide();
            textBox4.Text = "";
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button3.ForeColor = Color.Red;
            button3.Text = "DELETE ACCOUNT";
            button4.Show();
            button5.Hide();
            button6.Hide();
            dataGridView1.Hide();
        }

        private void viewRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Database";
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Show();
            button6.Show();
            dataGridView1.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            string connectionString = @"Data Source=MARKPINEDA\SQLEXPRESS;Initial Catalog=GroupProjectABM;User Id=sa;Password=mark28";
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter SQdA = new SqlDataAdapter("Select * From tblgroupABM", conn);
            DataTable dt = new DataTable();
            SQdA.Fill(dt);
            dataGridView1.Show();
            dataGridView1.DataSource = dt;

            return;
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Show();
            button6.Show();
            dataGridView1.Hide();
        }
    }
}
