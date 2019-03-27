using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);
    }
}
