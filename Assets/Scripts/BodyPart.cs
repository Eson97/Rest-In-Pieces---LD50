using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer Dialog;
    [SerializeField] private AudioSource Carry;
    [SerializeField] private AudioSource Leave;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    private bool inRange = false;
    private bool isBeingCarried = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if ((inRange || isBeingCarried) && Input.GetKeyDown(KeyCode.F))
        {
            if (GameManager.instance.status == Status.empty)
            {
                GameManager.instance.status = Status.carry;
                GameManager.instance.currentBodyPart = transform;
                GameManager.instance.SetBodyPartParent(player);
                isBeingCarried = true;
                Carry.Play();

            }
            else
            {
                GameManager.instance.status = Status.empty;
                GameManager.instance.RemoveBodyPartParent();
                GameManager.instance.currentBodyPart = null;
                isBeingCarried = false;
                Leave.Play();
            }
        }
    }
    private void OnTransformParentChanged()
    {
        if (transform.parent == null)
        {
            spriteRenderer.enabled = true;
            circleCollider.enabled = true;
        }
        else if(transform.parent.tag == "Player")
        {
            spriteRenderer.enabled = true;
            circleCollider.enabled = false;
            inRange = true;
            isBeingCarried = true;
            GameManager.instance.status = Status.carry;
            GameManager.instance.currentBodyPart = transform;
        }
        else
        {
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            inRange = false;
            isBeingCarried = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
            if(GameManager.instance.status == Status.empty)
                Dialog.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
            if(Dialog.enabled)
                Dialog.enabled = false;
        }
    }
}
