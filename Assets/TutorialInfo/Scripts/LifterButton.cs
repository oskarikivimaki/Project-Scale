using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifterButton : MonoBehaviour
{
    [SerializeField] Animator[] liftAnim;
    bool pushed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && !pushed)
            {
                pushed = true;
                foreach (Animator an in liftAnim)
                {
                    an.SetBool("Activate", true);
                }
            }
        }
    }
}
