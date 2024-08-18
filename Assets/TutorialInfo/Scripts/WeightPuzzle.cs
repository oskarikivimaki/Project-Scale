using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class WeightPuzzle : MonoBehaviour
{
    private GameObject plate;
    private GameObject player;

    private float holdingMass;

    // Start is called before the first frame update
    void Start()
    {
        plate = GameObject.FindGameObjectWithTag("Button");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            holdingMass += rb.mass;
            print(holdingMass);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != player)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            holdingMass -= rb.mass;
            print(holdingMass);
        }
    }
}
