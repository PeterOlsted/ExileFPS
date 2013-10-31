using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 2000f;
	public float strength = 1f;
	public float radius = 100f;
	public float lifespan = 5f;
	
	public Player author;
	
	void Start(){
		StartCoroutine(DeleteAfterTimeout());
	}
	
	public IEnumerator DeleteAfterTimeout(){
		yield return new WaitForSeconds(lifespan);
		GameObject.Destroy(this.gameObject);
	}
	
	void OnTriggerEnter(Collider col){
				
		GameObject.Destroy(this.gameObject);
		//TODO EKSPLOZION
		
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		foreach(GameObject p in players){
			p.rigidbody.AddExplosionForce(strength,transform.position,radius);
			if (p.GetComponent<Player>() != author)
				p.GetComponent<Player>().lastHit = this.author;
		}
	}
}
