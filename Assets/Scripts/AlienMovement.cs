using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour {

	float Speed = 5.0f;

	//This is the target that we'll look towards, it'll be set in the editor
	public Transform Target;

	// Update is called once per frame
	void Update ()
	{
		//Face the car in the direction of the "Target" Game Object
		Vector3 dir = Target.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//Move the car "foward" using space relative to the rotation of the object
		transform.Translate(Vector3.right * Time.deltaTime * Speed, Space.Self);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Finish") {
			Destroy (this.gameObject);
			Score.AddPoints (1);

		}
	
	}
}