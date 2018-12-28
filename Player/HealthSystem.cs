using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public enum DamageType {CORROSION, UV, ELECTRIC, FALL, IMPACT,
                            BULLET, FIRE, COLD, BLAST, RADIATION, GENERIC, HEAL};

    private int currentHealth, maxHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void modifyImmediate(int i, DamageType t)
    {
        Debug.Log("causing " + i + " damage of type :" + t.ToString());

        currentHealth += i;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        else if (currentHealth < 0)
            currentHealth = 0;
    }

    //called from outsied, calls private ienum
    public void modifyOverTime(int i, int s, DamageType t)
    {
        StartCoroutine(overTimeCoroutine(i, s, t));
    }

    //causes damage or heals i amount over t seconds
    private IEnumerator overTimeCoroutine(int i, int s, DamageType t)
    {
        int elapsedSeconds;

        for (elapsedSeconds = 0; elapsedSeconds < s; elapsedSeconds++)
        {
            //if healing and at current health
            if (i > 0 && currentHealth == maxHealth)
                yield break;

            modifyImmediate(i, t);
            yield return new WaitForSeconds(1);
        }

        yield break;

        
    }

    public int getHealth()
    {
        return currentHealth;
    }
}
