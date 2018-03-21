using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econtact
{
    public partial class Login : Form
    {
        //Metoda e Konstruktori per login
        public Login() 
        {
            InitializeComponent();
            textBox2.PasswordChar='*';
        }
        enum Username
        {
            Artoni,
            Albana,
            Suferina,
        };
        //Metoda e Butonit
        private void button1_Click(object sender, EventArgs e)
        {
            String username = "Admin";
            String password = "123";

            Username user = Username.Artoni;

            if(user == Username.Artoni)
            {
                MessageBox.Show("U kyq Artoni");
            }else if(user == Username.Albana)
            {
                MessageBox.Show("U kyq Albana");

            }else{
                MessageBox.Show("U kyq Suferina");
            }
            if (textBox1.Text == username && textBox2.Text == password) {

                //Redirect to Hotel Management
                this.Hide();
                Econtact ec = new Econtact();
                ec.ShowDialog();
            }
            else {
                MessageBox.Show("This User Does Not Exist");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
