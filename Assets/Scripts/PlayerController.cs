using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rigidBody;
	private int pickupCounter;
	public Text counterText;
	public float speed = 10.0f;

    void Start(){
		rigidBody = GetComponent<Rigidbody> ();
		pickupCounter = 0;
		setCounter ();
    }

	void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.AddForce(movement*speed);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pickup")){
			other.gameObject.SetActive(false);
			pickupCounter++;
			setCounter ();
		}
	}

	void setCounter(){
		counterText.text = "Count: " + pickupCounter.ToString ();		
	}
}
