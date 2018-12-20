using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Player player;
    public float interactionDistacne = 2;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void interact()
    {
        GameObject target = player.getCurrentTarget();

        if (Vector3.Distance(this.transform.position, target.transform.position)
            <= interactionDistacne && target.GetComponent<Interactable>() != null)
        {
            target.GetComponent<Interactable>().onInteraction();   
            Debug.Log("interacted with" + target.name);
        }
    }
}
