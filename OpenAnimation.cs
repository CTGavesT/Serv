using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAnimation : MonoBehaviour
{
    private Animator _drawerAnimation;
    public AudioSource sound;
  

    private void Start()
    {
        _drawerAnimation = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _drawerAnimation.SetBool("IsOpen", true);
            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _drawerAnimation.SetBool("IsOpen", false);
            sound.Play();
        }
    }
}
