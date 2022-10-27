using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brushAI : MonoBehaviour
{

    public enum states {looking,hunting,returning,sleeping, waiting, movingIn, movingOut};
    public states cState;

    public singleLevel levelManager;
    public levelManager manager;

    public float waitTimeS;
    public float waitTimeW;
    public float cWaitS;
    public float cWaitW;

    public float speed;
    public float animSpeed;

    public GameObject eye;


    public Transform[] spots;

    public bool hasSearched;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cState = states.waiting;
        
        levelManager = manager.levelManagers[manager.cLevel].GetComponent<singleLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        player = manager.levelManagers[manager.cLevel].GetComponent<singleLevel>().player;
        if (cState == states.sleeping)
        {
            if (hasSearched)
            {
                if (cWaitS < waitTimeS)
                {
                    cWaitS += Time.deltaTime;
                }
                else if (cWaitS >= waitTimeS)
                {
                    cWaitS = 0;
                    cState = states.movingOut;
                }
            }
            else
            {
                eye.SetActive(true);

                if (cWaitS < waitTimeS)
                {
                    cWaitS += Time.deltaTime;
                }
                else if (cWaitS >= waitTimeS)
                {
                    cWaitS = 0;
                    cState = states.looking;
                }
            }
            



        }
        if(cState == states.looking)
        {
            if (levelManager.isHidden)
            {
                hasSearched = true;
                cState = states.sleeping;
            } else if (!levelManager.isHidden)
            {
                cState = states.hunting;
            }
        }
        if(cState == states.hunting)
        {
            if (levelManager.isHidden)
            {
                cState = states.returning;
            } else if (!levelManager.isHidden)
            {
                transform.position += new Vector3((player.transform.position.x - transform.position.x)*speed, (player.transform.position.y - transform.position.y) * speed, 0);
            }
        }

        if(cState == states.returning)
        {
            transform.position += (spots[0].position - transform.position) * speed;
            if(Vector3.Distance(transform.position,spots[0].position) < 0.2f)
            {
                hasSearched = true;
                cState = states.sleeping;
            }
        }

        if(cState == states.waiting)
        {
            

            if(cWaitW < waitTimeW)
            {
                cWaitW += Time.deltaTime;
            } else if(cWaitW >= waitTimeW)
            {
                cWaitW = 0;
                hasSearched = false;
                cState = states.movingIn;
                
                // Enter
            }
        }

        if(cState == states.movingIn)
        {
            if(Vector3.Distance(transform.position, spots[0].position) < 0.2f)
            {
                cState = states.sleeping;
            }
            else
            {
                Vector3 movement = new Vector3((spots[0].position.x - transform.position.x) * animSpeed, ((spots[0].position.y - transform.position.y) * animSpeed),0);
                transform.position += movement;
            }
        }

        if(cState == states.movingOut)
        {
            if (Vector3.Distance(transform.position, spots[2].position) < 0.4f)
            {
                eye.SetActive(false);
                cState = states.waiting;
                transform.position = spots[1].position;
            }
            else
            {
                Vector3 movement = new Vector3((spots[2].position.x - transform.position.x) * animSpeed, ((spots[0].position.y - transform.position.y) * animSpeed), 0);
                transform.position += movement;
            }
        }

    }

}
