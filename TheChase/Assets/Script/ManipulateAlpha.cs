using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateAlpha : MonoBehaviour
{
    public KeyCode increaseAlpha;
    public KeyCode decreaseAlpha;
    public float alphaLevel = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(increaseAlpha))
        {
            alphaLevel += .5f;
            Color c = this.GetComponent<MeshRenderer>().material.color;
            c.a = alphaLevel;
            this.GetComponent<MeshRenderer>().material.SetColor("_Color", c);
        }
        if(Input.GetKeyDown(decreaseAlpha))
        {
            alphaLevel -= .5f;
            Color c = this.GetComponent<MeshRenderer>().material.color;
            c.a = alphaLevel;
            this.GetComponent<MeshRenderer>().material.SetColor("_Color", c);
        }

     
    }
  
}
