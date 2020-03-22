using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookButtonForm : MonoBehaviour
{
	public int id;
    public string name;
    public string author;
    public int rate;
    public int price;
    public string imgLink;
    public GameObject starsController;

    public Text nameText;
    public Text authorText;
    //public Text rateText;
    public Text priceText;
    public Image bookImage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateBookButtonForm(int _id, string _name, string _author, int _rate, int _price, string _imgLink)
    {
        id = _id;
        name = _name;
        author = _author;
        rate = _rate;
        price = _price;
        imgLink = _imgLink;

        nameText.text = name;
        authorText.text = author;
        //rateText.text = rate.ToString();
        priceText.text = price.ToString();

        starsController.GetComponent<StarController>().UpdateStars(rate);

        /*string url = _imgLink;  

        WWW imageURLWWW = new WWW(url);  
 
         //yield return imageURLWWW;        
 
         if(imageURLWWW.texture != null) {
 
            Sprite sprite = Sprite.Create(imageURLWWW.texture, new Rect(0, 0, 500, 625), Vector2.zero);  
 
             //Assign the sprite to the Image Component
            bookImage.GetComponent<Image>().sprite = sprite;  
         }*/
        // Debug.Log("======");
         StartCoroutine (imgLoader());
    }

    IEnumerator imgLoader()
    {

    	 string url = imgLink;  
    	 Debug.Log("======");
        WWW imageURLWWW = new WWW(url);  
 Debug.Log("===");
         yield return imageURLWWW;        
 
         if(imageURLWWW.texture != null) {
 			
 			            Sprite sprite = Sprite.Create(imageURLWWW.texture, new Rect(0, 0, 443, 655), Vector2.zero);  // 358, 531)
 
             //Assign the sprite to the Image Component
            bookImage.GetComponent<Image>().sprite = sprite;  
         }
    }


}
