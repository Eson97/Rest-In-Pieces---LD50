using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Interactable
{
    [SerializeField] Sprite emptyContainer;
    [SerializeField] Sprite fullContainer;

    private bool isEmpty = true;
    //private int bodyPart = -1;

    protected override void canInteract()
    {
        base.canInteract();
        if(inRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (isEmpty)
            {
                GetComponent<SpriteRenderer>().sprite = fullContainer;
                isEmpty = false;

                Debug.Log("Se guardo una parte");
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = emptyContainer;
                isEmpty = true;
                //bodyPart = -1;
                Debug.Log("Se saco una parte");
            }
        }
        if (copInRange)
        {

        }
    }
}
