using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmSoft
{
    public partial class frmmedics : Form
    {
        public frmmedics()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
        private void clear()
        {
            txtpid.Text = "";
            txtheight.Text = "";
            txtconsultant.Text = "";
            txtdepartment.Text = "";
            txtpulserate.Text = "";
            txtweght.Text = "";
            txtxrespiration.Text = "";
            txtxtemp.Text = "";
            txtbp.Text = "";
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
             try
                        {
                 
                            MySqlConnection   con = new MySqlConnection(cs.myconnection1);
                            string Query1 = "insert Into  patientparameter(patient_id,department,consultant,pulserate,temparature,height,bp,respiration,weght) VALUES ('" + Convert.ToInt32(txtpid.Text) + "','" +txtdepartment.Text+ "','" +txtconsultant.Text+ "','" + txtpulserate.Text + "','" + txtxtemp.Text + "','" + txtheight.Text + "','" + txtbp.Text + "','" + txtxrespiration.Text + "','" +txtweght.Text + "')";
                               
                            con.Open();
                            MySqlCommand mycommand1 = new MySqlCommand(Query1, con);                            
                            MySqlDataReader myreader1;
                            myreader1 = mycommand1.ExecuteReader();//execution command 
                      MessageBox.Show("Registered");
                     clear();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error check the data");
                            return;
                        }
                   
        }
    }
}
