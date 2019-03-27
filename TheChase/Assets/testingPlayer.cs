using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");

        //making the player to move 
        this.transform.position += new Vector3(Horizontal, 0f, vertical) * speed * Time.deltaTime;
    }
}
