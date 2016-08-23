using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class FinaleMenu : MonoBehaviour {
	public	 GUISkin MenuSkin;
	public Texture bonusTexture;
	public float score;
	public float bonus;
	public float bestscore;

	public GameObject scoreEntry;
	public GameObject ScoreScrollList;
	FbHolder f; 
	// Use this for initialization


	void Start () {
		Advertisement.Initialize ("96242");

		f = new FbHolder();

		score = PlayerPrefs.GetFloat ("Score", 0f); 
		bonus = PlayerPrefs.GetFloat ("Bonus");
		bestscore = PlayerPrefs.GetFloat ("best",0f); 
		if (score > bestscore) {
			bestscore = score;
			PlayerPrefs.SetFloat ("best", bestscore);
		
		
			

		}


		SetScore (bestscore);

		StartCoroutine (ShowAds());
		//QueryScores ();

	}

	IEnumerator ShowAds()
	{
		while (!Advertisement.IsReady())
			yield return null;
		Advertisement.Show ();
		
		
	}

	// Update is called once per frame
	void OnGUI() {
		GUI.skin = MenuSkin;
		GUI.BeginGroup(new Rect(0,0,Screen.width,Screen.height));
		GUI.Box(new Rect(Screen.width/4,Screen.height/10,Screen.width/2,Screen.height-(Screen.height/8)),"Flip Flop");
		if(  GUI.Button(new Rect(Screen.width/3,Screen.height/5,Screen.width/3,Screen.height/10),"Replay")){
			
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (Screen.width / 3, (Screen.height / 3), Screen.width / 3, Screen.height / 10), "Score")) {
		
			PlayerPrefs.SetInt("backpos",1);
			Application.LoadLevel(3);
		}
		if( GUI.Button(new Rect(Screen.width/3,2*(Screen.height/3)-(Screen.height/5),Screen.width/3,Screen.height/10),"Menu"))  {
			
			Application.LoadLevel(0);
		}
		
		/*	 if( GUI.Button(Rect(Screen.width/3,3*(Screen.height/3)-2*(Screen.height/5),Screen.width/3,Screen.height/10),"Quit")){
         		 Application.Quit();
         		            }    */
		GUI.Label(new Rect(Screen.width/3,3*(Screen.height/3)-2.2f*(Screen.height/5),Screen.width/3,Screen.height/10),"Best score :"+bestscore);        
		GUI.DrawTexture(new Rect(Screen.width/3,4*(Screen.height/3)-3f*(Screen.height/5),Screen.height/10,Screen.height/10),bonusTexture); 
		GUI.Label(new Rect(Screen.width/2.2f,4*(Screen.height/3)-3.5f*(Screen.height/5),Screen.width/3,Screen.height/10),"Score : "+score);       
		GUI.Label(new Rect(Screen.width/2.2f,4*(Screen.height/3)-3f*(Screen.height/5),Screen.width/3,Screen.height/10),"Bonus : " +bonus);  
		if (GUI.Button (new Rect (Screen.width / 3, 5 * (Screen.height / 3) - 4 * (Screen.height / 5), Screen.width / 3, Screen.height / 10), "Share your score")) {
			f.ShareWithFriends(score);
		
		}

		GUI.EndGroup ();
		
		
		
		
	}



	public void SetScore(float scoreToSet){
		
		var scoreData = new Dictionary<string, string> ();
		scoreData ["score"] = scoreToSet.ToString ();
		FB.API ("/me/scores", HttpMethod.POST, delegate(IGraphResult result) {
			Debug.Log ("Scores " + result.ToString ());
		}, scoreData);
	}

}
