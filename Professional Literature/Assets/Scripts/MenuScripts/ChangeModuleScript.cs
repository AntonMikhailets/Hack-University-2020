using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModuleScript : MonoBehaviour
{	

	public GameObject[] modules;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void ActivateModule(int moduleNum)
    {
    	foreach (GameObject i in modules)
    	{
       		i.active = false;   
    	}

    	modules[moduleNum].active = true;
    }
}
