using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {

	// Use this for initialization

	private float nextScoreTime;
	private float scorePeriod = 0.5f;
	private float scoreAmount = 0f;

	
	void start(){
		

		
	}
	
	void Update(){
		if (Time.time > nextScoreTime)
		{
			scoreAmount=scoreAmount+10f;
			nextScoreTime += scorePeriod;
		}
	//	dis = dis * Time.deltaTime;
	Debug.Log(scoreAmount); //Test to see if distance is working. Not required.
		
		//Do whatever you want with variable dis

}
}