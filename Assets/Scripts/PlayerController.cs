using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Update is called once per frame
	public Text countText;
	private Rigidbody rb;
	public float speed;
	private int count;
	public Text winText;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal")*speed;
		float moveVertical = Input.GetAxis ("Vertical")*speed;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement);
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}
	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}

}
