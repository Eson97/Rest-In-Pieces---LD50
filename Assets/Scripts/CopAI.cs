using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class CopAI : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float nextWaypointDistance = 3f;

    private Path path;
    private Seeker seeker;
    private Transform target;
    private Rigidbody2D body;
    private Vector2 direction;
    private Vector2 force;

    private int CurrentWaypoint = 0;
    private int numberOfContainers;
    private bool reachedEndOfPath = false;
    private bool isDistracted = false;
    private bool hasBeenRedirected = false;

    void Start()
    {
        numberOfContainers = GameManager.instance.ContainersPosition.Count;
        seeker = GetComponent<Seeker>();
        body = GetComponent<Rigidbody2D>();
        UpdatePath();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) return;

        if (GameManager.instance.isDistractorOn && !hasBeenRedirected) { isDistracted = true; hasBeenRedirected = true; }
        

        if (CurrentWaypoint >= path.vectorPath.Count || isDistracted)
        {
            if (isDistracted) isDistracted = false;
            reachedEndOfPath = true;
            UpdatePath();
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        direction = ((Vector2)path.vectorPath[CurrentWaypoint] - body.position).normalized;
        force = direction * speed * Time.deltaTime;

        body.AddForce(force);

        float distance = Vector2.Distance(body.position, path.vectorPath[CurrentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            CurrentWaypoint++;
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            CurrentWaypoint = 0;
            reachedEndOfPath = true;
            Debug.Log("Se completo el path");
        }
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            if (GameManager.instance.isDistractorOn)
            {
                target = GameManager.instance.distractorOrigin;
                seeker.StartPath(body.position, target.position, OnPathComplete);
            }
            else
            {
                target = GameManager.instance.ContainersPosition[UnityEngine.Random.Range(0, numberOfContainers)];
                seeker.StartPath(body.position, target.position, OnPathComplete);
            }
        }
    }
}
