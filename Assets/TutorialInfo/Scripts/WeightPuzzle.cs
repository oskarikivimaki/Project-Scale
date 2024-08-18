using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class WeightPuzzle : MonoBehaviour
{
    private GameObject plate;

    // Start is called before the first frame update
    void Start()
    {
        plate = GameObject.FindGameObjectWithTag("Button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
