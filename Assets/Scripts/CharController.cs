using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpForce = 2.0f;

    private Vector3 forward, right;
    private Rigidbody rb;

    private bool isGrounded;
    private Vector3 jump;


    private void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        jump = new Vector3(0.0f, 3.0f, 0.0f);

        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        { 
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        else
            Move();
    }

  

    void Move()
    {
        float originalHeight = transform.position.y;

        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMove = right * speed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 forwardMove = forward * speed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMove + forwardMove);
        //transform.forward = heading;

        if (transform.position.y > originalHeight)
        {
            Debug.Log("jumping");
            transform.position += (rightMove / 2.0f);
            transform.position += (forwardMove / 2.0f);
        } else
        {
            transform.position += rightMove;
            transform.position += forwardMove;
        }
        
    }
}
