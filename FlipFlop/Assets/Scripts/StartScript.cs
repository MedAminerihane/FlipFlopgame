using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
public	GUISkin MenuSkin;
	// Use this for initialization
	FbHolder f; 
	void Start () {
		 f = new FbHolder();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI() {
		GUI.skin = MenuSkin;
		GUI.BeginGroup(new Rect(0f,0f,Screen.width,Screen.height));
		GUI.Box(new Rect(Screen.width/4f,Screen.height/10f,Screen.width/2f,Screen.height-(3*Screen.height/10f)),"Funky Flip");
		if(  GUI.Button(new Rect(Screen.width/3f,Screen.height/5f,Screen.width/3f,Screen.height/10f),"Play")){
			
			Application.LoadLevel(1);
	
		//	f.SetScore();
		}
	if (GUI.Button (new Rect (Screen.width / 3f, (Screen.height / 3f), Screen.width / 3f, Screen.height / 10f), "Score")) {
			PlayerPrefs.SetInt("backpos",0);
			Application.LoadLevel(3);
		}
		if (GUI.Button (new Rect (Screen.width / 3f, 2f * (Screen.height / 3f) - (Screen.height / 5f), Screen.width / 3f, Screen.height / 10f), "Invite Friends")) {


			f.InviteFriends();
		//	f.QueryScores();

		//	f.FBloginAction();
		}
		if( GUI.Button(new Rect(Screen.width/3,3*(Screen.height/3)-2*(Screen.height/5),Screen.width/3,Screen.height/10),"Facebook Login")){

			f.FBlogin();
		}           

		GUI.EndGroup ();
		
		
		
		
	}

}
