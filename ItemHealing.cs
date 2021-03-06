using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ItemHealing : MonoBehaviour
{
    Player_Manager _playermanager;
    MessagePanel _messagePanel;

    public static int healingAmmountchips = 20;
    public GameObject player;
    //public GameObject UI_Healthbar;
    public AudioSource sound;

    public GameObject MessagePanels;
    public bool hasObject;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playermanager = player.GetComponent<Player_Manager>();
        _messagePanel = player.GetComponent<MessagePanel>();
        sound = GetComponent<AudioSource>();
        
        //MessagePanels = GameObject.FindGameObjectWithTag("message");
        //_playerHealthScript = FindObjectOfType<Player_Manager>();
        // _MessagePanels = FindObjectOfType<MessagePanel>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasObject == true)
        {
            sound.Play();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" )
        {
            MessagePanels.SetActive(true);
            PickUp();
            // _messagePanel.OpenMessagePanel("");
        }

    }
    public void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("Item Picked Up");


            Player_Manager.playerHealthCurrent += healingAmmountchips;
            
            // UI_Healthbar.GetComponent<Slider>().value = Player_Manager.playerHealthCurrent;
            print("ayto edw" + Player_Manager.playerHealthCurrent);
            MessagePanels.SetActive(false);
            Destroy(gameObject);
            
            //Destroy (GameObject.FindGameObjectWithTag("message"));
        }
    } 
}
