using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace RegistrationForm
{
    public partial class Form1 : Form
    {

        public string connetionString = @"data source=MS-SQL8-14\SQL2008;initial catalog=dbSeapinesSupplierAPI;user id=atul;password=cis1234;MultipleActiveResultSets=True";
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd;
        int id = 0;

        public Form1()
        {
            InitializeComponent();
            showData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbSeapinesSupplierAPIDataSet.RegistrationFormNeha' table. You can move, or remove it, as needed.
            this.registrationFormNehaTableAdapter.Fill(this.dbSeapinesSupplierAPIDataSet.RegistrationFormNeha);

        }

        public void connectionCode(object sender, EventArgs e)
        {
            {
                string connetionString = null;
                SqlConnection cnn;
                connetionString = @"data source=MS-SQL8-14\SQL2008;initial catalog=dbSeapinesSupplierAPI;user id=atul;password=cis1234;MultipleActiveResultSets=True";
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();
                    // MessageBox.Show("Connection Open ! ");
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Can not open connection ! ");
                }
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fname.Text))
            {
                // errorProviderForfname.SetError(fname, "name should be filled");
                label1.Text = "name";
                label1.Visible = true;
            }
            if (string.IsNullOrEmpty(lname.Text))
            {
                // errorProviderForlname.SetError(lname, "last name should be filled");
                label2.Text = "last";
                label2.Visible = true;
            }
            if (string.IsNullOrEmpty(email.Text) /*&& !System.Text.RegularExpressions.Regex.IsMatch(email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")*/)
            {
                // errorProviderForemail.SetError(email, "email should be filled");
                label3.Text = "email";
                label3.Visible = true;
            }

            if (string.IsNullOrEmpty(contact.Text))
            {
                // errorProviderForcontact.SetError(contact, "contact should be filled");
                label4.Text = "contact";
                label4.Visible = true;
            }
            //if (System.Text.RegularExpressions.Regex.IsMatch(contact.Text, "[^0-9]"))
            //{
            //    //errorProviderForcontact.SetError(contact, "invalid number");
            //    label4.Text = "invalid number";
            //}
            if (state.SelectedItem == null)
            {
                //  errorProviderForstate.SetError(state, "select state");
                label5.Text = "state";
                label5.Visible = true;
                //errorProviderForcity.SetError(city, "select city");
                label6.Text = "city";
                label6.Visible = true;
            }
            else
            {
                insertionOfData();
            }
            /*else
       {
           errorProviderForstate.Clear();

              if (city.SelectedItem == null)
              {
              errorProviderForcity.SetError(city, "select city");
              }

       }*/
           //if(!(string.IsNullOrEmpty(lname.Text)) && (string.IsNullOrEmpty(fname.Text)) && (string.IsNullOrEmpty(email.Text)) 
           //     && (string.IsNullOrEmpty(contact.Text)) && (string.IsNullOrEmpty(state.Text))
           //     && (string.IsNullOrEmpty(city.Text)) && (string.IsNullOrEmpty(radioButton1.Text)))
           // {
                
           // }
                 showData();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {
            // errorProviderForfname.Clear();
            label1.Visible = false;
            if (string.IsNullOrEmpty(fname.Text))
            {
                //// errorProviderForfname.SetError(fname, "name should be filled");
                //label1.Text = "name";
                //label1.Visible = true;
            }

        }

        private void state_SelectedIndexChanged(object sender, EventArgs e)
        {
            //errorProviderForstate.Clear();
            label5.Visible = false;
            city.Items.Clear();
            switch (Convert.ToString(state.SelectedItem))
            {
                case "M.P.":
                    city.Items.AddRange(new string[] { "Mandsaur", "Neemuch", "Ratlam" });
                    break;
                case "Gujrat":
                    city.Items.AddRange(new string[] { "gandhi nagar", "surat", "dahod" });
                    break;
            }


        }

        private void reset_Click(object sender, EventArgs e)
        {
            fname.Clear();
            lname.Clear();
            email.Clear();
            contact.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            city.SelectedItem = null;
            state.SelectedItem = null;
            city.Items.Clear();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;


        }

        private void lname_TextChanged(object sender, EventArgs e)
        {
            // errorProviderForfname.Clear();
            label2.Visible = false;
            if (string.IsNullOrEmpty(lname.Text))
            {
                // errorProviderForfname.SetError(fname, "name should be filled");
                //label2.Text = "last";
                //label2.Visible = true;
            }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(email.Text))
            {
                // errorProviderForfname.SetError(fname, "name should be filled");
                //label3.Text = "email";
                //label3.Visible = true;
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    label3.Text = "invalid email";
                }
                else
                {
                    label3.Visible = false;
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {
            // errorProviderForcity.Clear();
            label6.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void fnamelabel_Click(object sender, EventArgs e)
        {
            if (fname.Text != null)
            {
                label1.Text = "";
            }
        }

        private void lnamelabel_Click(object sender, EventArgs e)
        {
            if (lname.Text != null)
            {
                label2.Text = "";
            }
        }

        private void emaillabel_Click(object sender, EventArgs e)
        {
            if (email.Text != null)
            {
                label3.Text = "";
            }
        }

        private void contactlabel_Click(object sender, EventArgs e)
        {
            if (contact.Text != null)
            {
                label4.Text = "";
            }
        }

        private void contact_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(contact.Text, "^[a-zA-Z]+$"))
            {
                contact.Text = "";
            }
            //  errorProviderForcontact.Clear();
            label4.Visible = false;
            if (string.IsNullOrEmpty(contact.Text))
            {
                // errorProviderForfname.SetError(fname, "name should be filled");
                //label4.Text = "contact";
                //label4.Visible = true;
            }
        }

        public void insertionOfData()
        {
            //try
            //{
                //SqlConnection cnn = new SqlConnection(connetionString);
                cnn.ConnectionString = connetionString;
                cnn.Open();
                string s = "INSERT INTO RegistrationFormNeha(first_name,last_name,email,contact,gender,state,city)" +
                   " VALUES ('" + fname.Text + "','" + lname.Text + "','" + email.Text + "'," + contact.Text + ",'" + radioButton1.Text + "', '" +
                    state.Text + "','" + city.Text + "')";
                cmd = new SqlCommand(s, cnn);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show(i + " Row(s) Inserted ");
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

        }

        public void showData()
        {
            //try
            //{
                cnn.ConnectionString = connetionString;
                cnn.Open();
                DataTable dt = new DataTable();
                //string m = "select * from RegistrationFormNeha";
                //    cmd = new SqlCommand(m, cnn);
                //  cmd.Fill(dt);

                //  DataTable dt = new DataTable();
                var adapt = new SqlDataAdapter("select * from RegistrationFormNeha", cnn);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            //}
            //catch
            //{

            //}
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                cmd = new SqlCommand("delete RegistrationFormNeha where id=@id", cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Record Deleted Successfully!");
                showData();
                fname.Text = "";
                lname.Text = "";
                email.Text = "";
                contact.Text = "";
                state.Text = "";
                city.Text = "";
                id = 0;
            }

            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
      
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            fname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            lname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            email.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            contact.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            state.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            city.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        public void Update_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(lname.Text))) /*&& (string.IsNullOrEmpty(fname.Text)) && (string.IsNullOrEmpty(email.Text))
              && (string.IsNullOrEmpty(contact.Text)) && (string.IsNullOrEmpty(state.Text))
               && (string.IsNullOrEmpty(city.Text)) && (string.IsNullOrEmpty(radioButton1.Text)))*/
                {
                    cmd = new SqlCommand("update RegistrationFormNeha set first_name=@name,last_name=@last where id=@id", cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", fname.Text);
                cmd.Parameters.AddWithValue("@last",lname.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                cnn.Close();
                showData();
                fname.Text = "";
                lname.Text = "";
                email.Text = "";
                contact.Text = "";
                state.Text = "";
                city.Text = "";
                
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }
    }

        
    }

