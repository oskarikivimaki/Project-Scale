using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawnButton : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    [SerializeField] PipesManager pipesManager;
    [SerializeField] Transform spawn;
    private bool playerIn;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(balls[index], spawn.position, spawn.localRotation);
        }
    }

}
