using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBall : MonoBehaviour
{

    public PlayerController playerControllerScript;
    public GameObject yellowFirework;
    public int lifeValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player Ball").GetComponent<PlayerController>();   
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
            Instantiate(yellowFirework, transform.position, yellowFirework.transform.rotation);
            playerControllerScript.UpdateLife(lifeValue);

        }
    }
}
