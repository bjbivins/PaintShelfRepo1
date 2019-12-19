using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Xml;
using MySql.Data.MySqlClient;

namespace BivinsBraxton_PaintShelf
{
    public partial class Form1 : Form
    {
        WebClient apiConnection = new WebClient();
        List<data> dataList = new List<data>();
        MySqlConnection conn = new MySqlConnection();
        DataTable theData = new DataTable();
        string connectionString = "";
        int row = 0;
        int maxCount = 0;
        string uid = "dbremoteuser"; //"dbsAdmin";
        string dbs = "paintshelf"; //"exampleDatabase";
        string pas = "password";

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


        string startingAPI = "https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVin/";
        string midAPI = "?format=xml&modelyear=";
        string VIN_API = "5UXWX7C5*BA";
        string YEAR_API = "2011";
        string apiEndPoint;
        string make;
        string model;

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

        private void BuildAPI()
        {
            apiEndPoint = startingAPI + VIN_API + midAPI + YEAR_API;
        }

        private void ReadFromAPI()
        {
            make = "";
            model = "";
            //string pnt_Code = "";
            // string pnt_Name = "";

            using (XmlReader apiData = XmlReader.Create(apiEndPoint))
            {
                while(apiData.Read())
                {
                    if (apiData.Name == "Make")
                    {
                        make = apiData.ReadElementContentAsString();
                    }

                    if (apiData.Name == "Model")
                    {
                        model = apiData.ReadElementContentAsString();
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            connectionString = BuildConnectionString(dbs, uid, pas);
            Connect(connectionString, dbs);
            //BuildAPI();
            //ReadFromAPI();

           // MessageBox.Show("Make: " + make + "Model: " + model);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void SelectColors(int cid)
        {
            string completeString = "No Paint stored";
            string sql = "SELECT Make, Year, PaintCode, PaintName FROM paints where ColorID = " + cid.ToString();

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
                        maxCount = numberOfRecords;

                        completeString += "Make = " + make + "\n" +
                                                "Year = " + year + "\n" +
                                                "Paint Code = " + paintCode + "\n" +
                                                "Paint Name = " + paintName + "\n\n";
                    }
                }
            }

            catch
            {
                completeString = "Connection to Database Failed";
            }
            MessageBox.Show(completeString);
        }

        private void RedButton_Click(object sender, EventArgs e)
        {
            // 1 RED //
            SelectColors(1);
        }

        private void BlueButton_Click(object sender, EventArgs e)
        {
            // 2 BLUE //
            SelectColors(2);
        }

        private void GreenButton_Click(object sender, EventArgs e)
        {
            // 3 GREEN //
            SelectColors(3);
        }

        private void YellowButton_Click(object sender, EventArgs e)
        {
            // 4 YELLOW //
            SelectColors(4);
        }

        private void PinkButton_Click(object sender, EventArgs e)
        {
            // 5 PINK //
            SelectColors(5);
        }

        private void BlackButton_Click(object sender, EventArgs e)
        {
            // 6 BLACK //
            SelectColors(6);
        }

        private void GrayButton_Click(object sender, EventArgs e)
        {
            // 7 GRAY //
            SelectColors(7);
        }

        private void SilverButton_Click(object sender, EventArgs e)
        {
            // 8 SILVER //
            SelectColors(8);
        }

        private void OrangeButton_Click(object sender, EventArgs e)
        {
            // 9 ORANGE //
            SelectColors(9);
        }

        private void PurpleButton_Click(object sender, EventArgs e)
        {
            // 10 PURPLE //
            SelectColors(10);
        }

        private void WhiteButton_Click(object sender, EventArgs e)
        {
            // 11 WHITE //
            SelectColors(11);
        }

        private void SpecialButton_Click(object sender, EventArgs e)
        {
            // 12 SPECIAL //
            SelectColors(12);
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
        }

        private void newPaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string make = "Dodge";
            int year = 2017;
            string paintCode = "PR4";
            string paintName = "Hot Rod Red";
            int colorId = 1;

            AddNewPaint(make, year, paintCode, paintName, colorId);
        }
    }
}
