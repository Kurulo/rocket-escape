using System;
using UnityEngine;

public class Oscillator : MonoBehaviour { 
    [SerializeField] private Vector3 _movementVector;
    private float _movementFactor;
    [SerializeField] private float period = 2f;
    
    private Vector3 _startPosition;
    private Transform _transform;

    private void Start() {
        _transform = GetComponent<Transform>();
        _startPosition = _transform.position;
    }

    private void Update() {
        if (period <= Mathf.Epsilon) { return;}
        float cycle = Time.time / period;
        
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycle * tau);

        _movementFactor = (rawSinWave + 1f) / 2;
        
        Vector3 offset = _movementVector * _movementFactor;
        _transform.position = _startPosition + offset;
    }
}
