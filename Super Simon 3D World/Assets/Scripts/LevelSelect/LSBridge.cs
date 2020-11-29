using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSBridge : MonoBehaviour
{
    public string LevelToUnlock;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(LevelToUnlock + "_unlocked") == 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
