using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerX : MonoBehaviour
{
    public int damageToGive = 0;

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
        if(other.CompareTag("Player"))
        {
            Vector3 hitDir = other.transform.position - transform.position;
            hitDir = hitDir.normalized;
            FindObjectOfType<PlayerControllerD>().knockBack(hitDir);
        }

        if(other.CompareTag("bots"))
        {
            Vector3 hitDir = other.transform.position - transform.position;
            hitDir = hitDir.normalized;
            FindObjectOfType<ToonyTinyPeopleControllerD>().knockBack(hitDir);
        }
    }
}
