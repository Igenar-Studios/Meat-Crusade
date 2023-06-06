using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public double health = 150;
    public HealthBar healthBar;

    public bool acceptingInput = true;

    private float y;
    private float runSpeed;
    private float walkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth((int) health);
        y = transform.localScale.y;
        runSpeed = speed;
        walkSpeed = speed / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, y / 2, transform.localScale.z);
            speed = walkSpeed;
        } else
        {
            transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
            speed = runSpeed;
        }
 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        healthBar.SetHealth((int)health);
    }
}
