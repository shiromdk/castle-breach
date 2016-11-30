using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	//Clicking on this button will exit the game
	void OnMouseDown(){
		Application.Quit ();
	}
}
