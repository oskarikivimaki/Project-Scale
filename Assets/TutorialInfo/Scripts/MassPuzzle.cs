using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class MassPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject ActionObject;
    private GameObject plate;
    private GameObject player;

    [SerializeField] private float actMass;
    private float holdingMass;
    [SerializeField] private bool OneObject;

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
        if (OneObject && holdingMass == actMass)
        {
            Animator _anim = ActionObject.GetComponent<Animator>();
            ActivateAnim(_anim);
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

    private void ActivateAnim(Animator anim)
    {
        anim.SetBool("Activate", true);
        print("Activate lifter");
    }
}
