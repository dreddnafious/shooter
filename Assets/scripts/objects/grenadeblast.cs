using UnityEngine;
using System.Collections;

public class grenadeblast : MonoBehaviour
{

	Transform myTransform;
	private PlayerStats pStats;

	// Use this for initialization
	void Start ()
	{
		
		myTransform = transform;
		
	}
	
		public void SetOwner(PlayerStats playerStats)
	{
		pStats = playerStats;	
		
		
	}
	
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
