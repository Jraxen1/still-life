﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        manager.GetComponent<levelManager>().mover.move(0);
    }

    public void endGame()
    {
        Application.Quit();
    }
}
