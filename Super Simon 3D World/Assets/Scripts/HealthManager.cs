using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth, maxHealth;

    public float inviciblelength = 2f;
    private float invincCounter;

    public Sprite[] healthBarImages;



    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;

                for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
                {
                    if(Mathf.Floor(invincCounter * 5f) % 2 == 0)
                    {
                        PlayerController.instance.playerPieces[i].SetActive(true);
                    }
                    else
                    {
                        PlayerController.instance.playerPieces[i].SetActive(false);
                    }

                    if(invincCounter <= 0)
                    {
                        PlayerController.instance.playerPieces[i].SetActive(true);
                    }
                }
        }
    }

    public void Hurt()
    {
        if (invincCounter <= 0)
        {


            currentHealth--;
            AudioManager.instance.PlaySFX(8);

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                GameManager.instance.Respawn();

            }
            else
            {
                PlayerController.instance.KnockBack();
                invincCounter = inviciblelength;
            }
            UpdateUI();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UIManager.instance.healtImage.enabled = true;
        UpdateUI();
    }

    public void AddHealth(int amountToHeal)
    {
        currentHealth += amountToHeal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        UIManager.instance.healthText.text = currentHealth.ToString();

        switch(currentHealth)
        {
            case 5:
                UIManager.instance.healtImage.sprite = healthBarImages[4];
                break;
            case 4:
                UIManager.instance.healtImage.sprite = healthBarImages[3];
                break;
            case 3:
                UIManager.instance.healtImage.sprite = healthBarImages[2];
                break;
            case 2:
                UIManager.instance.healtImage.sprite = healthBarImages[1];
                break;
            case 1:
                UIManager.instance.healtImage.sprite = healthBarImages[0];
                break;
            case 0:
                UIManager.instance.healtImage.enabled = false;
                break;

        }
    }

    public void Playerkilled()
    {
        currentHealth = 0;
        UpdateUI();
    }
}
