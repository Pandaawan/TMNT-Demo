﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        powerUpSignal.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) //!trigger checks that it's the physics collider
        {
            playerInventory.coins += 1;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
