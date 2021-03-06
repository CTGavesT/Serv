using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameObject plyr;

   // public GameEnding gameEnding;
    bool m_IsPlayerInRange;



    private void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
           Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction /*transform.forward + Vector3.up*/);
            RaycastHit raycastHit;
         //  print("ola");
            if (Physics.Raycast(ray, out raycastHit))
            { 
                if (/*raycastHit.collider.transform == player*/ raycastHit.collider.tag =="Player")
                {
                   
                  //GameEnding.CaughtPlayer();
                   // Destroy(_player, 2f);
                }
            }
        }
    }
}
