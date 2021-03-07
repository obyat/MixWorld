﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float MaxTime = 30f;
    [SerializeField]
    private float CountDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        CountDown = MaxTime;   
    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= Time.deltaTime;
        if(CountDown <= 0){
            Coin.CoinCount = 0;
    Debug.Log("You lost");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
