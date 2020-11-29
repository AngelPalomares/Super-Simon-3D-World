using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2 : MonoBehaviour
{
    public GameObject cpOn, cpOff;
    //public CheckPoint[] cps;


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
        GameManager2.instance.SetSpawnPoint(transform.position);
        GameManager2.instance.SetSpawnPoint2(transform.position);

        CheckPoint[] allCP = FindObjectsOfType<CheckPoint>();
        for (int i = 0; i < allCP.Length; i++)
        {
            allCP[i].cpOff.SetActive(true);
            allCP[i].cpOn.SetActive(false);
        }

        cpOff.SetActive(false);
        cpOn.SetActive(true);
        AudioManager.instance.PlaySFX(4);
    }
}
