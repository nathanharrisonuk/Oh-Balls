using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{

    //private ScoreBall scoreBallScript;
   // private EnemyBall enemyBallScript;
    //private HealthBall healthBallScript;
    private SpawnManager spawnManagerScript;
    public PlayerController playerControllerScript;
   
    public TextMeshProUGUI restartTitle;
    public Button restartButton;
    public GameObject mainTitles;
    private GameObject playerBall;
    private AudioSource mainAudio;


   
    

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        playerControllerScript = GameObject.Find("Player Ball").GetComponent<PlayerController>();
        playerBall = GameObject.Find("Player Ball");

        
        //scoreBallScript = GameObject.Find("Score Ball").GetComponent<ScoreBall>();
        //enemyBallScript = GameObject.Find("Enemy Ball").GetComponent<EnemyBall>();
        //healthBallScript = GameObject.Find("Health Ball").GetComponent<HealthBall>();

       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame(int difficulty)
    {
        isGameActive = true;
      
        mainTitles.gameObject.SetActive(false);
        spawnManagerScript.CommenceSpawn(difficulty);
        mainAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        mainAudio.Play();
     }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  

    public void GameOver()
    {
        restartTitle.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        
        mainAudio.Stop();
    }
}
