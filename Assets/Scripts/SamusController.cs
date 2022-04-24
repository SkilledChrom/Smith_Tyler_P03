using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamusController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -8;
    public float jumpHeight = 3;
    //public float sprintSpeed = 1;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public AudioSource cannonShoot;
    public GameObject armAsset;
    [SerializeField] ParticleSystem beamCannon = null;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -8f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move * speed * sprintSpeed * Time.deltaTime);
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        /*
        (Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeed = 2;
        }
        else
        {
            sprintSpeed = 1;
        }
        */

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cannonShoot.Play();
            //armAsset.DOPunchPosition(new)
            beamCannon.Play();
        }
    }
}
