using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour {

    public Camera playerCamera;
    public Ray rayFromPlayer;
    public RaycastHit hit;
    public Player player;
    public GameObject currentTarget;

    // Use this for initialization
    void Start ()
    {
        playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //cast a ray from the center of the player camera,
        //lines up with the crosshair in the center of the screen
        rayFromPlayer = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        //if the current target has changed since last frame
        //update the player manager
        if (Physics.Raycast(rayFromPlayer, out hit, 300))
        {
            if (hit.collider.gameObject != currentTarget)
            {
                currentTarget = hit.collider.gameObject;
                player.setCurrentTarget(currentTarget);
            }
        }

        //if the current target has become null since last frame
        //update the player manager
        else
        {
            if (currentTarget != null)
            {
                currentTarget = null;
                player.setCurrentTarget(currentTarget);
            }
        }
    }
}
