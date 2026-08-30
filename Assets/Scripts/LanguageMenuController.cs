using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LanguageMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text loadText;
    [SerializeField] private TMP_Text playText;
    [SerializeField] private TMP_Text exitText;
    [SerializeField] private TMP_Text settingsText;
    [SerializeField] private TMP_Text backText;

    [SerializeField] private Button englishButton;
    [SerializeField] private Button russuianButton;

    private string currentLanguage;

    private void Start()
    {
        currentLanguage = SaveManager.LoadLanguage();
        UpdateTexts();
    }

    public void EnglishLanguage()
    {
        currentLanguage = "EN";
        SaveManager.SaveLanguage(currentLanguage);
        UpdateTexts();
    }

    public void RussianLanguage()
    {
        currentLanguage = "RU";
        SaveManager.SaveLanguage(currentLanguage);
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        if (currentLanguage == "RU")
        {
            backText.text = "Назад в меню";
            playText.text = "Начать игру";
            exitText.text = "Выйти из игры";
            settingsText.text = "Настройки";
            loadText.text = "Продолжить";

            englishButton.gameObject.SetActive(true);
            russuianButton.gameObject.SetActive(false);
        }
        else if (currentLanguage == "EN")
        {
            backText.text = "Back to menu";
            playText.text = "Start game";
            exitText.text = "Exit game";
            settingsText.text = "Settings";
            loadText.text = "Continue";

            englishButton.gameObject.SetActive(false);
            russuianButton.gameObject.SetActive(true);
        }
    }
}
