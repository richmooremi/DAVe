using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameObject currentTarget;
    Interactor interactor;

	// Use this for initialization
	void Start ()
    {
        interactor = this.GetComponent<Interactor>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //called by the RayController, 
    public void setCurrentTarget(GameObject g)
    {
        currentTarget = g;

        if (currentTarget != null)
            Debug.Log(currentTarget.gameObject.name);
    }

    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }

    public void interact()
    {
        interactor.interact();
    }
}
