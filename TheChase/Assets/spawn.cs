using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] Players;
    float randomX, randomZ;
    float randomX1, randomZ1;
    float decider;
    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.RandomRange(-20f, -15f);
        randomZ = Random.RandomRange(-11, 11);
        randomX1 = Random.RandomRange(12, 15);
        randomZ1 = Random.RandomRange(-9, 9);

       
        //decider
        decider = Random.Range(0, 2);
        Debug.Log(decider);
        if(decider==0)
        {
            Players[0].transform.position = new Vector3(Random.RandomRange(12f, 15f), 9f, Random.RandomRange(-9, 8));
            Players[1].transform.position = new Vector3(Random.RandomRange(-20f, -14f), 9f, Random.RandomRange(-11, 11));
            Players[2].transform.position = new Vector3(Random.RandomRange(12f, 15f), 9f, Random.RandomRange(-9, 8));
            Players[4].transform.position = new Vector3(Random.RandomRange(12f, 15f), 9f, Random.RandomRange(-9, 8));
            Players[5].transform.position = new Vector3(Random.RandomRange(-20f, -14f), 9f, Random.RandomRange(-11, 11));

            //lets Instantiate them 
            /*Instantiate(Players[0].gameObject, new Vector3(Random.RandomRange(12f, 15f), 1f, Random.RandomRange(-9, 9)), Quaternion.identity);
            Instantiate(Players[1].gameObject, new Vector3(Random.RandomRange(-20f, -15f), 1f, Random.RandomRange(-11, 11)), Quaternion.identity);
            Instantiate(Players[2].gameObject, new Vector3(Random.RandomRange(12f, 15f), 1f, Random.RandomRange(-9, 9)), Quaternion.identity);
            Instantiate(Players[3].gameObject, new Vector3(Random.RandomRange(-20f, -15f), 1f, Random.RandomRange(-11, 11)), Quaternion.identity);
            Instantiate(Players[4].gameObject, new Vector3(Random.RandomRange(12f, 15f), 1f, Random.RandomRange(-9, 9)), Quaternion.identity);
            Instantiate(Players[5].gameObject, new Vector3(Random.RandomRange(-20f, -15f), 1f, Random.RandomRange(-11, 11)), Quaternion.identity);*/

        }

    
        else
        {
            if(decider==1)
            {
                Players[0].transform.position = new Vector3(Random.RandomRange(-20f, -14f), 9f, Random.RandomRange(-11, 11));
                Players[1].transform.position = new Vector3(Random.RandomRange(12f, 15f), 9f, Random.RandomRange(-9, 8));
                Players[2].transform.position = new Vector3(Random.RandomRange(-20f, -14f), 9f, Random.RandomRange(-11, 11));
                Players[3].transform.position = new Vector3(Random.RandomRange(12, 15f), 9f, Random.RandomRange(-9, 8));
                Players[4].transform.position = new Vector3(Random.RandomRange(12f, 15f), 9f, Random.RandomRange(-9, 8));
                Players[5].transform.position = new Vector3(Random.RandomRange(-20f, -14f), 9f, Random.RandomRange(-11, 11));
                /*Instantiate(Players[0].gameObject, new Vector3(Random.RandomRange(-20f, -15f), 1f, Random.RandomRange(-11, 11)), Quaternion.identity);
                Instantiate(Players[1].gameObject, new Vector3(Random.RandomRange(12f, 15f), 1f, Random.RandomRange(-9, 9)), Quaternion.identity);
                Instantiate(Players[2].gameObject, new Vector3(Random.RandomRange(-20f, -15f), 1f, Random.RandomRange(-11, 11)), Quaternion.identity);
                Instantiate(Players[3].gameObject, new Vector3(Random.RandomRange(12, 15f), 1f, Random.RandomRange(-9, 9)), Quaternion.identity);
                Instantiate(Players[4].gameObject, new Vector3(Random.RandomRange(12f, 15f), 1f, Random.RandomRange(-9, 9)), Quaternion.identity);
                Instantiate(Players[5].gameObject, new Vector3(Random.RandomRange(-20f, -15f), 1f, Random.RandomRange(-11, 11)), Quaternion.identity);*/

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        decider = Random.Range(0, 2);
        Debug.Log(decider);

    }
}
