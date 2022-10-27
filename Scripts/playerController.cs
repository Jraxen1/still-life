using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y <= 0.1)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if(rb != null)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y, 0);
            rb.velocity = movement*speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "jumper")
        {
            if (canJump)
            {
                rb.velocity += new Vector3(0, collision.gameObject.GetComponent<jumper>().jumpValue, 0);
            }
           
        }
    }

}
