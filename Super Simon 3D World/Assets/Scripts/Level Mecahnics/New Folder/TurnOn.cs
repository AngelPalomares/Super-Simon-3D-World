using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    public GameObject on;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        on.SetActive(true);
    }
}
