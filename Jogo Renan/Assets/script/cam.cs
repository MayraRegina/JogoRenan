using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour

{
    private Transform player;
    public float smooth;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.position.x >=0 && player.position.x <=164.2)
        {
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime); 
        }

        if (player.position.y <=7.9 && player.position.y >=0)
        {
            Vector3 following = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime); 
        }
        
    }
}
