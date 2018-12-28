using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestImmediateHeal : MonoBehaviour {

    public int healAmount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Player>().heal(healAmount);
    }
}
