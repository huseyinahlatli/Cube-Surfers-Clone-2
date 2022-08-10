using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header ("UI")]
    public PlayerController player;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI tapToStart;
    public TextMeshProUGUI winGoldText;
    [HideInInspector]public int goldScore = 0;
    private GameState _currentGameState;
    public GameObject deathScreen;
    public GameObject winScreen;
    public GameObject backgroundMusic;
    public Animator animator;    
    
    [Header ("AudioClips")]
    public AudioClip startSound;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip fallSound;
    public AudioClip fireSound;
    public AudioClip gameOverSound;
    public AudioClip winSound;

    #region Singleton Class: GameManager
    
    public static GameManager gameManager;
    private void Awake()
    {
        if(gameManager == null)
            gameManager = this;
    }
    
    #endregion
    
    public enum GameState
    {
        Prepare,
        MainGame,
        FinishGame,
        GameOver
    }

    public GameState CurrentGameState
    {
        get
        {
            return _currentGameState;
        }

        set
        {
            switch (value)
            {
                case GameState.Prepare:
                    break;
                case GameState.MainGame:
                    AudioSource.PlayClipAtPoint(startSound, player.transform.position);
                    break;
                case GameState.FinishGame:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
            _currentGameState = value;
        }
    }

    public void Retry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Prepare:
                player.playerSpeed = 0f;
                winScreen.SetActive(false);
                deathScreen.SetActive(false);
                tapToStart.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    CurrentGameState = GameState.MainGame;
                }
                break;
           
            case GameState.MainGame:
                animator.SetBool("MainGame",true);
                tapToStart.enabled = false;
                player.playerSpeed = 4.5f;
                break;
           
            case GameState.FinishGame:
                Destroy(backgroundMusic);
                animator.SetBool("MainGame",false);
                animator.SetBool("FinishGame",true);
                winScreen.SetActive(true);
                break;
           
            case GameState.GameOver:
                Destroy(backgroundMusic);
                animator.SetBool("MainGame",false);
                animator.SetBool("Death",true);
                deathScreen.SetActive(true);
                break;
               
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
