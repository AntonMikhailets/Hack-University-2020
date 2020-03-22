using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModuleScriptActivator : MonoBehaviour
{

	public int id;
	public GameObject modulesController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateModulesController()
    {
        modulesController.GetComponent<ChangeModuleScript>().ActivateModule(id);
    }
}
