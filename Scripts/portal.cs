using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    int level;
    public GameObject cLevelmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endLevel()
    {

        cLevelmanager.GetComponent<singleLevel>().end();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            print("ending level");
            endLevel();
        }
    }
}
