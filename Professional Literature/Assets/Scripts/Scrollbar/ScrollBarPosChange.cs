using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBarPosChange : MonoBehaviour
{
	public GameObject scrollBar;
    // Start is called before the first frame update
    void Start()
    {
        scrollBar.GetComponent<RectTransform>().localPosition = new Vector3(100,100,100);
    }

    // Update is called once per frame
    void Update()
    {
        //scrollBar.GetComponent<RectTransform>().localPosition = new Vector3(100,100,100);
    }
}
