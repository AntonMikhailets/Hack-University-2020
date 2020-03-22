using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarObjectsSpawner : MonoBehaviour
{	
	public RectTransform bookPrefab;
	public RectTransform content;


    // Start is called before the first frame update
    void Start()
    {
    }

    public void CleanSearchList()
    {
    	foreach (Transform child in content)
    	{
    		Destroy(child.gameObject);
    	}
    }

    // Update is called once per frame
    public void UpdateScrollbar(int _id, string _name, string _author, int _rate, int _price, string _imgLink)
    {
        	var instance = GameObject.Instantiate(bookPrefab.gameObject) as GameObject;
        	instance.transform.SetParent(content, false);
        	instance.GetComponent<BookButtonForm>().UpdateBookButtonForm(_id, _name, _author, _rate, _price, _imgLink);
    }

}
