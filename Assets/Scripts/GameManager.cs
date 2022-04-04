using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        time = Time.time + CopSpawnTime;
    }

    private void Update()
    {
        if(time < Time.time)
        {
            Instantiate(Cop,CopSpawnPoint.position,Quaternion.identity);
            time = Time.time + CopSpawnTime;
        }
    }

    //References
    public GameObject player;
    public GameObject Cop;
    public Rigidbody2D playerBody;
    public Transform currentBodyPart;
    public Transform distractorOrigin;
    public List<Transform> ContainersPosition;
    public Transform CopSpawnPoint;


    //Logic
    public int traps = 3;
    public int distractor = 1;
    public Status status = Status.empty;
    public bool isDistractorOn = false;
    private Vector3 spawnPoint = new Vector3(0, -1, 0);
    private float time;
    public float CopSpawnTime = 10f;


    public void SetBodyPartParent(Transform parent)
    {
        if (currentBodyPart == null) return;

        currentBodyPart.SetParent(parent);
        currentBodyPart.position = parent.position;
        
        if (parent.tag == "ContainerFull")
            currentBodyPart = null;
    }
    public void SetBodyPartParent(Transform BodyPart,Transform parent)
    {
        if(parent == null) return;

        currentBodyPart = BodyPart;
        currentBodyPart.SetParent(parent);
        currentBodyPart.position = parent.position;
    }
    public void RemoveBodyPartParent()
    {
        currentBodyPart.parent = null;
        currentBodyPart.position = (Vector3)(player.transform.position + spawnPoint);
    }

}
