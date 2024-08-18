using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] string itemName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<PlayerController>().PickItem(itemName);
            print("Picked " +  itemName);
        }
        Destroy(gameObject);
    }
}
