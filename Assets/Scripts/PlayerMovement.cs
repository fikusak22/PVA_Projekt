using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 moveInput;
    [SerializeField]private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }
    
    private void OnMove(InputValue input)
    {
       moveInput = input.Get<Vector2>();
    }
}

