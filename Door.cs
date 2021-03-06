using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Key key;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player" && Key.hasKey==true)
        {
            print("vrhkes");
           
              anim.SetBool("open", true);
           
           
        }
    }
}
