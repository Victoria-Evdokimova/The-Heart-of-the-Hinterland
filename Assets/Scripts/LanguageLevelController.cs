using UnityEngine;
using TMPro;

public class LanguageLevelController : MonoBehaviour
{
    [SerializeField] private TMP_Text pauseText;
    [SerializeField] private TMP_Text goToMenuText;
    [SerializeField] private TMP_Text continueGameText;

    private string currentLanguage;
    private void Start()
    {
        currentLanguage = SaveManager.LoadLanguage();
        UpdateTexts();
    }
    private void UpdateTexts()
    {
        if (currentLanguage == "RU")
        {
            pauseText.text = "Пауза";
            goToMenuText.text = "Перейти в главное меню";
            continueGameText.text = "Продолжить игру";
        }
        else if (currentLanguage == "EN")
        {
            pauseText.text = "Pause";
            goToMenuText.text = "Go back to the menu";
            continueGameText.text = "Continue the game";
        }
    }
}
