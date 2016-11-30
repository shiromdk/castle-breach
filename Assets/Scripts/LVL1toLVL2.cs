using UnityEngine;
using System.Collections;
//This script deals with going from the outside of the castle to the towers of hanoi script
public class LVL1toLVL2 : MonoBehaviour {
	bool clickable = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void onTriggerEnter2D(Collider2D col){
		clickable = true;
		//Application.LoadLevel ("prototype");
	}
	void OnTriggerExit2D(Collider2D col){
		Debug.Log ("fsdfsdf");
		clickable = false;
	}
	void OnTriggerStay2D(Collider2D col){
		clickable = true;
	

	}

	void OnMouseDown(){
		Debug.Log ("fsdfsdf");
		if (clickable) {
			Application.LoadLevel ("prototype");
		}
	}
}
