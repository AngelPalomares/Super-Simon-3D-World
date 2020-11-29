using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit2 : MonoBehaviour
{
    public Animator anim;
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
        if (other.tag == "Player")
        {
            anim.SetTrigger("Hit");
            StartCoroutine(GameManager2.instance.LevelEndCo());
        }
    }
}
