using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpeed : MonoBehaviour
{
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
        PlayerController.instance.MoveSpeed = 10.0f;
    }

    private void OnTriggerExit(Collider other)
    {

        PlayerController.instance.MoveSpeed = 5.0f;
    }
}
