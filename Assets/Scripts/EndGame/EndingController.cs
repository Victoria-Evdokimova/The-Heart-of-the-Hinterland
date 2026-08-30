using TMPro;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    private string currentLanguage;
    [SerializeField] private GameObject endingCanvas;
    [SerializeField] private GameObject generalCanvas;
    [SerializeField] private TMP_Text endingText;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource endingMusic;
    [SerializeField] private AudioClip playerDiedMusic;
    [SerializeField] private AudioClip bossDiedMusic;
    [SerializeField] private AudioClip peacefulEndingMusic;

    private void Start()
    {
        currentLanguage = SaveManager.LoadLanguage();
    }
    public enum EndingType
    {
        PlayerDied,
        BossDied,
        PeacefulEnding
    }

    public void ShowEnding(EndingType ending)
    {
        endingCanvas.SetActive(true);
        generalCanvas.SetActive(false);
        backgroundMusic.Stop();

        switch (ending)
        {
            case EndingType.PlayerDied:
                endingMusic.clip = playerDiedMusic;
                PLayerDied();
                break;

            case EndingType.BossDied:
                endingMusic.clip = bossDiedMusic;
                BossDied();
                break;

            case EndingType.PeacefulEnding:
                endingMusic.clip = peacefulEndingMusic;
                PeacefulEnding();
                break;
        }
        endingMusic.Play();
        Time.timeScale = 0f;
    }

    private void PLayerDied()
    {
        if (currentLanguage == "RU")
        {
            endingText.text = "К великому сожалению, Джек Вуд погиб, попытавшись навсегда избавиться от Уильяма Джонсона. " +
                "Уильям остался жить в Тёмном Царстве, ещё больше поддавшись влиянию тёмных сил. Зло, наступающее на American Fork, возросло в огромное количество раз. " +
                "Деревня продолжила разрушаться, а её жители не переставали дрожать от ужаса и молиться Господу, чтобы зло поскорее оставило их... " +
                "К великому сожалению, спустя некоторое время от прекрасной деревни не осталось ничего, а некоторые её жители погибли... " +
                "Кому-то из них удалось сбежать и сохранить жизнь, но больше никогда не будет той чудесной деревни American Fork, которая многие десятилетия радовала её жителей... " +
                "Мне бесконечно жаль Джека, но он поступил неправильно со своей стороны. Нужно выбирать путь света и добра, а насилие никогда не приводит ни к чему хорошему!";
        }
        else if (currentLanguage == "EN")
        {
            endingText.text = "To my great sorrow, Jack Wood perished, tryin’ to be rid of William Johnson once and for all. William stayed on in the Dark Kingdom, " +
                "fallin’ ever deeper under the sway of dark forces. The evil bearin’ down on American Fork swelled a hundredfold. The town kept crumblin’, " +
                "and its folk never stopped tremblin’ from the terror and prayin’ to the Lord for the evil to soon depart… To my great sorrow, after a spell, nothin’ " +
                "remained of that fine town, and some of its folk perished… A few of ’em managed to flee and keep their lives, but there’ll never again be that wondrous " +
                "town of American Fork that brought joy to its people for many a decade… I’m powerful sorry for Jack, but he done wrong on his part. " +
                "A body’s got to choose the path of light and goodness — violence never leads to nothin’ good!";
        }
    }

    private void BossDied()
    {
        if (currentLanguage == "RU")
        {
            endingText.text = "К великому сожалению, Джек выбрал путь зла и жестокости и убил Уильяма Джонсона - молодого парнишку, который бы мог прожить ещё много лет... " +
                "Джек Вуд вернулся в American Fork один. Жители деревни смотрели на Джека холодно, сторонились его и говорили, что он жестокий человек. " +
                "Это правда. Мир в деревне был восстановлен, но жители деревни так и не простили парня, поэтому Джеку пришлось навсегда покинуть деревню... " +
                "Я не понимаю, зачем Джек убил Уильяма. Ведь любой конфликт можно решить разговором! Убийство и жестокость - это ужасно, и нужно всегда выбирать добро и свет!";
        }
        else if (currentLanguage == "EN")
        {
            endingText.text = "To my great sorrow, Jack chose the path of evil and cruelty and killed William Johnson — a young fella who could have lived many more years… " +
                "Jack Wood returned to American Fork alone. The townsfolk looked at Jack cold, shunned him, and said he was a cruel man. And that’s the truth. " +
                "Peace was restored to the town, but the folks never forgave the boy, so Jack had to leave the town for good… I don’t understand why Jack killed William. " +
                "Any quarrel can be settled with words! Murder and cruelty are awful things — a man ought always to choose goodness and light.";
        }
    }

    private void PeacefulEnding()
    {
        if (currentLanguage == "RU")
        {
            //endingText.text = "К счастью, Джеку удалось смягчить сердце Уильяма. Уильям понял, что был неправ, и ощутил сильную вину перед жителями деревни. " +
            //    "Джек простил Уильяму его ошибку, потому что увидел искреннее раскаяние парня. Уильям почувствовал, что скучает по деревне, Стиву, Джону, Кэтрин и Сандре. " +
            //    "Джек Вуд и Уильям Джонсон вернулись в American Fork вместе, и жители деревни с радостью встретили их обоих и простили Уильяму его поступок. " +
            //    "Теперь они живут долго и счастливо, а Уильям работает над собой и старается стать ещё лучше. Джек сделал правильный выбор. " +
            //    "Любой конфликт можно решить словами, а не насилием!";

            endingText.text = "К счастью, Джеку удалось наставить Уильяма на путь света. " +
               "Джек простил Уильяму его ошибку, потому что увидел, что Уильям действительно понял весь ужас этой ситуации. Уильям почувствовал, что скучает по деревне, " +
               "Стиву, Джону, Кэтрин и Сандре и ощутил сильную вину перед жителями деревни. " +
               "Джек Вуд и Уильям Джонсон вернулись в American Fork вместе, и жители деревни с радостью встретили их обоих и простили Уильяму его поступок, увидев, " +
               "под какое сильное влияние зла попал бедный парнишка. " +
               "Теперь они живут долго и счастливо, а Уильям работает над собой и старается полностью изгнать дьявола из себя. Джек сделал правильный выбор. " +
               "Любой конфликт можно решить словами, а не насилием!";
        }
        else if (currentLanguage == "EN")
        {
            //endingText.text = "Fortunately, Jack managed to soften William’s heart. William came to see he’d been in the wrong, and he felt a heavy guilt before the town folk. " +
            //    "Jack forgave William his mistake, for he saw honest remorse in the young man. William found himself longing for the town — for Steve, John, Katherine, and Sandra. " +
            //    "Jack Wood and William Johnson came back to American Fork together, and the townsfolk welcomed them both with gladness and forgave William his doings. " +
            //    "Now they live long and happy, and William works on himself, striving to become an even better man. Jack made the right choice. " +
            //    "Any quarrel can be settled with words, not with lead!";

            endingText.text = "Luckily, Jack managed to set William straight. Jack forgave William his wrongdoings, for he saw that William had truly grasped the full terror of " +
                "what he'd done. William felt a longing for the town — for Steve, John, Katherine, and Sandra — and a heavy guilt weighed on him for what he'd put the townsfolk " +
                "through. Jack Wood and William Johnson came back to American Fork together, and the settlers welcomed them both with open arms, forgiving William once they saw " +
                "how badly the poor young feller had been twisted by evil. Now they're all living long and happy, and William is working on himself, striving to drive the devil " +
                "clean out of his soul. Jack made the right call. Any feud can be settled with words, not with violence!";
        }
    }
}