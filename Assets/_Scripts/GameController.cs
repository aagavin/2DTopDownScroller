using UnityEngine;
using System.Collections;
// reference to the UI namespace
using UnityEngine.UI;


/*
 * Aaron Fernandes
 * 300773526
 *  Last Modified: Aaron Fernandes
 *  Date last Modified: 10/22/2016
 *  Program description: A 2D top down scroller using the Unity Game Engine
 *  Revision History: See https://github.com/aagavin/2DTopDownScroller
 */
public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount;

    [Header("Game Objects")]
    public GameObject tank;

    [Header("UI Objects")]
    public Text LivesLabel;
    public Text ScoreLabel;

    // PRIVATE INSTANCE VARIABLES
    private int _lives;
    private int _score;


    /// <summary>
    /// Public propities
    /// </summary>
    /// 
    //Lives 
    public int Lives {
        get {
            return this._lives;
        }
        set {
            this._lives = value;
            this.LivesLabel.text = "Lives: " + this._lives;
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
            this.ScoreLabel.text = "Score: " +this._score;
        }
    }


    // Use this for initialization
    void Start () {
        this._init();
		this._GenerateTanks ();
	}

    // Update is called once per frame
    void Update() { }

    private void _init()
    {
        this._lives = 10;
        this._score = 0;
    }

	// generate Tanks
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}
}
