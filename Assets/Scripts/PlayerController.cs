using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject Trap;
    [SerializeField] private GameObject Distractor;
    [SerializeField] private CinemachineVirtualCamera LocalCam;
    [SerializeField] private CinemachineVirtualCamera GlobalCam;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        CameraSwitcher.Register(LocalCam);
        CameraSwitcher.Register(GlobalCam);
        CameraSwitcher.SwitchCamera(LocalCam);
    }
    private void OnDisable()
    {
        CameraSwitcher.Unregister(LocalCam);
        CameraSwitcher.Unregister(GlobalCam);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(GameManager.instance.traps > 0)
            {
                GameManager.instance.traps--;
                Instantiate(Trap, transform.position, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(GameManager.instance.distractor > 0)
            {
                GameManager.instance.distractor--;
                Instantiate(Distractor, transform.position, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (CameraSwitcher.activeCamera == LocalCam)
            {
                CameraSwitcher.SwitchCamera(GlobalCam);
                body.bodyType = RigidbodyType2D.Static;
            }
            else if(CameraSwitcher.activeCamera == GlobalCam)
            {
                CameraSwitcher.SwitchCamera(LocalCam);
                body.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        /**
         * TODO:
         * -Recolectar y soltar partes del cuerpo
         */

    }
}
