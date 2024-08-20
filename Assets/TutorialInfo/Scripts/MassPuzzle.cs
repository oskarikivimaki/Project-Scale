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

    [SerializeField] bool StartsDirector = false;

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
            if(StartsDirector)
            {
                if(GetComponent<PlayCutscene>() != null)
                {
                    PlayCutscene playCut = GetComponent<PlayCutscene>();
                    playCut.ActivateDirector();
                }
            }
            
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

    public void ActivateAnim(Animator anim)
    {
        anim.SetBool("Activate", true);
        print("Activate lifter");
    }
}
