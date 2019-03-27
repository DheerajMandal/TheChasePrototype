using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class NavMeshMove : MonoBehaviour
{
    [SerializeField]
    public Transform destination;

    public NavMeshAgent navMeshAgent;
    Rigidbody rb;
    //locations of striking 
    float pushX, pushZ;
    public float pushSpeed = 1.0f;
    public GameObject parent;
    [Header("Player")]
    public GameObject player;
    [Header("PlayerScript")]
    public actualPlayerMove playerScript;
    public GameObject[] enemies;
    public winningConcept winningScript;
    bool distanceNotCovered = false;
    bool isOnfinalSurface = false;
    GameObject finalFlag;
    public Text countDownText;
    public float countDuration = 10f;
    float counter;
    public Text startText;
    public Button startButton;
    float distanceEnemyNeeded1;
    float distanceEnemyNeeded2;
    float distanceEnemyNeeded3;
    float distanceEnemyNeeded4;
    public bool finalSurface = true;
    public GameObject[] targetDown;
    public float forwardSpeed = 5.0f;
    bool groundSurface = false;
    int randomTarget;
    Rigidbody rb1;
    public float flagSpeed = 10f;
    public GameObject follow;
    float random;Vector3 targetRotation;
    public float rotationSpeed = 0.6f;
    public GameObject wall;
    float distance;
    bool fleeOff = false;
    float up, down, left, right;
    Vector3 oldPosition;public bool rotate = false;
    public bool offOthers = false;
    bool canStop = false;
    public GameObject[] randomLocation;
    bool makeGeneral = true;
  int random1;int random2;
    bool dontExecute,dontExceuteInner;
    public GameObject arrow;
    Vector3 backtoPos;
    public GameObject arrowPart1, arrowPart2;
    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("arrow");
        backtoPos = arrow.transform.position;
        oldPosition = this.transform.position;
        up = 0f;
        down = 180f;
        left = -90f;
        right = 90f;
        finalSurface =false;
        Time.timeScale = 1;
        counter = countDuration;
        finalFlag = GameObject.FindWithTag("nationalFlag");
        rb = this.GetComponent<Rigidbody>();
        rb1 = finalFlag.GetComponent<Rigidbody>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();




    }
    private void FixedUpdate()
    {

        arrow.transform.position = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y + 3f, player.transform.localPosition.z);
        arrow.transform.LookAt(destination.transform.position);

        if (!winningScript.carriedByEnemy && !winningScript.carriedByPlayer)
        {
            //back to normal speed
            navMeshAgent.speed = 6.5f;
            playerScript.speed = 6.5f;
            navMeshAgent.angularSpeed = 130f;
            navMeshAgent.acceleration = 15f;
        }
      

        if (winningScript.carriedByPlayer)
        {
            arrow.transform.position = new Vector3(0f,0f,0f);
            //lets make the enemy speed to 15
            navMeshAgent.speed = 12f;
            navMeshAgent.angularSpeed = 600f;
            navMeshAgent.acceleration = 42f;
            playerScript.speed = 10f;
          
           
           // winningScript.GetComponent<BoxCollider>().isTrigger = false;
         


        }
     
        

        
      
       
        

        if (navMeshAgent == null)
        {
            Debug.Log("The navmesg agent is not attached to it ");
        }
        else
        {
            if(makeGeneral==true)
            setLocation(destination.transform.position);
        }
        if( winningScript.carriedByEnemy)
        {
            if (this.transform.name!=winningScript.enemyCurrentName)
            {
                navMeshAgent.speed = 10f;
                navMeshAgent.angularSpeed = 600f;
                navMeshAgent.acceleration = 42f;
            }
        }
       


        //lets start this only when the flag is holded by the current enemy 
        if (winningScript.carriedByEnemy && this.transform.name == winningScript.enemyCurrentName)
        {

            //lets indicate the player 
            arrowPart1.GetComponent<MeshRenderer>().material.SetColor("_Color", this.transform.gameObject.GetComponent<MeshRenderer>().material.color);
            arrowPart2.GetComponent<MeshRenderer>().material.SetColor("_Color", this.transform.gameObject.GetComponent<MeshRenderer>().material.color);



            navMeshAgent.angularSpeed = 600f;
            navMeshAgent.acceleration = 42f;
           

            if (this.transform.position == oldPosition)
            {
                //rotate = true;
                offOthers = false;
                dontExecute = false;
                dontExceuteInner = false;
                Debug.Log("PlayerStopped moving");
                //enemy stopped moving
                if (rotate == true)
                {

                   // random1 = UnityEngine.Random.Range(0, 2);
                   // navMeshAgent.SetDestination(randomLocation[random1].transform.position);

                    makeGeneral = false;
                   // offOthers = true;
                }
                


            }
            else
            {
                //enemy is moving
                oldPosition = this.transform.position;
              offOthers = false;

            }
            //it will make keep moving
            if (offOthers == false)
            {
                
                //lets tweak this 
                if(!dontExecute)
                random1 = UnityEngine.Random.Range(0, 2);
                if(random1==0)
                {
                    dontExecute = true;
                    if(!dontExceuteInner)
                    random2 = UnityEngine.Random.Range(0, 2);
                    if(random2==0)
                    {
                        navMeshAgent.SetDestination(randomLocation[0].transform.position);
                        dontExceuteInner = true;
                    }
                   
                    if(random2==1)
                    {
                        navMeshAgent.SetDestination(randomLocation[1].transform.position);
                        dontExceuteInner = true;

                    }
                       


                }
                if (random1==1)
                {
                    dontExecute = true;
                    navMeshAgent.SetDestination(follow.transform.position);
                }
               
                makeGeneral = false;
                navMeshAgent.speed = 10f;

            }
            else
            {
                //reset
                dontExecute = false;
                dontExceuteInner = false;
            }
            float distanceEnemy = Vector3.Distance(transform.position, player.transform.position);
            if(enemies[1].gameObject!=null)
            distanceEnemyNeeded1 = Vector3.Distance(transform.position, enemies[1].transform.position);
            if(enemies[2].gameObject!=null)
            distanceEnemyNeeded2 = Vector3.Distance(transform.position, enemies[2].transform.position);
            if(enemies[3].gameObject!=null)
            distanceEnemyNeeded3 = Vector3.Distance(transform.position, enemies[3].transform.position);
            if(enemies[4].gameObject!=null)
            distanceEnemyNeeded4 = Vector3.Distance(transform.position, enemies[4].transform.position);
            navMeshAgent.speed = 10f;
            //  navMeshAgent.acceleration = 130f;
            // navMeshAgent.SetDestination(transform.forward * Time.deltaTime * forwardSpeed);
            playerScript.speed = 10f;
            //winningScript.GetComponent<BoxCollider>().isTrigger = false;
            //let begin the countdown 
            countDownText.text = winningScript.enemyCurrentName + ": " + (int)counter;
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                countDownText.text = winningScript.enemyCurrentName + ": " + "win";
                startButton.enabled = true;
                startText.enabled = true;
                startText.text = "Press anywhere to restart";
                Time.timeScale = 0;

            }

            if (!fleeOff)
            {
                if (distanceEnemy <= 4f)
                {
                    // groundSurface = false;

                    //attack the player 
                   // Debug.Log("Distance is less now ");
                   if(this.transform.gameObject!=null)
                    {
                        Vector3 dirToPlayer = this.transform.position - player.transform.position;
                        Vector3 dest = transform.position + dirToPlayer;

                        navMeshAgent.speed = 10.0f;
                        navMeshAgent.SetDestination(dest);
                        distanceNotCovered = true;
                        offOthers = true;
                        rotate = false;
                        canStop = false;
                        makeGeneral = false;

                    }

                }
                else
                {
                    
                }
                if (distanceEnemyNeeded1 <= 4f)
                {
                    if(enemies[1].gameObject!=null)
                    {
                        Vector3 dirToPlayer = this.transform.position - enemies[1].transform.position;
                        Vector3 dest = transform.position + dirToPlayer;
                        navMeshAgent.speed = 10.0f;
                        navMeshAgent.SetDestination(dest);
                        distanceNotCovered = true;
                        offOthers = true;
                        rotate = false;
                        canStop = false;
                        makeGeneral = false;
                    }
                
                    // groundSurface = false;
                }
                else
                {
                    canStop = true;
                }


                if (distanceEnemyNeeded2 <= 4f)
                {
                    if(enemies[2].gameObject!=null)
                    {
                        Vector3 dirToPlayer = this.transform.position - enemies[2].transform.position;
                        Vector3 dest = transform.position + dirToPlayer;
                        navMeshAgent.speed = 10.0f;
                        navMeshAgent.SetDestination(dest);
                        distanceNotCovered = true;
                        offOthers = true;
                        rotate = false;
                        canStop = false;
                        makeGeneral = false;
                    }
                  
                    //groundSurface = false;
                }
                else
                {
                    canStop = true;
                }


                if (distanceEnemyNeeded3 <= 4f)
                {
                    if(enemies[3].gameObject!=null)
                    {
                        Vector3 dirToPlayer = this.transform.position - enemies[3].transform.position;
                        Vector3 dest = transform.position + dirToPlayer;
                        navMeshAgent.speed = 10.0f;
                        navMeshAgent.SetDestination(dest);
                        distanceNotCovered = true;
                        offOthers = true;
                        rotate = false;
                        canStop = false;
                        makeGeneral = false;

                    }
                 
                    //groundSurface = false;
                }
                else
                {
                    canStop = true;
                }


                if (distanceEnemyNeeded1 <= 4f)
                {
                    if(enemies[4].gameObject!=null)
                    {
                        Vector3 dirToPlayer = this.transform.position - enemies[4].transform.position;
                        Vector3 dest = transform.position + dirToPlayer;
                        navMeshAgent.speed = 10.0f;
                        navMeshAgent.SetDestination(dest);
                        distanceNotCovered = true;
                        offOthers = true;
                        rotate = false;
                        makeGeneral = false;
                        canStop = false;
                    }
                  
                    //groundSurface = false;
                }
                else
                {
                    canStop = true;
                }
                if(canStop==true)
                {
                   // rotate = true;
                   //offOthers = false;
                }

            }



            


            //lets diable the current enemy attack logic by simply disabling the renderer off
            this.gameObject.transform.Find("attackPlayer").GetComponent<attackPlayer>().enabled = false;

            
           


          if(groundSurface)
            {
                ///  navMeshAgent.SetDestination(transform.forward * Time.deltaTime);
                // Debug.Log("ground surface comign------------------------------------");
                //navMeshAgent.Move(transform.forward * Time.deltaTime * forwardSpeed);
                //navMeshAgent.SetDestination(transform.forward * Time.deltaTime * forwardSpeed);

                fleeOff = false;
                finalSurface = false;
              //  rotate = true;
                }
            
                //now check for the surfaces 
           
                //if they are really close then make the player to jump downwards thats it// 
                if(finalSurface)
                {
                fleeOff = true;
                navMeshAgent.SetDestination(targetDown[randomTarget].transform.position);
                navMeshAgent.speed = 10f;
               // groundSurface = false;


                //lets jump once step down 

                   // navMeshAgent.SetDestination(transform.forward * forwardSpeed * Time.deltaTime);
                    //this.transform.position += transform.forward * forwardSpeed * Time.deltaTime;




                
            
               
               
            }
    
           
           
        }
        else
        {
             this.gameObject.transform.Find("attackPlayer").GetComponent<attackPlayer>().enabled = true;
            //arrow.transform.position = backtoPos;
            //le
        }
        //Attacking the Player 
        if (winningScript.enemyCurrentName!=this.transform.name)
        {
            if (player != null && this.transform.gameObject != null) ;
            float distance = Vector3.Distance(player.transform.position, this.transform.position);

            if (distance <=3f)
            {
                //attacking the player 
                if(navMeshAgent.enabled==true)
                navMeshAgent.SetDestination(player.transform.position);
                navMeshAgent.speed = 10f;
               // playerScript.speed = 6.0f;

            }
            else
            {
                setLocation(destination.transform.position);
            }
         
            

        }

    }

    public  void setLocation(Vector3 targetPos)
    {

        try
        {
            if(navMeshAgent.enabled==true)
            navMeshAgent.SetDestination(targetPos);
            //navMeshAgent.destination = transform.forward * forwardSpeed * Time.deltaTime;
        }
        catch(Exception e)
        {

        }
       
    }



    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(0.66f);
        navMeshAgent.enabled = true;
        setLocation(destination.transform.position);

    }
    private void OnCollisionStay(Collision collision)
    {
        if (winningScript.carriedByEnemy && this.transform.name == winningScript.enemyCurrentName)
        {
            Debug.Log("Coming in collider");
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "enemy")
            {

                // finalFlag.transform.position = winningScript.originalPos;
                foreach (ContactPoint cp in collision.contacts)
                {
                    pushX = cp.normal.x;
                    pushZ = cp.normal.z;
                }
                //make the navmesh to fallback 
                //navMeshAgent.Stop(true);



                rb1.velocity = (new Vector3(pushX, 2, pushZ) * flagSpeed);
                counter = countDuration;
                //lets get back the flag to its position 
                winningScript.carriedByEnemy = false;

                makeGeneral = true;
            }
           
         

        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "enemy")
        {

            //Debug.Log("enemy hitted by player");
            foreach (ContactPoint cp in collision.contacts)
            {
                pushX = cp.normal.x;
                pushZ = cp.normal.z;
            }
            //make the navmesh to fallback 
            //navMeshAgent.Stop(true);

            navMeshAgent.enabled = false;

            rb.velocity = (new Vector3(pushX, 2, pushZ) * pushSpeed);
            //counter = countDuration;
            StartCoroutine(WaitFor());
        }


        
        if (collision.gameObject.tag == "nationalFlag")
        {
            counter = countDuration;
            
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.tag == "finalSurface")
            {
          
                finalSurface = true;
                groundSurface = false;
                Debug.Log("Final surface arrived--------------------");
                randomTarget = UnityEngine.Random.RandomRange(0, 4);
                Debug.Log(randomTarget);
            
          

            }
      
        
        if (collision.gameObject.tag == "DeadZone")
        {
            Destroy(this.gameObject);
        }
        if (winningScript.carriedByEnemy && this.transform.name == winningScript.enemyCurrentName)
        {
            if (collision.gameObject.tag == "GroundSurface")
            {
                finalSurface = false;
                groundSurface = true;
                Debug.Log("ground surface arrived");

            }
        }
        if(collision.gameObject.tag == "trickPush")
        {
            Destroy(this.gameObject);
        }
    }

}
