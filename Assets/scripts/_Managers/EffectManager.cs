using UnityEngine;
using System.Collections;


	
public class EffectManager : MonoBehaviour
{
	

	
	public GameObject partWeaponEffect; //= new GameObject("peffect"); // = GetComponent<peffect>.Clone();
	public GameObject partExplosionEffect;
	
	void Start()
	{
		
		
	}
		
		
	void OnEnable()
	{
		
		Messenger.AddListener<Vector3, float>(EventDictionary.Instance.onProjectileHit(), OnProjectileHit);
		Messenger.AddListener<Vector3>(EventDictionary.Instance.onHealthZero(), OnHealthZero);
		
	}
	
	
	void OnDisable()
	{
		
		//Debug.Log("removing effect listener");
		//Messenger.RemoveListener<Vector3>(EventDictionary.Instance.onProjectileHit(), OnProjectileHit);
	}
		
	void OnProjectileHit(Vector3 position, float dmg)
	{
		Instantiate(partWeaponEffect, position, Quaternion.identity);

	}		
		
	void OnHealthZero(Vector3 position)
	{
		
		Instantiate(partExplosionEffect, position, Quaternion.identity);	
		
	}
		
}	
	
	
	


	
	

	
	

	
	

