using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearSight : MonoBehaviour
{
    public float DistanceToPlayer = 2.0f;
    public Material TransparentMaterial = null;
    public float FadeInTimeout = 0.6f;
    public float FadeOutTimeout = 0.2f;
    public float TargetTransparency = 0.3f;
    public GameObject[] objectsToFade;
    public GameObject Player;
    Material[] m1,m2,m3;
    bool greenSurface = false;
    public actualPlayerMove playerScript;
    private void Start()
    {
        //getting all the material from the object 
        m1 = objectsToFade[0].GetComponent<MeshRenderer>().materials;
        m2= objectsToFade[1].GetComponent<MeshRenderer>().materials;
        m3 = objectsToFade[2].GetComponent<MeshRenderer>().materials;


    }
    private void Update()
    {
        RaycastHit[] hits; // you can also use CapsuleCastAll() 
                           // TODO: setup your layermask it improve performance and filter your hits. 
        hits = Physics.RaycastAll(transform.position, transform.forward, DistanceToPlayer);
        foreach (RaycastHit hit in hits)
        {
            Renderer R = hit.collider.GetComponent<Renderer>();
            if (R == null)
            {

                continue;
            }
            else
            {
                Color c = objectsToFade[0].GetComponent<MeshRenderer>().material.color;
                Color c1 = objectsToFade[1].GetComponent<MeshRenderer>().material.color;
                c.a = 0;
                c1.a = 0;
                //lets check wheter it is on green surafce or in the ground surface 
               if(playerScript.greenSuracfe == true)
                {
                   
                    c.a = 1;
                    c1.a = 0;

                    //we will make the green surface visible
                    m1[0].SetColor("_Color", c);
                    m1[1].SetColor("_Color", c);
                    m1[2].SetColor("_Color", c);
                    m2[0].SetColor("_Color", c1);
                    m2[1].SetColor("_Color", c1);
                    m2[2].SetColor("_Color", c1);
                    m3[0].SetColor("_Color", c1);
                    m3[1].SetColor("_Color", c1);
                    m3[2].SetColor("_Color", c1);

                }
               else
                {
                    m1[0].SetColor("_Color", c);
                    m1[1].SetColor("_Color", c);
                    m1[2].SetColor("_Color", c);
                    m2[0].SetColor("_Color", c1);
                    m2[1].SetColor("_Color", c1);
                    m2[2].SetColor("_Color", c1);

                }
               
                //  objectsToFade[0].GetComponent<MeshRenderer>().material.SetColor("_Color", c);
                // objectsToFade[1].GetComponent<MeshRenderer>().material.SetColor("_Color", c1);

            }
            // no renderer attached? go to next hit 
            // TODO: maybe implement here a check for GOs that should not be affected like the player
          
           
        }
        if(Player.transform.position.z <=-0.5f)
        {
            Color c = objectsToFade[0].GetComponent<MeshRenderer>().material.color;
            Color c1 = objectsToFade[1].GetComponent<MeshRenderer>().material.color;
            c.a = 1;
            c1.a = 1;
            m1[0].SetColor("_Color", c);
            m1[1].SetColor("_Color", c);
            m1[2].SetColor("_Color", c);
            m2[0].SetColor("_Color", c1);
            m2[1].SetColor("_Color", c1);
            m2[2].SetColor("_Color", c1);
        }
    }
}
