using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    
    [Header("Movement data")]
    public float moveSpeed;
    public float rotateSpeed;
    
    private float _verticalInput;
    private float _horizontalInput;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        var movement = transform.forward * (moveSpeed * _verticalInput);
        
        _rb.linearVelocity = movement;
        
        transform.Rotate(0, _horizontalInput * rotateSpeed, 0);
    }
}
