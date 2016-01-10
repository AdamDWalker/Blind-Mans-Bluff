using UnityEngine;
using System.Collections;

public class displayBlock : MonoBehaviour {

	public Sprite[] Sprites = new Sprite[3];

	// Use this for initialization
	void Start () 
	{
		var gameBlock = gameObject;
		GetComponent<SpriteRenderer> ().sprite = Sprites [Random.Range (0, 3)];
		gameBlock.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, -254f);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}


	public void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag == "Bullet") 
		{
			showBlock();
			Destroy(hit.gameObject);
		}
	}

	// Take the invisible block and return the opacity to full thus revealing it
	public void showBlock()
	{
		var gameBlock = gameObject;
		gameBlock.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
	}
}
