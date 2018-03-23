﻿using Econtact.econtactClasses;
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
using Econtact.FactoryClasses;

namespace Econtact
{
    struct mbyll
    {
        public string mbyllet;
    }
    public partial class Econtact : Form
    {
        private contactClass a = null;

        public Econtact()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the value from the input fields
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;

            //Inserting Data into Database
            bool success = c.Insert(c);
            if(success==true)
            {
                //Successfully Inserted
                MessageBox.Show("New Contact Successfully Inserted");
                //Call the Clear Method Here
                Clear();
            }
            else
            {
                //Failed to Add Contact
                MessageBox.Show("Failed to add New Contact. Try Again.");
            }
            //Load Data on Data Gridview
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void Econtact_Load(object sender, EventArgs e)
        {
            //Load Data on Data Gridview
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }
        mbyll cl = new mbyll();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            cl.mbyllet = "Aplikacioni po mbyllet!";
            MessageBox.Show(cl.mbyllet);
            Application.Exit();
        }
        //Method to Clean Fields
        public void Clear()
        {
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtBoxContactNumber.Text = "";
            txtBoxAddress.Text = "";
            cmbGender.Text = "";
            txtboxContactID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the Data from textboxes
            c.ContactID = int.Parse(txtboxContactID.Text);
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;
            //Update Data in Database
            bool success = c.Update(c);
            if(success==true)
            {
                //Updated Successfully
                MessageBox.Show("Contact has been successfully Updated.");
                //Load Data on Data Gridview
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                //Call Clear Method
                Clear();
            }
            else
            {
                //Failed to Update
                MessageBox.Show("Failed to Update Contact.Try Again.");
            }
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxContactNumber.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Call Clear Method Here
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the Contact ID fromt Application
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            bool success = c.Delete(c);
            if(success==true)
            {
                //Successfully Deleted
                MessageBox.Show("Contact successfully deleted.");
                //Refresh Data GridView
                //Load Data on Data GRidview
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                //Call the Clear Method Here
                Clear();
            }
            else
            {
                //Failed to Delete
                MessageBox.Show("Failed to Delete Dontact. Try Again.");
            }
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get teh value from text box
            string keyword = txtboxSearch.Text;
            
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE FirstName LIKE '%"+keyword+"%' OR ContactID LIKE '%"+keyword+"%' OR LastName LIKE '%"+keyword+"%' OR Address LIKE '%"+keyword+"%'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = Factory.Create(comboBox1.Text);
        }
    }
}