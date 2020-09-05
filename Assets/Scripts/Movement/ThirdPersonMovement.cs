using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller = default;
    [SerializeField] Animator animator = default;
    [SerializeField] Transform cam = default;

    [SerializeField] float speed = 6;
    float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3;
    [SerializeField] Vector3 velocity = default;
    bool isGrounded;

    [SerializeField] Transform groundCheck = default;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask = default;

    float turnSmoothVelocity;
    [SerializeField] float turnSmoothTime = 0.1f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Jump();
        Fall();
        Move();
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (isGrounded)
        {
            animator.SetTrigger("Land");
            animator.SetBool("Falling", false);
        }
        else
        {
            animator.SetBool("Falling", true);
        }

        
    }
    void Fall()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("Walking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
}
