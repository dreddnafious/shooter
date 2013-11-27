using UnityEngine;
using System.Collections;

public class laserrifle : MonoBehaviour
{
	
	
	
	public GameObject partWeaponEffect;
	
	public GameObject hackGrenade;
	private float      grenadeForce;//the force applied to the grenade when it launches
	private Vector3   grenadeForceVector;//the vector we scale the grenade launcher with.
	
	public bloomcontrol bloomController;
	
	
	private crosshair crosshairscript;
	
	private float DeadCenterWidth;//pixel perfect center width of screen
	private float DeadCenterHeight;//pixel perfect center height of screen
	
	
	private float rateOfFire = 0.15f;//the smaller the number the faster the rate of fire, implies the delay time between rounds
	
	
	
	PlayerStats pStats;
		
	private enum RifleState
	{
		Idle,
		Recharging,
		ReadyToFire,
		Fired,
		Reloading
		
	}
	
	private RifleState _state = RifleState.ReadyToFire;
	
	
	// Use this for initialization
	void Start()
	{	
		
		DeadCenterWidth = Screen.width / 2;
		DeadCenterHeight = Screen.height / 2;
		
	
		
		bloomController = gameObject.GetComponent<bloomcontrol>();
		
		//pStats = gameObject.GetComponent<PlayerStats>();
		pStats = gameObject.transform.parent.transform.parent.GetComponent<PlayerStats>();
		pStats.SetUpStats();
		
		crosshairscript = gameObject.GetComponentInChildren<crosshair>();
		crosshairscript.SetCrosshair("rifle");

		grenadeForce = 35f;
		grenadeForceVector = new Vector3(grenadeForce, grenadeForce, grenadeForce);
		
	}
	
	

	// Update is called once per frame
	void Update ()
	{
		
		
		switch(_state)
		{
		case RifleState.ReadyToFire:
			Fire();
			break;
		case RifleState.Fired:
			StartCoroutine(Recharge(rateOfFire));
			break;
		case RifleState.Recharging:
			//do nothing
			break;
		case RifleState.Reloading:
			break;
		}
		
	
	}
	
	private void Fire()
	{
		float currentBloom = bloomController.GetBloom();
		
		//if mouse is down fire
		if (Input.GetMouseButton(0))
		{
			
			crosshairscript.SetCrosshair("rifle");
			
			//hack
			if(pStats.currentCapacity > 0.0f)
			{
			pStats.currentCapacity -= 5.0f;
			//Debug.Log("currentCapacity = " + pStats.currentCapacity.ToString());
			
			
			if(!bloomController.IsGrowing())
			{//if we havent started growing the bloom, start it now, otherwise let it continue to grow.
				bloomController.SetGrow();
			}
			//this chooses a width and height range from the center of the screen to the + and - of the bloom amount
			float Xpos = Random.Range(DeadCenterWidth - currentBloom, DeadCenterWidth + currentBloom);
			float YPos = Random.Range(DeadCenterHeight - currentBloom, DeadCenterHeight + currentBloom);
			Vector3 rayPos = new Vector3(Xpos, YPos, 0.0f);//z component is always 0 because it's a 2d calculation
			
			Ray ray = Camera.main.ScreenPointToRay(rayPos);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit))
			{

				

				Vector3 tempVec = new Vector3(hit.point.x, hit.point.y, hit.point.z);

				
				Vector3 lookatVec;
				//this calculates the forward vector for the projectile to be spawned
				lookatVec = tempVec - transform.position;
					
				Messenger.Broadcast<Vector3, Vector3, PlayerStats>(EventDictionary.Instance.onRifleFired(), transform.position,
												lookatVec, pStats);	
					
					
					//Vector3 shakeVector = new Vector3(5.0f, 0.0f, 0.0f);
					//Hashtable ht = new Hashtable;
					//Camera.mainCamera.transform.Rotate(shakeVector);
					
					
					//iTween.ShakeRotation(Camera.mainCamera.gameObject, shakeVector, rateOfFire);
					//iTween.ShakePosition(gameObject, shakeVector, rateOfFire);
					//iTween.ShakePosition(gameObject, iTween.Hash("z", 3, "time", rateOfFire, "islocal", true));
					
			}//end Physics.RayCast
				
				

			
		_state = RifleState.Fired;
			
			}//end check capacity
		}//end if button 0 down
		
		else
		{//fire option was called but player is not attempting to fire, shrink bloom
			bloomController.SetShrink();		
			
		}//end else
		
		if(Input.GetMouseButtonDown(1))
			//hack for a grenade shot
			//if(Input.GetMouseButton(1))
				{
			
			
			crosshairscript.SetCrosshair("grenade");
			
			//this chooses a width and height range from the center of the screen to the + and - of the bloom amount
			float Xpos = Random.Range(DeadCenterWidth - currentBloom, DeadCenterWidth + currentBloom);
			float YPos = Random.Range(DeadCenterHeight - currentBloom, DeadCenterHeight + currentBloom);
			//start raycast need to put in a function		
			Vector3 rayPos = new Vector3(Xpos, YPos, 0.0f);//z component is always 0 because it's a 2d calculation
			
			Ray ray = Camera.main.ScreenPointToRay(rayPos);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit))
			{

				#region 
				///<summary>This bit of code grabs the vector that the rifle is facing
				/// and scales it by the amount of projectile force the grenade has
				/// this allows the grenade to launch out and then fall with gravity
				/// over time</summary>
				/// 
				Vector3 tmpAim;
				//Vector3 tmpScale = new Vector3(35.0f, 35.0f, 35.0f);

				tmpAim = Vector3.Scale(ray.direction, grenadeForceVector);
				#endregion


				Messenger.Broadcast<Vector3, Vector3, PlayerStats>(EventDictionary.Instance.onGrenadeLaunched(), transform.position,
				                                                   tmpAim, pStats);

				//Debug.Log(tmpAim.ToString());
				
			//Messenger.Broadcast<Vector3, Vector3, PlayerStats>(EventDictionary.Instance.onGrenadeLaunched(), transform.position,
												//AimatVec, pStats);	
			//end raycast need to put in a function
				
				//GameObject tmpGrenade;
				//grenadescript GScript;
			
				//tmpGrenade = (GameObject)Instantiate(hackGrenade, gameObject.transform.position, Quaternion.identity);
				//GScript = tmpGrenade.GetComponent<grenadescript>().Fire(lookatVec);
				//GScript = tmpGrenade.GetComponent<grenadescript>();
				//GScript.Fire(lookatVec);
				
			}	//end if Physics.raycast
				} //end if GetMouseButtonDown(0);

		
		Messenger.Broadcast<string>(EventDictionary.Instance.onDebugText(),
									"crosshairBloom = " + bloomController.GetBloom().ToString());
		
	}
	
	
	private IEnumerator Recharge(float RateofFire)
	{
		_state = RifleState.Recharging;
		yield return new WaitForSeconds(RateofFire);
		_state = RifleState.ReadyToFire;
		
	}
}
