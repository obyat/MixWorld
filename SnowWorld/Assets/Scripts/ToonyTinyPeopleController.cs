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

    // Start is called before the first frame update
    void Start()
    {
        dest = "Dest1";
        ThisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = transform.GetComponent<Animator>();
        Destinations = GameObject.FindGameObjectsWithTag(dest);
        ThisAgent.SetDestination(Destinations[Random.Range(0,Destinations.Length)].transform.position);
        ThisAgent.isStopped = false;
        ThisAgent.stoppingDistance = 2f;
        ThisAgent.speed = 8.5f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", true);
        if(ThisAgent.remainingDistance <= ThisAgent.stoppingDistance){
            updateDest();
        }
    }

    private void updateDest()
    {
        int nextIndex = (int)char.GetNumericValue(dest[4]) + 1;
        dest = "Dest" + nextIndex;
        Destinations = GameObject.FindGameObjectsWithTag(dest);
        ThisAgent.SetDestination(Destinations[Random.Range(0,Destinations.Length)].transform.position);
    }
}
