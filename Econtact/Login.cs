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
            String username = "Albana";
            String password = "123";
            String username1 = "Artoni";
            String password1 ="123";
            String username2 = "Suferina";
            String password2 = "123";

            Username user = Username.Albana;
            Username user1 = Username.Artoni;
            Username user2 = Username.Suferina;
            
            if (textBox1.Text == username && textBox2.Text == password) {

               if (user == Username.Albana)
                {
                    MessageBox.Show("U kyq Albana");
                }
                this.Hide();
                Econtact ec = new Econtact();
                ec.ShowDialog();
            }
            else if(textBox1.Text == username1 && textBox2.Text == password1)
            {
                if (user1 == Username.Artoni)
                {
                    MessageBox.Show("U kyq Artoni");
                }
                this.Hide();
                Econtact ec = new Econtact();
                ec.ShowDialog();
            }
            else if(textBox1.Text == username2 && textBox2.Text == password2)
            {
                if (user2 == Username.Suferina)
                {
                    MessageBox.Show("U kyq Suferina");
                }
                this.Hide();
                Econtact ec = new Econtact();
                ec.ShowDialog();
            }
            else{
                MessageBox.Show("This User Does Not Exist");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
