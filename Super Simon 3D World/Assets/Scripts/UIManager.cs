using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image BlackScreen;

    public float fadespeed = 2f;

    public bool fadeToBlack, fadeFromBlack;

    public Text healthText;

    public Image healtImage;

    public Text coinText;

    public GameObject ScreenPause;

    public GameObject optionsScreen;

    public Slider MusicVolSlider, SFXVolSlider;

    public string levelSelect, mainmenuSelect;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, Mathf.MoveTowards(BlackScreen.color.a, 1f, fadespeed * Time.deltaTime));

            if (BlackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, Mathf.MoveTowards(BlackScreen.color.a, 0f, fadespeed * Time.deltaTime));

            if (BlackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void Resume()
    {
        GameManager.instance.PausePause();
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainmenuSelect);
        Time.timeScale = 1f;
    }

    public void MusicLevel()
    {
        AudioManager.instance.setMusicLevel();
    }

    public void SFXLevel()
    {
        AudioManager.instance.SFXLevel();
    }

}
