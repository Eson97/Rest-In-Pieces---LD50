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

    private void Update()
    {
        //TODO: Add time count
    }

    //References
    public List<GameObject> containers;
    public List<GameObject> cops;
    public List<GameObject> bodyParts;
    public GameObject player;

    //Logic
    public int traps = 3;
    public int CurrentBodyPart = -1;
    public Status status = Status.empty;
}
