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
    public GameObject player;
    public Transform currentBodyPart;
    public Transform distractorOrigin;
    public List<Transform> ContainersPosition;

    //Logic
    public int traps = 3;
    public int distractor = 1;
    public Status status = Status.empty;
    public bool isDistractorOn = false;

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
        currentBodyPart.position = player.transform.position;
    }

}
