using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.UI;
public class ScoreScrypt : MonoBehaviour {
	public GameObject scoreEntry;
	public GameObject ScoreScrollList;
	private List<object> scoresList=null;

	// Use this for initialization
	void Start () {
		QueryScores ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Back(){
		if (PlayerPrefs.GetInt ("backpos",0)==1) { 

			Application.LoadLevel (2);
		} else {
			Application.LoadLevel (0);
		
		}
		
		}
	public void QueryScores(){
		FB.API ("/app/scores?fields=score,user.limit(30)", HttpMethod.GET, ScoresCallback);
	}
	
	
	private void ScoresCallback(IResult result)
	{
		//Debug.Log ("Scores callback:" + result.ToString());
		scoresList = Util.DeserializeScores (result.RawResult);
		foreach (object score in scoresList) {
			
			var entry = (Dictionary<string,object>)score;
			var user = (Dictionary<string,object>)entry ["user"];
			GameObject ScorePanel;
			ScorePanel = Instantiate (scoreEntry) as GameObject;
			ScorePanel.transform.SetParent (ScoreScrollList.transform, false);
			Transform thisScoreName = ScorePanel.transform.Find ("FriendName");
			Transform thisScoreScore = ScorePanel.transform.Find ("FriendScore");

			Text ScoreName = thisScoreName.GetComponent<Text> ();

			Text ScoreScore = thisScoreScore.GetComponent<Text> ();
			ScoreName.text = user ["name"].ToString ();
			ScoreScore.text = entry ["score"].ToString ();

			Transform theUserAvatar = ScorePanel.transform.Find ("UserAvatar");
			Image UserAvatar = theUserAvatar.GetComponent<Image> ();
			FB.API(Util.GetPictureURL (user ["id"].ToString (), 128, 128), HttpMethod.GET, delegate(IGraphResult pictureResult) {
				if (pictureResult.Error != null) {
					Debug.Log (pictureResult.Error);
				} else {
					UserAvatar.sprite = Sprite.Create (pictureResult.Texture, new Rect (0, 0, 128, 128), new Vector2 (0, 0));
				}
			});
		
			Debug.Log ("Scores callback:" + "UN: " + user ["name"] + entry ["score"] + ",");
		}}
		

}
