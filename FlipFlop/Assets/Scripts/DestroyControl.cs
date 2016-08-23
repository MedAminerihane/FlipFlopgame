using UnityEngine;
using System.Collections;

public class DestroyControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {


		if (collision.gameObject.tag == "obstacle"||collision.gameObject.tag == "coin") {
			Destroy (collision.gameObject);
		
		
		}
	}
}
