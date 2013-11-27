using UnityEngine;
using System.Collections;

public class MobManager : MonoBehaviour
{
	public GameObject purplemob;
	public GameObject spawnpoint;
	private float spawnTime = 3.0f;
	
	private Vector3 hereVector;
	
	private enum MobStates
	{
		Idle,
		Spawning,
		Recharging
		
		
		
	}
	
	MobStates _states = MobStates.Spawning;
	

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
		switch(_states)
		{
		case MobStates.Recharging:
			break;
		case MobStates.Spawning:
			Spawn();
			break;
			
			
		}
		
		
	
	}
	
	
	
	private void Spawn()
	{
		
		float t = Random.value;
		hereVector = Vector3.Lerp(spawnpoint.collider.bounds.min, spawnpoint.collider.bounds.max, t);
		
		//Debug.Log(spawnpoint.collider.bounds.min.ToString());
		//Debug.Log(spawnpoint.collider.bounds.max.ToString());
		//Debug.Log(hereVector.ToString());
		//spawnpoint.transform.position
		//instance
		Instantiate(purplemob, hereVector, Quaternion.identity);
		_states = MobStates.Recharging;
		StartCoroutine(Recharge());
		
	}
	
	
	private IEnumerator Recharge()
	{
		spawnTime = Random.Range(3.0f, 4.0f);
		
		yield return new WaitForSeconds(spawnTime);
		_states = MobStates.Spawning;
		
	}
	
}
