using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool IsPressed;
    public Transform Button,buttondDown;
    private Vector3 buttonup;

    public bool isOnOff;

    public int SoundToPlay;


    // Start is called before the first frame update
    void Start()
    {
        buttonup = Button.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (isOnOff)
            {
                if (IsPressed)
                {

                    Button.position = buttonup;
                    AudioManager.instance.PlaySFX(SoundToPlay);
                    IsPressed = false;

                }
                else
                {
                    Button.position = buttondDown.position;
                    AudioManager.instance.PlaySFX(SoundToPlay);
                    IsPressed = true;

                }
            }
            else
            {
                if(!IsPressed)
                {
                    Button.position = buttondDown.position;
                    AudioManager.instance.PlaySFX(SoundToPlay);
                    IsPressed = true;
                }
            }
        }
    }
}
