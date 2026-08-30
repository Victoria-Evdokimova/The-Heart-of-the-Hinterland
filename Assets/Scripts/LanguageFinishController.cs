using TMPro;
using UnityEngine;

public class LanguageFinishController : MonoBehaviour
{
    [SerializeField] private TMP_Text aboutButtonText;
    [SerializeField] private TMP_Text goToMenuText;
    [SerializeField] private TMP_Text aboutAuthorText;

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
            aboutButtonText.text = "О разработчике";
            goToMenuText.text = "Главное меню";
            aboutAuthorText.text = "Игру разработала ученица Лицея Информационных Технологий №1533 Виктория Олеговна Евдокимова, группа 10.3. Я очень надеюсь, что моя игра понравилась и принесла Вам хорошее настроение! Большое спасибо за прохождение!";
        }
        else if (currentLanguage == "EN")
        {
            aboutButtonText.text = "About developer";
            goToMenuText.text = "Main menu";
            aboutAuthorText.text = "This here game was crafted by Victoria Olegovna Evdokimova, a pupil of the Information Technologies Lyceum No. 1533, ridin’ with Posse 10.3. I sure do hope y’all took a shine to my game and it filled your spirits with good cheer! Much obliged for playin' it through!";
        }
    }
}
