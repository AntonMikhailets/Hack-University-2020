using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ServerControllerSystem : MonoBehaviour
{

	public GameObject GetBooksByGenreObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }
		public string login = "renat1998@yandex.ru";
       public string site = "balticSea.somee.com";//balticSea.somee.com
    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Dictionary<string, string>> GetBooksByGenre(int id, string name, string author, bool sortByRate=true)
        {
            List<Dictionary<string, string>> books = new List<Dictionary<string, string>>();
            string param = string.Format("id={0}&name={1}&author={2}&sortByRate={3}",id, name, author, sortByRate);
            WebRequest request = WebRequest.Create("http://"+ site + "/Home/GetBooksByGenre?"+ param);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    if (json == "") return new List<Dictionary<string, string>>();
                    string[] lines = json.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        Dictionary<string, string> book = new Dictionary<string, string>();
                        book = line.Split(new char[] { ';' })
                            .Select(part => part.Split('='))
                            .ToDictionary(x => x[0], x => x[1]);
                        books.Add(book);
                    }
                }
            }
            return books;
        }
        public Dictionary<string, string> GetOneBook(int id)
        {
            WebRequest request = WebRequest.Create("http://" + site + "/Home/GetOneBook?id=" + id.ToString()+ "&login="+ login);
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
        public List<Dictionary<string, string>> GetAllBooks(string name, string author, bool sortByRate = true)
        {
            List<Dictionary<string, string>> books = new List<Dictionary<string, string>>();
            string param = string.Format("name={0}&author={1}&sortByRate={2}", name, author, sortByRate);
            WebRequest request = WebRequest.Create("http://" + site + "/Home/GetBooks?" + param);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    if (json == "") return new List<Dictionary<string, string>>();
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

        public string GetName(string login)
        {
            WebRequest request = WebRequest.Create("http://" + site + "/Home/GetUserName?login=" + login);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return  reader.ReadToEnd();
                }
            }
        }
        ///Жанры
        public string[] GetGenres()
        {
            WebRequest request = WebRequest.Create("http://" + site + "/Home/GetGenres");
            WebResponse response = request.GetResponse();
            string[] arr=new string[]{};
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string ret=  reader.ReadToEnd();
                     arr = ret.Split(new char[] { ':' });
                    
                    //comboBox1.Items.AddRange(arr);
                }
            }
            return arr;
        }
        public string AddItemToOrder(string login, int id)
        {
            string param = string.Format("login={0}&id={1}", login, id);
            string json = "";
            WebRequest request = WebRequest.Create("http://" + site + "/Home/AddItemToOrder?" + param);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                    
                }
            }
            return json;
        }
////////////////////////////////////////////////////////////////////////////////////////////////
        public void But_click_GetAll_Books()
        {
        	var books = GetAllBooks("","",true);
        	for(int i=0;i<books.Count;i++)
        	{
        		int id = int.Parse(books[i]["Id"]);
        		string name = books[i]["Name"];
        		string author = books[i]["Author"];
        		int rate = int.Parse(books[i]["Price"]);
        		string imgLink = "http://"+site+"/Images/"+books[i]["Image"]+".jpg";
        		Debug.Log(string.Format("Id={0} Name={1} Author={2} Rate={3} Img={4}",id, name,author,rate,imgLink));

        	}
        }
        

        public void But_click_By_Seria(int seria)
        {
        	var books = GetBooksByGenre(seria,"","",true);

        	GetBooksByGenreObject.GetComponent<ScrollbarObjectsSpawner>().CleanSearchList();

        	for(int i=0;i<books.Count;i++)
        	{
        		int id = int.Parse(books[i]["Id"]);
        		string name = books[i]["Name"];
        		string author = books[i]["Author"];
        		int rate = int.Parse(books[i]["Rate"]);
        		int price = int.Parse(books[i]["Price"]);
        		string imgLink ="http://"+site+"/Images/1.jpg" ;//"http://"+site+"/Images/"+books[i]["Image"]+".jpg";
        		Debug.Log(string.Format("Id={0} Name={1} Author={2} Rate={3} Img={4}",id, name,author,rate,imgLink));

        		GetBooksByGenreObject.GetComponent<ScrollbarObjectsSpawner>().UpdateScrollbar(id, name, author, rate, price, imgLink);

        		if(i == 5)break;
        	}
        }


        public void GenreClick()
        {
        	var genres = GetGenres();
        	for(int i =0;i<genres.Length;i++)
        	{
	        	Debug.Log(genres[i]);
        	}

        }


}
