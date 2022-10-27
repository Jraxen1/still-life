using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelControllers : MonoBehaviour
{
    public Transform[] pos;
    public bool isMoving;
    public float speed;
    public int moveTargfet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving && moveTargfet == 0)
        {
            transform.position = pos[0].position;
        }

        if (isMoving && moveTargfet == 1)
        {
            transform.position += (pos[1].position - pos[0].position) * speed;

            if (Vector3.Distance(transform.position, pos[1].position) <= 0.05f)
            {
                isMoving = false;
            }
        } else if(isMoving && moveTargfet == 2)
        {
            transform.position += (pos[2].position - pos[1].position) * speed;
            if(Vector3.Distance(transform.position, pos[2].position) <= 0.05f)
            {
                isMoving = false;
            }
        }
         
    }

    public void move(int position)
    {
        moveTargfet = position;
        isMoving = true;
    }
}
