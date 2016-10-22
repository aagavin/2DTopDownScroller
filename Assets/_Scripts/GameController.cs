using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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


    // Use this for initialization
    void Start () {
        this._init();
        this._GenerateTanks();
	}

    // Update is called once per frame
    void Update() { }

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }


    /// <summary>
    ///     
    /// </summary>
    private void _init(){}

	// generate Tanks
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}


    /// <summary>
    /// Click handler for when a button is clicked
    /// </summary>
    public void RestartButton_Clicked()
    {
        SceneManager.LoadScene("Main");
    }
}
