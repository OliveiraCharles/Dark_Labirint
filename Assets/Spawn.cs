using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public List<GameObject> coin;
    public List<GameObject> enemy;
    public float timeCoin = 2f;
    public float timeEnemy = 10f;
    float tCoin;
    float tEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        tCoin += Time.deltaTime;
        tEnemy += Time.deltaTime;

        if (tCoin > timeCoin)
        {
            tCoin = 0;
            coin[Random.Range(0,4)].SetActive(true);             
        }        
        if (tEnemy > timeEnemy)
        {
             tEnemy = 0;
             enemy[Random.Range(0,4)].SetActive(true);           
        }  
       
    }
}
