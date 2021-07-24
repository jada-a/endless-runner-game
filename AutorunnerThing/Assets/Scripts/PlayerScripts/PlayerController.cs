using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Scripts")]
    [SerializeField]
    internal PlayerInput inputScript;
    [SerializeField]
    internal PlayerMovement movementScript;
    [SerializeField]
    internal PlayerCollision collisionScript;

    [Header("Player Physics")]
    [SerializeField]
    internal float walkSpeed = 10;
    [SerializeField]
    internal float jumpForce = 10;
    [SerializeField]
    internal float fallMultiplier = 2.5f;
    [SerializeField]
    internal float gravity = 5;
    [SerializeField]
    internal float airTime;
    internal float airTimeCounter;

    [Header("Player Attributes")]
    [SerializeField]
    internal int health;
    [SerializeField]
    internal float walkSpeedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    public Transform groundCheck;
    public float groundCheckRadius;

    [Header("Other")]
    internal Animator anim;
    internal Rigidbody2D rgbody;

    [SerializeField]
    internal BoxCollider2D boxCollider;

    [SerializeField]
    private LayerMask layerMask;

    public GameManager gameManager;

    public CameraController camController;

    public ScoreManager scoreManager;

    private void Awake()
    {
        print("Playerscript Awake");
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rgbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        airTimeCounter = airTime;
    }

    private void Update()
    {
        //Level Speed Up
        /*
        if (transform.position.x > speedMilestoneCount) 
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * walkSpeedMultiplier;
            walkSpeed = walkSpeed * walkSpeedMultiplier;
        }
        */

        //Check to make running animation
        if (movementScript.isMoving)
        {
            anim.SetBool("isMoving", true);
        }
        else 
        {
            anim.SetBool("isMoving", false);
        }

        //Resets the timer for holding button down for higher jump
        if (IsGrounded())
        {
            airTimeCounter = airTime;
        }


        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.y < 0)
        {
            Die();
        }

    }

    internal bool IsGrounded()
    {
        //RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, layerMask);
        //Debug.Log(raycast.collider);
        //return raycast.collider != null;

        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerMask);

    }

    public void Die()
    {
        rgbody.velocity = Vector2.zero;
        gameManager.GameOver();
    }

}
