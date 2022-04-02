using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;

    [SerializeField] private float baseSpeed = 300f;

    private Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        float speed = (GameManager.instance.status == Status.carry)
            ? baseSpeed / 2
            : baseSpeed;

        body.velocity = velocity * speed * Time.deltaTime;

        if(transform.childCount > 0)
        {
            var child = transform.GetChild(0).gameObject;
            child.transform.position = transform.position;
        }
    }
}
