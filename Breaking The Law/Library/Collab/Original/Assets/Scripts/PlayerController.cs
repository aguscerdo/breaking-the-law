using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Animator animator;

	public float maxLateralSpeed, speed, jumpHeight;
	public int paperCount;
	public bool canJump = true;
	public GameController gameController;
	public bool facing_left;
	public Text gravLevel;
	public Text paperLevel;
	public int lifeCount;
	public Vector2 spawnPos;

	public int gravity_count;
	private int gravity_used;
	private float delta_gravity;
	private float dg;
	public float def_g;
	public bool idle;

	void Start(){
		//sets the life count if it was not explicitly stated in the editor
		if (lifeCount == 0) {
			lifeCount = 3;
		}

		//gets the rigid body of the sprite
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		GameObject gc = GameObject.FindWithTag ("GameController");
		if (gc == null) {
			Debug.Log ("Couldn't find game controller");
		} else
			gameController = gc.GetComponent<GameController> ();
		
		gravity_count = 0;
		gravity_used = 0;
		delta_gravity = 0.0f;
		dg = 0.2f;
		def_g = 1.5f;
		rb.gravityScale = def_g;

		//get initial spawn position
		spawnPos = transform.position;

		facing_left = true;
		idle = true;
		paperLevel.text = "0/" + gameController.numberOfPapers.ToString ();
	}

	// Update is called once per frame
	void Update () {
		if (gravLevel != null) {
			gravLevel.text = "Gravity: " + rb.gravityScale + "\nGravity Coins: " + gravity_count.ToString();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
	//for physics based mechanics
	void FixedUpdate(){

		//move right
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (new Vector2 (1, 0) * speed * Time.deltaTime);
			if (!facing_left) {
				facing_left = true;
				sr.flipX = false;
			}
			animator.SetBool ("state", false);

		}
		//move left
		else if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (new Vector2 (-1, 0) * speed * Time.deltaTime);
			if (facing_left) {
				facing_left = false;
				sr.flipX = true;
			}
			animator.SetBool ("state", false);
		} else {
			animator.SetBool ("state", true);
		}
		//jump
		if (canJump && Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Jumped");
			rb.AddForce (new Vector2 (0, 1) * jumpHeight * Time.deltaTime);
		}
					

		if (Input.GetKeyDown (KeyCode.E)) {
			if (gravity_count > 0) {
				if (gravity_used == 0) {//Default Gravity
					gravity_used += 1;
					delta_gravity += dg;
				} else if (delta_gravity < 0) {	//Negative Gravity -> Increasing
					gravity_used -= 1;
					delta_gravity += dg;
				} else if (delta_gravity > 0 && gravity_used < gravity_count) { //Positive Gravity -> Increasing
					gravity_used += 1;
					delta_gravity += dg;
				}
				rb.gravityScale = def_g + delta_gravity;
			}
		} else if (Input.GetKeyDown (KeyCode.Q)) {	//Reduce Gravity
			if (gravity_count > 0) {
				if (gravity_used == 0) {//Default Gravity
					gravity_used++;
					delta_gravity -= dg;
				} else if (delta_gravity > 0) {	//Positive Gravity -> Decreasing
					gravity_used--;
					delta_gravity -= dg;
				} else if (delta_gravity < 0 && gravity_used < gravity_count) {	//Negative Gravity -> Decreasing
					gravity_used++;
					delta_gravity -= dg;
				}

				rb.gravityScale = def_g + delta_gravity;
			}
		}



		//slows the player

		if(Mathf.Abs(rb.velocity.x) > maxLateralSpeed){
			int dir = -1;
			if (rb.velocity.x > 0)
				dir = 1;
			rb.velocity = (new Vector2 (maxLateralSpeed * dir, rb.velocity.y));

		}

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "ground") {
			canJump = false;
		}
	}


	void OnTriggerEnter2D(Collider2D otherCollider){
		string tag = otherCollider.tag;
		if (tag == "paper") {
			Disable (otherCollider.gameObject);
			paperCount++;
			paperLevel.text = (paperCount).ToString () + "/" + gameController.numberOfPapers.ToString();
		}
		if (tag == "ground")
			canJump = true;
		if (tag == "door") {
			gameController.AllPapersCollected (paperCount);
		}
		if (tag == "gravity") {
			gravity_count++;
			Disable (otherCollider.gameObject);
		}
		if (tag == "enemy") {
			lifeCount--;
			if (lifeCount < 1) {
				gameController.LoseCondition ();
			} else {
				rb.velocity = new Vector2 (0, 0);
				transform.position = spawnPos;
			}
		}
	}
}
