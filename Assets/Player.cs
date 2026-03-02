using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    
    [Header("Movement data")]
    public float moveSpeed;
    public float rotateSpeed;
    
    private float _verticalInput;
    private float _horizontalInput;
    
    [FormerlySerializedAs("tankTower")] [Header("Tower data")]
    public Transform tankTowerTransform;
    public float towerRotationSpeed;
    
    [Header("Aim data")]
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
        
        var direction = aimTransform.position - tankTowerTransform.position;
        direction.y = 0;
        
        var newRotation = Quaternion.LookRotation(direction);
        tankTowerTransform.rotation =
            Quaternion.RotateTowards(tankTowerTransform.rotation, newRotation, towerRotationSpeed);
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
