using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public int cLevel;

    public bool isInLevel;

    public levelControllers mover;

    public GameObject preGameCanvas;

    public GameObject[] levelManagers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInLevel!=true)
        {
            levelManagers[cLevel].gameObject.GetComponent<singleLevel>().begin();
            preGameCanvas.SetActive(false);
        }
    }
}
