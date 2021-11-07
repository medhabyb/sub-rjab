using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float jumpForce;
    [SerializeField] float playerSpeed;
    private int desiredLane = 1;
    private float laneDistance = 3f;
    [SerializeField] private float maxSpeed;
    private bool isGrounded = true;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeManager.tap)
        {
            animator.SetBool("started", true);
        }
        if (!PlayerManager.isGameStarted)
            return;

      

        //input 
        if ((Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            animator.SetBool("ingr", true);
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
            


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("islft", true);
            



        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("islft", false);




        }



        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            
            if (desiredLane == 3)
            {
                desiredLane = 2;
               
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //changing line 

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;

        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 150 * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
            PlayerManager.gameOver = true;
        if (collision.gameObject.tag == "grr")
            animator.SetBool("ingr", false);



    }
    void OnCollisionStay()
    {
        isGrounded = true;

    }

    private void FixedUpdate()
    {   
        if (!PlayerManager.isGameStarted)
            return;

       

        

        rb.velocity += transform.forward * playerSpeed * Time.deltaTime;

        //limiting player speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }


}

