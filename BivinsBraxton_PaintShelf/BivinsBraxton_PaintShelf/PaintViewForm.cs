using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace BivinsBraxton_PaintShelf
{
    public partial class PaintViewForm : Form
    {
        MySqlConnection conn = new MySqlConnection();
        DataTable theData = new DataTable();
        string connectionString = "";
        string uid = "dbremoteuser"; //"dbsAdmin";
        string dbs = "paintshelf"; //"exampleDatabase";
        string pas = "password";
        string[] colors = new string[12] { "RED", "BLUE", "GREEN", "YELLOW", "PINK", "BLACK", "GRAY", "SILVER", "ORANGE", "PURPLE", "WHITE", "SPECIAL" };
        int maxCount = 0;


        public PaintViewForm(int cid)
        {
            InitializeComponent();
            HandleClientWindowSize();
            colorLabel.Text = colors[cid - 1];
            connectionString = BuildConnectionString(dbs, uid, pas);
            Connect(connectionString, dbs);
            SelectColors(cid);
        }

        void HandleClientWindowSize()
        {
            //Modify ONLY these float values
            float HeightValueToChange = 1.4f;
            float WidthValueToChange = 6.0f;

            //DO NOT MODIFY THIS CODE
            int height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Height / HeightValueToChange);
            int width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Width / WidthValueToChange);
            if (height < Size.Height)
                height = Size.Height;
            if (width < Size.Width)
                width = Size.Width;
            this.Size = new Size(width, height);
            //this.Size = new Size(376, 720);
        }


        public void SelectColors(int cid)
        {
            string completeString = "No Paint stored";
            string sql = "SELECT Make, Year, PaintCode, PaintName, id FROM paints where ColorID = " + cid.ToString();
            theData.Clear();
            try
            {
                MySqlDataAdapter adr = new MySqlDataAdapter(sql, conn);
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(theData);
                int numberOfRecords = theData.Select().Length;
                if (numberOfRecords > 0)
                {
                    completeString = "";
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string make = theData.Rows[i]["Make"].ToString();
                        int year = 0;
                        int.TryParse(theData.Rows[i]["Year"].ToString(), out year);
                        string paintCode = theData.Rows[i]["PaintCode"].ToString();
                        string paintName = theData.Rows[i]["PaintName"].ToString();
                        int pID = 0;
                        int.TryParse(theData.Rows[i]["id"].ToString(), out pID);
                        maxCount = numberOfRecords;
                        completeString = "Make: " + make +
                                          " Year: " + year +
                                          " Paint Code: " + paintCode +
                                          " Paint Name: " + paintName +
                                          " id: " + pID;
                        PaintInfo.Items.Add(completeString);
                    }
                }
            }

            catch
            {
                MessageBox.Show("FAILED");
            }
        }

        private string BuildConnectionString(string database, string uid, string pword)
        {
            string serverIP = "";
            try
            {
                using (StreamReader sr = new StreamReader("C:\\VFW\\connect.txt"))
                {
                    serverIP = sr.ReadToEnd();
                }
                string prt = "3306";
                return "server=" + serverIP + ";uid=" + uid +
                    ";pwd=" + pword + ";database=" + database + ";port=" + prt;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return "ERROR";
            }
        }

        private void Connect(string myConnectionString, string database)
        {
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();
                // connectStatus.Text = "Connected to: " + database;
            }

            catch (MySqlException e)
            {
                string msg = "";

                switch (e.Number)
                {
                    case 0:
                        {
                            msg = e.ToString();
                            break;
                        }

                    case 1042:
                        {
                            msg = "Can't Resolve Host Address.\n" + myConnectionString;
                            break;
                        }

                    case 1045:
                        {
                            msg = "Invalid Username or Password";
                            break;
                        }

                    default:
                        {
                            msg = e.ToString() + "\n" + myConnectionString;
                            break;
                        }
                }
                MessageBox.Show(msg);
            }
        }

        public void AddNewPaint(string make, int year, string paintCode, string paintName, int cid)
        {
            string sqlString = "insert into Paints ( Make, Year, PaintCode, PaintName, ColorID) values ('" +
                make + "', " + year + ", '" + paintCode + "', '" + paintName + "', " + cid + ")";
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            Connect(connectionString, dbs);
            try
            {
                using (MySqlCommand comm = new MySqlCommand(sqlString, conn))
                {
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }

            catch
            {
                MessageBox.Show("ERROR");
            }

            clearTexts();
        }

        private void PaintViewForm_Load(object sender, EventArgs e)
        {

        }

        private void PaintInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            DataRow theRow = theData.Rows[0];
            MakeText.Text = theRow["Make"].ToString();
            int year = 0;
            int.TryParse(theRow["Year"].ToString(), out year);
            YearUD.Value = year;
            pntCodeText.Text = theRow["PaintCode"].ToString();
            PntNameText.Text = theRow["PaintName"].ToString();
            ColorDrop.Text = colorLabel.Text;

            EditButton.Enabled = true;
            AddButton.Enabled = false;
            DeleteButton.Enabled = true;
        }

        private void clearTexts()
        {
            MakeText.Text = "";
            YearUD.Value = YearUD.Minimum;
            pntCodeText.Text = "";
            PntNameText.Text = "";
            ColorDrop.Text = "";
            EditButton.Enabled = false;
            AddButton.Enabled = false;
            DeleteButton.Enabled = false;
            int cid = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                if (colorLabel.Text == colors[i])
                {
                    cid = i + 1;
                }
            }
            SelectColors(cid);
            PaintInfo.Refresh();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int idd = 0;
            int colorID = 0;

            for (int i = 0; i < colors.Length; i++)
            {
                if (ColorDrop.Text.ToUpper() == colors[i].ToString())
                {
                    int theI = 0;
                    theI = i + 1;
                    colorID = theI;
                }
            }
            string sqlString2 = "UPDATE Paints SET Make =@Make, Year = @Year," +
                " PaintCode = @PaintCode, PaintName = @PaintName, ColorId = @ColorId WHERE id = @id;";

            DataRow theRow = theData.Rows[0];
            int.TryParse(theRow["id"].ToString(), out idd);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            Connect(connectionString, dbs);
            try
            {
                using (MySqlCommand comm = new MySqlCommand(sqlString2, conn))
                {
                    comm.Parameters.AddWithValue("@Make", MakeText.Text);
                    comm.Parameters.AddWithValue("@Year", YearUD.Value);
                    comm.Parameters.AddWithValue("@PaintCode", pntCodeText.Text);
                    comm.Parameters.AddWithValue("@PaintName", PntNameText.Text);
                    comm.Parameters.AddWithValue("@ColorId", colorID);
                    comm.Parameters.AddWithValue("@id", idd);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    PaintInfo.Items.Remove(PaintInfo.SelectedItem);
                }
            }

            catch
            {
                MessageBox.Show("ERROR");
            }

            clearTexts();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int year = 0;
            int.TryParse(YearUD.Value.ToString(), out year);
            int colorID = 0;

            for (int i = 0; i < colors.Length; i++)
            {
                if (ColorDrop.Text.ToUpper() == colors[i].ToString())
                {
                    int theI = 0;
                    theI = i + 1;
                    colorID = theI;
                }
            }
            AddNewPaint(MakeText.Text, year, pntCodeText.Text, PntNameText.Text, colorID);
        }

        private void allFilled()
        {
            if (EditButton.Enabled == false && DeleteButton.Enabled == false)
            {
                if (MakeText.Text != "" && pntCodeText.Text != "" && PntNameText.Text != "" &&
                   ColorDrop.Text != "")
                {
                    AddButton.Enabled = true;
                }

                else { AddButton.Enabled = false; }
            }

            else
            {
                AddButton.Enabled = false;
            }
        }

        private void MakeText_TextChanged(object sender, EventArgs e)
        {
            allFilled();
        }

        private void pntCodeText_TextChanged(object sender, EventArgs e)
        {
            allFilled();
        }

        private void PntNameText_TextChanged(object sender, EventArgs e)
        {
            allFilled();
        }

        private void ColorDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            allFilled();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int idd = 0;
            DataRow theRow = theData.Rows[0];
            int.TryParse(theRow["id"].ToString(), out idd);
            string sqlString = "DELETE FROM paints WHERE id = " + idd + ";";
            theData.Rows[0].Delete();
            if (conn.State == ConnectionState.Open) { conn.Close(); }
            Connect(connectionString, dbs);
            try
            {
                using (MySqlCommand comm = new MySqlCommand(sqlString, conn))
                {
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch { MessageBox.Show("ERROR"); }
            PaintInfo.Items.Remove(PaintInfo.SelectedItem);
            clearTexts();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
