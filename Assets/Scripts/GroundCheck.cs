using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void onTriggerEnter2D(Collider2D col){
		player.grounded = true;
	}
	
	void onTriggerStay2D(Collider2D col){
		player.grounded = true;
	}
	
	void onTriggerExit2D(Collider2D col){
		player.grounded = false;
	}
}
