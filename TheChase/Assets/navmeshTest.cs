using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshTest : MonoBehaviour
{
    public float speed = 3.0f;
    NavMeshAgent agent;
    public GameObject follow;
    int random;
    Vector3 targetRotation;
    public float rotationSpeed = 0.1f;
    public GameObject wall;
    float distance;
    float playerDistance;
    GameObject Player;
    bool offOthers = false;
    Vector3 oldPosition;
    float up, down, left, right;
    float randomSelector;
    public GameObject[] randomLocation;
    bool rotate = true;
    // Start is called before the first frame update
    void Start()
    {
        up = 0f;
        down = 180f;
        left = -90f;
        right = 90f;
        oldPosition = this.transform.position;
        agent = this.GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (this.transform.position == oldPosition)
        {
            if(rotate == true)
            {
                randomSelector = Random.Range(0, 4);
                if (randomSelector == 0)
                {
                    this.transform.eulerAngles = new Vector3(0f, up, 0f);
                }
                if (randomSelector == 1)
                {
                    this.transform.eulerAngles = new Vector3(0f, down, 0f);
                }
                if (randomSelector == 2)
                {
                    this.transform.eulerAngles = new Vector3(0f, right, 0f);
                }
                if (randomSelector == 3)
                {
                    this.transform.eulerAngles = new Vector3(0f, left, 0f);
                }
            }
            //the enemy  has stop moving 
            //i will randomize the enemy direction like where it will move 
             
            //lest go for random location 
           // random = Random.Range(0, 12);
            //agent.SetDestination(randomLocation[random].transform.position);
            Debug.Log("enemy has stop moving" + random);
            offOthers = true;

        }
        else
        {
            //not stopped
            offOthers = false;
            oldPosition = this.transform.position;
        }
        playerDistance = Vector3.Distance(this.transform.position, Player.transform.position);
        if(playerDistance <=2f)
        {
            //making the enemy flee from it 
            Vector3 diff = this.transform.position - Player.transform.position;
            Vector3 dest = this.transform.position + diff;
            agent.SetDestination(dest);
            offOthers = true;
            rotate = false;
            
        }
        else
        {
            //offOthers = false;
            rotate = true;
            offOthers = false;
        }
        if(offOthers==false)
        agent.SetDestination(follow.transform.position);

        /*  distance = Vector3.Distance(transform.position, wall.transform.position);
          if(distance < 6f)
          {
              Vector3 direction = transform.position - wall.transform.position;
              Vector3 dest = transform.position + direction;
              agent.SetDestination(dest);
          }*/
        // Debug.Log(""+Physics.Raycast(transform.position, Vector3.down + Vector3.forward, 2f));
        Vector3 position = follow.transform.position;

        RaycastHit hit;
       /* if (Physics.Raycast(position, Vector3.down, out hit, 1000f))
        {
            //  agent.SetDestination(position);
            agent.SetDestination(follow.transform.position);
            Debug.Log("Surface is visible");
        }
        else
        {
            //if surface is not visible then i have to turn right or left randomly 
            random = Random.Range(-1, 3);
            Debug.Log(random);
            if (random == 0)
            {
                //then turn to right
                targetRotation = new Vector3(0f, 90f, 0f);
                //this.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed);

            }
             else if(random == -1)
             {

                 //watever the random value is  
                 //turn left 
                 targetRotation = new Vector3(0f, -90f, 0f);
                 this.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed);

             }
             else if(random ==1)
             {//up
                 targetRotation = new Vector3(0f, 0f, 0f);
                 this.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed);
             }
             else if(random==2)
             {
                 //down
                 targetRotation = new Vector3(0f, 180f, 0f);
                 this.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed);
             }

             Debug.Log(random);
         }*/


            //agent.SetDestination(hit.transform.position);


        
    }
}
