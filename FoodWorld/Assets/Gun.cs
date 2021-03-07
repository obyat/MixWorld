using UnityEngine;
using UnityStandardAssets.Cameras;
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
        
    }

    void Shoot(){
        RaycastHit hit;
        if(UnityEngine.Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
       
        Debug.Log(hit.transform.gameObject.name);
       
        // if (Physics.Raycast(UnityEngine.Camera.main.WorldToScreenPoint(transform.position), UnityEngine.Camera.main.WorldToScreenPoint(transform.forward), out hit, range)){
        }
    }

}


