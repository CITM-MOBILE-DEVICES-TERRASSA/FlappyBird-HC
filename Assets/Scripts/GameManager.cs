using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;

    public bool isGameOver; 

    private static GameManager instance; 
    public static GameManager Instance { get { return instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        //iniciamos el juego, si no existe GameManager aun, le asignamos este mismo
        if(instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject); //nos aseguramos de que solo haya 1 instancia
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame(); 
        }
    }

    public void GameOver()
    {
        isGameOver = true; 
        gameOverText.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
