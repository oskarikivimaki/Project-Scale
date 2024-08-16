using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _jumpForce = 500;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _camerTransform;
    [SerializeField] private Transform _cameraMovement;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
        vel = Quaternion.AngleAxis(_camerTransform.rotation.eulerAngles.y, Vector3.up) * vel;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;

        

        if (Input.GetKeyDown(KeyCode.Space)) _rb.AddForce(Vector3.up * _jumpForce);
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
}
