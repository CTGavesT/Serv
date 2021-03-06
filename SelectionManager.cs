using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;

    Player_Manager _playermanager;
    MessagePanel _messagePanel;


    public static int healingAmmountbar = 10;
    public GameObject player;
    //public GameObject UI_Healthbar;
    public AudioSource sound;

    public GameObject MessagePanels;
    //private GameObject bar;
    public bool hasObject;
    public float range = 5f;
    int shootableMask;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        player = GameObject.FindGameObjectWithTag("Player");
        _playermanager = player.GetComponent<Player_Manager>();
        _messagePanel = player.GetComponent<MessagePanel>();
        sound = GetComponent<AudioSource>();
        //  GameObject bar = GameObject.Find("AktoBar_table1");
 //bar = GameObject.FindGameObjectWithTag("bar");

        //_playerHealthScript = FindObjectOfType<Player_Manager>();
        // _MessagePanels = FindObjectOfType<MessagePanel>();
    }

    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit/*,shootableMask*/,range ))
        {
            var selection = hit.transform;
            if (/*selection.gameObject.layer == 10CompareTag(selectableTag)*/ hit.collider.tag == "bar")
            {
                var selectionRenderer = selection.GetComponent<Renderer>();


                MessagePanels.SetActive(true);
              Deactivate();
            
                //PickUp();

                  if (Input.GetKeyDown(KeyCode.F))
        {
            print("Item Picked Up");
                   

                    Player_Manager.playerHealthCurrent += healingAmmountbar;

            // UI_Healthbar.GetComponent<Slider>().value = Player_Manager.playerHealthCurrent;
                    //MessagePanels.SetActive(false);
                    
                    hasObject = true;
                    if (Input.GetKeyDown(KeyCode.F) && hasObject == true)
                    {
  sound.Play();
                    }
            Destroy(hit.collider.gameObject,1f);
                
                  
        }

                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;
            }
        }
    }
    public void Deactivate()
    {
        StartCoroutine(RemoveAfterSeconds(2));
    }
    IEnumerator RemoveAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        MessagePanels.SetActive(false);
    }
 

 

}
