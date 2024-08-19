using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
    private bool redIn, blueIn, yellowIn;
    [SerializeField] SphereSpawnButton spawnButton;
    [SerializeField] Animator acidAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallIn(string ballColor) {
        switch (ballColor)
        {
            case "blue":
                blueIn = true;
                spawnButton.index += 1;
                print(ballColor + " in");
                break;

            case "red":
                redIn = true;
                spawnButton.index += 1;
                print(ballColor + " in");
                break;

            case "yellow":
                yellowIn = true;
                spawnButton.index += 1;
                print(ballColor + " in");
                break;

            case null: print("ERROR!!!");  break;
        }

        if (redIn && blueIn && yellowIn) {
            print("All balls in");
            acidAnim.SetBool("Down", true);
        }
    }
}
