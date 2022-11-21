using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public ScoreManager score;

    void OnCollisionEnter(Collision collision)
    {
		
        if (collision.gameObject.name == "Player")
        {
            score.UpdateScore(coinValue);
            
            gameObject.SetActive(false);
        }
	}
}
