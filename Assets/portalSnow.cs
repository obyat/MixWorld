using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalSnow : MonoBehaviour
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
        if(other.CompareTag("Player")){
            other.gameObject.SetActive(false);
        }
        if(other.CompareTag("bots")){
            other.gameObject.SetActive(false);
        }
    }
}
