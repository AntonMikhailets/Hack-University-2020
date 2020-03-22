using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBookActivator : MonoBehaviour
{

	public string getText;
	public Text searchText;
	public Text searchTextInNextPannel;


    // Start is called before the first frame update
    void Start()
    {
        searchText.text = "";
    }

    // Update is called once per frame
    public void Search()
    {
        if(searchText.text != "")
        {
        	getText = searchText.text;
        }
    }
}
