using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmSoft
{
    public partial class frmpatientmaster : Form
    {
        public frmpatientmaster()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
        private void frmpatientmaster_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            try
            {

                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                myconn1.Open();
                string query = "select 	patient_id AS 'PATIENT ID',fname AS 'PATIENT NAME',gender AS GENDER ,county AS COUNTY,status AS 'CIVIL STATUS'from patient_registration ";


                MySqlCommand mycommand1 = new MySqlCommand(query, myconn1);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                myadapter.SelectCommand = mycommand1;
                DataTable dTable = new DataTable();
                myadapter.Fill(dTable);

                int a = dTable.Columns.Count;

                dataGridView1.DataSource = dTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "STOP!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                
                    MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                    myconn1.Open();
                    string query = "select 	patient_id AS 'PATIENT ID',fname AS 'PATIENT NAME',gender AS GENDER ,county AS COUNTY,status AS 'CIVIL STATUS'from patient_registration WHERE fname like '&" + txtsearch.Text + "&'";                


                    MySqlCommand mycommand1 = new MySqlCommand(query, myconn1);

                    MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                    myadapter.SelectCommand = mycommand1;
                    DataTable dTable = new DataTable();
                    myadapter.Fill(dTable);
                   
                    int a = dTable.Columns.Count;

                    dataGridView1.DataSource = dTable;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "STOP!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmpatientregistration fr = new frmpatientregistration();
            this.Hide();
            fr.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtsearch.Text = "";
            load();
        }
        private void update()
        {
           
           

        }
        private void btnmodify_Click(object sender, EventArgs e)
        {

            try
            {
                //modify the patient registration
                frmmedics ncs = new frmmedics();
                this.Hide();
                ncs.txtpid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();                             
                ncs.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error please check the data");
            }
        }

        private void btnnotes_Click(object sender, EventArgs e)
        {

            try
            {
                //modify the patient registration
                frmmedication nw = new frmmedication();
                this.Hide();
                nw.txtpid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                nw.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error please check the data");
            }
        }
        }
    }

