using UnityEngine;
using System.Collections;

public class purplemob : MonoBehaviour
{
	
	Transform myTransform;
	Quaternion facingPlayer;
	//Quaternion lastRotation;
	Transform target;
	Vector3 lookatVec;
	
	float tempFireDelay;
	float lastFireTime;
	
	
	
	
	private receivedamage damagescript;
	
	private PlayerStats pStats;
	
	void OnEnable()
	{
		
		//Messenger.AddListener(EventDictionary.Instance.onHealthZero(), OnHealthZero);
		
	}

	// Use this for initialization
	void Start ()
	{
		myTransform = transform;
		target = Camera.mainCamera.transform;
		
		//hack mechanism for rate of fire.
		tempFireDelay = 2.5f;
		lastFireTime = 0.0f;
		
		pStats = gameObject.GetComponent<PlayerStats>();
		
		
		InitPurpleMob();
	
	}
	
	
	
	private void InitPurpleMob()
	{
		
		
		pStats.SetUpStats();
		pStats.Stamina = 30.0f;
		pStats.RecalculateHealth();
		pStats.currentExperience = 30.0f;
	
		
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		lookatVec = (target.position - myTransform.position);
		facingPlayer = Quaternion.LookRotation(lookatVec);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, facingPlayer, 0.2f);
		myTransform.Translate(Vector3.forward * pStats.CurrentMoveRate * Time.deltaTime);
		
		
		//hack for testing
		lastFireTime += Time.deltaTime;
		
		tempFireDelay = Random.Range(1.0f, 3.0f);
		
		if(lastFireTime >= tempFireDelay)
		{
			//Debug.Log("Fired at " + lastFireTime);
			lastFireTime = 0.0f;
			Vector3 fireVec = myTransform.FindChild("orbmount").transform.position;
			
			
			
			Messenger.Broadcast<Vector3, Vector3>(EventDictionary.Instance.onFiredOrb(),
													fireVec, lookatVec);
			
		}
		
		
	}
	

	

}
