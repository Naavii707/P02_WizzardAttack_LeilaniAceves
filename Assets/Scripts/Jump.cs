using UnityEngine;
using UnityEngine.Events;

public class jUMP : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float maxJumpTime = 0.3f;
    [SerializeField]
    private float jumpBoost = 0.5f;

    [SerializeField]
    private int maxJumps = 2;
    private int jumps;

    [SerializeField]
    private UnityEvent OnJump;

    private Rigidbody rb;

    private bool isGrounded;
    private bool isJumping;
    private bool buttonPressed;
    private bool canJump = true;

    private float jumpTimeCounter;

    private SoundsEffects soundsEffects;

    private void RestartJumps()
    {
        jumps = maxJumps;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        soundsEffects = GetComponent<SoundsEffects>();
    }

    public void SetCanJump(bool value)
    {
        canJump = value;
        isGrounded = true;
    }

    public void StartJump()
    {
        if (!canJump)
        {
            return;
        }

        buttonPressed = true;

        if (isGrounded || jumps > 0)
        {
            jumps--;
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.linearVelocity = Vector3.up * jumpForce; // Cambi� linearVelocity a velocity
            isGrounded = false;

            // Llamar a JumpSfx cuando el jugador comienza a saltar
            soundsEffects.JumpSfx();
        }
    }

    public void EndJump()
    {
        buttonPressed = false;
    }

    private void FixedUpdate()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (buttonPressed && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.linearVelocity = Vector3.up * (jumpForce + jumpBoost);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            RestartJumps();
            isGrounded = true;
        }
    }

    public void JumpSound()
    {
        if (isJumping == true)
        {
            soundsEffects.JumpSfx();
        }
    }
}

