using UnityEngine;
using System.Collections;
using System;

public class receivedamage : MonoBehaviour 
{

	
	private PlayerStats pStats;
	Transform myTransform;
	GameObject myGameObject;
	Vector3 shakeVector;
	
	private enum HitType
	{
		Crit,
		Hit,
		Glancing
		
	}
	
	private HitType crithitglancing = HitType.Hit;
	
	private string hitName = "hit";
	
	
	void OnEnable()
	{
		
		//Messenger.AddListener<Vector3>(EventDictionary.Instance.onProjectileHit(), OnProjectileHit);
		
	}

	// Use this for initialization
	void Start ()
	{	
		pStats = gameObject.GetComponent<PlayerStats>();
		myTransform = gameObject.transform;
		myGameObject = gameObject;
		shakeVector = new Vector3(3.0f, 3.0f, 3.0f);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	

	public void ApplyDamage(float dmg, float accuracy)
	{
		
		
		float combatRoll = UnityEngine.Random.Range(0f, 1000f);
		
		if(combatRoll <= accuracy)
		{//its a crit
			crithitglancing = HitType.Crit;
			
			
		}
		
		if(combatRoll > accuracy)
		{//its a normal hit
			crithitglancing = HitType.Hit;
			hitName = "hit";
		}
		
		//now roll for fortitude check
		float fortCheck = UnityEngine.Random.Range(0f, 1000f);
		
		if(fortCheck <= pStats.currentFortitude)
		{//successful fort check
			
			switch(crithitglancing)
			{//here we bump the hit down one on a successful fort check
			case HitType.Hit:
				crithitglancing = HitType.Glancing;
				break;
			case HitType.Crit:
				crithitglancing = HitType.Hit;
				break;
			}
			
			
		}
		
		if(crithitglancing == HitType.Crit)
		{
			//Debug.Log("You critically hit!");
			dmg = (dmg * 1.5f) + (dmg * pStats.CrueltyModifier);	
			hitName = "crit";
		}
		
		if(crithitglancing == HitType.Glancing)
		{
			//Debug.Log("Glancing Hit, half damage!");
			dmg = dmg * 0.5f;	
			hitName = "glancing";
		}
		
		
			dmg -= dmg * pStats.currentArmorReduction;
		
		//truncates damage to a whole number;
		dmg = (float)Math.Truncate(dmg);
		
		pStats.CurrentHealth -= dmg;
		
		if(myGameObject.tag == "Player")
		{
		
				//Debug.Log("should shake");	
			iTween.ShakeRotation(Camera.mainCamera.gameObject, shakeVector, 0.20f);	
			
		}
		
		
		
		Vector3 tempPos = gameObject.transform.position;
		Messenger.Broadcast<Vector3, float, string>(EventDictionary.Instance.onDealtDamage(), tempPos, dmg, hitName);
		
		if(pStats.CurrentHealth <= 0f)
		{
			
			if(pStats.gameObject.tag == "Enemies")
			{
			
			Messenger.Broadcast(EventDictionary.Instance.onHealthZero(), myTransform.position);
			Destroy(gameObject);
			
			}
			
			if(pStats.gameObject.tag == "Player")
				Debug.Log("Game Over Bitches");

			
			
		}
		

			
	}
	
	private void Glancing(float dmg)
	{
		
		
	}
	
	private void Crit(float dmg)
	{
		
		
	}
	
	private void Hit(float dmg)
	{
		
		
		
	}
	
	
}
