using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;

public class LevelsStatisticSaver {
    private string filePath => Path.Combine(Application.persistentDataPath, "levelsStatistic.json");

    public void SaveLevelsStatistic(int[] levelsStatstic) {
        Debug.Log(filePath);
        string json = JsonConvert.SerializeObject(levelsStatstic);

        if (!File.Exists(filePath)) {
            File.WriteAllText(filePath, "{}");
        }

        File.WriteAllText(filePath, json);
    }

    public int[] LoadLevelsStatistic() {
        if (File.Exists(filePath)) {
            string json = File.ReadAllText(filePath);

            try {
                int[] levelsStatistic = JsonConvert.DeserializeObject<int[]>(json);
                if (levelsStatistic == null) {
                    Debug.LogError("Failed to deserialize JSON data.");
                } else {
                    return levelsStatistic;
                }
            }
            catch (JsonException e) {
                Debug.LogError($"Error deserializing JSON: {e.Message}");
                return null;
            }
        }

        return null;
    }
}
