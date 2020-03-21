using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Request
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string login = "renat1998@yandex.ru";
        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = GetName(login);
        }

        public List<Dictionary<string, string>> GetBooksByGenre(int id, string name, string author, bool sortByRate=true)
        {
            List<Dictionary<string, string>> books = new List<Dictionary<string, string>>();
            string param = string.Format("id={0}&name={1}&author={2}&sortByRate={3}",id, name, author, sortByRate);
            WebRequest request = WebRequest.Create("http://localhost:58201/Home/GetBooksByGenre?"+ param);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    string[] lines = json.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        Dictionary<string, string> book = new Dictionary<string, string>();
                        book = line.Split(new char[] { ';' })
                            .Select(part => part.Split(':'))
                            .ToDictionary(x => x[0], x => x[1]);
                        books.Add(book);
                    }
                }
            }
            return books;
        }
        public Dictionary<string, string> GetOneBook(int id)
        {
            WebRequest request = WebRequest.Create("http://localhost:58201/Home/GetOneBook?id="+id.ToString()+ "&login="+ login);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
Dictionary<string, string> book = new Dictionary<string, string>();
                        book = json.Split(new char[] { ';' })
                            .Select(part => part.Split('='))
                            .ToDictionary(x => x[0], x => x[1]);
                    return book;
                }
            }
        }
        public List<Dictionary<string, string>> GetAllBooks(string name, string author)
        {
            List<Dictionary<string, string>> books = new List<Dictionary<string, string>>();
            WebRequest request = WebRequest.Create("http://localhost:58201/Home/GetBooks");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    string[] lines = json.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        Dictionary<string, string> book = new Dictionary<string, string>();
                        book = line.Split(new char[] { ';' })
                            .Select(part => part.Split(':'))
                            .ToDictionary(x => x[0], x => x[1]);
                        books.Add(book);
                    }
                }
            }
            return books;
        }
        string GetName(string login)
        {
            WebRequest request = WebRequest.Create("http://localhost:58201/Home/GetUserName?login=" + login);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return  reader.ReadToEnd();
                }
            }
        }
        void GetGenres()
        {
            WebRequest request = WebRequest.Create("http://localhost:58201/Home/GetGenres");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string ret=  reader.ReadToEnd();
                    string[] arr = ret.Split(new char[] { ':' });
                    comboBox1.Items.AddRange(arr);
                }
            }
        }
        // List<Dictionary<string, string>> books = new List<Dictionary<string, string>>();
        private void button2_Click(object sender, EventArgs e)
        {
            GetAllBooks(textBoxName.Text, textBoxAuthor.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetOneBook(4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetBooksByGenre(1, textBoxName.Text, textBoxAuthor.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetGenres();
        }
    }
}