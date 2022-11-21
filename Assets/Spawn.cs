using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public List<GameObject> coin;
    // public List<GameObject> bomb;
    public float timeCoin = 2f;
    public float timeBomb = 10f;
    float tCoin;
    // float tBomb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        tCoin += Time.deltaTime;
        // tBomb += Time.deltaTime;

        if (tCoin > timeCoin)
        {
            tCoin = 0;
            // coin.SetActive(true);  
            coin[Random.Range(0,4)].SetActive(true);             
        }        
        // if (tBomb > timeBomb)
        // {
        //      tBomb = 0;
        //      bomb[Random.Range(0,4)].SetActive(true);           
        // }  
       
    }
}
