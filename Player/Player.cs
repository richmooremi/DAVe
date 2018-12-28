using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameObject currentTarget;
    Interactor interactor;
    HealthSystem healthSystem;

	// Use this for initialization
	void Start ()
    {
        interactor = this.GetComponent<Interactor>();
        healthSystem = this.GetComponent<HealthSystem>();
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

    public void takeDamage(int i)
    {
        healthSystem.modifyImmediate(-i, HealthSystem.DamageType.GENERIC); //negative to take damage
    }

    public void heal(int i)
    {
        healthSystem.modifyImmediate(i, HealthSystem.DamageType.HEAL); //positive to heal damage
    }

    public void damageOverTime(int i, int t)
    {
        healthSystem.modifyOverTime(-i, t, HealthSystem.DamageType.GENERIC); //negative to take damage
    }

    public void healOverTime(int i, int t)
    {
        healthSystem.modifyOverTime(i, t, HealthSystem.DamageType.HEAL);  //positive to heal damage
    }
}
