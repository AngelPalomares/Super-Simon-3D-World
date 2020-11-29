using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart2 : MonoBehaviour
{
    public int healAmout;
    public bool isFullHeal;

    public GameObject healtheffect;

    public int soundplay;
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
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(healtheffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(soundplay);

            if (isFullHeal)
            {
                HealthManager2.instance.ResetHealth();

            }
            else
            {
                HealthManager2.instance.AddHealth(healAmout);
            }

        }
    }
}
