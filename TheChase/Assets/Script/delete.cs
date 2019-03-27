using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class delete : MonoBehaviour
{
    public float speed = 5.0f;
    float mouseXHolder, mouseYHolder;
    Rigidbody rb;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 position = transform.position;
           
            if (Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0)
            {
                mouseXHolder = Input.GetAxis("Mouse X");//let 2
                mouseYHolder = Input.GetAxis("Mouse Y");//let 3

                rb.velocity = new Vector3(mouseXHolder,0f,mouseYHolder) * speed ;
                //lets make the mouse stop not the rotation 


            }
            
            
           
            
            //lets make the player move 
           
            //lets make the player rotation as  it is moving 

            if(Input.GetAxis("Mouse X")!=0 && Input.GetAxis("Mouse Y") !=0)
            Debug.Log("Coming here"+Input.GetAxis("Mouse X") + "Z " + Input.GetAxis("Mouse Y"));
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "circleEnd")
        {
           rb.velocity = new Vector3(0,0,0);
           rb.angularVelocity = Vector3.zero;
            rb.Sleep();
            
            Debug.Log("end is coming");
        }
    }
}
