using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Collidable
{
    [SerializeField] private float stunTime = 5f;
    private float time = 0f;
    private bool isWaitingForActivation = true;

    protected override void onCollide(Collider2D collider)
    {
        if (collider.tag == "Cop")
            CopDetected(collider);
    }

    protected virtual void CopDetected(Collider2D collider)
    {
        GameObject Cop = collider.gameObject;
        Rigidbody2D cRB = Cop.GetComponent<Rigidbody2D>();

        cRB.bodyType = RigidbodyType2D.Static;

        if (isWaitingForActivation)
        {
            isWaitingForActivation = false;
            time = Time.time + stunTime;
        }

        if(time < Time.time)
        {
            cRB.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject);
        }

    }


}
