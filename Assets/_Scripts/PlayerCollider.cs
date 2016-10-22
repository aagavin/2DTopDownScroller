using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
    // get a reference to the gameController
    public ScoreBoard scoreBoardController;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = this.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// OnTrigger for when player hits Enemy
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.scoreBoardController.Lives -= 1;
            this.audioSource.Play();
        }
    }
}
