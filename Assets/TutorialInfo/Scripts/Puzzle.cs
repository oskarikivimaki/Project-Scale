using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField]
    private Transform blank, correct, wrong;
    private PipesManager _mang;
    private bool ballIn = true;
    public string color;

    private void Start()
    {
        blank = transform.set
        _mang = GetComponentInParent<PipesManager>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == color)
        {
            _mang.BallIn(color);
        }
        else
        {
            print("Wrong colored ball");
            Destroy(other.gameObject);
        }
    }

    private void GiveFeedback(bool isCorrect)
    {
        if(isCorrect)
        {

        }
    }

}
