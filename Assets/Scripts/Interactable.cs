using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable
{
    protected bool inRange;
    protected bool copInRange;

    protected override void onCollide(Collider2D collider)
    {
        if (collider.tag == "Player")
            canInteract();
        else if (collider.tag == "Cop")
            canSearch();
    }

    protected virtual void canInteract()
    {
        inRange = true;
    }

    protected virtual void canSearch()
    {
        copInRange = true;
        Debug.Log("cop in range");
    }
}
