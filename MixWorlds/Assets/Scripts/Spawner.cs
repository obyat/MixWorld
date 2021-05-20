using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject WeakEthan;
    [SerializeField] public GameObject MediumEthan;
    [SerializeField] public GameObject StrongEthan;
    private GameObject EthanType;
    public int EthanCount;
    public int difficulty;
    public UIManager uiManager;
    //public static GameObject EthanType;
	private float minLocation = 0.9f;
	private float maxLocation =  100f;
	Vector3 RandomDest = new Vector3(0,0,0);
    
    public void RandomSpawn(){
        RandomDest = new Vector3(Random.Range(minLocation, maxLocation), 0f, Random.Range(minLocation, maxLocation));
    }
    
    void Start()
    {
        // WeakEthan =  GameObject.FindGameObjectWithTag("Enemy");
        EthanType = WeakEthan;
        EthanCount =  GameController.toonyPeopleCount;
        difficulty =  GameController.difficulty;
        RandomSpawn();
        SpawnEthans(EthanCount, difficulty);
    }

    public void SpawnEthans(int EthanCount, int difficulty){
        for(int i = 0; i < EthanCount; i++){
        if(difficulty == 0){
            EthanType = WeakEthan;
        } else if(difficulty == 1){
            EthanType = MediumEthan;
        }  else if(difficulty == 2){
            EthanType = StrongEthan;
        } 
        RandomSpawn();
        if(EthanType != null)
        Instantiate(EthanType, RandomDest, UnityEngine.Quaternion.LookRotation(RandomDest));

        }
    }

}
