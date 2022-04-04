using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CopDetection_v2 : MonoBehaviour
{
    private bool playerDetected = false;
    private bool bodyDetected = false;

    void FixedUpdate()
    {
        if (playerDetected || bodyDetected)
        {
            GameManager.instance.playerBody.bodyType = RigidbodyType2D.Static;

            //Start GameOver
            SceneManager.LoadScene("GameOverScreen");

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
        
    }
}
