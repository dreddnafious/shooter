using UnityEngine;
using System.Collections;

public class greenfireorb : MonoBehaviour
{
	Transform myTransform;
	
	private float orbspeed;

	// Use this for initialization
	void Start ()
	{
		myTransform = transform;
		orbspeed = 25.0f;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		myTransform.Translate(Vector3.forward * orbspeed * Time.deltaTime);
	
	}
	
	void OnTriggerEnter(Collider other)
	{

		
		if(other.gameObject.tag == "Player")
		{
			receivedamage script = other.gameObject.GetComponent<receivedamage>();
			script.ApplyDamage(50f, 200.0f);
				Debug.Log("Player hit!");
				Destroy(gameObject);
			
		}
		
		if(other.gameObject.tag == "Default")
		{
		Destroy(gameObject);		
		}
	}
	
}
