using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 moveInput;
    [SerializeField]private float rotationSpeed;
    [SerializeField]private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
       SetPlayerVelocity();
        Rotate();
    }
    private void Rotate()
    {
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotation);
        }
    }
    private void SetPlayerVelocity()
    {
        rb.linearVelocity = moveInput * speed;
    }
    
    private void OnMove(InputValue input)
    {
       moveInput = input.Get<Vector2>();
    }
}

