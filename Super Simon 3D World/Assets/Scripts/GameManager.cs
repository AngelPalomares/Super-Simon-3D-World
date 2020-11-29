using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    public GameObject deathEffect;

    public int currentCoins;

    public int levelend = 8;

    public string LevelToLoad;

    public bool isRespawning;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UIManager.instance.BlackScreen.color = new Color(UIManager.instance.BlackScreen.color.r, 
        UIManager.instance.BlackScreen.color.g, 
        UIManager.instance.BlackScreen.color.b, 1f);
        UIManager.instance.fadeFromBlack = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = PlayerController.instance.transform.position;
        UIManager.instance.coinText.text = "" + currentCoins;

        AddCoins(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PausePause();
        }
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
        HealthManager.instance.Playerkilled();
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        CameraController.instance.CMbrain.enabled = false;


        UIManager.instance.fadeToBlack = true;

        AudioManager.instance.PlaySFX(8);
        Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f,1f,0f), PlayerController.instance.transform.rotation);

        yield return new WaitForSeconds(2f);

        isRespawning = true;

        HealthManager.instance.ResetHealth();

        UIManager.instance.fadeFromBlack = true;

        PlayerController.instance.transform.position = respawnPosition;

        CameraController.instance.CMbrain.enabled = true;

        PlayerController.instance.gameObject.SetActive(true);
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        UIManager.instance.coinText.text = "" + currentCoins;
    }

    public void PausePause()
    {
        if(UIManager.instance.ScreenPause.activeInHierarchy)
        {
            UIManager.instance.ScreenPause.SetActive(false);
            Time.timeScale = 1f;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            UIManager.instance.ScreenPause.SetActive(true);
            UIManager.instance.CloseOptions();
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    public IEnumerator LevelEndCo()
    {
        AudioManager.instance.PlayMusic(levelend);
        PlayerController.instance.stopMove = true;
        UIManager.instance.fadeToBlack = true;
        yield return new WaitForSeconds(4f);
        Debug.Log("Level Ended");

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_coins"))
        {
            if(currentCoins > PlayerPrefs.GetInt((SceneManager.GetActiveScene().name + "_coins")))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_coins", currentCoins);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_coins", currentCoins);
        }

        SceneManager.LoadScene(LevelToLoad);
    }
}
