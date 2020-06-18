using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMa : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    public float cameraSmoothness = .5f; 

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }    
    }
}
