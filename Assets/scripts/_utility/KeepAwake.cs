/// <summary>
/// Keep awake. Must apply this to colliders otherwise they won't trigger when they're not moving
/// it's a cheap hack but works and is cheaper than switching to kinematic rigid bodies
/// </summary>

using UnityEngine;
using System.Collections;

public class KeepAwake : MonoBehaviour
{

	private Transform myTransform;

	// Use this for initialization
	void Start ()
	{
			myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		myTransform.position += Vector3.zero; 
	}
}
