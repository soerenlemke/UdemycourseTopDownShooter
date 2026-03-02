using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    
    [Header("Movement data")]
    public float moveSpeed;
    public float rotateSpeed;
    
    private float _verticalInput;
    private float _horizontalInput;
    
    [Space]
    public LayerMask whatIsAimMask;
    public Transform aimTransform;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateAim();
        
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        var movement = transform.forward * (moveSpeed * _verticalInput);
        
        _rb.linearVelocity = movement;
        
        transform.Rotate(0, _horizontalInput * rotateSpeed, 0);
    }

    private void UpdateAim()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, whatIsAimMask))
        {
            var fixedY = aimTransform.position.y;
            aimTransform.position = new Vector3(hit.point.x, fixedY, hit.point.z);
        }
    }
}
