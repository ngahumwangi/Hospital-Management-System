using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace pharmSoft
{
    public partial class frmpatientregistration : Form
    {
        public frmpatientregistration()
        {
            InitializeComponent();
            cboyears.Items.Add("Years");
            cbomaincategory.Items.Add("OutPatient");
            cbomaincategory.Items.Add("InPatient");
           
           
        }
        //generate unique key
        
        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            //digits only
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txttelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //digits only
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        //Generate RandomNo
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        private void frmpatientregistration_Load(object sender, EventArgs e)
        { 
            try{

           
            //leads counties txt file and then add to combox
                string[] lineOfContents = File.ReadAllLines(Directory.GetCurrentDirectory()+"/counties.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                cbocounty.Items.Add(tokens[0]);
            }
                /****load bood groups****/

            //leads blood txt file and then add to combox
            string[] lineof = File.ReadAllLines(@"D:\PROJECTS AND IDEAS\Hospital system\Hospital management system\boutisoft\blood.txt");
            foreach (var line in lineof)
            {
                string[] tokens = line.Split(',');
                cbobloodgroup.Items.Add(tokens[0]);
            }
            /****load gender****/

            //leads gender txt file and then add to combox
            string[] lineOfContent = File.ReadAllLines(@"D:\PROJECTS AND IDEAS\Hospital system\Hospital management system\boutisoft\gender.txt");
            foreach (var line in lineOfContent)
            {
                string[] tokens = line.Split(',');
                cbogender.Items.Add(tokens[0]);
            }
            /****load bood groups****/

            //leads tittle txt file and then add to combox
            string[] lineOfContenti= File.ReadAllLines(@"D:\PROJECTS AND IDEAS\Hospital system\Hospital management system\boutisoft\tittle.txt");
            foreach (var line in lineOfContenti)
            {
                string[] tokens = line.Split(',');
                cbotittle.Items.Add(tokens[0]);
            
            }
                //defaultselections
            cboyears.SelectedIndex = 0;
            cbomaincategory.SelectedIndex = 1;
                //CURSOR focus
            txtfname.Focus();

                 }
            catch(Exception )
            {
                MessageBox.Show("Error while loading counties");
            }
        }

        private void fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtregno.Text = "P-" + GenerateRandomNo().ToString();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {

            // open file dialog 
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                picbox.Image = new Bitmap(open.FileName);
                // image file path
                txtphoto.Text = open.FileName;
            }
           
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            //clear picturebox
            picbox.Image.Dispose();
            picbox.Image = null;
            txtphoto.Text = "no pic";
        }

        private void txtfname_Validating(object sender, CancelEventArgs e)
        {
            if (txtfname.Text == string.Empty)
            {
                errorProvider1.SetError(txtfname, "Please Enter Name");
                errorProvider2.SetError(txtfname, "");
                errorProvider3.SetError(txtfname, "");
            }
            else
            {
                errorProvider1.SetError(txtfname, "");
                errorProvider2.SetError(txtfname, "");
                errorProvider3.SetError(txtfname, "Correct");
            }
        }

        private void lname_Validating(object sender, CancelEventArgs e)
        {
            if (txtlname.Text == string.Empty)
            {
                errorProvider1.SetError(txtlname, "Please Enter Last Name");
                errorProvider3.SetError(txtlname, "");
            }
            else
            {
                errorProvider1.SetError(txtlname, "");
                errorProvider3.SetError(txtlname, "Correct");
            }
        }



        private void dtp_Validating(object sender, CancelEventArgs e)
        {

            if (txtfname.Text == string.Empty)
            {
                errorProvider1.SetError(txtfname, "Please Select Gender");
                errorProvider3.SetError(txtfname, "");
            }
            else
            {
                errorProvider1.SetError(txtfname, "");
                errorProvider3.SetError(txtfname, "Correct");
            }
        }
 
     
       
       

      

       
        }
    }
