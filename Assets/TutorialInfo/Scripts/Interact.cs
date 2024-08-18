using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private GameObject player;
    [SerializeField] string itemToUse;
    private Animator animator;


    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            string[] playerItems = other.GetComponent<PlayerController>().items;
            if (CheckItems(playerItems))
            {
                animator.SetBool("Interact", true);
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
}
