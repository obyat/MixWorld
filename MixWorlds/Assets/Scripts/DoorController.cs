using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    public bool isLocked;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setIsLocked(bool state)
    {
        isLocked = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("Player") && !isLocked) 
            || ((other.CompareTag("bots")&& !isLocked)) )
        {
            animator.SetBool("canOpen", true);
        }
    }
}
