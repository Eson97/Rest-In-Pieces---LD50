using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : Collidable
{
    protected override void onCollide(Collider2D collider)
    {
        if (collider.tag == "Player")
            PlayerDetected(collider);
        else if (collider.tag == "Container")
            Search();
    }

    protected virtual void PlayerDetected(Collider2D collider)
    {
        Debug.Log("player in range");

        GameObject Player = collider.gameObject;
        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        
    }

    protected virtual void Search()
    {
        Debug.Log("container in range");
    }
}
