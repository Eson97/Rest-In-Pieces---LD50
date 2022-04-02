using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_v2 : MonoBehaviour
{
    [SerializeField] private Sprite emptyContainer;
    [SerializeField] private Sprite fullContainer;
    [SerializeField] private SpriteRenderer Dialog;

    private bool inRange;
    private bool isEmpty = true;
    private int bodyPart = -1;

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.instance.CurrentBodyPart < 0 && isEmpty) return;

            if (isEmpty)
            {
                GetComponent<SpriteRenderer>().sprite = fullContainer;
                isEmpty = false;

                bodyPart = GameManager.instance.CurrentBodyPart;
                GameManager.instance.CurrentBodyPart = -1;

                gameObject.tag = "ContainerFull";

                Debug.Log("Se guardo una parte");
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = emptyContainer;
                isEmpty = true;
                
                GameManager.instance.CurrentBodyPart = bodyPart;
                bodyPart = -1;

                gameObject.tag = "ContainerEmpty";

                Debug.Log("Se saco una parte");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameManager.instance.CurrentBodyPart < 0 && isEmpty) return;
            Dialog.enabled = true;
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Dialog.enabled)
                Dialog.enabled = false;
            if(inRange)
                inRange = false;
        }
    }
}
