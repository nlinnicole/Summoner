using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpForce = 2.0f;

    private Vector3 forward, right;

    private bool isGrounded;
    private bool isMoving = false;
    private Vector3 jump;

    public GameObject[] portalExit;
    public GameObject SpawnPointsCol;
    private List<GameObject> spawnCol = new List<GameObject>();
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

        //Check if walking
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
        //if(collision.gameObject.tag == "Portal")
        //{
        //    transform.position = portalExit[index].transform.position;
        //}

        index = spawnCol.IndexOf(collision.gameObject);
    }
}
