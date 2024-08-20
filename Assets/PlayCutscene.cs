using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayCutscene : MonoBehaviour
{

    public PlayableDirector director;
    
    public void ActivateDirector()
    {
        director.Play();
    }
}
