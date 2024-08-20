using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class FillAcid : MonoBehaviour
{
    [SerializeField] Animator acid;
    Animator anim;
    bool playerIn;
    [SerializeField] private PlayableDirector dir;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerIn)
        {
            if(Input.GetKeyDown(KeyCode.E)) {
                dir.Play();      
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

    public void SpinAnimation(Animator anim)
    {
        anim.SetBool("Turn", true);
    }
    public void FillAnimation(string whatBool)
    {
        acid.SetBool(whatBool, true);
    }
}
