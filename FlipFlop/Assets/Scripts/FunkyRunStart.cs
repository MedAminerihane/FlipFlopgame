using UnityEngine;
using System.Collections;

public class FunkyRunStart : MonoBehaviour {
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.position = new Vector2 (rb.position.x + 0.05f, Mathf.Clamp (rb.position.y, -4f, 4.7f));
	}
}
