using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerTemp : MonoBehaviour
{
    public Text difficultyText;
    public int gameDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gameDifficulty = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEasySetting()
    {
        gameDifficulty = 1;
        difficultyText.text = "Difficulty: Easy";
    }
    public void setMediumSetting()
    {
        gameDifficulty = 2;
        difficultyText.text = "Difficulty: Medium";
    }
    public void setHardSetting()
    {
        gameDifficulty = 3;
        difficultyText.text = "Difficulty: Hard";
    }
}
