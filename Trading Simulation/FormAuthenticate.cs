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
        #region SECTION: Define Variables
        public event EventHandler eventsubmit;
        public event EventHandler eventclose;

        List<User> users;
        #endregion

        #region SECTION: Define variable  + method in cosntructor
        public FormAuthenticate()
        {
            InitializeComponent();
            users = new List<User>();
            userDB();
        }

        #endregion

        #region SECTION: SIMULATE DB  , Where USER CREDENTIAL IS STORED
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
        #endregion

        #region SECTION: CLOSE FORM AND RELEASE MEMORY
        private void CloseForm()
        {
            this.Close();
            this.Dispose();
        }
        #endregion

        #region SECTION: Validate user ID and Password
        private bool ValidateUserEntry()
        { 
            //TODO : For many Users
            bool isFound = false;
            string usid_entered = this.textBox1.Text;
            string password_entered = this.textBox2_password.Text;
            //find user
            var get_user = users.Where(x => x.Password.Equals(password_entered));
            if (get_user == null)
            {
                //user is not authorised
                //isFound = false;
            }
            else
            {
                //user is not authorised
                isFound = true;
            }
            return isFound;
        }
        #endregion

        #region SECTION: EVENT "SUBMIT" Called , do this
        private void button1_submit_Click(object sender, EventArgs e)
        {
            if (this.eventsubmit != null)
            {
                this.eventsubmit(ValidateUserEntry(), e); // TODO -> Event Passed
            }
            this.CloseForm();   
        }
        #endregion

        #region SECTION: EVENT "CANCEL_EXIT" Called , do this
        private void button2_cancel_Click(object sender, EventArgs e)
        {
            if (this.eventclose != null)
            {
                this.eventclose("Cancel", e); // TODO -> Event Passed
            }
            this.CloseForm();
        }
        #endregion
    }
    #region SECTION: (POCO CLASS) BLUEPRINT of USER CREDENTIAL FIELDS 
    class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
    #endregion

}
