using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trading_Simulation
{
    public partial class FormAuthenticate : Form , IDisposable
    {
        public event EventHandler eventsubmit;
        public event EventHandler eventclose;

        List<User> users;
        public FormAuthenticate()
        {
            InitializeComponent();
            users = new List<User>();
            userDB();

        }

        private void userDB()
        {
            //user 1
            User u1 = new User();
            u1.UserId = "User 1";
            u1.Password = "123";

            //user 2
            User u2 = new User();
            u2.UserId = "User 2";
            u2.Password = "124";

        }

        private void CloseForm()
        {
            this.Close();
            this.Dispose();
        }

        private bool ValidateUserEntry()
        { //TODO : For many Users

            bool isFound = false;

            string usid_entered = this.textBox1.Text;
            string password_entered = this.textBox2_password.Text;

            //find user
            var get_user = users.Where(x => x.Password.Equals(password_entered));

            if (get_user == null)
            {
                //user is not authorised
            }
            else
            {
                //user is not authorised
                isFound = true;
            }

            return isFound;
        }

        private void button1_submit_Click(object sender, EventArgs e)
        {

            if (this.eventsubmit != null)
            {
                this.eventsubmit(ValidateUserEntry(), e); // TODO -> Event Passed
            }


            this.CloseForm();   


        }

        private void button2_cancel_Click(object sender, EventArgs e)
        {
            if (this.eventclose != null)
            {
                this.eventclose("Cancel", e); // TODO -> Event Passed
            }

            this.CloseForm();
        }
    }

    class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }

}
