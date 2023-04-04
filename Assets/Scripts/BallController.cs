using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject ball;
    Rigidbody rb;
    bool didStart;
    [SerializeField] float movementSpeed = 1f;
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (Input.GetMouseButtonDown(0) && didStart == false)
        {
            didStart = true;
            rb.velocity = new Vector3(movementSpeed, 0, 0);
            
        }
        if (didStart) {
            
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(rb.velocity.z, 0f, rb.velocity.x);
            }
            if(rb.velocity.x != 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            }
            else if (rb.velocity.z != 0)
            {
                rb.velocity = new Vector3(0, 0, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(movementSpeed, 0, 0);
            }
            rb.transform.forward = rb.velocity;
            rb.velocity = rb.transform.forward;
        }

    }
    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * rb.mass, ForceMode.Force);
       
    }
    public bool isFalling()
    {
        if (Mathf.Abs(rb.velocity.y) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.GetComponent<Collider>().tag == "Platform")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Collider>().tag == "Diamond")
        {
            Destroy(collision.gameObject);
        }
    }

}
