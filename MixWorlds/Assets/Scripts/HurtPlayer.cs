using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 0;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 hitDir = other.transform.position - transform.position;
            hitDir = hitDir.normalized;
            FindObjectOfType<PlayerController>().knockBackX(hitDir);
            sound.Play();
        }
    }
}
