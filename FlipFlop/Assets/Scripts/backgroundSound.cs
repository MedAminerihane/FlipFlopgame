using UnityEngine;
using System.Collections;

public class backgroundSound : MonoBehaviour {

	AudioSource audio;
//	public AudioClip[] sounds; // set the array size and fill the elements with the sounds
	//public string[] soundName;

	private static backgroundSound _instance;


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		PlayRandom ();
	}


	public static backgroundSound instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<backgroundSound>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}




	
	// Update is called once per frame
	/*void Update () {
		PlayRandom ();
	
	}*/


	void PlayRandom(){ // call this function to play a random sound
		if (!audio.isPlaying) { // don't play a new sound while the last hasn't finished
			//soundToPlay= Resources.Load("sound"+Random.Range (0, soundName.Length)) as AudioClip;
			//soundToPlay= Resources.Load("gamesong") as AudioClip;
			//AudioClip.=soundToPlay;
			audio.clip = (AudioClip)Resources.Load("gamesong"); 
			audio.Play ();
		}
	}
	/*
	void PlayRandom(){ // call this function to play a random sound
		if (!audio.isPlaying) { // don't play a new sound while the last hasn't finished
			audio.clip = sounds [Random.Range (0, sounds.Length)];
			audio.Play ();
		}
	}*/
}
