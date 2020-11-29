using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel, levelSelect, controllers;

    public GameObject continueButton;
    public string[] levelnames;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Continue"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            ResetProgress();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);
        PlayerPrefs.SetInt("Continue", 0);
        PlayerPrefs.SetString("CurrentLevel", firstLevel);

        ResetProgress();
    }
    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Controls()
    {
        SceneManager.LoadScene(controllers);
    }
    public void ResetProgress()
    {
        for(int i = 0; i < levelnames.Length; i++)
        {
            PlayerPrefs.SetInt(levelnames[i] + "_unlocked", 0);
        }
    }
}
