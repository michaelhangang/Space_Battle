using UnityEngine;
using System.Collections;
public class EnemySpawning : MonoBehaviour
{
    //Timer Vars
	private const float TRIGGER_TIME = 5.0f;
	private float timeCount;

	public GameObject PrefabToSpawn;

    //This is the transform of the player we'll be chasing, it gets set in the start function
	private Transform PlayerToChase;

    //This count will be increase every time we spawn a new car so we don't spawn to many
	private float  spawnNum;

	// Use this for initialization
	void Start ()
	{
		timeCount = 0.0f;

		spawnNum = MenuScript.LoadDifficult ();
		PlayerToChase = GameObject.FindWithTag("Player").transform;
	}




	// Update is called once per frame
	void Update ()
	{
		timeCount += Time.deltaTime;

		//spawnCount will fail when we start removing enemies, it'll remain at 5
        //Time to do some research to fix this issue!
		if (timeCount >= TRIGGER_TIME)
		{
			for (float i = 1.0f; i <= spawnNum; i++) {
				Vector3 newSpawnPos = new Vector3 (27.7f, Random.Range (-10.6f, 8.6f), 0.296875f);
				GameObject newCar = Instantiate (PrefabToSpawn, newSpawnPos, Quaternion.identity);
				newCar.GetComponent<AlienMovement> ().Target = PlayerToChase;

				Vector3 newSpawnPos1 = new Vector3 (Random.Range (22.1f, -27.9f), 13.6f, 0.296875f);
				GameObject newCar1 = Instantiate (PrefabToSpawn, newSpawnPos1, Quaternion.identity);
				newCar1.GetComponent<AlienMovement> ().Target = PlayerToChase;

				Vector3 newSpawnPos2 = new Vector3 (-29.8f, Random.Range (-10.6f, 8.6f), 0.296875f);
				GameObject newCar2 = Instantiate (PrefabToSpawn, newSpawnPos2, Quaternion.identity);
				newCar2.GetComponent<AlienMovement> ().Target = PlayerToChase;

			}

			timeCount = 0.0f;

		}

	}


}
