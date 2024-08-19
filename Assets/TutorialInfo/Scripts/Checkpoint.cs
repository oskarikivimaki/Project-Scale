using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 spawnpoint;
    private void Start()
    {
        spawnpoint= transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.tag == "Player")
            {
                other.GetComponent<PlayerController>().AddCheckpoint(spawnpoint);
            }
        }
    }
}
