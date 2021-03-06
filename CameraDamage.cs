using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDamage : MonoBehaviour
{
    
    public int damage = 20;
    public float rythimofHits = 0.5f;

    GameObject plyr;
    Player_Manager player_Manager;



    bool plyrinRange;
    float timer;

   

    private void Awake()
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
        player_Manager = plyr.GetComponent<Player_Manager>();
      
     
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= rythimofHits && plyrinRange)
        {
            Hit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == plyr)
        {
            plyrinRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == plyr)
        {
            plyrinRange = false;
        }
    }
    private void Hit()
    {
        timer = 0f;

        if (Player_Manager.playerHealthCurrent >= 0)
        {
            player_Manager.GetDamaged(damage);
            print(Player_Manager.playerHealthCurrent);
        }
     
    }
}
