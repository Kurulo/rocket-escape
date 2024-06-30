using UnityEngine;

public class RocketMovement : MonoBehaviour {
    public float forceFly;
    public float forceRotate;
    
    private Transform _transform;
    private Rigidbody _rigidbody;
    
    void Start() {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void RotateLeft() {
        ApplyRotation(forceRotate);
    }
    
    public void RotateRight() {
        ApplyRotation(-forceRotate);
    }
    
    public void MakeFly() {
        _rigidbody.AddRelativeForce(Vector3.up * forceFly * Time.deltaTime);
    }
    
    public void ApplyRotation(float applyRotatio) {
        _rigidbody.freezeRotation = true;
        _transform.Rotate(Vector3.forward * applyRotatio * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }
}
