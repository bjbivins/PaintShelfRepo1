using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;
using System.IO;

namespace BivinsBraxton_PaintShelf
{
    public partial class VinDecoderForm : Form
    {
        string startingAPI = "https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVinValues/"; // Begining Of API call
        string midAPI = "*BA?format=xml&modelyear="; // API search Data
        string apiEndPoint; // End of API Call
        string make = "";
        string model = "";
        string paintCode = "";
        MySqlConnection conn = new MySqlConnection(); // My Connection String
        DataTable theData = new DataTable(); // My Data table to be filled with SQL Data
        string connectionString = ""; // My Connection String
        string uid = "dbremoteuser"; //"dbsAdmin"; // My User ID
        string dbs = "paintshelf"; // My Database name
        string pas = "password";   // My User ID Password
        string[] colors = new string[12] { "RED", "BLUE", "GREEN", "YELLOW", "PINK", "BLACK", "GRAY", "SILVER", "ORANGE", "PURPLE", "WHITE", "SPECIAL" }; // Colors in Order 

        private void BuildAPI(string vin, string year) // Build entire API String
        {
            apiEndPoint = startingAPI + vin + midAPI + year;
        }

        private void ReadFromAPI() // Read Data From API String
        {
            using (XmlReader apiData = XmlReader.Create(apiEndPoint)) // Create XML Reader
            {
                while (apiData.Read()) // Read XML
                {
                    if (apiData.Name == "Make") // retrieve make from API
                    {
                        make = apiData.ReadElementContentAsString();
                    }

                    if (apiData.Name == "Model") // retrieve model from API
                    {
                        model = apiData.ReadElementContentAsString();
                    }

                    if (apiData.Name == "ManufacturerId") // retrieve paint code from API
                    {
                        paintCode = apiData.ReadElementContentAsString();
                    }
                }
            }
        }

        public VinDecoderForm()
        {
            InitializeComponent();
            connectionString = BuildConnectionString(dbs, uid, pas); // Connection String construction
            Connect(connectionString, dbs); // Connect to My Database
        }

        private void VinDecoderForm_Load(object sender, EventArgs e)
        {

        }
        // TEST VIN and YEAR
        //2A8HR64X68R148067
        // 2008
        public void DecodeVin()
        {
            if (VinTText.Text != "") // Unlock vid decode button
            {
                vinDecodeButton.Enabled = true;
            }
        }

        private void vinDecodeButton_Click(object sender, EventArgs e)
        {
            BuildAPI(VinTText.Text, YearUD.Value.ToString()); // Build API String
            ReadFromAPI(); // read data from API
            makeText.Text = make; // set local variables to data from API
            modelText.Text = model;
            PaintCodeText.Text = paintCode;
            PaintNameText.Enabled = true; // Unlock paint name and color choices
            colorDrop.Enabled = true;
        }

        private void VinTText_TextChanged(object sender, EventArgs e) // When clicked, run vin decoder
        {
            DecodeVin(); 
        }

        private void YearUD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PaintNameText_TextChanged(object sender, EventArgs e) // Add Paint name and color category to successfully add to database
        {
            if (PaintNameText.Text != "" && colorDrop.Text != "")
            {
                AddPaint.Enabled = true;
            }

            else { AddPaint.Enabled = false; }
        }

        private void colorDrop_SelectedIndexChanged(object sender, EventArgs e) // Add Paint name and color category to successfully add to database
        {
            if (PaintNameText.Text != "" && colorDrop.Text != "")
            {
                AddPaint.Enabled = true;
            }

            else { AddPaint.Enabled = false; }

        }

        private void AddPaint_Click(object sender, EventArgs e)
        {
            int year = 0;
            int.TryParse(YearUD.Value.ToString(), out year);
            int colorID = 0;

            for (int i = 0; i < colors.Length; i++)
            {
                if (colorDrop.Text.ToUpper() == colors[i].ToString()) // Get Correct color category
                {
                    int theI = 0;
                    theI = i + 1;
                    colorID = theI;
                }
            }
            AddNewPaint(makeText.Text, year, PaintCodeText.Text, PaintNameText.Text, colorID); // Add new paint to database
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

        private void clearTexts() // clear all text boxes and lock all buttons
        {
            VinTText.Text = "";
            YearUD.Value = YearUD.Minimum;
            makeText.Text = "";
            modelText.Text = "";
            PaintCodeText.Text = "";
            PaintNameText.Text = "";
            colorDrop.Text = "";
            vinDecodeButton.Enabled = false;
            AddPaint.Enabled = false;
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Close(); // close dialog box
        }
    }
}


/// SKIZMO ///
// FAKE //
// http://vinapi.skizmo.com/vins/ 

/// FORTELLIS ///
// WAITING FOR AUTH CODE // DOESNT RETURN PAINT FROM VIN // 
// https://api.fortellis.io/service/reference/v4/vehicle-specifications/vins/{vin} 
// WAITING FOR AUTH CODE // ONLY CARS BEING SERVICED // 
// https://developer.fortellis.io/api-reference/vehicle-service/service-vehicle-specifications-api
// WAITING FOR AUTH CODE // ONLY CARS BEING SOLD // 
// https://api.fortellis.io/sales/inventory/v2/merchandisable-vehicles/

/// NHTSA ///
// https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVin/5UXWX7C5*BA?format=xml&modelyear=2011

