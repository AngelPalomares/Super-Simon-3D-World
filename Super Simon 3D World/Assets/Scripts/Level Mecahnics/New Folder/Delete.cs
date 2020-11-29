using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public GameObject on;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(on);
    }
}
