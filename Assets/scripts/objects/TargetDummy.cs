using UnityEngine;
using System.Collections;

public class TargetDummy : MonoBehaviour
{
	PlayerStats pStats;

	// Use this for initialization
	void Start ()
	{
		pStats = gameObject.GetComponent<PlayerStats>();
		pStats.SetUpStats();
		pStats.Stamina = 5000.0f;
		pStats.RecalculateHealth();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
