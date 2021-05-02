using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] keys;
    public int frontDoor;
    public int backDoor;

    // Start is called before the first frame update
    void Start()
    {
        frontDoor = Random.Range(0,4);
        backDoor = Random.Range(2,6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
