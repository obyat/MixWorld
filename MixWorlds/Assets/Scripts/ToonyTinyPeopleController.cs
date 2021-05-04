using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToonyTinyPeopleController : MonoBehaviour
{
    //Reference to nav mesh agent
	private UnityEngine.AI.NavMeshAgent ThisAgent = null;
    private Animator animator;
    private GameObject[] Destinations;
    public string dest;
    private int nextIndex;
    public string finalDest;
    public Rigidbody body = null;
    public float knockBackTime;
    public float immuneTime;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        dest = "Dest1";
        ThisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        body = GetComponent<Rigidbody>();
        animator = transform.GetComponent<Animator>();
        Destinations = GameObject.FindGameObjectsWithTag(dest);
        ThisAgent.SetDestination(Destinations[UnityEngine.Random.Range(0,Destinations.Length)].transform.position);
        ThisAgent.isStopped = false;
        ThisAgent.stoppingDistance = 2f;
        ThisAgent.speed = 8f;

        animator.SetBool("isMoving", true);
        knockBackTime = 2f;
        immuneTime = 1f;
        nextIndex = 1;

        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -30) 
        {
            transform.position = spawnPoint;
        }

        knockBackTime -= Time.deltaTime;
        immuneTime -= Time.deltaTime;
        if(body.velocity.magnitude <= 0.05f && knockBackTime < 0)
        {
            body.isKinematic = true;
            ThisAgent.enabled = true;
        } 
        try{
            if (ThisAgent.remainingDistance <= ThisAgent.stoppingDistance && dest == finalDest)
            {
                animator.SetBool("isMoving", false);
            }
            else if (ThisAgent.remainingDistance <= ThisAgent.stoppingDistance)
            {
                updateDest();
            }
        } 
        catch (Exception e) 
        {
            Debug.Log("NavMeshAgent things: " + e);
        }
    }

    private void updateDest()
    {
        nextIndex++;
        dest = "Dest" + nextIndex;
        Destinations = GameObject.FindGameObjectsWithTag(dest);
        ThisAgent.SetDestination(Destinations[UnityEngine.Random.Range(0,Destinations.Length)].transform.position);
    }
    public void knockBack(Vector3 dir)
    {
        ThisAgent.isStopped = true;
        body.isKinematic = false;
        ThisAgent.enabled = false;
        body.AddForce(dir*40, ForceMode.Impulse);
        knockBackTime = 0.1f;
        animator.SetBool("isMoving", true);
        ThisAgent.SetDestination(Destinations[UnityEngine.Random.Range(0,Destinations.Length)].transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && immuneTime < 0)
        {
            Vector3 hitDirBot = transform.position - other.transform.position;

            Vector3 hitDirPlayer = other.transform.position - transform.position;
            
            hitDirBot = hitDirBot.normalized;
            hitDirPlayer = hitDirPlayer.normalized;

            this.knockBack(hitDirBot);
            FindObjectOfType<PlayerController>().knockBackX(hitDirPlayer);
            immuneTime = 1f;
        }
        if((other.CompareTag("BigSnowman") || other.CompareTag("RollingBall")
            || other.CompareTag("Skeletons")) && immuneTime < 0)
        {
            Vector3 hitDirBot = transform.position - other.transform.position;
            hitDirBot = hitDirBot.normalized;
            this.knockBack(hitDirBot);

            immuneTime = 1f;
        }
        if(other.CompareTag("Doors"))
        {
            if(other.GetComponent<DoorController>().isLocked)
            {
                nextIndex--;
                dest = "Dest" + nextIndex;
                Destinations = GameObject.FindGameObjectsWithTag(dest);
                ThisAgent.SetDestination(Destinations[UnityEngine.Random.Range(0,Destinations.Length)].transform.position);
            }
        }
        if(other.CompareTag("Respawn")){
            spawnPoint = other.transform.position;
        }
    }
}
