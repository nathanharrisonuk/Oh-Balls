using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    public GameObject explosion;
    public PlayerController playerControllerScript;
    public GameManager gameManagerScript;



    public int lifeValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player Ball").GetComponent<PlayerController>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            

            
            Destroy(gameObject);
            playerControllerScript.UpdateLife(-lifeValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);

            
        }
    }

    

}
