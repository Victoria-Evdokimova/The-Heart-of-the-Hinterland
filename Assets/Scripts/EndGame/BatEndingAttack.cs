using UnityEngine;
using Cainos.PixelArtMonster_Dungeon;

public class BatEndingAttack : MonoBehaviour
{
    [SerializeField] private float riseHeight = 2f;

    private MonsterFlyingController flyingController;
    private Transform player;
    private Transform damage;

    private bool isRising;
    private Vector3 riseTarget;

    private void Awake()
    {
        flyingController = GetComponent<MonsterFlyingController>();

        damage = transform.Find("Damage");
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        if (isRising)
        {
            Vector2 dir = (riseTarget - transform.position).normalized;

            flyingController.inputMove = dir;

            if (Vector2.Distance(transform.position, riseTarget) < 0.2f)
            {
                isRising = false;
            }
        }
        else
        {
            Vector2 dir = (player.position - transform.position).normalized;

            flyingController.inputMove = dir;

            FlipDamage(dir.x);
        }
    }

    private void FlipDamage(float directionX)
    {
        if (damage == null)
            return;

        if (directionX > 0.01f)
        {
            damage.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (directionX < -0.01f)
        {
            damage.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void AttackPlayer()
    {
        flyingController.inputAttack = true;

        riseTarget = transform.position + Vector3.up * riseHeight;
        isRising = true;
    }
}