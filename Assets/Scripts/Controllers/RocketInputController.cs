using System;
using UnityEngine;

public class RocketInputController : MonoBehaviour {
    public GameObject rocket;
    public GameObject particleController;

    private ParticleController _particleController;
    private RocketMovement _rocketMovement;
    private RocketSounds _rocketSounds;
    
    void Start() {
        TakeComponents();
    }
    
    void Update() {
        InputSpace();
        InputRotation();
    }
    
    private void InputSpace() {
        if (Input.GetKey(KeyCode.Space)) { 
            ProcessFly();
        } else {
            StopFlying();
        }
    }
    
    private void InputRotation() {
        if (Input.GetKey(KeyCode.A)) {
            RotateLeft();
        } else if (Input.GetKey(KeyCode.D)) {
            RotateRight();
        } else {
            StopRotationParticles();
        }
    }   
    
    private void RotateLeft() {
        _rocketMovement.RotateLeft();
        _particleController.PlayLeftBoost();
    }
    
    private void RotateRight() {
        _rocketMovement.RotateRight();
        _particleController.PlayRightBoost();
    }
    
    private void StopRotationParticles() {
        _particleController.StopLeftBoost();
        _particleController.StopRightBoost();
    }
    
    private void ProcessFly() {
        _rocketMovement.MakeFly();
        _rocketSounds.PlayBoostSound();
        _particleController.PlayBoost();
    }
    
    private void StopFlying() {
        _particleController.StopBoost();
        _rocketSounds.StopBoostPaying();
    }

    private void TakeComponents() {
        if (rocket.GetComponent<RocketMovement>()) {
            _rocketMovement = rocket.GetComponent<RocketMovement>();
        } else {
            throw new NullReferenceException("Miss Rocket Movement");
        }
        
        if(particleController.GetComponent<ParticleController>()) {
            _particleController = particleController.GetComponent<ParticleController>();
        } else {
            throw new NullReferenceException("Miss Particle Controller");
        }
        
        if (rocket.GetComponent<RocketSounds>()) {
            _rocketSounds = rocket.GetComponent<RocketSounds>();
        } else {
            throw new NullReferenceException("Miss Rocket Sounds");
        }
    }
}
