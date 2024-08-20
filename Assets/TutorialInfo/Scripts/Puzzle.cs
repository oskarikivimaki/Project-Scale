using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject blank, correct, wrong;
    private PipesManager _mang;
    private bool ballIn = true;
    public string color;

    private void Start()
    {
        blank.SetActive(true);
        correct.SetActive(false);
        wrong.SetActive(false);
        _mang = GetComponentInParent<PipesManager>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == color)
        {
            _mang.BallIn(color);
            GiveFeedback(true);
        }
        if(other.transform.tag == "Player")
        {
            other.GetComponent<PlayerController>().Respawn();
        }
        else
        {
            print("Wrong colored ball");
            Destroy(other.gameObject);
            GiveFeedback(false);
        }
    }

    private void GiveFeedback(bool isCorrect)
    {
        if(isCorrect)
        {
            blank.SetActive(false);
            wrong.SetActive(false);
            correct.SetActive(true);
        }
        if (!isCorrect)
        {
            blank.SetActive(false);
            wrong.SetActive(true);
            correct.SetActive(false);
        }
    }

}
