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

    // Start is called before the first frame update
    void Start()
    {
        dest = "Dest1";
        ThisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        body = GetComponent<Rigidbody>();
        animator = transform.GetComponent<Animator>();
        Destinations = GameObject.FindGameObjectsWithTag(dest);
        ThisAgent.SetDestination(Destinations[Random.Range(0,Destinations.Length)].transform.position);
        ThisAgent.isStopped = false;
        ThisAgent.stoppingDistance = 2f;
        ThisAgent.speed = 8f;

        animator.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.magnitude <= 0.5f)
        {
            body.isKinematic = true;
            ThisAgent.enabled = true;
            // Debug.Log(body.velocity.magnitude);
        }
        if (ThisAgent.remainingDistance <= ThisAgent.stoppingDistance && dest == finalDest)
        {
            animator.SetBool("isMoving", false);
        }
        else if (ThisAgent.remainingDistance <= ThisAgent.stoppingDistance)
        {
            updateDest();
        }
    }

    private void updateDest()
    {
        nextIndex++;
        dest = "Dest" + nextIndex;
        Destinations = GameObject.FindGameObjectsWithTag(dest);
        ThisAgent.SetDestination(Destinations[Random.Range(0,Destinations.Length)].transform.position);
    }
    public void knockBack(Vector3 dir)
    {
        body.isKinematic = false;
        ThisAgent.enabled = false;
        // body.AddForce(dir * ThisAgent.speed);
        body.AddForce(-100, -100, -100, ForceMode.Force);
        Debug.Log(body.velocity.magnitude);
        Debug.Log(dir * ThisAgent.speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 hitDir = other.transform.position - transform.position;
            hitDir = hitDir.normalized;
            hitDir.y = ThisAgent.speed;
            FindObjectOfType<PlayerController>().knockBack(hitDir);
            knockBack(hitDir);
        }
    }
}
