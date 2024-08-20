using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawnButton : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    [SerializeField] PipesManager pipesManager;
    [SerializeField] Transform spawn;
    private bool playerIn;
    private bool canPress;
    public int index = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        
        if (Input.GetKey(KeyCode.E) && canPress)
        {
            canPress = false;
            if (GameObject.FindGameObjectWithTag(balls[index].tag))
            {
                Destroy(GameObject.FindGameObjectWithTag(balls[index].tag));
                Instantiate(balls[index], spawn.position, spawn.localRotation);
            }
            else
            {
                Instantiate(balls[index], spawn.position, spawn.localRotation);
            }
            StartCoroutine(CoolDown());
            
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        canPress = true;
    }

}
