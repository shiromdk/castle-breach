using UnityEngine;
using System.Collections;

public class NewGameScript : MonoBehaviour {

	// Clicking on this starts the game
	void OnMouseDown(){
		Application.LoadLevel("PlatformerPart1");
	}

}
