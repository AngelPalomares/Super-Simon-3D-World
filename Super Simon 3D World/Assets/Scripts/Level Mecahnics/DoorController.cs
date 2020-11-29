using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Transform Door, Openrot;

    public float openSpeed;

    private Quaternion startRot;

    public ButtonController Button;

    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Button.IsPressed)
        {
           
            Door.rotation = Quaternion.Slerp(Door.rotation, Openrot.rotation, openSpeed * Time.deltaTime);

        }
        else
        {
            Door.rotation = Quaternion.Slerp(Door.rotation, startRot, openSpeed * Time.deltaTime);

        }
    }
}
