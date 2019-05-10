﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_Entity : MonoBehaviour {

    [Header("Entity Health")]
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int health;
    [SerializeField] [Range(0.0f, 1.0f)] protected float setHealth = 1.0f;

    [SerializeField] public int maxResource = 100;
    [SerializeField] public int resource;
    [SerializeField] [Range(0.0f, 1.0f)] protected float setResource = 1.0f;

    [SerializeField] bool isKillable = false;

    public int GetCurrentHealth() { return health; }
    public int GetMaxHealth() { return maxHealth; }

    public int GetCurrentResource() { return resource; }
    public int GetMaxResource() { return maxResource; }

    [SerializeField] List<GameObject> criticalPoints = new List<GameObject>();

    private void Start()
    {
        health = Mathf.RoundToInt(maxHealth * setHealth);
        //resource = Mathf.RoundToInt(maxResource * setResource);
    }

    public virtual void Destruct()
    {
        // Temporary -- Destruct script should be found in the child script
        Destroy(gameObject);
    }

    public void DamageEntity(float amount, GameObject hit)
    {

        // If it's a critical hit location, multiply the damage by ten.

        if (hit != null)
        {
            if (criticalPoints.Contains(hit))
            {
                health -= Mathf.RoundToInt(amount) * 50;
            }
        }
        

        else { health -= Mathf.RoundToInt(amount); }

        if (!isKillable && health - amount < 1)
        {
            health = 1;
        }
    }    

    public void SubtractResource(int amount)
    {
        resource -= amount;
    }

    public void AddResource(int amount)
    {
        resource += amount;
    }
}
