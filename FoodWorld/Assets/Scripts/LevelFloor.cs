using System.Collections;
using System.Collections.Generic;
using UnityEngine;
Vector3 PlayerInitalPosition;


public class LevelFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Palyer")){
       // Vector3 dir = aimTarget.position - transform.position;
        //other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0,currentShot.upforce,0);
        //Vector3 ballDir = Ball.position - transform.position;
        // if(ballDir.x >= 0){
        // animator.Play("forehand");
        
        // } else {
        // animator.Play("backhand");

        // }

        // Ball.GetComponent<Ball>().hitter = "player";
        other.position = Vector3 
        aimTarget.position = aimmTargetInitalPosition;
    }
}


}
