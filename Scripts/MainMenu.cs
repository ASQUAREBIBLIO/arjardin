// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject PanelA;
    public GameObject StartPanel; 
    public void PanelOpener() {  
        if (PanelA != null) {  
            bool isActive = PanelA.activeSelf;  
            PanelA.SetActive(!isActive);
            StartPanel.SetActive(false);
        }  
    }  

    public void quitButton(){
        if (StartPanel != null) {  
            bool isActive = StartPanel.activeSelf;  
            StartPanel.SetActive(!isActive);
            PanelA.SetActive(false);
        }  
    }
}
