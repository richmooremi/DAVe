using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGroup : Interactable
{
    public List<Light> lights;

    public override void onInteraction()
    {
        foreach (Light l in lights)
            l.enabled = !l.enabled;
    }
}
