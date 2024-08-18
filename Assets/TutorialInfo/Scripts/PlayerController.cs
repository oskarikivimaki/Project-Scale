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
    public float checkRadius;
    public LayerMask isGround;
    private Animator _animator;

    public bool isGrounded;



    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _speed = _speedBIG;
        _jumpForce = _jumpForceBIG;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, checkRadius, isGround);

        var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
        vel = Quaternion.AngleAxis(_camerTransform.rotation.eulerAngles.y, Vector3.up) * vel;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;
        WalkAnimation(vel.magnitude);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            _rb.AddForce(Vector3.up * _jumpForce);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Punch();
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(_groundCheck.position, checkRadius);
    }
}
