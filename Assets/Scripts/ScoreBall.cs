using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBall : MonoBehaviour
{
    
    public GameObject scoreExplosion;
    public PlayerController playerBallScript;
    public int pointValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerBallScript = GameObject.Find("Player Ball").GetComponent<PlayerController>();
        
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
            Instantiate(scoreExplosion, transform.position, scoreExplosion.transform.rotation);
            
            playerBallScript.UpdateScore(pointValue);
        }
        
    }


    
}
