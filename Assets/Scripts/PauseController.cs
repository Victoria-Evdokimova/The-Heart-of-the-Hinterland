using Cainos.InteractivePixelWater;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject tutorialButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject tutorialMenu;


    private bool isPaused;
    private bool isTutorialOpened;


    private void Start()
    {
        isTutorialOpened = SaveManager.IsFirstLaunch();
        isPaused = !isTutorialOpened;
        pauseMenu.SetActive(false);
        tutorialMenu.SetActive(isTutorialOpened);
        pauseButton.SetActive(!isTutorialOpened);
        tutorialButton.SetActive(!isTutorialOpened);

        Time.timeScale = isTutorialOpened ? 0f : 1f;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isTutorialOpened)
            {
                CloseTurorial();
            }
            else if (isPaused)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }
    }

    public void OpenPause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        tutorialMenu.SetActive(false);
        pauseButton.SetActive(false);
        tutorialButton.SetActive(false);
    }

    public void ClosePause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        pauseButton.SetActive(true);
        tutorialButton.SetActive(true);
    }

    public void OpenTutorial()
    {
        isTutorialOpened = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(false);
        tutorialMenu.SetActive(true);
        pauseButton.SetActive(false);
        tutorialButton.SetActive(false);
    }

    public void CloseTurorial()
    {
        isTutorialOpened = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        pauseButton.SetActive(true);
        tutorialButton.SetActive(true);
    }
    private void OnDestroy()
    {
        Time.timeScale = 1f;
        SaveManager.SaveFirstLaunch();
    }
}