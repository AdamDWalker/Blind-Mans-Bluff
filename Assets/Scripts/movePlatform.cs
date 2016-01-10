using UnityEngine;
using System.Collections;

public class movePlatform : MonoBehaviour {

	public float moveRate = 2.0f;

	private float moveWait;

	public float speed = 5f;

	private float direction = 1;

	// Use this for initialization
	void Start () 
	{
		moveWait = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveWait > 0)
		{
			moveWait -= Time.deltaTime;
		}

		if (moveWait <= 0 )
		{
			moveWait = moveRate;
			direction *= -1f;
		}

		transform.Translate(speed * direction * Time.deltaTime, 0, 0);
	}
}
