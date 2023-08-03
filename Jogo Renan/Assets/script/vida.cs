using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    public int healthValue;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<jogador>().IncreaseLife(healthValue);
            Destroy(gameObject, 0.2f);
        }
    }
}
