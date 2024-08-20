using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    // Update is called once per frame
    void Update()
    {
        if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !m_Animator.IsInTransition(0)){
            print("Test");
            SceneManager.LoadScene(0);
        }   
    }
}
