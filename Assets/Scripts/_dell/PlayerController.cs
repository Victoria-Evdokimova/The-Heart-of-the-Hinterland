using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5; // Скорость обычной ходьбы
    [SerializeField] private float runSpeed = 10; // Скорость бега
    [SerializeField] private float jumpPower = 5; // Сила прыжка

    private float speedPower; // Текущая скорость движения (ходьба или бег)

    private float moveInput; // Направление движения: -1 = влево, 0 = стоим, 1 = вправо

    private Rigidbody2D rigidBody2D; // Ссылка на Rigidbody2D игрока

    private bool isGround; // Стоит ли игрок на земле
    private bool isJumpPressed; // Нужно ли выполнить прыжок в следующем FixedUpdate
    private bool isJumping; // Удерживается ли сейчас кнопка прыжка

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D с этого объекта
    }

    private void Start()
    {
        speedPower = walkSpeed; // По умолчанию игрок ходит
    }

    private void Update()
    {
        if (Keyboard.current.aKey.isPressed) // Если нажата клавиша A
        {
            moveInput = -1f; // Движение влево
        }
        else if (Keyboard.current.dKey.isPressed) // Если нажата клавиша D
        {
            moveInput = 1f; // Движение вправо
        }
        else // Если ничего не нажато
        {
            moveInput = 0f; // Игрок стоит на месте
        }

        if (Keyboard.current.shiftKey.wasPressedThisFrame) // Если клавиша Shift была нажата
        {
            speedPower = runSpeed; // Переключаемся на скорость бега
        }

        if (Keyboard.current.shiftKey.wasReleasedThisFrame) // Если клавиша Shift отпущена
        {
            speedPower = walkSpeed; // Возвращаем обычную скорость
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGround) // Если нажали Space и игрок стоит на земле
        {
            isJumpPressed = true; // Запоминаем, что нужно выполнить прыжок
            isJumping = true; // Запоминаем, что кнопка прыжка удерживается
        }

        if (Keyboard.current.spaceKey.wasReleasedThisFrame) // Если Space отпустили
        {
            isJumping = false; // Перестаём считать, что кнопка удерживается
        }
    }

    private void FixedUpdate()
    {
        rigidBody2D.linearVelocity = new Vector2( // Устанавливаем скорость движения по горизонтали
            moveInput * speedPower,
            rigidBody2D.linearVelocity.y);

        if (isJumpPressed) // Если был запрошен прыжок
        {
            rigidBody2D.linearVelocity = new Vector2( // Придаём игроку скорость вверх
                rigidBody2D.linearVelocity.x,
                jumpPower);

            isJumpPressed = false; // Сбрасываем запрос на прыжок
            isGround = false; // Игрок больше не находится на земле
        }

        if (!isGround && isJumping && rigidBody2D.linearVelocity.y > 0f) // Если игрок летит вверх и удерживает кнопку прыжка
        {
            rigidBody2D.gravityScale = 0.5f; // Уменьшаем гравитацию, чтобы прыжок был выше
        }
        else
        {
            rigidBody2D.gravityScale = 1.5f; // Возвращаем обычную гравитацию
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            isGround = true; // Игрок снова стоит на земле
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            isGround = false; // Игрок находится в воздухе
    }
}