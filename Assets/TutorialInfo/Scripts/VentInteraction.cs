using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentInteraction : MonoBehaviour
{
    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && Input.GetKeyDown(KeyCode.E))
        {

        }
    }
}
