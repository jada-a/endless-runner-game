using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    private bool facingRight = true;

    internal bool isMoving;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;

    private int direction;

    void Start()
    {
        player.rgbody.velocity = new Vector2(0,0);
        isMoving = false;
        dashTime = startDashTime;
    }

    private void Update()
    {
       
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);

        if (player.inputScript.isRightPressed || player.inputScript.isLeftPressed)
        {
            isMoving = true;
            MovePlayer(horizontal);
        }
        else
        {
            isMoving = false;
            StopMovement();
        }

        if (player.inputScript.isSpaceDownPressed && player.IsGrounded()) 
        {
            MovePlayerUp();
        }

        
        if (player.inputScript.isUpPressed && player.airTimeCounter > 0) 
        {
            MovePlayerUpTImer();
        }

        if (player.inputScript.isSpaceReleased)
        {
            player.airTimeCounter = 0;
        }
        /*

        if (direction == 0)
        {
            if (player.inputScript.isRightDashPressed)
            {
                direction = 1;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                player.rgbody.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                player.anim.SetTrigger("Dash");

                if (direction == 1)
                {
                    player.rgbody.velocity = Vector2.right * dashSpeed;
                }
            }
        }
        */
    }
    /*
    private void MovePlayerLeft()
    {
        player.rgbody.velocity = new Vector2(-player.walkSpeed, 0);
    }
    private void MovePlayerRight()
    {
        player.rgbody.velocity = new Vector2(player.walkSpeed, 0);
    }
    */

    private void MovePlayer(float horizontal)
    {
        player.rgbody.velocity = new Vector2(player.walkSpeed * horizontal, 0);
    }
    private void MovePlayerUp()
    {
        player.rgbody.AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
    }
    private void MovePlayerUpTImer()
    {
        if (player.airTimeCounter > 0)
        {
            player.rgbody.AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
            player.airTimeCounter -= Time.deltaTime;
        }
    }
    private void StopMovement()
    {
        player.rgbody.velocity = new Vector2(0, 0);
    }

    void Flip(float horizontal)
    {
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) 
        {
            facingRight = !facingRight;

            Vector3 scale = player.transform.localScale;

            scale.x *= -1;

            player.transform.localScale = scale;
        }
    }
}
