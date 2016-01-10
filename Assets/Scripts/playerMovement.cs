using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed = 5;
	public float jumpHeight = 25;
	public bool isGrounded = false;
	public Transform playerPrefab;
	/*public GUIText scoreText;
	public static int score;
	private int scoreValue;*/
	//variables that will set the death count for when the player dies

	public void Start ()
	{
		//scoreText.text = "Deaths: " + score;
	}

	void Update()
	{
		//scoreText.text = "Deaths: " + score;

		movement ();

		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;

		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;

		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp (transform.position.y, topBorder, bottomBorder),
			transform.position.z);
	}

	void movement()
	{
		// Move Right
		if (Input.GetKey (KeyCode.D))
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}

		// Move Left
		if (Input.GetKey (KeyCode.A))
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}

		// Jumping
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector2.up * speed * Time.deltaTime);
		}

	}

	public void OnTriggerEnter2D (Collider2D hit)
	{
		if (hit.gameObject.tag == "spikes")
		{
			Debug.Log ("detected spikes");
			Application.LoadLevel(Application.loadedLevel);
			//score++;
		}
		else
		if (hit.gameObject.tag == "checkpoint")
		{
			Debug.Log ("detected checkpoint");
			if (Application.loadedLevel < Application.levelCount)
				Application.LoadLevel (Application.loadedLevel + 1);
		} 

	}

}
