using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LSUiManager : MonoBehaviour
{
    public static LSUiManager instance;
    public Text LevelName;
    public GameObject LnamePanel;
    public Text Coins;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
