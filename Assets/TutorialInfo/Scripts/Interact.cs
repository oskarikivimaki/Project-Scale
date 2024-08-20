using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Interact : MonoBehaviour
{
    private GameObject player;
    [SerializeField] string itemToUse;
    private Animator animator;
    [SerializeField] private bool hasDirector;
    [SerializeField] private PlayableDirector dir;
    private bool opened;


    void Start()
    {
        animator = GetComponentInParent<Animator>();
        opened = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && Input.GetKey(KeyCode.E) && !opened)
        {
            opened = true;
            string[] playerItems = other.GetComponent<PlayerController>().items;
            if (CheckItems(playerItems))
            {
                if(!hasDirector)
                {
                    animator.SetBool("Interact", true);
                }
                else
                {
                    dir.Play();
                }
                
            }
            else
            {
                print("You dont have the right item");
            }
        }
    }

    private bool CheckItems(string[] items)
    {
        int playerItemAmount = items.Length;
        
        bool hasItem = false;
        for (int i = 0; i < playerItemAmount; i++)
        {
            print(items[i]);
            if (items[i] == itemToUse)
            {
                hasItem = true;
                break;
            }
            else
            {
                continue;
            }
            
        }
        return hasItem;
    }

    public void PlayAnimation(Animator anim)
    {
        anim.SetBool("Interact", true);
    }
}
