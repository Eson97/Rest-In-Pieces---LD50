using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;

    [SerializeField] private Animator animator;
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

        if (velocity.x > 0.01f)
            spriteRenderer.flipX = true;
        else if(velocity.x < -0.01f)
            spriteRenderer.flipX = false;
    }

    private void FixedUpdate()
    {
        if (body.bodyType == RigidbodyType2D.Static) return;

        float speed = (GameManager.instance.status == Status.carry)
            ? baseSpeed / 2
            : baseSpeed;

        animator.SetFloat("Speed",velocity.normalized.magnitude);

        body.velocity = velocity.normalized * speed * Time.deltaTime;

        if(transform.childCount > 0)
        {
            var child = transform.GetChild(0).gameObject;
            child.transform.position = transform.position;
        }
    }
}
