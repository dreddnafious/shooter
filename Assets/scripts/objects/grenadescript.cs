using UnityEngine;
using System.Collections;

public class grenadescript : MonoBehaviour 
{
	Transform myTransform;
	private PlayerStats pStats;

	// Use this for initialization
	void Start ()
	{
		
		myTransform = transform;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void Fire(Vector3 aimVector)
	{
		
		//if(aimVector.x < 1.0f)
			//aimVector.x = 1.0f;
		
		gameObject.rigidbody.AddForce(aimVector * 55.0f); 	
		
	}
	
		public void SetOwner(PlayerStats playerStats)
	{
		pStats = playerStats;	
		
		
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemies")
		{
		//Debug.Log("collided with " + other.gameObject.name);
		//Messenger.Broadcast<Vector3, float>(EventDictionary.Instance.onProjectileHit(),
					//myTransform.position, 1000.0f);


			//Debug.Log(pStats.ToString());
			
			Messenger.Broadcast<Vector3, PlayerStats>(EventDictionary.Instance.onGrenadeHit(),
				myTransform.position, pStats);
			
			receivedamage damagescript = other.gameObject.GetComponent<receivedamage>();
			damagescript.ApplyDamage(700.0f, 700.0f);
			
			Destroy(gameObject);	
		}
		
		if(other.tag == "Default")
			Destroy(gameObject);
		
		
		
		
		
		
		//Destroy(gameObject);	
		
	}
	
	
}
