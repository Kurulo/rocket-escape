using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LeveStatistic", menuName = "Data/LeveStatistic", order = 1)]
public class LevelsCompleteStatistic : ScriptableObject {
    [SerializeField] private int[] _levelsStatistic;
    private const int _maxStarNumber = 3;

    private LevelsStatisticSaver _saver;

    private void OnEnable() {
        _saver = new LevelsStatisticSaver();

        if (_saver.LoadLevelsStatistic() != null)
            _levelsStatistic = _saver.LoadLevelsStatistic();

        ShowAllStatistic();
    }

    public void ShowAllStatistic() {
        for (int i = 0; i < _levelsStatistic.Length; i++) {
            Debug.Log($"Level {i}: {_levelsStatistic[i]}");
        }
    }

    public void ResetAllStatistic() {
        for (int i = 0; i < _levelsStatistic.Length; i++) {
            _levelsStatistic[i] = 0;
        }

        _saver.SaveLevelsStatistic(_levelsStatistic);
    }

    public void ChangeLevelStatistic(int key, int value) {
        if (_levelsStatistic[key] <= _maxStarNumber) {
            _levelsStatistic[key] = value;
        }

        _saver.SaveLevelsStatistic(_levelsStatistic);
    }

    public int GetLevelStatistic(int key) {
        return _levelsStatistic[key];
    }
}
