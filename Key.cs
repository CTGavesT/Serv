using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool hasKey;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            hasKey = true;
            gameObject.SetActive(false);
        }
    }
}
