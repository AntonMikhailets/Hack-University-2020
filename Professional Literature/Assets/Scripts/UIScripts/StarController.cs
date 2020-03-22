using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour
{	
	public Image[] starIcons;
	public Color defoultColor;
	public Color redColor;

    // Start is called before the first frame update
    void Start()
    {
    	//UpdateStars(0);
        //UpdateStars(1);
    }

    // Update is called once per frame
    public void UpdateStars(int rate)
    {
        for(int i = 0; i < starIcons.Length;i++)
        {
        	starIcons[i].color = defoultColor;
        }

        for(int i = 0; i < rate;i++)
        {
        	starIcons[i].color = redColor;
        }
    }
}
