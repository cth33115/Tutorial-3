using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour {

	public float speed;
	public Text counttext;
	public Text wintext;

	private Rigidbody rb;
	private int count;

	void Start ()
		{
			rb = GetComponent<Rigidbody>();
			count = 0;
			Setcounttext ();
			wintext.text = "";
		}


	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("pick up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			Setcounttext ();

		}
	}
	void Setcounttext ()
	{
		counttext.text = "count: " + count.ToString ();
		if (count >= 12)
		{
			wintext.text = "YOU WIN!";
		}
	}
}
