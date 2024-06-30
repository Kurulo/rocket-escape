using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    [SerializeField] private float _levelLoadTime;
    private GameCycleController _gameCycle;

    public void RestartLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentSceneIndex + 1;
        
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextLevelIndex);
        } else {
            LoadFirstLevel();
        }
    }

    public void LoadSelectedLevel(int id) {
        SceneManager.LoadScene(id);
    }

    private void LoadFirstLevel() {
        SceneManager.LoadScene(0);
    }
    
    public void InvokeResLvl() {
        Invoke(nameof(RestartLevel), _levelLoadTime);
    }
    
    public void InvokeLoadNextLvl() {
        Invoke(nameof(LoadNextLevel), _levelLoadTime);
    }
    
    public void InvokeLoadFirstLvl() {
        Invoke(nameof(LoadFirstLevel), _levelLoadTime);
    }
}
