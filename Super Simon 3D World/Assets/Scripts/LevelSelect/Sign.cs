using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign : MonoBehaviour
{
    public string levelName;
    public string LeveltoCheck;
    public string DisplayName;

    private bool canLoadLevel, levelunlocked, loadinglevel;
    public GameObject Active, Inactive;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt(LeveltoCheck + "_unlocked") == 1 || LeveltoCheck == "")
        {
            Active.SetActive(true);
            Inactive.SetActive(false);
            levelunlocked = true;
        }
        else
        {
            Active.SetActive(false);
            Inactive.SetActive(true);
            levelunlocked = false;
        }
        if (PlayerPrefs.GetString("CurrentLevel") == levelName)
        {
            PlayerController.instance.transform.position = transform.position;
            LSResetPosition.instance.respawnposition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && canLoadLevel && levelunlocked && !loadinglevel)
        {
            StartCoroutine(LevelCo());
            loadinglevel = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = true;
            LSUiManager.instance.LnamePanel.SetActive(true);
            LSUiManager.instance.LevelName.text = DisplayName;
            if (PlayerPrefs.HasKey(levelName + "_coins"))
            {
                LSUiManager.instance.Coins.text = PlayerPrefs.GetInt(levelName + "_coins").ToString();
            }
            else
            {
                LSUiManager.instance.Coins.text = "???";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = false;
            LSUiManager.instance.LnamePanel.SetActive(false);
        }
    }
    public IEnumerator LevelCo()
    {
        PlayerController.instance.stopMove = true;
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelName);

        PlayerPrefs.SetString("CurrentLevel", levelName);
    }
}
