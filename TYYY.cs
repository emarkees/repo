using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concrate
{
    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Elev8"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Insert into [TableName](Properties) Values(content)
                    String query = "INSERT INTO Employeeinfo(Surname,OtherNames,Gender, MobileNo,Address,DateofBirth) Values(@Surname,@OtherNames,@Gender, @MobileNo,@Address, @DateofBirth)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                        command.Parameters.AddWithValue("@OtherNames", txtOtherNames.Text);
                        command.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        command.Parameters.AddWithValue("@DateofBirth", DateofBirth.Value);
                        command.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                        else
                        {
                            MessageBox.Show("Record Added Successfully.");
                            clear();
                        }


                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }



        }
        void clear()
        {

            txtAddress.Text = String.Empty;
            txtMobileNo.Text = String.Empty;
            txtOtherNames.Text = String.Empty;
            txtSurname.Text = String.Empty;
            cmbGender.Text = String.Empty;
		    cmbAge.Text = String.Empty;
		    cmbNationality.Text = String.Empty;
		    cmbStateofOrigin.Text = String.Empty;
		    cmbLGA.Text = String.Empty;
            DateofBirth.Text = String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String sql = "SELECT * FROM FamilyVerification";

                SqlCommand sqlcom = new SqlCommand(sql, connection);
                try
                {
                    sqlcom.Connection.Open();
                    sqlcom.ExecuteNonQuery();
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    DataTable datatable = new DataTable();
                    datatable.Load(reader);
                    dgView.DataSource = datatable;
                    //MessageBox.Show("LEFT OUTER成功");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Update [TableName] set Property=@Value where PK=?
                    String query = "Update Employeeinfo set Surname=@Surname, OtherNames=@OtherNames, Gender=@Gender, DateofBirth=@DateofBirth, MobileNo=@MobileNo, Address=@Address where Id= @1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                        command.Parameters.AddWithValue("@OtherNames", txtOtherNames.Text);
                        command.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        command.Parameters.AddWithValue("@DateofBirth", DateofBirth.Value);
                        command.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        connection.Open();
                        int result = command.ExecuteNonQuery();


                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error Updating data in Database!");
                        }
                        else
                        {
                            MessageBox.Show("Record Updated Successfully.");
                            clear();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        

        }

         private void button4_Click(object sender, EventArgs e)
         {
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        //Delete [TableName] set Property=@Value where PK=?
                        string query = "Delete FROM Employeeinfo where Surname=@Surname, OtherNames=@OtherNames, Gender=@Gender, DateofBirth=@DateofBirth, MobileNo=@MobileNO, Address=@Address where";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                            command.Parameters.AddWithValue("@OtherNames", txtOtherNames.Text);
                            command.Parameters.AddWithValue("@Gender", cmbGender.Text);
                            command.Parameters.AddWithValue("@DateofBirth", DateofBirth.Value);
                            command.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text);
                            command.Parameters.AddWithValue("@Address", txtAddress.Text);

                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            if (result < 0)
                            {
                                Console.WriteLine("Error Delete data in Database!");
                            }
                            else
                            {
                                MessageBox.Show("Record Deleted Successfully.");
                                clear();
                            }
                        }



                        // Check Error
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                   
                }
            }
        }
    }
}
