using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    [SerializeField] private ContactFilter2D contactFilter;

    private CircleCollider2D circleCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    protected virtual void Update()
    {
        circleCollider.OverlapCollider(contactFilter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            onCollide(hits[i]);

            hits[i] = null;
        }
    }

    protected virtual void onCollide(Collider2D collider)
    {
        Debug.Log("onCollide not Implemented yet in" + this.name);
    }
}
