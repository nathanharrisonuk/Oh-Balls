using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public float jumpSpeed;

    private Rigidbody playerRb;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    private SpawnManager spawnManagerScript;
    private GameManager gameManagerScript;

    private AudioSource ballAudio;
    public AudioClip scoreBlip;
    public AudioClip enemyBoom;
    public AudioClip healthBlip;

    int score = 0;
    int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        ballAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
      
        gameManagerScript.isGameActive = true;
        
    }





    // Update is called once per frame
    void Update()
    {

        MovePlayer();

        

    }




    void MovePlayer()
    {
        if (gameManagerScript.isGameActive)
        {
            // get the input via arrow keys and assign to variables
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            // move the ball using phsyics via AddForce from RigidBody
            playerRb.AddForce(Vector3.forward * speed * verticalInput);
            playerRb.AddForce(Vector3.right * speed * horizontalInput);

            // make the ball jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

            }
            // the player falling off triggers game over
            else if (transform.position.y < -5)
            {
                Debug.Log("Game Over!");
                gameManagerScript.GameOver();
                // spawnManagerScript.CancelSpawn();
            }
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gameManagerScript.isGameActive)
        {
            ballAudio.PlayOneShot(enemyBoom, 1.0f);
            Debug.Log("Player has collided with enemy!");
        
        }
        else if(collision.gameObject.CompareTag("Health") && gameManagerScript.isGameActive)
        {
            ballAudio.PlayOneShot(healthBlip, 1.0f);
            Debug.Log("Player has gained a life!");
        }
        else if (collision.gameObject.CompareTag("Score") && gameManagerScript.isGameActive)
        {
            ballAudio.PlayOneShot(scoreBlip, 1.0f);
            Debug.Log("Play has gained a point!");
        }

    }


    public void UpdateScore(int scoreToAdd)
    {
        

       if (gameManagerScript.isGameActive)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }
        
    }


    public void UpdateLife(int lifeUpDown)
    {
        lives += lifeUpDown;
        if (lives < 0)
        {
            lives = 0;
        }

        lifeText.text = ("Lives Remaining: " + lives);

        if (lives == 0)
        {
            lives = 0;
            gameManagerScript.GameOver();
            Debug.Log("Game Over!");
            
        }
    }



}
