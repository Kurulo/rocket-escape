using System;
using UnityEngine;

public class CheatInputController : MonoBehaviour {
    public GameObject rocket;

    private CollisionHandler _collisionHandler;

    private void Start() {
        GetComponents();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            _collisionHandler.SwitchCollisionDisabled();
        }
    }
    
    private void GetComponents() {
        if (rocket.GetComponent<CollisionHandler>()) {
            _collisionHandler = rocket.GetComponent<CollisionHandler>();
        }
    }
}
