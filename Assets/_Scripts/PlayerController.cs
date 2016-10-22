using UnityEngine;
using System.Collections;


/*
 * Aaron Fernandes
 * 300773526
 *  Last Modified: Aaron Fernandes
 *  Date last Modified: 10/22/2016
 *  Program description: A 2D top down scroller using the Unity Game Engine
 *  Revision History: See https://github.com/aagavin/2DTopDownScroller
 */

public class PlayerController : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
    // get a reference to the gameController
    public GameController gameController;
    //public float speed;
    public Boundary boundary;
	// get a reference to the camera to make mouse input work
	public Camera camera;


    // PRIVATE INSTANCE VARIABLES
    private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this._CheckInput ();
	}

	private void _CheckInput() {
		this._newPosition = gameObject.GetComponent<Transform> ().position; // current position

		/* movement by keyboard
		if (Input.GetAxis ("Horizontal") > 0) {
			this._newPosition.x += this.speed; // add move value to current position
		}
	
		
		if (Input.GetAxis ("Horizontal") < 0) {
			this._newPosition.x -= this.speed; // subtract move value to current position
		}
		*/

		// movement by mouse
		Vector2 mousePosition = Input.mousePosition;
		this._newPosition.x = this.camera.ScreenToWorldPoint (mousePosition).x;

		this._BoundaryCheck ();

		gameObject.GetComponent<Transform>().position = this._newPosition;
	}


    /*
     ******* Private Methods
     */

    /// <summary>
    /// Boundary Check
    /// </summary>
    private void _BoundaryCheck() {
		if (this._newPosition.x < this.boundary.xMin) {
			this._newPosition.x = this.boundary.xMin;
		}

		if (this._newPosition.x > this.boundary.xMax) {
			this._newPosition.x = this.boundary.xMax;
		}
	}


    /// <summary>
    /// OnTrigger for when player hits Enemy
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")){
            this.gameController.Lives -= 1;

        }
    }
}
