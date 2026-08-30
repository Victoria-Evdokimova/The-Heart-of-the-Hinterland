using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveLanguage(string language)
    {
        PlayerPrefs.SetString("Language", language);
        PlayerPrefs.Save();
    }

    public static string LoadLanguage()
    {
        return PlayerPrefs.GetString("Language", "EN");
    }

    public static void SaveFirstLaunch()
    {
        PlayerPrefs.SetInt("FirstLaunch", 1);
        PlayerPrefs.Save();
    }
    
    public static bool IsFirstLaunch()
    {
        return PlayerPrefs.GetInt("FirstLaunch", 0) == 0;
    }

    public static void SaveCurrentHealth(int health)
    {
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.Save();
    }

    public static int LoadCurrentHealth()
    {
        return PlayerPrefs.GetInt("Health", 5);
    }

    public static void SaveCurrentQuest(int currentQuest)
    {
        PlayerPrefs.SetInt("CurrentQuest", currentQuest);
        PlayerPrefs.Save();
    }

    public static int LoadCurrentQuest()
    {
        return PlayerPrefs.GetInt("CurrentQuest", 0);
    }

    public static void SaveQuestState(QuestState state)
    {
        PlayerPrefs.SetInt("QuestState", (int)state);
        PlayerPrefs.Save();
    }

    public static QuestState LoadQuestState()
    {
        return (QuestState)PlayerPrefs.GetInt("QuestState", 0);
    }

    public static void SaveCurrentScene(int sceneIndex)
    {
        PlayerPrefs.SetInt("SceneIndex", sceneIndex);
        PlayerPrefs.Save();
    }

    public static int LoadCurrentScene()
    {
        return PlayerPrefs.GetInt("SceneIndex", 1);
    }

    public static void SaveCheckpoint(int checkpointId)
    {
        PlayerPrefs.SetInt("CheckpointId",checkpointId);
        PlayerPrefs.Save();
    }

    public static int LoadCheckpoint()
    {
        return PlayerPrefs.GetInt("CheckpointId", 0);
    }

    public static void ResetGameData()
    {
        string language = LoadLanguage();

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        SaveLanguage(language);
        SaveFirstLaunch();
    }

    public static void DeleteAllSaves()
    {
        string language = LoadLanguage();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SaveLanguage(language);
    }
}