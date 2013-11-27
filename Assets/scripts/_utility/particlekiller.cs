using UnityEngine;
using System.Collections;

public class particlekiller : MonoBehaviour
{
	ParticleSystem psys;

	// Use this for initialization
	void Start () 
	{
		psys = this.particleSystem;
		//Object.Destroy(gameObject, psys.duration + psys.startLifetime);
		Object.Destroy(gameObject, psys.startLifetime);
	}
	
	// Update is called once per frame
	void Update ()
	
	{
		
		

			
			
	
	}
}
