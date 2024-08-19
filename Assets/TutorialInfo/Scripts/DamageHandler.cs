using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{

    private PlayerController pC;
    private bool isIn;

    private void OnTriggerEnter(Collider other)
    {
        pC = other.GetComponent<PlayerController>();

        if (pC.alive)
        {
            isIn = true;
            StartCoroutine(waiter());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isIn = false;
    }

    IEnumerator waiter()
    {
        print("1");
        if (isIn && pC.alive)
        {
            pC.TakeDamage(25);

            yield return new WaitForSeconds(5);

            StartCoroutine(waiter());
        }
    }
}
