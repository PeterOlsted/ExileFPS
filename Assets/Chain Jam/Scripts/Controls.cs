using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class Controls : MonoBehaviour {
	
	public float sensitivityX = 10F;
	public float sensitivityY = 10F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;
	
	public float inertiaX = 100f;
	public float inertiaY = 100f;
	
	float axisX = 0f;
	float axisY = 0f;
	float rotationY = 0F;
	
	void Update ()
	{
		// X axis
		
		if (
			ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.LEFT)){
			axisX -= sensitivityX * Time.deltaTime;	
		}
		if (ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.RIGHT)){
			axisX += sensitivityX * Time.deltaTime;	
		}
		if (
			!ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.LEFT)
			&&
			!ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.RIGHT)
			){
			
			axisX -= axisX * inertiaX * Time.deltaTime;
		}
		
		if (axisX > 1f) axisX = 1f;
		if (axisX < -1f) axisX = -1f;
		
		// Y axis
		
		if (
			ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.DOWN)){
			axisY -= sensitivityY * Time.deltaTime;	
		}
		if (ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.UP)){
			axisY += sensitivityY * Time.deltaTime;	
		}
		if (
			!ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.UP)
			&&
			!ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.DOWN)
			){
			
			axisY -= axisY * inertiaY * Time.deltaTime;
		}

		if (axisY > 1f) axisY = 1f;
		if (axisY < -1f) axisY = -1f;
		
		//and the actual rotation!
		
		float rotationX = transform.localEulerAngles.y + axisX;
		
		rotationY += axisY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		
		//jump
		if (ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.A)){
			Debug.Log("Oppa!");
		}
		
		//shoot
		if (ChainJam.GetButtonPressed(GetComponent<Player>().id,ChainJam.BUTTON.B)){
			Debug.Log("BLAM BLAM BLAM!");
		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
		
		
	}
}