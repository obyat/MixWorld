using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject[] doors;
    public int frontDoor;
    public int backDoor;
    private DoorController doorOne;
    private DoorController doorTwo;

    // Start is called before the first frame update
    void Start()
    {
        frontDoor = Random.Range(0,3);
        backDoor = Random.Range(3,6);
        doorOne = doors[frontDoor].GetComponent<DoorController>();
        doorTwo = doors[backDoor].GetComponent<DoorController>();
        doors[frontDoor].GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = false;
        doors[backDoor].GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        doorOne.setIsLocked(false);
        doorTwo.setIsLocked(false);
    }
}
