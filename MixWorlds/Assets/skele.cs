using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skele : MonoBehaviour
{

    private Animator animator;
    private Vector3 initialPos;
    private Rigidbody rb;
    private UnityEngine.AI.NavMeshAgent ThisAgent = null;
    private float time;
    private float speed;
    private float readyToAttack;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        ThisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        time = Random.Range(2f, 4f);
        initialPos = transform.position;
        speed = 2f;
        readyToAttack = 3f;
        waitTime = 2f;
        animator.SetBool("isWalk", true);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        readyToAttack -= Time.deltaTime;
        waitTime -= Time.deltaTime;
        if(waitTime < 0f){
            ThisAgent.speed = 8f;
            Vector3 dest = new Vector3(ThisAgent.transform.position.x + Random.Range(-5f, 5f) ,0 ,
                                            ThisAgent.transform.position.z + Random.Range(-5f, 5f));
            ThisAgent.SetDestination(dest);
            waitTime = 2f;
            animator.SetBool("isWalk", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("Player") || other.CompareTag("bots")) && readyToAttack < 0)
        {
            ThisAgent.SetDestination(other.transform.position);
            ThisAgent.acceleration = 20f;
            ThisAgent.speed = 20f;
            waitTime = 3f;
            readyToAttack = 5f;
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class skele : MonoBehaviour
// {

//     private Animator animator;
//     private Vector3 initialPos;
//     private Rigidbody rb;
//     private float time;
//     private float speed;
//     private float readyToAttack;

//     // Start is called before the first frame update
//     void Start()
//     {
//         animator = GetComponent<Animator>();
//         rb = GetComponent<Rigidbody>();
//         time = Random.Range(2f, 4f);
//         initialPos = transform.position;
//         speed = 2f;
//         readyToAttack = 3f;
//     }

//     // Update is called once per frame
//     void FixedUpdate()
//     {
//         time -= Time.deltaTime;
//         readyToAttack -= Time.deltaTime;
//         if(time < 0){
//             animator.SetBool("isWalk", false);
//             rb.velocity = transform.forward * 0f;
//             time = Random.Range(2F, 4f);
//         }  else if(time < 1) {
//             animator.SetBool("isWalk", true);
//             rb.velocity = -transform.forward * speed;
//         } else if(time < 2) {
//             animator.SetBool("isWalk", true);
//             rb.velocity = transform.forward * speed;
//         } else {
//             // transform.Translate(transform.forward* Time.deltaTime);
//         }
//         // if (transform.position.z < 155f || transform.position.z > 175f
//         //     || transform.position.x < -8f || transform.position.x > 75f)
//         // {
//         //     transform.position = initialPos;
//         // }
//     }
//     private void OnTriggerEnter(Collider other)
//     {
//         if(other.CompareTag("Player") || other.CompareTag("bots"))
//         {
//             if(Random.Range(0f, 1f) < 1f || readyToAttack < 0f)
//             {
//                 Vector3 pos = other.transform.position;
//                 float dist = Vector3.Distance(transform.position, other.transform.position);
//                 // Debug.Log("skelePOS: " + transform.position+ " playerPos " + pos + " dist " + dist);
//                 transform.position = Vector3.MoveTowards(transform.position, pos, Time.fixedDeltaTime*dist*100f);
//                 Debug.Log(Time.fixedDeltaTime*dist*100f);
//                 // transform.rotation = Quaternion.RotateTowards(transform.rotation, other.transform.rotation, Time.deltaTime*30);
//                 Vector3 rotate = other.transform.position - transform.position;
//                 rotate.x = 0;
//                 rotate.z = 0;
//                 transform.Rotate(rotate, 100f);
//                 if(Vector3.Distance(transform.position, other.transform.position) < 0.1f)
//                 {
//                     readyToAttack = 3f;
//                     // transform.position = new Vector3(transform.position.x, initialPos.y, transform.position.z);
//                 }
//             }
//         }
//     }
// }
