using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
public class FbHolder : MonoBehaviour {
	//private List<object> scoresList=null;

	void Awake (){
		if (!FB.IsInitialized) {
			FB.Init (SetInit, OnHideUnity);
		} else {
			FB.ActivateApp();
		}
		}

	private void SetInit(){
		Debug.Log ("Fb init done");
		if (FB.IsLoggedIn) {
			Debug.Log ("Fb logged");
		} else {
			//FBlogin();
		}
	}

	private void OnHideUnity(bool isGameShown){

		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale=1;
		}
	}

	public  void FBlogin(){
		FB.LogInWithReadPermissions (new List<string>(){ "user_friends","email"}, AuthCallback);

	/*	FB.LogInWithPublishPermissions (
			new List<string>(){"publish_actions"},
		AuthCallback
		);*/

	}

	public void FBloginAction(){
		FB.LogInWithPublishPermissions (
			new List<string>(){"publish_actions"},
		AuthCallback
		);

	}

	void AuthCallback(IResult result){
	
		if (FB.IsLoggedIn) {
			Debug.Log ("FB login worked!");
		} else {
			Debug.Log("Fb Login fall");
		
		}
	}

	public void ShareWithFriends(float myscore) {
	FB.FeedShare (
			string.Empty, //toId
			new System.Uri( "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? AccessToken.CurrentAccessToken.UserId : "guest")), //link
			"FlipFlop", //linkName
			"Try to beat my score, Play Now !", //linkCaption
			"I just reach "+ myscore, //linkDescription
			new System.Uri("http://s12.postimg.org/48ky9q0y5/funkydeformation.png"), //picture
			string.Empty //mediaSource

		);
	
	}

	public void InviteFriends(){
		FB.AppRequest (
			message: "This Game is awsome join me",
			title: "Invite friends to join you");
		
		
	}

	/*public void QueryScores(){
		FB.API ("/app/scores?fields=score,user.limit(30)", HttpMethod.GET, ScoresCallback);
	}


	private void ScoresCallback(IResult result)
	{
		//Debug.Log ("Scores callback:" + result.ToString());
		scoresList = Util.DeserializeScores (result.RawResult);
		foreach (object score in scoresList) {
		
			var entry= (Dictionary<string,object>) score;
			var user =(Dictionary<string,object>) entry["user"];
			GameObject ScorePanel;
		//	ScorePanel = Instantiate(scoreEntry) as GameObject;
	//		ScorePanel.transform.parent= ScoreScrollList.transform;
			Debug.Log ("Scores callback:" + "UN: " + user["name"]+entry["score"]+ ",");
		}

	}*/

	public void SetScore(){

		var scoreData = new Dictionary<string, string> ();
		scoreData ["score"] = Random.Range (10, 200).ToString ();
		FB.API ("/me/scores", HttpMethod.POST, delegate(IGraphResult result) {
			Debug.Log ("Scores " + result.ToString ());
		}, scoreData);
	}

	}



