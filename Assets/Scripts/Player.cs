using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce = 350f;
    private bool isDead;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    // Referencia al adaptador de entrada
    private IPlayerInput playerInput;

    // Variable para elegir el método de entrada (puede seleccionarse desde el Inspector)
    [SerializeField] private bool useKeyboard = true;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        // Selecciona el método de entrada según la opción configurada en el Inspector
        if (useKeyboard)
        {
            playerInput = new KeyboardInput();
        }
        else
        {
            playerInput = new ControllerInput();
        }
    }

    void Update()
    {
        // Detecta la entrada del jugador según el adaptador seleccionado
        if (playerInput.GetFlapInput() && !isDead)
        {
            Flap();
        }

        // Rotación del jugador basada en su velocidad vertical
        float angle = Mathf.Lerp(-90, 45, (playerRb.velocity.y + 10) / 20);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Flap()
    {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(Vector2.up * upForce);
        playerAnimator.SetTrigger("Flap");
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
        GameManager.Instance.GameOver();
    }

    // Método opcional para cambiar el tipo de entrada en tiempo de ejecución (por ejemplo, desde el menú de opciones)
    public void SetInputMethod(bool useKeyboard)
    {
        if (useKeyboard)
        {
            playerInput = new KeyboardInput();
        }
        else
        {
            playerInput = new ControllerInput();
        }
    }
}