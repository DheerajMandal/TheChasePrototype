using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class actualPlayerMove : MonoBehaviour
{
    [Header("References")]
    public float rotationY;
    Quaternion targetAngle;
    Rigidbody rb;
    public float speed=8.0f;
    public Text scoreText;
    public Button startButton;
    public Text startText;
    bool restart = false;
    float pushPlayerX;
    float pushPlayerZ;
    float pushX, pushZ;
    public float flagSpeed = 10f;
    public float pushSpeed=1.0f;

    [Header("WinningRefer")]
    public winningConcept winningScript;
    Animator anim;

    [Header("FireHolders")]
    public GameObject[] fireHolders;
    GameObject finalFlag;
    public Text countDownText;
    float countDuration = 10;
    float counter;
    Rigidbody rb1;
    public bool greenSuracfe = false;
    // Start is called before the first frame update
    void Start()
    {
        counter = countDuration;
        Time.timeScale = 1;
        startButton.enabled = false;
        startText.enabled = false;
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        finalFlag = GameObject.FindWithTag("nationalFlag");
        rb1 = finalFlag.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(winningScript.originalPos == winningScript.transform.position)
        {
            counter = countDuration;
        }
        //transform.eulerAngles = new Vector3(0f, player.transform.localEulerAngles.y,0f);
        //rb.velocity=(transform.forward * Time.deltaTime * speed);
        transform.position += transform.forward * Time.deltaTime * speed;
      
       if(winningScript.carriedByPlayer)
        {
            //let begin the countdown 
            countDownText.text = this.transform.name + ": " + (int)counter;
         counter -= Time.deltaTime;
            if(counter<=0)
            {
                countDownText.text = this.transform.name + ": " + "win";
                startButton.enabled = true;
                startText.enabled = true;
                startText.text = "Press anywhere to restart";
                Time.timeScale = 0;
               
            }
           
         
        }
   
     


    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if(winningScript.carriedByPlayer)
        {
            //actually holding the flag 
            //now check if it got hit or  not by other enemy 
            if(collision.gameObject.tag=="enemy")
            {
                counter = countDuration;
                //get the flag back to its original pos 
                //finalFlag.transform.position = winningScript.originalPos;
                foreach(ContactPoint cp in collision.contacts)
                {
                    pushX = cp.normal.x;
                    pushZ = cp.normal.z;

                }
                rb1.velocity= new Vector3(pushPlayerX, 2, pushPlayerZ) * flagSpeed;
                winningScript.carriedByPlayer = false;
       
                
            }
        }
        if (collision.gameObject.tag == "flag")
        {
            //lets make the player teleport 
            Destroy(collision.gameObject);
            scoreText.text = "You Win";
            Time.timeScale = 0;
            



        }
      
        if (collision.gameObject.tag == "DeadZone")
        {
            Destroy(this.gameObject);
           //scoreText.text = "Game Over";
            startButton.enabled = true;
            startText.enabled = true;
            startText.text = "Press anywhere to restart";
            Time.timeScale = 0;
            //lets display the canvas which contains reset button to restart the game 
            
        }
        if(collision.gameObject.tag == "enemy")
        {
            foreach(ContactPoint cp in collision.contacts)
            {
                pushPlayerX = cp.normal.x;//x pos
                
                pushPlayerZ = cp.normal.z;//z pos
            }
            //lets now make the player to get pushBack in that direction 
            rb.velocity = new Vector3(pushPlayerX, 1, pushPlayerZ) * pushSpeed;
            counter = countDuration;


        }
        if(collision.gameObject.tag =="surface")
        {
            //lets stop the countDown of player or enemy which is Currently have the flag 
            winningScript.countDownText.text = " ";
            winningScript.counter = winningScript.countDuration;
            winningScript.countBeganPlayer = false;

        }
        if(collision.gameObject.tag == "nationalFlag")
        {
            counter = countDuration;
        }
        if (collision.gameObject.tag == "trickPush")
        {
            Destroy(this.gameObject);
            startButton.enabled = true;
            startText.enabled = true;
            startText.text = "Press anywhere to restart";
            Time.timeScale = 0;
         
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "greenSurface")
        {
            greenSuracfe = true;
        }
        else
        {
            greenSuracfe = false;
        }
    }


}
