using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveWithMouse : MonoBehaviour
{
    [Header("Gui")]
    public Text scoreText;
    Vector3 targetPos;
    Quaternion playerRotation;
    public float rotationSpeed = 2.0f;
    public float speed = 2.0f;
    bool isPlayerMoving = false;
    bool forStart = true;
    Vector3 capturedPos;
    public float fallingSpeed = 1f;
    Vector3 targetAngle;
    Rigidbody rb;
    public float upSpeed = 5.0f;
    public float pushSpeed = 2.0f;
    float x, y;
    bool left, right, up, down;
    Vector2 startPos, endPos;
    float swipeDir;
    bool swipeDown = true;
    float x1;
    public float minDistance = 0.2f;
    Quaternion target;
    public float minDiagonalDistance = 1.0f;
    bool swipeActive = false;
    Vector3 tempPos;
    public GameObject targetOb;
    //delte after use
    GameObject gTarget;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        gTarget = GameObject.Find("target");
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(transform.forward * Time.deltaTime * speed, ForceMode.Acceleration);
        Vector3 targetPosition = new Vector3(gTarget.transform.position.x * rotationSpeed * Time.deltaTime, transform.position.y, gTarget.transform.position.z * rotationSpeed * Time.deltaTime);
        transform.LookAt(targetPosition);

       

       
        // swipeWithMouse();
        if (swipeActive)
        {
           // rb.AddForce(transform.forward * Time.deltaTime * speed, ForceMode.Impulse);

          
        }
        
        //lets make the player move when we click the button 
        //lets test 
        /* if(forStart)
         {
             transform.position = Vector3.MoveTowards(transform.position, capturedPos, speed * Time.deltaTime);
         }
         else
         {
             //capturedPos = targetPos;
             //this will make the player to move to the specific finite direction 
            //transform.position = Vector3.MoveTowards(transform.position, capturedPos, speed * Time.deltaTime);
             //transform.Translate(Vector3.forward * speed * Time.deltaTime);//makes the player move to forward only direction
             //where the player is looking 



         }*/
        #region Android Input
        movement();
        #endregion


        if (Input.GetMouseButton(0))
        {
            // setTargetPosition();
            forStart = false;
        }
        if (isPlayerMoving)
            move();
    }

    private void setTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit outHit;

        if (Physics.Raycast(ray, out outHit, 100))
        {
            targetPos = outHit.point;
            //this.transform.LookAt(targetPos);//this will also make the player to look up which we dont want 
            targetAngle = new Vector3(targetPos.x - transform.position.x, transform.position.y,
               targetPos.z - transform.position.z);
            playerRotation = (Quaternion.LookRotation(targetAngle));
            isPlayerMoving = true;
        }
    }

    void move()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);
        // transform.Translate(0f,0f,1 * speed * Time.deltaTime);//making the player bouncy 

        // transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        //transform.position += transform.forward * Time.deltaTime * speed;//this is too making the player boucny 
        rb.AddForce(transform.forward * Time.deltaTime * speed, ForceMode.Impulse);//this not happens instantly 
                                                                                   //rb.velocity = (transform.forward * Time.deltaTime * speed);




        if (transform.position == targetPos)
        {
            isPlayerMoving = false;
        }
    }
    
    void movement()
    {

        if (Input.touchCount > 0)//means we are actually touching
        {
            Touch current = Input.touches[0];
            switch (current.phase)
            {
                case TouchPhase.Began:
                    {
                        startPos = current.position;
                       

                        break;
                    }
                case TouchPhase.Moved:
                    {
                       
                        swipeActive = true;
                        endPos = current.position;
                        swipeDir = (endPos - startPos).magnitude;
                        if(swipeDir > minDistance)
                        {
                            //swipe();
                        }

                  
                        //x += Input.GetTouch(0).deltaPosition.x * rotationSpeed * Time.deltaTime;

                      


                        //x = Mathf.Clamp(x, -180, 180);
                        //this.transform.eulerAngles = new Vector3(0f, x, 0f);








                        //  y = Mathf.Clamp(y, 180, 0);
                        //  y += Input.GetTouch(0).deltaPosition.y * rotationSpeed * Time.deltaTime;



                        //lets rotate by eulerAngels
                        //this.transform.eulerAngles = new Vector3(0f, x, 0f);

                        // this.transform.rotation = Quaternion.RotateTowards(re, ry, rotationSpeed * Time.deltaTime);








                        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        break;
                    }
            }
        }

    }
    void swipe()
    {

        //lets do the swipe operation here 
        Vector2 distance = endPos - startPos;

        if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            //horizontal movement
            if(distance.x > 0)
            {
                //right
                //lets make the player to rotate right by transition 
                //target = Quaternion.Euler(0f, 90f, 0f);
                //transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
                // Debug.Log("rightX " + Mathf.Abs(distance.normalized.x) + "rightY" + Mathf.Abs(distance.normalized.y));
                targetOb.transform.position = new Vector3(0.51f, 20.555f, -8f);


                

            }
            if(distance.x < 0)
            {
                //left
                // target = Quaternion.Euler(0f, -90, 0f);
                //transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
                // Debug.Log("leftX " + Mathf.Abs(distance.normalized.x) + "leftY" + Mathf.Abs(distance.normalized.y));
                targetOb.transform.position = new Vector3(-1.901946f, 20.555f, -7.653405f);

            }
        }
        if(Mathf.Abs(distance.y) > Mathf.Abs(distance.x))
        {
            //vertical movement 
            if(distance.y > 0)
            {
                //up
                target = Quaternion.Euler(0f, 0f, 0f); 
                
                transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
            }
            if(distance.y < 0)
            {
                //down
             
                 target = Quaternion.Euler(0f, 180f, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
            }
        }
        if(Mathf.Abs(distance.normalized.x) >=0.5 && Mathf.Abs(distance.normalized.y) <=0.9 && Mathf.Abs(distance.normalized.x) <=0.91 && Mathf.Abs(distance.normalized.y) >=0.42)
        {
            //diagonal up-right 
          //  target = Quaternion.Euler(0f, 45, 0f);
           // transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);

        }
        if(Mathf.Sign(distance.x) > minDiagonalDistance && Mathf.Sign(distance.y) < -minDiagonalDistance)
        {
            //diagonal down-right 
            if(Mathf.Abs(distance.normalized.x) >=0.70 && Mathf.Abs(distance.normalized.y)<=0.70 && Mathf.Abs(distance.normalized.x) <=0.94 && Mathf.Abs(distance.normalized.y)>=0.33)
            {
               //target = Quaternion.Euler(0f, -135, 0f);
                //Debug.Log("down-right" + Mathf.Sign(distance.x) + "down-RightY" + Mathf.Sign(distance.y));
             //    transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
            }

        }
        if(Mathf.Sign(distance.x) < -minDiagonalDistance && Mathf.Sign(distance.y) > minDiagonalDistance)
        {
            //diagonal up-left
           // target = Quaternion.Euler(0f, -45, 0f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
        }
        if(Mathf.Sign(distance.x) < -minDiagonalDistance && Mathf.Sign(distance.y) < -minDiagonalDistance)
        {
            //diagonal down-left 
            //target = Quaternion.Euler(0f, -135f, 0f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
        }
    }

}





    
    

    


