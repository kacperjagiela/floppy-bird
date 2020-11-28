using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Animator animator;
    public bool start = false;
    public bool failed = false;
    public int score = 0;
    public float playerSpeed = 2f;
    Text scoreText;
    Text gameStateText;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        gameStateText = GameObject.Find("GameStateText").GetComponent<Text>();
        if (instance != null && instance != this)
            Destroy(gameObject);    // Ensures that there aren't multiple Singletons

        instance = this;
    }

    void Update()
    {
        scoreText.text = score.ToString();

        if (start)
        {
            scoreText.transform.localScale = new Vector3(1, 1, 1);
            gameStateText.transform.localScale = new Vector3(0, 0, 0);
        }
        else if (!start && !failed)
        {
            gameStateText.text = "Press Space to start...";
        }
        else if (!start && failed)
        {
            animator.SetBool("Failed", true);
            gameStateText.transform.localScale = new Vector3(1, 1, 1);
            gameStateText.text = "Failed. Press Space to restart...";
        }
    }
}
