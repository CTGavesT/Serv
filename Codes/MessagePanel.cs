using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
     public GameObject MessagePanels;

    public void OpenMessagePanel(string text)
    {
        MessagePanels.SetActive(true);
    }

    public void OpenMessagePanel()
    {
        MessagePanels.SetActive(false);
    }

}
