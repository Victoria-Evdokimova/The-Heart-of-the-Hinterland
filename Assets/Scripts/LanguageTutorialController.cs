using TMPro;
using UnityEngine;

public class LanguageTutorialController : MonoBehaviour
{
    [SerializeField] private TMP_Text keyTutorialText;
    [SerializeField] private TMP_Text keyAText;
    [SerializeField] private TMP_Text keyDText;
    [SerializeField] private TMP_Text keyShiftText;
    [SerializeField] private TMP_Text keyControlText;
    [SerializeField] private TMP_Text keyEText;
    [SerializeField] private TMP_Text keyQText;
    [SerializeField] private TMP_Text keyEscapeText;
    [SerializeField] private TMP_Text keySpaceText;
    [SerializeField] private TMP_Text keyZText;
    [SerializeField] private TMP_Text keyCText;
    [SerializeField] private TMP_Text keyMouseLeftText;
    [SerializeField] private TMP_Text keyMouseRightText;
    [SerializeField] private TMP_Text titleText;

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
            keyAText.text = "Движение влево";
            keyDText.text = "Движение вправо";
            keyShiftText.text = "Бег";
            keyControlText.text = "Кувырок";
            keyEText.text = "Диалог с NPC";
            keyQText.text = "Открытие сундука";
            keyEscapeText.text = "Пауза /\nОтмена паузы";
            keySpaceText.text = "Прыжок";
            keyZText.text = "Ползти на четвереньках";
            keyCText.text = "Встать на колено /\nКрасться";
            keyMouseLeftText.text = "Атака";
            keyMouseRightText.text = "Повернуть голову";
            titleText.text = "Инструкция по управлению персонажем\nи возможным действиям";
            keyTutorialText.text = "Инструкция";

        }
        else if (currentLanguage == "EN")
        {
            keyAText.text = "Moving left";
            keyDText.text = "Moving right";
            keyShiftText.text = "To run";
            keyControlText.text = "To roll";
            keyEText.text = "Dialogue with NPC";
            keyQText.text = "Chest opening";
            keyEscapeText.text = "Pause /\nResume";
            keySpaceText.text = "Jumping";
            keyZText.text = "To crawl on hands and knees";
            keyCText.text = "To go down on one \nknee / To creep";
            keyMouseLeftText.text = "Attack";
            keyMouseRightText.text = "To turn head";
            titleText.text = "Instructions on how to control character\nand actions's possible to take";
            keyTutorialText.text = "Tutorial";
        }
    }


}
