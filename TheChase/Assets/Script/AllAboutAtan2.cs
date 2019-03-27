using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAboutAtan2 : MonoBehaviour
{
    Vector3 startPos, endPos;
    Vector3 distance;
    public GameObject actualPlayer;
    float angle;float j=0;
    public float rotationSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        actualPlayer.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the start and last pos
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - startPos;

            if (mouseDelta.sqrMagnitude < 0.5f)
            {
                return; // Ignoring the touch rotation
            }

            float angle = Mathf.Atan2(mouseDelta.x, mouseDelta.y) * Mathf.Rad2Deg;
        
          
               


        Vector3 targetRotation =new Vector3(0f,
                                                        angle,
                                                       0f);
           // actualPlayer.transform.localEulerAngles = Quaternion.Lerp(actualPlayer.transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);
           // actualPlayer.transform.rotation = Quaternion.Lerp(actualPlayer.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if(actualPlayer!=null)
            actualPlayer.transform.localEulerAngles = Vector3.Lerp(actualPlayer.transform.localEulerAngles, targetRotation,  rotationSpeed);
        }
    }
}
