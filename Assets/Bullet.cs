using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 2000f;
	
	public float lifespan = 5f;
	
	void Start(){
		StartCoroutine(DeleteAfterTimeout());
	}
	
	public IEnumerator DeleteAfterTimeout(){
		yield return new WaitForSeconds(lifespan);
		GameObject.Destroy(this.gameObject);
	}
}
