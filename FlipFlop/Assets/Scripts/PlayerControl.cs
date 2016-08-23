using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	Rigidbody2D rb;
	private float nextScoreTime;
	private float scorePeriod = 0.5f;
	private float scoreAmount = 0f;
	private float bonus = 0f;
	public Text countText;
	public Text bonusText;
	public GameObject GameOverText;
//	public GameObject text;
	private bool isDead;
	private float pat=0.145f;
	// Use this for initialization

	Animator animator;
	private bool isGrounded;
	public AudioClip jump;
	AudioSource audiojump;
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator>();
		//countText.text = "";
		//bonusText.text = "";
		audiojump = GetComponent<AudioSource>();

		nextScoreTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	


	

	 if (scoreAmount > 1000f) {
			pat=0.23f;
		}else if (scoreAmount > 600f) {
			pat=0.2f;
		}else if(scoreAmount > 300f) {
			pat=0.175f;
		}
		
		if (isDead == false) {
		
			if (Time.time > nextScoreTime) {
				nextScoreTime += scorePeriod;
				scoreAmount = scoreAmount + 5f;
				
			}
			countText.text = scoreAmount.ToString ();

 for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			
			// -- Tap: quick touch & release
			// ------------------------------------------------

			if (touch.phase == TouchPhase.Began )
			{
				if (transform.position.y > 0 && transform.position.y < 0.81f) {
				if (touch.position.y > (Screen.width/4)) {
					//do something
					rb.velocity=transform.up*8.5f;


						

				}



				else if(touch.position.y < (Screen.width/4)){

						transform.position = new Vector2 (transform.position.x, transform.position.y);
						transform.eulerAngles = new Vector3 (180f, 0f, 0f);
						Vector2 pos = transform.position;
						pos.y = -0.76f;
						
						transform.position = pos;
						rb.gravityScale = -2.5f;
					}



				}else if (transform.position.y < 0 && transform.position.y >-0.77f){

					if (touch.position.y > (Screen.width/4)) {
						//do something

						
						transform.position = new Vector2 (transform.position.x, transform.position.y);
						transform.eulerAngles = new Vector3 (0f, 0f, 0f);
						Vector2 pos = transform.position;
						pos.y = 0.8f;
						
						transform.position = pos;
						rb.gravityScale = 2.5f;
						
						
					}
					
					
					
					else if(touch.position.y < (Screen.width/4)){
						rb.velocity=transform.up*8.5f;

					}

				}


				








					}
			}
		

rb.position = new Vector2 (rb.position.x + pat, rb.position.y);
	}}


/*	
	void OnTriggerEnter2D(Collider2D other) {
		print("pass");

	}
	*/
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag=="obstacle")
		{
			//audiojump.clip = (AudioClip)Resources.Load("jump"); 
		
			//audiojump.Play ();

			audiojump.PlayOneShot(jump,1);
			isDead=true;
			animator.SetTrigger("dead");
			if (transform.position.y > -0.77f){
				rb.gravityScale=-1f;
			}else{
			
				rb.gravityScale=1f;
			}

			transform.localScale = new Vector3(0.5f,0.5f,0f);
			this.enabled=false;

		
		
		saveScores();

		Invoke("GameOver",2);
			Invoke("Replay",3);

		}


	

	}

	void saveScores() 
	
	{ 
		PlayerPrefs.SetFloat("Bonus",bonus);


		PlayerPrefs.SetFloat("Score",scoreAmount); } 
	void Replay() {
		//Time.timeScale = 0;

		Application.LoadLevel(2);
	}
	void GameOver() {
		//Time.timeScale = 0;
		GameOverText.SetActive(true);

	}
			
		
	void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag=="coin")
		{
			Destroy(collision.gameObject);
			

			animator.SetTrigger("bonus");
			bonus= bonus+10f;
			bonusText.text=bonus.ToString();
			
			print("Coin");

			
		}
		
	}
			}