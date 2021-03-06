using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    // Call Script
    public GameManager _gameManager;

    // Variables
    public CharacterController controller;
    public float gravity = -9.81f;
    public int maxHealth;
    public int CurrentHealth;
    public int maxStamina;
    public int currentStamina;
    public float walkingSpeed;
    public float runSpeed;
    public bool isDead = false;
    public float jumpHeight = 3f;
    public GameManager gameManager;
    public Slider HealthBar;
    
    // Gravity
    Vector3 velocity;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded = true;

    private void Start()
    {
        HealthBar.maxValue = maxHealth;
        HealthBar.value = CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(50);
        }
        getMovement();
        getGravity();
    }

    void getMovement()
    {
        var speed = walkingSpeed;

        float x = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * Z;
        controller.Move(move * walkingSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            if (!Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = walkingSpeed;
            }
        }
    }

    void getGravity()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            _gameManager.GameOver();
        }
        float _ch = Mathf.Clamp(CurrentHealth, 0, 100);
        HealthBar.value = CurrentHealth;
    }
}
