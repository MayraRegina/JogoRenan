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
        if (player.position.x >=-28 && player.position.x <=46)
        {
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime); 
        }

        if (player.position.y <=15 && player.position.y >=0.8)
        {
            Vector3 following = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime); 
        }
        
    }
}
