using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public Button button;
    private GameManager gameManagerScript;
    private SpawnManager spawnManagerScript;
    public int difficultyLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDiffculty);
    }

    // Update is called once per frame
    void SetDiffculty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManagerScript.StartGame(difficultyLevel);
    }
}
