using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmSoft
{
    public partial class frmmedication : Form
    {
        public frmmedication()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
        private void frmmedication_Load(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            txtpid.Text = "";
            txtconsultant.Text = "";
            txtnotes.Text = "";
            txtdiagnosis.Text = "";
            txtrecommedation.Text = "";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtnotes.Text=="")
                {
                    MessageBox.Show("Empty patient notes");
                    txtnotes.Focus();
                }
                else if (txtrecommedation.Text == "")
                {
                    MessageBox.Show("Please fill in the required data");
                    txtrecommedation.Focus();
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(cs.myconnection1);
                    string Query1 = "insert Into patientdoc(patient_id,consultant,notes,diagnosis,recommedations,datetime) VALUES ('" + Convert.ToInt32(txtpid.Text) + "','" + txtconsultant.Text + "','" + txtnotes.Text + "','" + txtdiagnosis.Text + "','" + txtrecommedation.Text + "','" + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + "')";
                    con.Open();
                    MySqlCommand mycommand1 = new MySqlCommand(Query1, con);
                    MySqlDataReader myreader1;
                    myreader1 = mycommand1.ExecuteReader();//execution command 
                    MessageBox.Show("Registered");
                    clear();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error please check the data");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prinreceipt();
        }
        private void prinreceipt()
        {
            try
            {
                PrintDialog printdialog = new PrintDialog();
                PrintPreviewDialog PrevieDialog = new PrintPreviewDialog();
                PrintDocument printdocument = new PrintDocument();
                printdialog.Document = printdocument;
                PrevieDialog.Document = printdocument;
                printdocument.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
                printdocument.Print();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            string kk = "       ";
            string kidogo = "    ";
            string push = "  ";
            string ssspace = "   ";
            string space = " ";
            string sspace = " ";
            string blankspace = "                                                                                             ";
            string blackspaceshort = "                          ";
            string underline = "---------------------------------------------------------------------------------------------";
            try
            {

                Graphics graphics = e.Graphics;
                Font font = new Font("Constantia", 10);
                float fontHeight = font.GetHeight();
                int startX = 5;
                int startY = 45;
                int Offset = 40;
                StringFormat str = new StringFormat();
                str.Alignment = StringAlignment.Near;
                str.LineAlignment = StringAlignment.Center;
                str.Trimming = StringTrimming.EllipsisCharacter;
                Pen p = new Pen(Color.White, 2.5f);
                graphics.DrawString(sspace + "KANGUNDO MEDICAL CENTRE", new Font("Constantia", 12), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(sspace + "TEL NO:" + "0202087761" + "KANGUNDO" + " ", new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(sspace + "DateTime:".PadRight(10) + DateTime.Now.ToShortDateString().PadRight(10) + DateTime.Now.ToShortTimeString(), new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(blankspace, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(kidogo + "Doctor's Note for patient No:" + space + "", new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(underline, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(txtnotes.Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(blankspace, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
 
                graphics.DrawString(kk +kk+ "We treat,God heals " + space, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
