using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentGold;

    public Text goldText;

    public GameObject blueSnake;
    public GameObject greenSnake;
    public int numOfSnakes;
    public int maxOfSnakes;
    public bool isBlue;

    public Text timer;
    public float timerText;

    // Start is called before the first frame update
    void Start()
    {
        isBlue = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(numOfSnakes < maxOfSnakes) 
        {
            spawnSnake();
        }
        timerText -= Time.deltaTime;
        timer.text = "Timer: " + (int)timerText;
        if(timerText <= 0)
        {
            // TODO
        }
    }

    public void addGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        goldText.text = "Points: " + currentGold;
        numOfSnakes--;
    }

    private void spawnSnake()
    {
        Vector3 spawn = new Vector3(Random.Range(-35.0f, 35.0f), 0f, Random.Range(-35.0f, 35.0f));
        if (isBlue)
        {
            Instantiate(blueSnake, spawn, Quaternion.identity);
            isBlue = false;
        } 
        else
        {
            Instantiate(greenSnake, spawn, Quaternion.identity);
            isBlue = true;
        }
        numOfSnakes++;
    }

    public void killedSnake()
    {
        numOfSnakes--;
    }

    public void setNumOfSnakes(int num)
    {
        numOfSnakes = num;
    }
}
