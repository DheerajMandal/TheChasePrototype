using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attackPlayer : MonoBehaviour
{
    bool calPlayerPos = false;
    GameObject player;
    public NavMeshMove navRefer;
    NavMeshAgent navAgent;
    public actualPlayerMove actualPlayerScript;
    public bool enemySelfAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        navAgent = navRefer.GetComponent<NavMeshAgent>();
        player = GameObject.Find("ActualPlayer");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

     

       
    }

    private void OnTriggerStay(Collider other)
    {
        enemySelfAttack = true;
        if(!enemySelfAttack)
        {
            if (other.gameObject.tag == "enemy")
            {
                try
                {
                    //Debug.Log("Enemy 1 hitted by enemy ");
                    navRefer.navMeshAgent.speed = 8;
                    navRefer.navMeshAgent.SetDestination(other.transform.position);


                }
                catch(Exception e)
                {

                }



            }
        }
       
       
       

    }
    private void OnTriggerExit(Collider other)
    {
       //enemySelfAttack = true;
        //Debug.Log("Playeer is gone from the radius so focus on reaching goal ");
        calPlayerPos = false;
        //gettin back to normal 
       
       // navRefer.setLocation(navRefer.destination.transform.position);
       // navAgent.speed = 4.6f;
        //get back player speed to normal 

        //actualPlayerScript.speed = 5f;
    }
}
