using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {
	
	public GameObject laserprojectile;
	public GameObject greenorb;
	public GameObject hackGrenade;
	public GameObject hackGrenadeBlast;
	
	private GameObject tempProjectile;
	
	
	
	void OnEnable()
	{
		
		Messenger.AddListener<Vector3, PlayerStats>(EventDictionary.Instance.onGrenadeHit(), OnGrenadeHit);
		Messenger.AddListener<Vector3, Vector3, PlayerStats>(EventDictionary.Instance.onGrenadeLaunched(), OnGrenadeLaunched);
		Messenger.AddListener<Vector3, Vector3, PlayerStats>(EventDictionary.Instance.onRifleFired(), OnRifleFired);	
		Messenger.AddListener<Vector3, Vector3>(EventDictionary.Instance.onFiredOrb(), OnFiredOrb);
		
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	
	
	void OnRifleFired(Vector3 position, Vector3 relativepos, PlayerStats playStats)
	{
		
		Quaternion goodrotation;
		
		goodrotation = Quaternion.LookRotation(relativepos);
		
		tempProjectile = (GameObject)Instantiate(laserprojectile, position, goodrotation); 
		tempProjectile.gameObject.GetComponent<laserproj>().SetOwner(playStats);
		//Debug.Log("Instanced laser @" + position.x + position.y + position.z);
	}
	
	void OnGrenadeLaunched(Vector3 position, Vector3 relativeposition, PlayerStats playStats)
	{
		
		GameObject tmpGrenade;
		grenadescript GScript;
		
		tmpGrenade = (GameObject)Instantiate(hackGrenade, position, Quaternion.identity);
		GScript = tmpGrenade.GetComponent<grenadescript>();
		GScript.SetOwner(playStats);
		GScript.Fire(relativeposition);
		
	}
	
	void OnGrenadeHit(Vector3 position, PlayerStats playStats)
	{
		Debug.Log(playStats.ToString());
		GameObject tmpGrenadeBlast = (GameObject)Instantiate(hackGrenadeBlast, position, Quaternion.identity);
		grenadeblast GBlastScript = tmpGrenadeBlast.GetComponent<grenadeblast>();
		GBlastScript.SetOwner(playStats);
		
		
	}
	
	
	void OnFiredOrb(Vector3 position, Vector3 relativepos)
	{
		
		Quaternion goodrotation;
		
		goodrotation = Quaternion.LookRotation(relativepos);
		
		Instantiate(greenorb, position, goodrotation); 	
		
		
	}
	
}
