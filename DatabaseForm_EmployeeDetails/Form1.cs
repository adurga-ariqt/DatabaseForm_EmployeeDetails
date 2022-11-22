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

namespace DatabaseForm_EmployeeDetails
{
    public partial class Form1 : Form
    {
        string connetionString = "";
        SqlConnection sqlCon;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        string query = "";
        public Form1()
        {
            InitializeComponent();
        }

        // private void label4_Click(object sender, EventArgs e)
        //{

        //}

        // private void label3_Click(object sender, EventArgs e)
        //{

        //}



        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connetionString = "server=LAPTOP-4UV87UTN;Database=Srk_Demo;Trusted_Connection=true;";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                query = "Insert into Employee values(" + txtEmpID.Text + ", '" + txtEmpName.Text + "', " + txtEmpSalary.Text + ",'" + txtEmpAdress.Text + "')";
                sqlCon = new SqlConnection(connetionString);
                cmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();  
                MessageBox.Show("Employee Information Saved Successfully");
                 ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                query = "Update Employee Set EmpName= '" + txtEmpName.Text + "', EmpSalary = " + txtEmpSalary.Text + " ,EmpAdress = '" + txtEmpAdress.Text + "' Where EmpID= " + txtEmpID.Text + "";



                sqlCon = new SqlConnection(connetionString);
                cmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();



                MessageBox.Show("Employee Information Updated Successfully");
                 ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                query = "Select * from Employee Where EmpID= " + txtEmpID.Text + "";



                sqlCon = new SqlConnection(connetionString);
                adpt = new SqlDataAdapter(query, sqlCon);
                sqlCon.Open();
                DataSet ds = new DataSet();
                adpt.Fill(ds, "Employee");
                sqlCon.Close();



                if (ds != null && ds.Tables["Employee"].Rows.Count > 0)
                {
                    txtEmpName.Text = ds.Tables["Employee"].Rows[0]["EmpName"].ToString();
                    txtEmpSalary.Text = ds.Tables["Employee"].Rows[0]["EmpSalary"].ToString();
                    txtEmpAdress.Text = ds.Tables["Employee"].Rows[0]["EmpAdress"].ToString();
                }
                else
                {
                    MessageBox.Show("No Employee Information Found");
                     ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                query = "Delete from Employee Where EmpID= " + txtEmpID.Text + "";



                sqlCon = new SqlConnection(connetionString);
                cmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();



                MessageBox.Show("Employee Information Deleted Successfully");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }



        private void ClearFields()
        {
            txtEmpID.Text = "";
            txtEmpName.Text = "";
            txtEmpSalary.Text = "";
            txtEmpAdress.Text = "";
        }
    }
}

  

    


