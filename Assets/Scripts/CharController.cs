using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpForce = 2.0f;

    private Vector3 forward, right;

    private bool isGrounded;
    private Vector3 jump;

    public GameObject[] portalExit;
    public int index = 0;

    private Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.x = 90;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        jump = new Vector3(0.0f, 3.0f, 0.0f);

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
        {
            Move();
        }
    }

    void Move()
    {
        float originalHeight = transform.position.y;

        Vector3 rightMove = right * speed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 forwardMove = forward * speed * Time.deltaTime * Input.GetAxis("VerticalKey");

        if (transform.position.y > originalHeight)
        {
            transform.position += (rightMove / 2.0f);
            transform.position += (forwardMove / 2.0f);
        } else
        {
            transform.position += rightMove;
            transform.position += forwardMove;
        }

        //Turn character
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        } else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 );
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        } else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //Check if walking to play walking animation
        if (rightMove == Vector3.zero && forwardMove == Vector3.zero)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Artifact")
        {
            Debug.Log("Found artifact");
        }
        if(collision.gameObject.tag == "Ground")
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
