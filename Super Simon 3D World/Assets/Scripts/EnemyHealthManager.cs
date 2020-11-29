using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 1;
    private float currentHealth;

    public int deathsound;

    public GameObject deathEffect;

    public GameObject ItemToDrop;

    public GameObject appear;
    public GameObject Disappear;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        currentHealth--;
        if(currentHealth <=0)
        {
            AudioManager.instance.PlaySFX(deathsound);
            Destroy(gameObject);
            PlayerController.instance.Bounce();
            Instantiate(deathEffect, transform.position + new Vector3(0, 1.2f,0f), transform.rotation);
            Instantiate(ItemToDrop, transform.position + new Vector3(0, .5f, 0f), transform.rotation);
            appear.SetActive(true);
            Disappear.SetActive(false);
        }
    }
}
