using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Transform player;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    private bool inRange = false;
    private bool isBeingCarried = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer.sprite = _sprite;
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

            }
            else
            {
                GameManager.instance.status = Status.empty;
                GameManager.instance.RemoveBodyPartParent();
                GameManager.instance.currentBodyPart = null;
                isBeingCarried = false;
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
            //spriteRenderer.enabled = false;
            circleCollider.enabled = false;
        }
        else
        {
            //spriteRenderer.enabled = false;
            circleCollider.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }
}
