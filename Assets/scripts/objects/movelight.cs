using UnityEngine;
using System.Collections;

public class movelight : MonoBehaviour
{
	Transform myTransform;
	//float sweep = 0.0f;
	

	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		myTransform.Rotate(Vector3.left * (Time.deltaTime * 30.0f));
		
		//Debug.Log("rotation =" + myTransform.right.ToString());
	}
}
