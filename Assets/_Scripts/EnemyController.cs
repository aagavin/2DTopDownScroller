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

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour
{
    // PUBLIC INSTANCE VARIABLES
    public Speed speed;
    public Boundary boundary;
    public ScoreBoard scoreBoardController;

    // PRIVATE INSTANCE VARIABLES
    private float _CurrentSpeed;
    private float _CurrentDrift;

    // Use this for initialization
    void Start()
    {
        this._Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.y -= this._CurrentSpeed;
        gameObject.GetComponent<Transform>().position = currentPosition;

        // Check bottom boundary
        if (currentPosition.y <= boundary.yMin)
        {
            this._Reset();
        }
    }

    // resets the gameObject
    private void _Reset(bool playerhit = false)
    {
        this._CurrentSpeed = Random.Range(speed.minSpeed, speed.maxSpeed);
        Vector2 resetPosition = new Vector2(Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
        gameObject.GetComponent<Transform>().position = resetPosition;
        if (playerhit == false)
        {
            scoreBoardController.Score += 10;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("I'm bad, hit player");
            this._Reset(true);
        }
    }
}