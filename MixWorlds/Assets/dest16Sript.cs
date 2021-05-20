using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dest16Sript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bots") || other.CompareTag("Player"))
        {
            GameObject[] bots = GameObject.FindGameObjectsWithTag("bots");
            foreach(GameObject bot in bots){
                int num = bot.GetComponent<ToonyTinyPeopleController>().nextIndex;
                if(other.GetInstanceID() != bot.GetInstanceID() && num < 16)
                {
                    bot.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(transform.position);
                }
            }
        }
    }
}
