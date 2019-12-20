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

namespace BivinsBraxton_PaintShelf
{
    public partial class VinDecoderForm : Form
    {
        //WebClient apiConnection = new WebClient(); // API connection variable

        string startingAPI = "https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVinValues/"; // Begining Of API call
        string midAPI = "*BA?format=xml&modelyear="; // API search Data
        //string VIN_API = "5UXWX7C5"; // VIN for VIN Decode
        //string YEAR_API = "2011"; // Year for VIN Decode
        string apiEndPoint; // End of API Call
        string make = "";
        string model = "";
        string paintCode = "";

        private void BuildAPI(string vin, string year) // Build entire API String
        {
            apiEndPoint = startingAPI + vin + midAPI + year;
        }

        private void ReadFromAPI() // Read Data From API String
        {
            //string pnt_Code = "";
            // string pnt_Name = "";

            using (XmlReader apiData = XmlReader.Create(apiEndPoint))
            {
                while (apiData.Read())
                {
                    if (apiData.Name == "Make")
                    {
                        make = apiData.ReadElementContentAsString();
                    }

                    if (apiData.Name == "Model")
                    {
                        model = apiData.ReadElementContentAsString();
                    }

                    if (apiData.Name == "ManufacturerId")
                    {
                        paintCode = apiData.ReadElementContentAsString();
                    }
                }
            }
        }

        public VinDecoderForm()
        {
            InitializeComponent();
        }

        private void VinDecoderForm_Load(object sender, EventArgs e)
        {

        }

        //2A8HR64X68R148067
        // 2008
        public void DecodeVin()
        {
            if (VinTText.Text != "")
            {
                vinDecodeButton.Enabled = true;
            }
        }

        private void vinDecodeButton_Click(object sender, EventArgs e)
        {
            BuildAPI(VinTText.Text, YearUD.Value.ToString());
            ReadFromAPI();
            makeText.Text = make;
            modelText.Text = model;
            PaintCodeText.Text = paintCode;
            PaintNameText.Enabled = true;
            colorDrop.Enabled = true;
        }

        private void VinTText_TextChanged(object sender, EventArgs e)
        {
            DecodeVin();
        }

        private void YearUD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PaintNameText_TextChanged(object sender, EventArgs e)
        {
            if (PaintNameText.Text != "" && colorDrop.Text != "")
            {
                AddPaint.Enabled = true;
            }

            else { AddPaint.Enabled = false; }
        }

        private void colorDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaintNameText.Text != "" && colorDrop.Text != "")
            {
                AddPaint.Enabled = true;
            }

            else { AddPaint.Enabled = false; }

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

