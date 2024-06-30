using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIElementsVisualization : MonoBehaviour {
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _selectLevelPanel;
    [SerializeField] private GameObject _showLevelPanel;

    [SerializeField] private List<GameObject> _levelButtons;

    private LevelsCompleteStatistic _loadedGameData;

    private bool _isPausePanelActive = false;
    private bool _isSelectLevelPanelActive = false;

    public bool IsPausePaneActive { get { return _isPausePanelActive; } }
    public bool IsSelectLevelPanelActive { get { return _isSelectLevelPanelActive; } }

    private void Awake() {
        HideAllPanels();
        ShowLevelPanel();

        _loadedGameData = Resources.Load<LevelsCompleteStatistic>("LevelStatistic");
    }

    public void ShowPauseMenu() {
        HideLevelPanel();

        _isPausePanelActive = true;
        _pausePanel.SetActive(true);
    }

    public void HidePauseMenu() {
        _isPausePanelActive = false;
        _pausePanel.SetActive(false);
    }

    public void ShowSelectLevelMenu() {
        _isSelectLevelPanelActive = true;
        _selectLevelPanel.SetActive(true);

        VisualizeLevelResult(); 
    }

    public void VisualizeLevelResult() {
        for (int level = 0; level < _levelButtons.Count; level++) {
            Image[] starsImg = _levelButtons[level].GetComponentsInChildren<Image>();
            int starsCount = _loadedGameData.GetLevelStatistic(level);

            Debug.Log($"level: {level} Count: {starsImg.Length}");

            for (int img = 1; img < starsImg.Length; img++) {
                if (img <= starsCount)
                    starsImg[img].enabled = true;
                else
                    starsImg[img].enabled = false;
            }
        }
    }

    public void HideSelectLevelMenu() {
        ShowPauseMenu();

        _isSelectLevelPanelActive = false;
        _selectLevelPanel.SetActive(false);
    }

    public void HideAllPanels() {
        HideSelectLevelMenu();
        HidePauseMenu();
        HideLevelPanel();
    }

    public void HideLevelPanel() {
        _showLevelPanel.SetActive(false);
        _showLevelPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Level " +
            (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }

    public void ShowLevelPanel() {
        StartCoroutine(ShowLevelPanelCoroutine());
    }

    IEnumerator ShowLevelPanelCoroutine() {
        yield return new WaitForSeconds(0.1f);
        _showLevelPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Level " +
            (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        _showLevelPanel.SetActive(true);

        yield return new WaitForSeconds(1.25f);
        _showLevelPanel.SetActive(false);
    }
}
