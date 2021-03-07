using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ++Coin.CoinCount;
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Destroy(gameObject);
        }
   // Debug.Log("Entered Coll");
    }   
    private void OnDestroy() {
        --Coin.CoinCount;
        //Debug.Log("INSIDE DESTROY");

        if(Coin.CoinCount<=0){
            GameObject timer = GameObject.Find("LevelTimer");
            Destroy(timer);      
            GameObject[] FireworkSystems = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach(GameObject go in FireworkSystems) {            
                 go.GetComponent<ParticleSystem>().Play();
            }

            Debug.Log("You win!!!!!!!!!!!!!");
        }       
    }
}

    // // Update is called once per frame NO UPDATE NEEDED
    // void Update()
    // {
        
    // }
