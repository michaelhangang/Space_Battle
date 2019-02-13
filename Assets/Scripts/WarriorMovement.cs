using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class WarriorMovement : MonoBehaviour
{
	float Speed = 10.0f;
	public GameObject Bullet;
	public  AudioSource Laser;
	public  AudioSource die;
	private bool a ;
	float timer;
	const float HONK_TIME = 1.5f;
	private Rigidbody rig;
	private float turnspeed =60;
	// Update is called once per frame


	void Start(){

		a = false;
		timer = 0.0f;
	}
	void Awake()
	{
		

	}
	void Update ()
	{
		//Get the rotation using mouse position and converting the players transform position to screen position
		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//This offset places the bullet a distance away from the center of the player
		Vector3 bulletOffset = transform.right * 2;

		//Every mouse button will spawn a bullet
		//You could combine this with a timer to make a machine gun
		if (Input.GetMouseButtonDown(0) ||Input.GetButtonDown("Square"))
		{
			Instantiate(Bullet, transform.position + bulletOffset, transform.rotation);
			Laser.Play();

		}

		if (Input.GetMouseButton(1)||Input.GetButton("X"))
		{
			Laser.Play();

			Instantiate(Bullet, transform.position + bulletOffset, transform.rotation);
		}

		//Move the player up using world space
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * Time.deltaTime * Speed, Space.World);

		}

	

		//Move the player down using world space
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * Time.deltaTime * Speed, Space.World);
		}

		//Move the player left using world space
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);
		}

		//Move the player right using world space
		if (Input.GetKey(KeyCode.D))
		{			transform.Translate(Vector3.right * Time.deltaTime * Speed, Space.World);
		}

		if (Input.GetKey(KeyCode.Escape)||Input.GetButton("Options"))
		{
			SceneManager.LoadScene("Menu");
	     }

		if (Input.GetAxis ("DpadX") != 0) {
			Vector3 move = new Vector3(Input.GetAxis ("DpadX"),0,0);
			transform.Translate(move* Time.deltaTime * Speed, Space.World);
		}

		if (Input.GetAxis ("DpadY") != 0) {
			Vector3 move = new Vector3(0,Input.GetAxis ("DpadX"),0);
			transform.Translate(move* Time.deltaTime * Speed, Space.World);
		}

		float hAxix = Input.GetAxis ("Horizontal");
		float vAxix = Input.GetAxis ("Vertical");

		float rStick = Input.GetAxis ("RightStickX");

		Vector3 movemnet = transform.TransformDirection (new Vector3 (hAxix, vAxix, 0)*Time.deltaTime * Speed);
		rig.MovePosition (transform.position + movemnet);
		Quaternion rotation = Quaternion.Euler (new Vector3 (0,0, rStick)*turnspeed*Time.deltaTime);
		transform.Rotate (new Vector3(0,0,rStick),turnspeed*Time.deltaTime );


	}
	
     private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.tag == "back") 
		     StartCoroutine(DelayedLoad());
		

	}

	IEnumerator DelayedLoad()
	{
		//Play the clip once
		die.Play();

		//Wait until clip finish playing
		yield return new WaitForSeconds (0.5f);    

		//Load scene here
		SceneManager.LoadScene ("Main");
	}
}
