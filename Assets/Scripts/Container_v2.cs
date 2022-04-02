using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_v2 : MonoBehaviour
{
    [SerializeField] private Sprite emptyContainer;
    [SerializeField] private Sprite fullContainer;
    [SerializeField] private SpriteRenderer Dialog;
    [SerializeField] private Transform player;

    private bool inRange = false;
    private bool isEmpty = true;

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {

            if (GameManager.instance.status == Status.empty && isEmpty) return;

            if (isEmpty)
            {
                GetComponent<SpriteRenderer>().sprite = fullContainer;
                isEmpty = false;
                gameObject.tag = "ContainerFull";

                GameManager.instance.SetBodyPartParent(transform);
                GameManager.instance.status = Status.empty;


                Debug.Log("Se guardo una parte");
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = emptyContainer;
                isEmpty = true;
                gameObject.tag = "ContainerEmpty";

                GameManager.instance.SetBodyPartParent(transform.GetChild(1), player);
                GameManager.instance.status = Status.carry;



                Debug.Log("Se saco una parte");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameManager.instance.status == Status.empty && isEmpty) return;
            inRange = true;
            Dialog.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Dialog.enabled)
                Dialog.enabled = false;
            inRange = false;
        }
    }
}
