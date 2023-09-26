using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace WinFormClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void handleRes_Click(object sender, EventArgs e)
        {
            GetSum();
        }

        public async void GetSum()
        {
            string baseUrl = "https://localhost:44381/api/sumex4";
            HttpClient client = new HttpClient();
            string num1 = parm1.Text;
            string num2 = parm2.Text;
            StringContent contentOut = new StringContent($"{{\"num1\": \"{num1}\", \"num2\":\"{num2}\"}}");
            HttpResponseMessage response =await client.PostAsync(baseUrl,contentOut);
            string message = await response.Content.ReadAsStringAsync();
            result.Text="Результат: "+message;

        }
    }
}
