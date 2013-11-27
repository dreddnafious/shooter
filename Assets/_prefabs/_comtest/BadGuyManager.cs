using UnityEngine;
using System.Collections;

public class BadGuyManager : MonoBehaviour
{
	
	public GameObject badguy;
	public GameObject spawnpoint;
	
	private GameObject tempBG;
	
	
	//private Transform myTransform;

	// Use this for initialization
	void Start ()
	{
		//myTransform = transform;
		
		tempBG = (GameObject)Instantiate(badguy, spawnpoint.transform.position, Quaternion.identity);
		
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		tempBG.transform.Translate(Vector3.forward * 3f * Time.deltaTime);
		
	
	}
}
