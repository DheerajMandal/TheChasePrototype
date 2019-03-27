using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public GameObject camera;
    public float offsetZ = 3.0f;
    public float offsetX = 2.0f;
    public float offsetY = 5.0f;

    public float rOffsetX = 1.0f;
    public float rOffsetY = 1.0f;
    public float rOffsetZ = 1.0f;
    //rotation offset
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if(player !=null)
        {
            camera.transform.position = new Vector3(Mathf.Lerp(camera.transform.position.x, player.transform.position.x + offsetX, 0.5f),
          Mathf.Lerp(camera.transform.position.y, player.transform.position.y + offsetY, 0.5f), Mathf.Lerp(camera.transform.position.z, player.transform.position.z - offsetZ, 0.5f));
           // came/ra.transform.eulerAngles = new Vector3(Mathf.Lerp(camera.transform.eulerAngles.x, player.transform.eulerAngles.z, 0.5f),
               // Mathf.Lerp(camera.transform.eulerAngles.y, camera.transform.eulerAngles.y, 0.5f),
              //  Mathf.Lerp(camera.transform.eulerAngles.z, player.transform.eulerAngles.z, 0.5f));
        }
       

    }
}
