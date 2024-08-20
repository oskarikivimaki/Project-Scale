using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ObjectInteract : MonoBehaviour
{
    [SerializeField] private Transform[] children;
    [SerializeField] private Animator objAnim;
    [SerializeField] string _tag;
    [SerializeField] private bool noChildren;
    [SerializeField] private bool hasDirector;
    [SerializeField] private PlayableDirector dir;
    // Start is called before the first frame update
    void Start()
    {
        if (!noChildren)
        {
            int amount = transform.childCount;
            children = new Transform[amount];

            for (int i = 0; i < amount; i++)
            {
                children[i] = transform.GetChild(i);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == _tag)
        {
            if (!hasDirector)
            {

                if (!noChildren)
                {
                    print("THONG!!!");
                    foreach (Transform t in children)
                    {
                        Animator an = t.GetComponent<Animator>();
                        an.SetBool("Interact", true);
                    }
                }
                if (noChildren)
                {
                    objAnim.SetBool("Interact", true);
                }
            }
            if (hasDirector)
            {
                dir.Play();
            }
        }
    }

    public void PlayAnimation(Animator anim)
    {
        anim.SetBool("Interact", true);
            
    }
}
