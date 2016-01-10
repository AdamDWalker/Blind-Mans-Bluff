using UnityEngine;
using System.Collections;

public class chooseTexture : MonoBehaviour {

	public Sprite[] Sprites = new Sprite[3];

	// Use this for initialization
	void Start () 
	{
		GetComponent<SpriteRenderer> ().sprite = Sprites [Random.Range (0, 3)];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
