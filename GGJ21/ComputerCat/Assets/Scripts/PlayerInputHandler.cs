using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    // CharController reference 
    public CharController controller;
    // Set ground movement speed
    private float movementSpeed = 65f;
    private Animator anim;
    public AudioSource footstep;
    public AudioSource jumpingSound;
    private bool walking = false;
    private float horizontalInput = 0f;
    private bool jumping = false;
    private bool dropMem = false;
    private bool midJump = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for horizontal input
        horizontalInput = Input.GetAxisRaw("Horizontal") * movementSpeed;
        // Check if jump has been pressed this frame, jump at the end of the frame if so
        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
        } 
        if(Input.GetKeyDown(KeyCode.X))
        {
            dropMem = true;
        }
        if(midJump && controller.getYVelo() == 0.0f && controller.m_Grounded)
        {
            anim.SetTrigger("Land");
            if(jumpingSound.isPlaying)
            {
                jumpingSound.Stop();
            }
            midJump = false;
        }
        
    }

    private void FixedUpdate()
    {
        // Tell our controller to move with the specified inputs
        if (horizontalInput != 0.0 && !walking)
        {
            walking = true;
            anim.SetBool("Walking", true);

        }
        if (horizontalInput == 0.0 && walking)
        {
            walking = false;
            anim.SetBool("Walking", false);
        }
        if(jumping && controller.m_Grounded)
        {
            anim.SetTrigger("Jump");
            footstep.Stop();
            midJump = true;
        }
        if(jumping && !jumpingSound.isPlaying)
        {
            jumpingSound.Play();
        }
        if (controller.m_Grounded && walking && !footstep.isPlaying)
        {
            footstep.Play();
        }
        if(!walking && footstep.isPlaying || !controller.m_Grounded)
        {
            footstep.Stop();
        }
        controller.Move(horizontalInput * Time.fixedDeltaTime, jumping);
        jumping = false;
        if(dropMem)
        {
            dropMem = false;
            GetComponent<MemHolder>().dropMem();
        }
    }
}
