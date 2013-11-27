using UnityEngine;
using System.Collections;

public class movespotlight : MonoBehaviour
{
	Transform myTransform;
	//float sweep = 0.0f;
	Vector3 transVector;
	
	private enum SweepState
	{
		Idle,
		MovingLeft,
		MovingRight
		
	}
	
	private SweepState _state = SweepState.Idle;

	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
		transVector = new Vector3(1.0f, 0.0f, 0.0f);
		//transVector.x = myTransform.position.x;
		//transVector.y = 0.0f;
		//transVector.z = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (myTransform.position.x <= -60.0f)
		{
			
			//transVector.x = transVector.x + Time.deltaTime;
			//transVector.y = transVector.y;
			//transVector.z = transVector.z;
			
			//myTransform.Translate(transVector);
		//myTransform.Rotate(Vector3.left * (Time.deltaTime * 30.0f));
		
		Debug.Log("-60 fired" + myTransform.position.x.ToString());
			_state = SweepState.MovingRight;
			
		}
		
		if (myTransform.position.x >= 60.0f)
		{
			//transVector.x = transVector.x - Time.deltaTime;
			//transVector.y = transVector.y;
			//transVector.z = transVector.z;
			
			//myTransform.Translate(transVector);
		//myTransform.Rotate(Vector3.left * (Time.deltaTime * 30.0f));
		
		//Debug.Log("rotation =" + myTransform.right.ToString());
			Debug.Log("+60 fired" + myTransform.position.x.ToString());
			_state = SweepState.MovingLeft;
			
		}
		
		Move();
		
	}
	
	void Move()
	{
		switch(_state)
		{
		case SweepState.MovingLeft:
			transVector.x = -15.0f * Time.deltaTime;
			Debug.Log("light should be moving left by " + transVector.x.ToString());
			break;
		case SweepState.MovingRight:
			transVector.x = 15.0f * Time.deltaTime;
			Debug.Log("light should be moving right by " + transVector.x.ToString());
			break;
			
		}
		
		myTransform.Translate(transVector);
		
		Debug.Log("translationvector x is" + transVector.x.ToString() + "translationvector y is" + transVector.y.ToString() +
		"translationvector z is" + transVector.z.ToString());
		
	}
}
