using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScaling : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerNormal;
    private Vector3 playerSmall;

    [SerializeField]
    [Range(0f, 1f)]
    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        playerNormal = new Vector3(1f, 1f, 1f);
        playerSmall = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && player.transform.localScale == playerSmall)
        {
            
            Collider[] contacts = Physics.OverlapSphere(player.transform.position, player.transform.localScale.magnitude - radius, LayerMask.GetMask("isWall"));
            print(player.transform.localScale.magnitude);
            if (contacts.Length == 0)
            {
                player.transform.localScale = playerNormal;
                print(player.transform.localScale);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Q) && player.transform.localScale == playerNormal)
        {
            player.transform.localScale = playerSmall;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(player.transform.position, player.transform.localScale.magnitude - radius);
    }
}
