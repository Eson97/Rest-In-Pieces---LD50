using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_v2 : MonoBehaviour
{
    [SerializeField] private float stunTime = 5f;
    private Rigidbody2D copBody;

    private float time = 0f;
    private bool haveCopInRange = false;

    void FixedUpdate()
    {
        if (haveCopInRange)
        {
            if(time < Time.time)
            {
                copBody.bodyType = RigidbodyType2D.Dynamic;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Cop")
        {
            copBody = collision.GetComponent<Rigidbody2D>();
            copBody.bodyType = RigidbodyType2D.Static;

            haveCopInRange = true;
            time = Time.time + stunTime;
        }
    }
}
