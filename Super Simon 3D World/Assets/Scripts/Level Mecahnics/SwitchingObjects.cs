using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingObjects : MonoBehaviour
{
    public GameObject Object;

    public ButtonController Button;

    public bool revel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Button.IsPressed)
        {
            Object.SetActive(revel);
        }
        else
        {
            Object.SetActive(!revel); ;
        }
    }
}
