using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerController player;

    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isSpaceDownPressed;
    internal bool isUpPressed;
    internal bool isDownPressed;
    internal bool isSpaceReleased;
    internal bool isAttackPressed;
    internal bool isLeftDashPressed;
    internal bool isRightDashPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeftPressed = true;
        }
        else
        {
            isLeftPressed = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRightPressed = true;
        }
        else
        {
            isRightPressed = false;
        }
        if (Input.GetButton("Jump"))
        {
            isUpPressed = true;
        }
        else 
        {
            isUpPressed = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            isSpaceDownPressed = true;
        }
        else 
        {
            isSpaceDownPressed = false;
        }
        if (Input.GetButtonUp("Jump"))
        {
            isSpaceReleased= true;
        }
        else
        {
            isSpaceReleased = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            isAttackPressed = true;
        }
        else 
        {
            isAttackPressed = false;
        }
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRightDashPressed = true;
        }
        else
        {
            isRightDashPressed = false;
        }
        */
    }
}
