using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenreMSA : MonoBehaviour
{	
	public Text textOfSearchPannel;
	public int IdOfCategory;
	//public int IdModule;
	public GameObject ServerController;
	//public GameObject modulesController;
	public string genreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void UpdateModulesController()
    {	
    	textOfSearchPannel.text = genreText;
    	ServerController.GetComponent<ServerControllerSystem>().But_click_By_Seria(IdOfCategory); 
      //  modulesController.GetComponent<ChangeModuleScript>().ActivateModule(IdModule);
    }
}
