using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    [SerializeField]
    GameObject plate;
    [SerializeField]
    Material red;
    [SerializeField]
    Material green;

    MeshRenderer meshRenderer;


    private void Start()
    {
        meshRenderer = plate.GetComponent<MeshRenderer>();
        red = meshRenderer.material;
        green.mainTextureScale = red.mainTextureScale;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            print("JEEEE TOIMII");
            meshRenderer.material = meshRenderer.material.name.StartsWith(green.name) ? red : green;
        }
    }

}
