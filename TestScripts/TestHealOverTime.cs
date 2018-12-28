using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealOverTime : MonoBehaviour {

    public int healAmount;
    public int healSeconds;

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
            other.GetComponent<Player>().healOverTime(healAmount, healSeconds);
    }
}
