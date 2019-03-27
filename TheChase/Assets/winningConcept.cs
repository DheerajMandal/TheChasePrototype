using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class winningConcept : MonoBehaviour
{
    [Header("References")]
    public Text countDownText;
    public bool countBeganPlayer=false;
    public bool countBeganEnemy = false;
    public float countDuration = 10f;
    public float counter;
    string Name = "";
    public bool win = false;
    public bool carriedByPlayer = false;
    public bool carriedByEnemy = false;
    GameObject player;
    public NavMeshMove navMeshScript;
    GameObject currentEnemy;
    public string enemyCurrentName;
   public Vector3 originalPos;
    BoxCollider bc;
    float pushX, pushZ;
    public float pushBackSpeed=10;
    Rigidbody rb;
    void Start()
    {
        originalPos = this.transform.position;
        counter = countDuration;
        player = GameObject.FindGameObjectWithTag("Player");
        bc = this.GetComponent<BoxCollider>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
      
        if(carriedByPlayer)
        {
            //lets make the flag move with the player with getting the player position
            Vector3 playerPos = player.transform.position;
            playerPos.y += 2f;
            this.transform.position = playerPos;
            bc.isTrigger = true;
     
            //if player got hit while carrying the flag then the flag will get back to its original place .. 
         

        }
        else
        {
            bc.isTrigger = false;
        }
        if(carriedByEnemy )//if name got changed then no change in position 
        {
            Vector3 currentEnemyPos = currentEnemy.transform.position;
            currentEnemyPos.y +=2.2f;
            
            this.transform.position = currentEnemyPos;
            //Debug.Log("Carried by enemy");
           
        }
        else
        {
           // bc.isTrigger = true;
        }
    }


   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            //player is on final surface then countdown start 
            //1.countDownStart 
            countBeganPlayer = true;
            countBeganEnemy = false;
            name = collision.gameObject.name;
            //it will get carried by the player 
            carriedByPlayer = true;



        }
        if (collision.gameObject.tag == "enemy")
        {
            countBeganEnemy = true;
            countBeganPlayer = false;
            //count logic will get implemented after chasing logic ,Pending for now 
            carriedByPlayer = false;
            carriedByEnemy = true;
            currentEnemy = collision.gameObject;
            enemyCurrentName = collision.gameObject.name;
        }
        if(collision.gameObject.tag =="DeadZone")
        {
            //lets spawn this at some other location 
            //x=13 and 11 
            //z=-18 and 8 
            this.transform.position = originalPos;
          
            
        }
        if(collision.gameObject.tag == "pushFlag")
        {
            //lets push back
            foreach (ContactPoint cp in collision.contacts)
            {
                pushX = cp.normal.x;
                pushZ = cp.normal.z;
            }
            //make the navmesh to fallback 
            //navMeshAgent.Stop(true);



            rb.velocity = (new Vector3(pushX, 2, pushZ) * pushBackSpeed);
        }
        if(collision.gameObject.tag == "trickPush")
        {
            rb.velocity = (new Vector3(3f, 10, 5) * 10f);
        }
    }






}
