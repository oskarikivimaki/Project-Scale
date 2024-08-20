using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScaling : MonoBehaviour
{
    PlayerController controller;
    private GameObject player;
    public Transform sphereCheck;
    private Vector3 playerNormal;
    private Vector3 playerSmall;
    bool isTiny = false;
    bool canShrink;
    [SerializeField]
    [Range(0f, 1f)]
    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        canShrink = true;
        controller = GetComponent<PlayerController>();
        player = this.gameObject;
        playerNormal = new Vector3(1f, 1f, 1f);
        playerSmall = new Vector3(0.2f, 0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(canShrink)
        {
            if (Input.GetKeyDown(KeyCode.Q) && player.transform.localScale == playerSmall)
            {

                Collider[] contacts = Physics.OverlapSphere(sphereCheck.position, player.transform.localScale.magnitude - radius, LayerMask.GetMask("isGround"));
                print(player.transform.localScale.magnitude);
                if (contacts.Length == 0)
                {
                    player.transform.localScale = playerNormal;
                    print(player.transform.localScale);
                    isTiny = false;
                }

            }
        }

        else if (Input.GetKeyDown(KeyCode.Q) && player.transform.localScale == playerNormal)
        {
            player.transform.localScale = playerSmall;
            isTiny = true;
        }
        controller.ChangeRunAndJump(isTiny);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Disable_Shrink")
        {
            canShrink = false;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
    //    Gizmos.DrawWireSphere(sphereCheck.position, player.transform.localScale.magnitude - radius);
    //}
}
