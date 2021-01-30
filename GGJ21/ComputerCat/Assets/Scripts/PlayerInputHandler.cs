using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    // CharController reference 
    public CharController controller;
    // Set ground movement speed
    private float movementSpeed = 65f;
    
    private float horizontalInput = 0f;
    private bool jumping = false;
    private bool dropMem = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for horizontal input
        horizontalInput = Input.GetAxisRaw("Horizontal") * movementSpeed;
        // Check if jump has been pressed this frame, jump at the end of the frame if so
        if(Input.GetButtonDown("Jump"))
        {
            jumping = true;
        } 
        if(Input.GetKeyDown(KeyCode.X))
        {
            dropMem = true;
        }
        
    }

    private void FixedUpdate()
    {
        // Tell our controller to move with the specified inputs
        controller.Move(horizontalInput * Time.fixedDeltaTime, jumping);
        jumping = false;
        if(dropMem)
        {
            dropMem = false;
            GetComponent<MemHolder>().dropMem();
        }
    }
}
