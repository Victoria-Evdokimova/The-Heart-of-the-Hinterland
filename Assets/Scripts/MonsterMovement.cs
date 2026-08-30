using Cainos.PixelArtMonster_Dungeon;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private GameObject topBoarder;
    private GameObject bottomBoarder;
    private GameObject leftBoarder;
    private GameObject rightBoarder;

    private Transform area;

    private Vector2 inputMove;

    private bool isRightDirection;
    private bool isTopDirection;
    [SerializeField] private bool canFly;
    [SerializeField] private bool canDamage;

    private MonsterController controller;
    private MonsterFlyingController flyingController;

    private void Awake()
    {
        controller = GetComponent<MonsterController>();
        flyingController = GetComponent<MonsterFlyingController>();

    }

    private void Start()
    {
        area = transform.parent;

        topBoarder = area.Find("TopBoarder")?.gameObject;
        bottomBoarder = area.Find("BottomBoarder")?.gameObject;
        leftBoarder = area.Find("LeftBoarder")?.gameObject;
        rightBoarder = area.Find("RightBoarder")?.gameObject;
    }


    private void Update()
    {
        if (isRightDirection)
        {
            inputMove.x = 1.0f;

            if (transform.position.x > rightBoarder.transform.position.x)
            {
                isRightDirection = false;

                if (canDamage)
                {
                    Transform damage = transform.Find("Damage");

                    if (damage != null)
                    {
                        damage.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    }
                }
            }
        }
        else
        {
            inputMove.x = -1.0f;

            if (transform.position.x < leftBoarder.transform.position.x)
            {
                isRightDirection = true;

                if (canDamage)
                {
                    Transform damage = transform.Find("Damage");

                    if (damage != null)
                    {
                        damage.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    }
                }
            }
        }

        if (canFly)
            if (isTopDirection)
            {
                inputMove.y = 1.0f;

                if (transform.position.y > topBoarder.transform.position.y)
                {
                    isTopDirection = false;
                }
            }

            else
            {
                inputMove.y = -1.0f;

                if (transform.position.y < bottomBoarder.transform.position.y)
                {
                    isTopDirection = true;
                }
            }

        if (controller) controller.inputMove = inputMove;
        if (flyingController) flyingController.inputMove = inputMove;
      
    }
}
