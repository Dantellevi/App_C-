using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace ASP_Controller_PC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string JSonData = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(textBox1.Text));

            WebRequest request = WebRequest.Create("http://localhost:41324/Home/Hello");
            request.Method = "POST";

            string query = $"name={JSonData}";
            byte[] byteMsg = Encoding.UTF8.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteMsg.Length;

            using (Stream stream = await request.GetRequestStreamAsync())
            {
                await stream.WriteAsync(byteMsg, 0, byteMsg.Length);

            }

            WebResponse response = await request.GetResponseAsync();
            string answer = null;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sR = new StreamReader(s))
                {
                    answer = await sR.ReadToEndAsync();
                }
            }

            response.Close();
            string helloStr = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<string>(answer));
            MessageBox.Show(helloStr);
        }
    }
}
