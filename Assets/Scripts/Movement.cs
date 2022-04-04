using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;

    [SerializeField] private Animator animator;
    [SerializeField] private float baseSpeed = 300f;
    [SerializeField] private AudioSource stepsSoud;

    private Vector2 velocity;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        if (velocity.x > 0.01f)
            spriteRenderer.flipX = true;
        else if(velocity.x < -0.01f)
            spriteRenderer.flipX = false;

        if (GameManager.instance.status == Status.carry)
            animator.SetBool("isCarring", true);
        else
            animator.SetBool("isCarring", false);
    }

    private void FixedUpdate()
    {
        if (body.bodyType == RigidbodyType2D.Static) return;

        float speed = (GameManager.instance.status == Status.carry)
            ? baseSpeed / 2
            : baseSpeed;

        animator.SetFloat("Speed",velocity.normalized.magnitude);

        //if(velocity.normalized.magnitude > 0.01f && !stepsSoud.isPlaying) stepsSoud.Play();

        body.velocity = velocity.normalized * speed * Time.deltaTime;

        if(transform.childCount > 2)
        {
            var child = transform.GetChild(0).gameObject;
            var bodypart = transform.GetChild(2).gameObject;
            bodypart.transform.position = child.transform.position;
        }
    }
}
