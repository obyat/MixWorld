using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            animator.SetBool("canOpen", true);
        }
    }
}
