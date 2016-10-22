using UnityEngine;
using System.Collections;
// reference to the UI namespace
using UnityEngine.UI;
// scent management
using UnityEngine.SceneManagement;


/*
 * Aaron Fernandes
 * 300773526
 *  Last Modified: Aaron Fernandes
 *  Date last Modified: 10/22/2016
 *  Program description: A 2D top down scroller using the Unity Game Engine
 *  Revision History: See https://github.com/aagavin/2DTopDownScroller
 */

public class ScoreBoard : MonoBehaviour {


    // PRIVATE INSTANCE VARIABLES
    private int _lives;
    private int _score;
    private int _highScore=0;

    [Header("UI Objects")]
    public Text LivesLabel;
    public Text ScoreLabel;
    [Header("Game Over Objects")]
    public Text GameOverScoreLabel;
    public Text HighScoreLabel;


    /// <summary>
    /// Public propities
    /// </summary>
    /// 
    //Lives 
    public int Lives
    {
        get
        {
            return this._lives;
        }
        set
        {
            this._lives = value;
            this.LivesLabel.text = "Lives: " + this._lives;
            if (this._lives < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    //Score
    public int Score
    {
        get
        {
            return this._score;
        }

        set
        {
            this._score = value;
            this.ScoreLabel.text = "Score: " + this._score;
        }
    }

    /// <summary>
    /// Dont distroy
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        this._lives = 10;
        this._score = 0;
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            this.GameOverScoreLabel.text = "Score: " + this.Score;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
