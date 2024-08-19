using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FillAcid : MonoBehaviour
{
    [SerializeField] Animator acid;
    Animator anim;
    bool playerIn;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerIn)
        {
            if(Input.GetKeyDown(KeyCode.E)) {
                StartCoroutine(Fill());        
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.tag == "Player")
            {
                playerIn = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other != null) { 
            if(other.tag == "Player")
            {
                playerIn = false;
            }
        }
    }

    IEnumerator Fill()
    {
        anim.SetBool("Turn", true);
        yield return new WaitForSeconds(2);
        acid.SetBool("Up", true);
        yield return new WaitForSeconds(5);
        acid.SetBool("Up2", true);
    }
}
