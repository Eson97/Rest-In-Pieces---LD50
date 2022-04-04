using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class CopAI : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float nextWaypointDistance = 3f;
    [SerializeField] private Animator animator;

    private Path path;
    private Seeker seeker;
    private Transform target;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Vector2 direction;
    private Vector2 force;

    private int CurrentWaypoint = 0;
    private int numberOfContainers;
    private bool reachedEndOfPath = false;
    private bool isDistracted = false;
    private bool hasBeenRedirected = false;

    private float time = 0.0f;
    private float timeLooking = 5f;

    private bool isLookingFor = false;


    void Start()
    {
        numberOfContainers = GameManager.instance.ContainersPosition.Count;
        seeker = GetComponent<Seeker>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        UpdatePath();
    }

    private void Update()
    {
        if (isLookingFor)
        {
            if (time < Time.time)
            {
                isLookingFor = false;
                animator.SetBool("isLookingFor", isLookingFor);
                return;
            }
        }
    }
    void FixedUpdate()
    {
        if (path == null || isLookingFor) return;



        if (GameManager.instance.isDistractorOn && !hasBeenRedirected) { isDistracted = true; hasBeenRedirected = true; }
        

        if (CurrentWaypoint >= path.vectorPath.Count || isDistracted)
        {
            if (isDistracted) isDistracted = false;
            UpdatePath();
            return;
        }
        direction = ((Vector2)path.vectorPath[CurrentWaypoint] - body.position).normalized;
        force = direction * speed * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(force.magnitude));
        if(force.x > 0.01f)
            sprite.flipX = true;
        else
            sprite.flipX = false;

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
            animator.SetFloat("Speed", 0.0f);
            isLookingFor = true;
            animator.SetBool("isLookingFor", isLookingFor);
            time = Time.time + timeLooking;
            Debug.Log("se completo el path");
        }
    }

    private void UpdatePath()
    {
        if (isLookingFor) return;
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
