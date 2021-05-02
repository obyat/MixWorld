using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 0;
    public AudioSource whistle;

    // Start is called before the first frame update
    void Start()
    {
        whistle = GetComponent<AudioSource>();
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
            FindObjectOfType<PlayerController>().knockBackX(hitDir);
            whistle.Play();
        }
    }
}
