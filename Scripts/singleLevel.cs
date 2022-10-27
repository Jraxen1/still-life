using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleLevel : MonoBehaviour
{

    public GameObject[] objectsToKill;
    public GameObject[] objectsToLoad;
    public GameObject manager;
    public GameObject[] fillAreas;
    public GameObject player;
    public GameObject eye1;
    public GameObject eye2;

    public float fillSpeed;

    public float fillValue;
    public bool isFilling;

    public Slider fillSlider;

    public bool isHidden;

    public bool playing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playing) {
            if (Mathf.Abs(player.GetComponent<Rigidbody>().velocity.x) < 0.05f)
            {
                isFilling = true;
            }
            else
            {
                isHidden = false;
                player.GetComponent<MeshRenderer>().enabled = true;
                eye1.GetComponent<MeshRenderer>().enabled = true;
                eye2.GetComponent<MeshRenderer>().enabled = true;
                fillValue = 0;
                for (int i = 0; i < fillAreas.Length; i++)
                {
                    fillAreas[i].SetActive(false);
                }
            }

            if (isFilling && fillValue < 100)
            {
                fillValue+= fillSpeed;
            }
            else if (!isFilling && fillValue >= 0)
            {
                fillValue--;
            }
            else if (isFilling && fillValue >= 100)
            {
                transformIntoBlock();
            }

            fillSlider.value = fillValue;
        }
        
    }

    public void transformIntoBlock()
    {
        float cBestDist = 99999;
        float cBestX = 99999;
        int cBest=0;
        for(int i = 0; i < fillAreas.Length; i++)
        {
            if(Vector3.Distance(player.transform.position, fillAreas[i].transform.position) < cBestDist)
            {
                cBestDist = Vector3.Distance(player.transform.position, fillAreas[i].transform.position);
                

                cBest = i;
            }

            if(Mathf.Abs(player.transform.position.x-fillAreas[i].transform.position.x) < cBestX)
            {
                cBestX = Mathf.Abs(fillAreas[i].transform.position.x - player.transform.position.x);
                cBest = i;
            }
        }
        isHidden = true;
        player.GetComponent<MeshRenderer>().enabled = false;
        eye1.GetComponent<MeshRenderer>().enabled = false;
        eye2.GetComponent<MeshRenderer>().enabled = false;
        fillAreas[cBest].SetActive(true);

    }

    public void begin()
    {
        for(int i = 0; i < objectsToKill.Length; i++)
        {
            objectsToKill[i].SetActive(false);
        }
        for(int i = 0; i < objectsToLoad.Length; i++)
        {
            objectsToLoad[i].SetActive(true);
        }
        playing = true;
    }

    public void end()
    {
        if(manager.GetComponent<levelManager>().cLevel == 0)
        {
            manager.GetComponent<levelManager>().cLevel = 1;
            print("go level" + 1);
            manager.GetComponent<levelManager>().mover.move(manager.GetComponent<levelManager>().cLevel);
        } else if(manager.GetComponent<levelManager>().cLevel == 1)
        {
            manager.GetComponent<levelManager>().cLevel = 2;
            manager.GetComponent<levelManager>().mover.move(manager.GetComponent<levelManager>().cLevel);
        }
    }
}
