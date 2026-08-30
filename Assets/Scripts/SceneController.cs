using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void RestartScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    
    public static int ShowCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public static void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex += 1;
        SaveManager.SaveCheckpoint(0);
        SaveManager.SaveCurrentScene(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadPreviousScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex -= 1;
        SaveManager.SaveCurrentScene(sceneIndex);
        SceneManager.LoadScene(sceneIndex);

    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadGame()
    {
        int sceneIndex = SaveManager.LoadCurrentScene();
        SceneManager.LoadScene(sceneIndex);
    }


    public static void ExitGame()
    {
        Application.Quit();
        Debug.Log("Игра завершена, Вы вышли из игры.");

    }

}
