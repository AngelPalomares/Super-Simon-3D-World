using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value;
    public int healAmout;
    public bool isFullHeal;

    public GameObject pickupEffect;

    public int soundToPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.AddCoins(value);
            Destroy(gameObject);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(soundToPlay);
            if (isFullHeal)
            {
                HealthManager.instance.ResetHealth();

            }
            else
            {
                HealthManager.instance.AddHealth(healAmout);
            }
        }
    }
}
