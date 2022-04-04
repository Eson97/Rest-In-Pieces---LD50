using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Text TeddysText;
    [SerializeField] private Text BottleText;
    [SerializeField] private GameObject Trap;
    [SerializeField] private GameObject Distractor;
    [SerializeField] private CinemachineVirtualCamera LocalCam;
    [SerializeField] private CinemachineVirtualCamera GlobalCam;
    [SerializeField] private AudioSource LeaveTrap;

    private Rigidbody2D body;
    private Vector2 SpawnPoint = new Vector2(0, -1);

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
                TeddysText.text = $": {GameManager.instance.traps}";
                LeaveTrap.Play();
                Instantiate(Trap, (Vector2)transform.position + SpawnPoint, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(GameManager.instance.distractor > 0)
            {
                GameManager.instance.distractor--;
                BottleText.text = $": {GameManager.instance.distractor}";
                Instantiate(Distractor, (Vector2)transform.position + SpawnPoint, Quaternion.identity);
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

    }
}
