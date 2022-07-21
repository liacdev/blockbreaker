using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Config parameters
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    
    // State variables
    [SerializeField] int currentScore = 0;

    private void Awake() 
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start() {
        DisplayScore();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = currentScore.ToString();
    }

}
