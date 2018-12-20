﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCatcher : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        getKeyboardInput();
	}
    
    void getKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.interact();
        }
    }

}


