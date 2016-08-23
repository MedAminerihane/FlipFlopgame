using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class wood : MonoBehaviour {
	List<GameObject> prefabList = new List<GameObject>();

	public GameObject woodobj;
	public GameObject whitespike;
	public GameObject coin;
	public GameObject sorciere;
	public GameObject sorcPos;
	public static bool isEnabled;
	// public  static bool stt;

	// Use this for initialization
	void Start () {
	//	srb = sorciere.GetComponent<Rigidbody2D> ();
		prefabList.Add(woodobj);
		prefabList.Add(whitespike);
		//prefabList.Add (sorciere);
	//	stt=false;
		Invoke("spawn",2f);
		Invoke ("spawnSorc", 3f);

		}

	
	// Update is called once per frame
	void Update () {


	
	}
	void spawn(){

	
	//	if (!isEnabled) {
			int prefabIndex = UnityEngine.Random.Range (0, 2);

			float randomTime = Random.Range (0.6f, 1.0f);
			int rand = Random.Range (1, 3);
			Debug.Log (rand);

			if (rand == 1) {
				if (prefabIndex == 1) {
					transform.position = new Vector2 (transform.position.x, transform.position.y);
					Vector2 poscoin = transform.position;
					poscoin.y = -2f;
					Instantiate (coin, poscoin, transform.rotation);

				}
				transform.position = new Vector2 (transform.position.x, transform.position.y);
				Vector2 pos = transform.position;
				pos.y = -0.76f;
				transform.eulerAngles = new Vector3 (180f, 0f, 0f);
				Instantiate (prefabList [prefabIndex], pos, transform.rotation);
				Invoke ("spawn", randomTime);
			} else {
				if (prefabIndex == 1) {
				
					transform.position = new Vector2 (transform.position.x, transform.position.y);
					Vector2 poscoin = transform.position;
					poscoin.y = 2f;
					Instantiate (coin, poscoin, transform.rotation);
				}
				transform.eulerAngles = new Vector3 (0f, 0f, 0f);
				Instantiate (prefabList [prefabIndex], transform.position, transform.rotation);


				Invoke ("spawn", randomTime);
			}
		}


	void spawnSorc(){
		int rand = Random.Range (0, 2);

		float randTime = Random.Range (1.2f, 3.8f);
		if (rand == 0) {
			sorcPos.transform.position = new Vector2 (sorcPos.transform.position.x, sorcPos.transform.position.y);
			Vector2 pos = sorcPos.transform.position;
			pos.y = 2.1f;
			sorcPos.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
			Instantiate (sorciere, pos, sorcPos.transform.rotation);
			Invoke ("spawnSorc", randTime);
		} else {

		


			sorcPos.transform.position = new Vector2 (sorcPos.transform.position.x, sorcPos.transform.position.y);
			Vector2 pos = sorcPos.transform.position;
			pos.y = -2.1f;
			sorcPos.transform.eulerAngles = new Vector3 (180f, 0f, 0f);
			Instantiate (sorciere, pos, sorcPos.transform.rotation);
			Invoke ("spawnSorc", randTime);



		}
	}

	//}




}
