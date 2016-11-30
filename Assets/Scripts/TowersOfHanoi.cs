using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TowersOfHanoi : MonoBehaviour {

	GameObject obj;
	public GameObject moveText;
	public Block[] blockList = new Block[6];

	public int movesTaken;

	private AudioSource clickSound;
	private bool winCheck;
	private int previousTower;


	//Initialises the blocks and their values
	void Start(){
		int posCount = 6;
		for (int i=0; i<6; i++) {
			blockList[i]= new Block(i+1,1,i+1,posCount);
			posCount--;
		}
		movesTaken = 0;
		clickSound = GetComponent<AudioSource>();

	}
			
	//This functions deals with moving the blocks from tower to wer
	public bool moveBlock(int blockNo,int towerNo){
		bool moveFlag = false;
		clickSound.Play ();
		previousTower = blockList [blockNo - 1].currentTower;
		//Check same tower
		if (previousTower == towerNo) {
			return moveFlag;
		}

		//check if block being moved is valid
		for (int i = 0;i<6;i++) {
			if(blockList[i].currentTower==towerNo){
				if(blockList[blockNo-1].size >= blockList[i].size){
					moveFlag = false;
					return moveFlag;
				}
			}else{
				moveFlag = true;
			}
		}
		//increments the position details in all the blocks of the tower that 
		//the new block is being moved to
		if (moveFlag == true) {

			for (int j=0; j<6; j++) {
				if (blockList [j].currentTower == towerNo) {
					blockList [j].currentPosition++;
				}
				if(blockList[j].currentTower==previousTower){
					blockList [j].currentPosition--;
				}
			}
			blockList [blockNo - 1].currentTower = towerNo;
			blockList [blockNo - 1].currentPosition = 1;
			int posCount = 0;
			for (int i=0; i<6; i++) {
				if(blockList [i].currentTower == towerNo){
					posCount++;
				}
			}

			blockList [blockNo - 1].posFromBottom = posCount;


		}

		movesTaken++;
		Text numberOfMoves = moveText.GetComponent<Text> ();
		numberOfMoves.text = movesTaken.ToString ();

		return moveFlag;
	}




	void Update(){
		updateBlockDragability ();
		winCheck = checkWinCondition ();
		if (winCheck) {
			Application.LoadLevel("placeholder");
		}
	}
	//will change the dragable attribute of block to true if its at the top of the tower
	void updateBlockDragability (){
		for (int i=0; i<6; i++) {
			if(blockList[i].currentPosition==1){
				blockList[i].dragable = true;
			}else{
				blockList[i].dragable = false;
			}
		}
	}
	//checks if all the blocks are in tower 3
	public bool checkWinCondition(){
	
		for (int i=0; i<6; i++) {
			if(blockList[i].currentTower!=3){
				return false;
			}
		}
		return true;
	}
	
	
	/*
	 * The Block class that is used to store information about each block.
	 * Everything has been made public so getters and setters were not required
	 * 
	 * */
	public class Block{
		public int size;
		public int currentTower;
		public int currentPosition;
		public int posFromBottom;
		public bool dragable;
		
		public Block(int newSize,int newTower,int newPosition,int posFromBot){
			this.size=newSize;
			this.currentTower=newTower;
			this.currentPosition=newPosition;
			this.dragable = false;
			
		}
	}

}
