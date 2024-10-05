using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance; 
    public static AudioManager Instance { get { return instance; } }
    
    [SerializeField] private AudioClip BackgroundMusic;
    [SerializeField] private AudioClip score;
    [SerializeField] private AudioClip gameOver;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource fxSource;

    private void Awake()
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

        musicSource.clip = BackgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayScore()
    {
        fxSource.clip = score;
        fxSource.Play();
    }

    public void PlayGameOver()
    {
        fxSource.clip = gameOver;
        fxSource.Play();
    }
}
