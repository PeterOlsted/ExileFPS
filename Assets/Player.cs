using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public ChainJam.PLAYER id;
	
	void Start(){
		iTween.CameraFadeAdd();
		
		ChainJam jam = (ChainJam) MonoBehaviour.FindObjectOfType(typeof(ChainJam));
		jam.AddFunctionBeforeExit(()=>Fadeout(),3); 
	}
	
	public void Fadeout(){	
		iTween.CameraFadeTo(1f,3f);
	}
}
