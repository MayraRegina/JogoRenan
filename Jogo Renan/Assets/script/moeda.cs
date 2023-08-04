using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moeda : MonoBehaviour
{
    public int scoreValue;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gamecontroller.instance.UpdateScore(scoreValue);
            Destroy(gameObject, 0.2f);
        }
    }
}
