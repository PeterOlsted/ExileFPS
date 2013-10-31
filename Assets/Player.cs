using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public ChainJam.PLAYER id;
	public float deathHeight = -1000f;
	
	public Player lastHit = null;
	
	//camera
	void Start(){
		iTween.CameraFadeAdd();
		
		ChainJam jam = (ChainJam) MonoBehaviour.FindObjectOfType(typeof(ChainJam));
		jam.AddFunctionBeforeExit(()=>Fadeout(),3); 
	}
	
	public void Fadeout(){	
		iTween.CameraFadeTo(1f,3f);
	}
	
	
	void Update(){
		if (transform.position.y < deathHeight){
			die ();			
		}
		
	}
	
	private void die(){
		if (lastHit != null)
			ChainJam.AddPoints(lastHit.id,1);
		
		this.transform.position = Platform.Platforms[
			Random.Range(0,Platform.Platforms.Count-1)
			].transform.position + Vector3.up;
	}
	
}
