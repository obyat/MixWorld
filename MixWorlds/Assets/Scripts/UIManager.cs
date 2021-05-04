using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Spawner))]
public class UIManager : MonoBehaviour
{
    public Animator startButton;
    public Animator settingsButton;
    public Animator dialog;

    // Start is called before the first frame update
    void Start()
    {
        GameController.toonyPeopleCount = 5;
        GameController.difficulty = 0;
        GameController.toonyPolice = 1;
        GameController.toonyZombie = 1;
        GameController.toonyFemale = 1;
        GameController.toonyMaleA = 1;
        GameController.toonyMaleB = 1;
    }
    public void EasyGame(int toonyPeopleCount){
        GameController.toonyPeopleCount = toonyPeopleCount;
        GameController.difficulty = 0;
    }

    public void MediumGame(int toonyPeopleCount){
        GameController.toonyPeopleCount = toonyPeopleCount;
        GameController.difficulty = 1;
    }
    public void HardGame(int toonyPeopleCount){
        GameController.toonyPeopleCount = toonyPeopleCount;
        GameController.difficulty = 2;
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }
    public void OpenSettings() 
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

    public void CloseSettings() 
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }
}