using UnityEngine;
using System.Collections;

public class CameraFolow : MonoBehaviour {
	public GameObject player;
	public Touch touch;
	GameObject particle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;
		pos.x=player.transform.position.x +6;
		transform.position = pos;



	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "bg") {
		
			Vector2 pos1= coll.gameObject.transform.position;
			pos1.x += 62.76f;
		
			coll.gameObject.transform.position=pos1;
		}
	
	}

}
