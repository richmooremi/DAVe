using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{

    public List<Interactable> targets;

    public override void onInteraction()
    {
        foreach(Interactable t in targets)
            t.onInteraction();
    }
}
