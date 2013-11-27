using UnityEngine;
using System.Collections;

public class laserproj : MonoBehaviour
{
	Transform myTransform;
	private PlayerStats pStats;
	
	
	public float projectilespeed = 500.0f;
	public float damage = 50f;
	private Vector3 fwd;
	private float distance;
	private float distancetraveled;
	private float range = 1000f;
	
	
	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
		fwd = myTransform.forward;
		distancetraveled = 0f;
		
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		

		
		
		distance = projectilespeed * Time.deltaTime;
		
			
			RaycastHit[] hits;
		
			
					
			hits = Physics.RaycastAll(myTransform.position,
									  fwd, distance,  ~(1 << 11 | 1 << 10));//this mask ignores projectiles and enemy projectiles
		
		//Debug.DrawRay(myTransform.position, fwd * 10, Color.blue);
		

		
			int i = 0;
			
			while(i < hits.Length)
			{
			
			
			
			if(hits[i].collider.gameObject.tag == "Enemies")
			{
				//Vector3 tempvec = new Vector3(hits[i].point.x, hits[i].point.y, hits[i].point.z);
				myTransform.position = GetCollisionPoint(hits[i]);

				HitEnemy(hits[i]);
				break;
					
			}//end if you hit something tagged enemies
			
			
			if(hits[i].collider.gameObject.tag == "Default")
			{
				myTransform.position = GetCollisionPoint(hits[i]);
				HitDefault(hits[i].collider);
				break;
							
			}
			
			i++;
			
				
			}//end while that looks through rayhit array
			
		
		
		
			myTransform.Translate(Vector3.forward * distance);
			distancetraveled += distance;
		
			if(distancetraveled >= range)
				Destroy(gameObject);
		
		
		
	}
	
	public void SetOwner(PlayerStats playerStats)
	{
		pStats = playerStats;	
		
		
	}

	
	
	void OnTriggerEnter(Collider other)
	{
		
		
		//Debug.Log("collided with " + other.gameObject.name);
		Messenger.Broadcast<Vector3, float>(EventDictionary.Instance.onProjectileHit(),
					myTransform.position, damage);
		
		
		
		Destroy(gameObject);	
		
	}
	
	
	void HitEnemy(RaycastHit hit)
	{
		
		damage = Random.Range(40.0f, 55.0f);
		
		Messenger.Broadcast<Vector3, float>(EventDictionary.Instance.onProjectileHit(),
					myTransform.position, damage);
		
			receivedamage script = hit.collider.gameObject.GetComponent<receivedamage>();
			script.ApplyDamage(damage, pStats.currentAccuracy);	
		//Debug.Log("HitEnemyApplied");
		Destroy(gameObject);
		
	}
	
	
	void HitDefault(Collider other)
	{
		
		//Debug.Log("collided with " + other.gameObject.name);
		Messenger.Broadcast<Vector3, float>(EventDictionary.Instance.onProjectileHit(),
					myTransform.position, damage);
		
		
		Destroy(gameObject);		
		
		
		
	}
	
	Vector3 GetCollisionPoint(RaycastHit hit)
	{
				Vector3 tempvec = new Vector3(hit.point.x, hit.point.y, hit.point.z);
				return tempvec;	
		
		
	}
	
	
}
