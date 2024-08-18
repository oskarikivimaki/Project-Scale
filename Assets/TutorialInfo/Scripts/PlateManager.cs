using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlateManager : MonoBehaviour
{
    private int managerInt = 1;
    [SerializeField]
    private Transform[] child;
    private int childCount;

    [SerializeField]
    private GameObject door;
    public string doorTag;



    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount;
        child = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            child[i] = transform.GetChild(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (managerInt == 3)
        {
            door = GameObject.FindGameObjectWithTag(doorTag);
            door.GetComponent<Animator>().SetBool("Open", true);
        }
    }

    public void Activated(int key)
    {
        if (key == managerInt)
        {
            managerInt++;
        }
        else
        {
            StartCoroutine(waiter());
            
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);

        foreach (Transform t in child)
        {
            t.GetComponent<Puzzle2>().Deactivate();
        }
        managerInt = 1;
    }
}
