using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpForceBIG = 500;
    [SerializeField] private float _jumpForceTINY = 500;
    [SerializeField] private float _speedBIG = 500;
    [SerializeField] private float _speedTINY = 500;


    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _camerTransform;
    [SerializeField] private Transform _cameraMovement;
    [SerializeField] private Transform _groundCheck;
    private Vector3 checkpoint;

    public string[] items = new string[5];
    private int nextItemSlot = 0;
    public float checkRadius;
    public LayerMask isGround;
    private Animator _animator;

    public bool isGrounded;

    [SerializeField]
    public float health;
    [SerializeField]
    public bool alive;



    void Start()
    {
        health = 100;
        alive = true;
        _animator = GetComponentInChildren<Animator>();
        _speed = _speedBIG;
        _jumpForce = _jumpForceBIG;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float vel = _rb.velocity.magnitude;
        WalkAnimation(vel);
        if (Input.GetMouseButtonDown(0))
        {
            Punch();
        }
    }

    void FixedUpdate()
    {
        if (alive)
        {
            isGrounded = Physics.CheckSphere(_groundCheck.position, checkRadius, isGround);

            var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
            vel = Quaternion.AngleAxis(_camerTransform.rotation.eulerAngles.y, Vector3.up) * vel;
            vel.y = _rb.velocity.y;
            _rb.velocity = vel;
            

            if (Input.GetKey(KeyCode.Space) && isGrounded == true)
            {
                _rb.AddForce(Vector3.up * _jumpForce);
            }

            
        }
    }


    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //private void OnCollisionStay(UnityEngine.Collision collision)
    //{
    //    if (collision.collider.CompareTag("isGround"))
    //    {
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit(UnityEngine.Collision collision)
    //{
    //    isGrounded = false;
    //}

    public void Respawn()
    {
        transform.position = checkpoint;
    }
    public void AddCheckpoint(Vector3 _checkpoint)
    {
        checkpoint = _checkpoint;
    }
    private void WalkAnimation(float vel)
    {
        _animator.SetFloat("Velocity", vel);
    }

    private void Punch()
    {
        _animator.SetTrigger("Punch");
    }

    public void ChangeRunAndJump(bool isTiny)
    {
        
        if (isTiny)
        {
            _speed = _speedTINY;
            _jumpForce = _jumpForceTINY;
        }
        if (!isTiny)
        {
            _speed = _speedBIG;
            _jumpForce = _jumpForceBIG;
        }
    }

    public void PickItem(string pickedItem)
    {
        items[nextItemSlot] = pickedItem;
        nextItemSlot++;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            alive = false;
            Death();
        }
    }

    public void Death()
    {
        _rb.isKinematic = true;
        _animator.SetTrigger("Death");
    }
    

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
    //    Gizmos.DrawWireSphere(_groundCheck.position, checkRadius);
    //}
}
