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
        MySqlConnection conn = new MySqlConnection(); // My Connection String
        DataTable theData = new DataTable(); // My Data table to be filled with SQL Data
        string connectionString = ""; // My Connection String
        string uid = "dbremoteuser"; //"dbsAdmin"; // My User ID
        string dbs = "paintshelf"; // My Database name
        string pas = "password";   // My User ID Password
        string[] colors = new string[12] { "RED", "BLUE", "GREEN", "YELLOW", "PINK", "BLACK", "GRAY", "SILVER", "ORANGE", "PURPLE", "WHITE", "SPECIAL" }; // Colors in Order 


        public PaintViewForm(int cid)
        {
            InitializeComponent(); // Always First
            HandleClientWindowSize(); // Window Size Code
            colorLabel.Text = colors[cid - 1]; // Text Label that shows the user what color thay are viewing
            connectionString = BuildConnectionString(dbs, uid, pas); // Connection String construction
            Connect(connectionString, dbs); // Connect to My Database
            SelectColors(cid); // list of stored paints in color group chozen by user
        }

        void HandleClientWindowSize() // Code given for iPhone Screen Size
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
            string completeString = "No Paint stored"; // Default Text
            string sql = "SELECT Make, Year, PaintCode, PaintName, id FROM paints where ColorID = " + cid.ToString(); // Select statement to view stored paint
            theData.Clear(); // clear sql data
            try
            {
                MySqlDataAdapter adr = new MySqlDataAdapter(sql, conn); // My SQL Adapter
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(theData); // Filling the data
                int numberOfRecords = theData.Select().Length; // total items in my data for specified color
                if (numberOfRecords > 0) // As long as there is one item, do the following
                {
                    completeString = ""; // clear default
                    for (int i = 0; i < numberOfRecords; i++) // iterate through records
                    {
                        string make = theData.Rows[i]["Make"].ToString(); // Store data in local variables
                        int year = 0;
                        int.TryParse(theData.Rows[i]["Year"].ToString(), out year);
                        string paintCode = theData.Rows[i]["PaintCode"].ToString();
                        string paintName = theData.Rows[i]["PaintName"].ToString();
                        int pID = 0;
                        int.TryParse(theData.Rows[i]["id"].ToString(), out pID);
                        completeString = "Make: " + make +
                                          " Year: " + year +
                                          " Paint Code: " + paintCode +
                                          " Paint Name: " + paintName +
                                          " id: " + pID; // display string
                        PaintInfo.Items.Add(completeString); // Add paints to specified list
                    }
                }
            }

            catch
            {
                MessageBox.Show("FAILED"); // error message
            }
        }

        private string BuildConnectionString(string database, string uid, string pword)
        {
            string serverIP = "";
            try
            {
                using (StreamReader sr = new StreamReader("C:\\VFW\\connect.txt")) // My VFW File
                {
                    serverIP = sr.ReadToEnd();
                }
                string prt = "3306";
                return "server=" + serverIP + ";uid=" + uid +
                    ";pwd=" + pword + ";database=" + database + ";port=" + prt; // Connection String
            }

            catch (Exception e) // Fail to connect message
            {
                MessageBox.Show(e.ToString());
                return "ERROR";
            }
        }

        private void Connect(string myConnectionString, string database)
        {
            try
            {
                conn.ConnectionString = myConnectionString; // Connection Successful
                conn.Open();
            }

            catch (MySqlException e) // Connection Fail with messages
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
                make + "', " + year + ", '" + paintCode + "', '" + paintName + "', " + cid + ")"; // Add New Paint String
            if (conn.State == ConnectionState.Open) // Close connection if open
            {
                conn.Close();
            }
            Connect(connectionString, dbs); // Connect
            try
            {
                using (MySqlCommand comm = new MySqlCommand(sqlString, conn)) // Read SQL string
                {
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }

            catch // Fail Message
            {
                MessageBox.Show("ERROR");
            }

            clearTexts(); // Clear all textboxes and deable edit, add, delete buttons
        }


        private void PaintInfo_MouseDoubleClick(object sender, MouseEventArgs e) // If item is double clicked
        {
            DataRow theRow = theData.Rows[0]; // Current Row
            MakeText.Text = theRow["Make"].ToString(); // Text box values are filled with selected item in list
            int year = 0;
            int.TryParse(theRow["Year"].ToString(), out year);
            YearUD.Value = year;
            pntCodeText.Text = theRow["PaintCode"].ToString();
            PntNameText.Text = theRow["PaintName"].ToString();
            ColorDrop.Text = colorLabel.Text;

            EditButton.Enabled = true; // unlock edit features
            AddButton.Enabled = false; // Dont add the same paint
            DeleteButton.Enabled = true; // unlock delete features
        }

        private void clearTexts() // clear all text boxes and lock all buttons
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
            SelectColors(cid); // Refresh List box values
            PaintInfo.Refresh();
        }

        private void EditButton_Click(object sender, EventArgs e) // ability to edit a selected paint
        {
            int idd = 0;
            int colorID = 0;

            for (int i = 0; i < colors.Length; i++) // iterate through colors to find color ID of paint
            {
                if (ColorDrop.Text.ToUpper() == colors[i].ToString())
                {
                    int theI = 0;
                    theI = i + 1;
                    colorID = theI;
                }
            }
            string sqlString2 = "UPDATE Paints SET Make =@Make, Year = @Year," +
                " PaintCode = @PaintCode, PaintName = @PaintName, ColorId = @ColorId WHERE id = @id;"; // Update sql statement

            DataRow theRow = theData.Rows[0]; // Selected items row
            int.TryParse(theRow["id"].ToString(), out idd); // get sql ID

            if (conn.State == ConnectionState.Open) // Close connection
            {
                conn.Close();
            }
            Connect(connectionString, dbs); // Connect to database
            try
            {
                using (MySqlCommand comm = new MySqlCommand(sqlString2, conn)) // Run SQL statement
                {
                    comm.Parameters.AddWithValue("@Make", MakeText.Text);
                    comm.Parameters.AddWithValue("@Year", YearUD.Value);
                    comm.Parameters.AddWithValue("@PaintCode", pntCodeText.Text);
                    comm.Parameters.AddWithValue("@PaintName", PntNameText.Text);
                    comm.Parameters.AddWithValue("@ColorId", colorID);
                    comm.Parameters.AddWithValue("@id", idd);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    PaintInfo.Items.Remove(PaintInfo.SelectedItem); // Remove pre edited item
                }
            }

            catch
            {
                MessageBox.Show("ERROR"); // Fail message
            }
            clearTexts(); // clear texts and lock buttons
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

        private void allFilled() // If all text boxes are filled and edit & delete button are locked, unlock add paint button to store a new item
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

        private void MakeText_TextChanged(object sender, EventArgs e) // ensure make text is filled
        {
            allFilled();
        } 

        private void pntCodeText_TextChanged(object sender, EventArgs e) // ensure paint code text is filled
        {
            allFilled();
        }

        private void PntNameText_TextChanged(object sender, EventArgs e) // ensure paint name is filled
        {
            allFilled();
        }

        private void ColorDrop_SelectedIndexChanged(object sender, EventArgs e) // ensure color dropdown has a value
        {
            allFilled();
        }

        private void DeleteButton_Click(object sender, EventArgs e) // Deletes item from database
        {
            int idd = 0;
            DataRow theRow = theData.Rows[0]; // the current selected row
            int.TryParse(theRow["id"].ToString(), out idd);
            string sqlString = "DELETE FROM paints WHERE id = " + idd + ";"; // delete sql string
            theData.Rows[0].Delete(); // delete local data on selected row
            if (conn.State == ConnectionState.Open) { conn.Close(); } // close connection
            Connect(connectionString, dbs); // connect to database
            try
            {
                using (MySqlCommand comm = new MySqlCommand(sqlString, conn)) // execute sql statement
                {
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch { MessageBox.Show("ERROR"); } // fail message
            PaintInfo.Items.Remove(PaintInfo.SelectedItem); // remove selected item
            clearTexts(); // clear texts and lock buttons
        }

        private void HomeButton_Click(object sender, EventArgs e) // close paint selection view form
        {
            this.Close();
        }
    }
}
