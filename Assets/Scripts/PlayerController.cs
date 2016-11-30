using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	

	
	public float maxSpeed = 10;
	public float speed = 50f;
	public float jumpForce = 10f;

	public bool grounded;

	private Rigidbody2D rb2d;
	private Animator anim;


	void Start()
	{
		//Sets references to the animator and rigidbody components assigned to the player obj
		anim = gameObject.GetComponent<Animator> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	void Update()
	{
		//Sets the animation status
		anim.SetBool ("grounded",grounded);
		anim.SetFloat ("speed",Mathf.Abs(Input.GetAxis ("Horizontal")));

		//checks facing left or right
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3(-1,1,1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3(1,1,1);
		}

		//jump function. currently not working as the grounded bool isnt working as intended
		if (Input.GetButtonDown ("Jump") && grounded) {
			rb2d.AddForce(Vector2.up*jumpForce);
		}
	}

	void FixedUpdate()
	{
		//check a or d keypresses or whatever is set to horizontal axis
		float horizontal = Input.GetAxis ("Horizontal");
		//moves player in that direction
		rb2d.AddForce ((Vector2.right * speed) * horizontal);
		//stops movement if no input.
		if (horizontal == 0f) {
			rb2d.velocity=new Vector2(0f,rb2d.velocity.y);
		}
		//caps movement speed to max speed
		if (rb2d.velocity.x > maxSpeed)
		{
			rb2d.velocity = new Vector2(maxSpeed,rb2d.velocity.y);	
		}
		if (rb2d.velocity.x < -maxSpeed){
			rb2d.velocity = new Vector2(-maxSpeed,rb2d.velocity.y);
		}
	}


	void onTriggerEnter2D(Collider2D col){
		Debug.Log ("Checking Collision");
	}
	

}