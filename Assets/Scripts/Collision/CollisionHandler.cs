using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    public GameObject levelManager;
    public GameObject rocketInputController;
    public GameObject soundsController;
    public GameObject particleController;

    private LevelManager _levelManager;
    private RocketInputController _rocketInputController;
    private SoundsController _soundsController;
    private ParticleController _particleController;

    private bool _isTransitioning = false;
    private bool _collisionDisabled = false;
    private LevelsCompleteStatistic _loadedGameData;

    private int _starColected = 0;
    private void Start() {
        GetComponents();
        _starColected = 0;
        _loadedGameData = Resources.Load<LevelsCompleteStatistic>("LevelStatistic");
    }

    private void OnCollisionEnter(Collision other) {
        if (_isTransitioning || _collisionDisabled) { return; }
        
        switch (other.gameObject.tag) {
            case "Friendly": 
                Debug.Log("Collision: Friendly");
                break;
            
            case "Finish":
                CollisionFinish();
                break;
            
            default:
                CollisionDefault();
                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        switch (other.gameObject.tag) {
            case "Star":
                Debug.Log("Collision: Star");
                _starColected += 1;
                CollisionWithStar(other.gameObject);
                break;
        }
    }

    private void CollisionWithStar(GameObject star) {
        star.SetActive(false);
    }

    private void CollisionFinish() {
        _isTransitioning = true;
        _rocketInputController.enabled = false;
                    
        NextLevelProcess();
    }

    private void CollisionDefault() {
        _isTransitioning = true;
        _rocketInputController.enabled = false;
                
        SmashProcess();
    }
    
    private void NextLevelProcess() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _loadedGameData.ChangeLevelStatistic(currentSceneIndex, _starColected);

        _particleController.PlaySuccess();
        _levelManager.InvokeLoadNextLvl();
        _soundsController.PlayFinishClip();
    }
    
    private void SmashProcess() {
        _particleController.PlaySmash();
        _soundsController.PlaySmashClip();
        _levelManager.InvokeResLvl();
    }
    
    public void SwitchCollisionDisabled() {
        _collisionDisabled = !_collisionDisabled;
    }
    
    private void GetComponents() {
        if (levelManager.GetComponent<LevelManager>()) {
            _levelManager = levelManager.GetComponent<LevelManager>();
        }
        if (rocketInputController.GetComponent<RocketInputController>()) {
            _rocketInputController = rocketInputController.GetComponent<RocketInputController>();
        }
        if (soundsController.GetComponent<SoundsController>()) {
            _soundsController = soundsController.GetComponent<SoundsController>();
        }
        if (particleController.GetComponent<ParticleController>()) {
            _particleController = particleController.GetComponent<ParticleController>();
        }
    }
}
