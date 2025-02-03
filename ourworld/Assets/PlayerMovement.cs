using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public float movementSpeed = 4;
    private Rigidbody rb;
    private Animator _animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    

    void Update()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        _animator.SetFloat("speed", 0);
        _animator.ResetTrigger("space");
        float speedMult = 1;
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward* movementSpeed * Time.deltaTime;
            _animator.SetFloat("speed", 1);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedMult = 2;
                _animator.SetFloat("speed", 2);

            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward* movementSpeed * Time.deltaTime;
            _animator.SetFloat("speed", -1);
        }
        transform.position += movement.normalized * movementSpeed* speedMult * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            //rb.MoveRotation(Quaternion.Euler(0, 3, 0));
            rb.rotation = (Quaternion.Euler(0, 1 + rb.rotation.eulerAngles.y, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.MoveRotation(Quaternion.Euler(0, 3, 0));
            rb.rotation = (Quaternion.Euler(0, -1 + rb.rotation.eulerAngles.y, 0));
        }
if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _animator.SetTrigger("space");
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);

            isGrounded = false;

        }

    }
} 