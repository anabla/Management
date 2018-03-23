﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econtact.ExceptionClass;
using Econtact.InterfaceClass;
using System.Windows.Forms;

namespace Econtact.econtactClasses
{
    public class contactClass
    {
        //Getter Setter Properties 
        //Acts as Data Carrier in Our Application
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public virtual void Validate()
        {
            throw new HoteliException("Not implemented (Will be impl.by child classes!");
        }

        //SElecting Data from Database
        public DataTable Select()
        {
            ///Step 1: Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //Step 2: Writing SQL Query
                string sql = "SELECT * FROM tbl_contact";
                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (HoteliException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //Inserting DAta into Database
        public bool Insert(contactClass c)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;

            //STep 1: Connect DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //STep 2: Create a SQL Query to insert DAta
                string sql = "INSERT INTO tbl_contact (FirstName, LastName, ContactNo, Address, Gender) VALUES (@FirstName, @LastName, @ContactNo, @Address, @Gender)";
                //Creating SQL Command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                //Connection Open Here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully then the value of rows will be greater than zero else its value will be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (HoteliException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //Method to update data in database from our application
        public bool Update(contactClass c)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL to update data in our Database
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@Lastname, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";

                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add value
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("ContactID", c.ContactID);
                //Open DAtabase Connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if the query runs sucessfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (HoteliException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        //Method to Delete Data from DAtabase
        public bool Delete(contactClass c)
        {
            //Create a default return value and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL To Delte DAta
                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";

                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                //Open Connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query run sucessfully then the value of rows is greater than zero else its value is 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (HoteliException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return isSuccess;
        }


    }
    public class Room : contactClass
    {
        public override void Validate()
        {
            if (FirstName.Length == 0)
            {
                throw new HoteliException("FirstName is required");
            }
            if (LastName.Length == 0)
            {
                throw new HoteliException("LastName is required");
            }
            if (ContactNo.Length == 0)
            {
                throw new HoteliException("ContactNo is required");
            }
            if (Gender.Length == 0)
            {
                throw new HoteliException("Gender is not properly set");
            }
            if (Address.Length == 0)
            {
                throw new HoteliException("Address is required");
            }
        }
    }
    public class ConfRoom : contactClass, Rezervimi, Hoteli
    {
        //Variablat
        protected Boolean Kaklime { get; set; }
        protected Boolean Suit { get; set; }
        //Konstruktori
        public ConfRoom()
        {
            this.Kaklime = Kaklime;
            this.Suit = Suit;
        }
        //Metoda ne interface
        public Boolean getSuit()
        {
            return false;
        }
        //Metoda ne interface
        public Boolean getKaklime()
        {
            return true;
        }
        //Metoda required
        public override void Validate()
        {
            if (FirstName.Length == 0)
            {
                throw new HoteliException("FirstName is required");
            }
            if (LastName.Length == 0)
            {
                throw new HoteliException("LastName is required");
            }
            if (ContactNo.Length == 0)
            {
                throw new HoteliException("ContactNo is required");
            }
            if (Gender.Length == 0)
            {
                throw new HoteliException("Gender is not properly set");
            }
            if (Address.Length == 0)
            {
                throw new HoteliException("Address is required");
            }
        }
    }
    public class RoomEven : Room, Rezervimi, Hoteli
    {
        protected Boolean Kaklime { get; set; }
        protected Boolean Suit { get; set; }

        public RoomEven()
        {
            this.Kaklime = Kaklime;
            this.Suit = Suit;
        }
        public Boolean getSuit()
        {
            return true;
        }
        public Boolean getKaklime()
        {
            return true;
        }

        public override void Validate()
        {
            if (FirstName.Length == 0)
            {
                throw new HoteliException("FirstName is required");
            }
            if (LastName.Length == 0)
            {
                throw new HoteliException("LastName is required");
            }
            if (ContactNo.Length == 0)
            {
                throw new HoteliException("ContactNo is required");
            }
            if (Gender.Length == 0)
            {
                throw new HoteliException("Gender is not properly set");
            }
            if (Address.Length == 0)
            {
                throw new HoteliException("Address is required");
            }
        }
    }
    public class RoomOdd : Room, Rezervimi, Hoteli
    {
        protected Boolean Kaklime { get; set; }
        protected Boolean Suit { get; set; }

        public RoomOdd()
        {
            this.Kaklime = Kaklime;
            this.Suit = Suit;
        }
        public Boolean getSuit()
        {
            return false;
        }
        public Boolean getKaklime()
        {
            return true;
        }
        public override void Validate()
        {
            if (FirstName.Length == 0)
            {
                throw new HoteliException("FirstName is required");
            }
            if (LastName.Length == 0)
            {
                throw new HoteliException("LastName is required");
            }
            if (ContactNo.Length == 0)
            {
                throw new HoteliException("ContactNo is required");
            }
            if (Gender.Length == 0)
            {
                throw new HoteliException("Gender is not properly set");
            }
            if (Address.Length == 0)
            {
                throw new HoteliException("Address is required");
            }
        }
    }
}
