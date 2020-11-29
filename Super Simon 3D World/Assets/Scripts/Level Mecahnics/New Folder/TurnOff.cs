using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    public GameObject off;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        off.SetActive(false);
    }
}
