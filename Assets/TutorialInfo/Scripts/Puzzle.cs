using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    public string doorTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Key")
        {
            door = GameObject.FindGameObjectWithTag(doorTag);
            door.GetComponent<Animator>().SetBool("Open", true);
            print("JEEEE TOIMII");
            
        }
    }

}
