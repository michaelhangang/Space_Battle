﻿using UnityEngine;


public class Bullet : MonoBehaviour
{


	// Update is called once per frame
	void Update ()
	{
		//Move the car "foward" using space relative to the rotation of the object
		transform.Translate(Vector3.right * Time.deltaTime * 15.0f, Space.Self);

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "back") 
			Destroy (this.gameObject);
		

		//Debug.Log("BULLET HIT");

		//You can use the line below to find out what GameObject you just collided with
		//collision.gameObject;
	}

    //This function will be called when the object goes off screen. It'll delete the object so we don't get too many
	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
