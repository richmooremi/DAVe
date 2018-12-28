using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageOverTime : MonoBehaviour
{

    public int damageAmount;
    public int damageSeconds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Player>().damageOverTime(damageAmount, damageSeconds);
    }
}
