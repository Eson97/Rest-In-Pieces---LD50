using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopDetection_v2 : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;

    private bool playerDetected = false;
    private bool isPlayerStatic = false;
    private bool bodyDetected = false;
    private bool isLookingFor = false;

    void FixedUpdate()
    {
        if (!isPlayerStatic && (playerDetected || bodyDetected))
        {
            //playerBody.bodyType = RigidbodyType2D.Static;
            isPlayerStatic = true;

            //Start GameOver
        }

        if (isLookingFor)
        {
            //Start Animation: Buscar
        }
    }

    //si esta en rango de vision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerDetected = true;
            Debug.Log("se encontro al jugador");
        }
        if(collision.tag == "BodyPart")
        {
            bodyDetected = true;
            Debug.Log("Se encontro un cuerpo en el suelo");
        }
    }

    //si esta pegado al objeto (tambien se puede pasar al contenedor para que este se encargue de cambiar la animacion)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ContainerFull")
        {
            bodyDetected = true;
            Debug.Log("Se encontro un cuerpo en contenedor");
        }
        if(collision.gameObject.tag == "ContainerEmpty")
        {
            isLookingFor = true;
            Debug.Log("Se encontro contenedor vacio");
        }
        
    }
}
