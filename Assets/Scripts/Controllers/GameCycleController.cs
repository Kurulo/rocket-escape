using UnityEngine;

public class GameCycleController
{
    private bool _isGamePaused = false;

    public bool IsGamePaused { get { return _isGamePaused; } }

    public void QuiteAplication()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _isGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _isGamePaused = false;
    }
}
