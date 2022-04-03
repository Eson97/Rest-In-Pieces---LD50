using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractor : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    private float time = 0f;
    void Start()
    {
        GameManager.instance.isDistractorOn = true;
        GameManager.instance.distractorOrigin = transform;
        time = Time.time + duration;
    }

    private void Update()
    {
        if (time < Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.isDistractorOn = false;
        GameManager.instance.distractorOrigin = null;
    }

}
