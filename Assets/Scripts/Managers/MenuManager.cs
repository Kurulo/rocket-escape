using UnityEngine;

public class MenuManager : MonoBehaviour {
    private LevelManager _levelManager;

    private UIElementsVisualization _uiVisual;
    private GameCycleController _gameCycleController;
    private LevelsCompleteStatistic _loadedGameData;

    private void Awake() {
        _loadedGameData = Resources.Load<LevelsCompleteStatistic>("LevelStatistic");

        _levelManager = FindObjectOfType<LevelManager>();
        _uiVisual = GetComponentInChildren<UIElementsVisualization>();

        _gameCycleController = new GameCycleController();
        _gameCycleController.ResumeGame();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseMenu();
            if (_uiVisual.IsSelectLevelPanelActive)
                _uiVisual.HideSelectLevelMenu();
        }
    }

    public void SelectLevel(int levelId) {
        _gameCycleController.ResumeGame();
        _uiVisual.HideAllPanels();
        _levelManager.LoadSelectedLevel(levelId);
    }

    public void PauseMenu() {
        if (_uiVisual.IsPausePaneActive) {
            if (!_uiVisual.IsSelectLevelPanelActive)
                _gameCycleController.ResumeGame();
            _uiVisual.HidePauseMenu();
        } else {
            if (!_uiVisual.IsSelectLevelPanelActive) {
                _gameCycleController.PauseGame();
                _uiVisual.ShowPauseMenu();
            }
        }
    }

    public void ResetAllLevelProgress() {
        _loadedGameData.ResetAllStatistic();
        _uiVisual.VisualizeLevelResult();
    }

    public void QuiteGame() {
        _gameCycleController.QuiteAplication();
    }
}
