using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 2000f;
	public float strength = 1f;
	public float lifespan = 5f;
	
	void Start(){
		StartCoroutine(DeleteAfterTimeout());
	}
	
	public IEnumerator DeleteAfterTimeout(){
		yield return new WaitForSeconds(lifespan);
		GameObject.Destroy(this.gameObject);
	}
	
	void OnTriggerEnter(Collider col){
		
		Debug.Log("A");
		
		GameObject.Destroy(this.gameObject);
		//TODO EKSPLOZION
		
		if (col.tag.Equals("Player")){
			col.rigidbody.AddForce(rigidbody.velocity * strength);
			
		}
	}
}
