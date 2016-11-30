using UnityEngine;
using System.Collections;
using System;

public class BlockDragScipt : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 initialPosition;
	public Camera main;
	private Vector3 newPosition;

	private string colName;
	public bool dragable = false;
	GameObject towers; 
	private string thisBlockName;
	int blockIntName=0;
	float[] positionValues = new float[7];


	void Start(){
		thisBlockName = gameObject.name;
		Int32.TryParse (thisBlockName, out blockIntName);
		towers = GameObject.Find ("Towers");
		positionValues[0] = -3.4f;
		positionValues[1]=-2.9f;
		positionValues[2]=-2.4f;
		positionValues[3]=-1.9f;
		positionValues[4]=-1.4f;
		positionValues[5]=-0.9f;
		positionValues[6] = -0.4f;

		
	}
	// grabs the game object if dragable is true.
	void OnMouseDown(){
		if (dragable == true) {
			initialPosition = gameObject.transform.position;
			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			offset = gameObject.transform.position -
				Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
			                                           screenPoint.z));
		}

	}
	// the gameobject will be move along with the mouse cursor.
	void OnMouseDrag(){
		if (dragable == true) {
			this.GetComponent<Rigidbody> ().isKinematic = false;
			Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
		                                         screenPoint.z);
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint);
			transform.position = currentPosition;
		}

	}
	/*
		OnMouseUp- sends the towers of hanoi script the the requested move sequence. if the move sequence if valid this method
		will then transform the position of block.

	 */

	void OnMouseUp(){
		bool moveConfirmed = false;
		if (dragable == true) {
			if (colName == "tower1"){
				moveConfirmed = towers.GetComponent<TowersOfHanoi>().moveBlock(blockIntName,1);
				if(moveConfirmed){
					gameObject.transform.position = gameObject.transform.position = new Vector3 (-6.0f, positionValues[towers.GetComponent<TowersOfHanoi>().blockList[blockIntName-1].posFromBottom-1], 0.0f);
				}else{
					gameObject.transform.position = initialPosition;
				}
			}else if (colName == "tower2") {
				moveConfirmed = towers.GetComponent<TowersOfHanoi>().moveBlock(blockIntName,2);
				if(moveConfirmed){
					gameObject.transform.position = gameObject.transform.position = new Vector3 (0.0f, positionValues[towers.GetComponent<TowersOfHanoi>().blockList[blockIntName-1].posFromBottom-1], 0.0f);
				}else{
					gameObject.transform.position = initialPosition;
				}
			}else if(colName == "tower3"){
				moveConfirmed = towers.GetComponent<TowersOfHanoi>().moveBlock(blockIntName,3);
				if(moveConfirmed){
					gameObject.transform.position = gameObject.transform.position = new Vector3 (6.0f, positionValues[towers.GetComponent<TowersOfHanoi>().blockList[blockIntName-1].posFromBottom-1], 0.0f);
		
				}else{
					gameObject.transform.position = initialPosition;
				}
			}else {
				gameObject.transform.position = initialPosition;
			}
		}

	}

	void OnCollisionEnter(Collision col){

		colName = col.gameObject.name;

	}

	void Update(){
		//checks towers of hanoi script to see if the block object with the same name as this object is dragable
		dragable = towers.GetComponent<TowersOfHanoi>().blockList[blockIntName-1].dragable;
	}


}
