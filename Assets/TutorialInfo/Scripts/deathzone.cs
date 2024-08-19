using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathzone : MonoBehaviour
{
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player") {
            if(controller != null)
            {
                StartCoroutine(RespawnTime());
            }
            else
            {
                controller = collision.transform.GetComponent<PlayerController>();
                StartCoroutine(RespawnTime());
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(1.5f);
        controller.Respawn();
    }
}
