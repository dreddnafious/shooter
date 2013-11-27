using UnityEngine;
using System.Collections;

public class bloomcontrol : MonoBehaviour 
{
	private enum BloomStates
	{
		
		Growing,
		Shrinking,
		Static	
	}
	
	private BloomStates _bloomstate = BloomStates.Static;
	
	
	private float currentBloom = 0.0f;

	private float bloomStep = 2.5f;
	private float bloomStepSize = 1.5f;
	private float recoverStep = 1.0f;
	private float recoverStepSize = 2.0f;
	
	private float fireTime = 0.0f;
	private float recoveryTime = 0.0f;
	
	private float bloomPerSecond = 9.0f;
	private float bloomRecoveyPerSecond = 10.0f; 
	private float maxBloom = 18.0f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(_bloomstate)
		{
		case BloomStates.Static:
			//do nothing
			break;
		case BloomStates.Growing:
			Grow();
			break;
		case BloomStates.Shrinking:
			Shrink();
			break;
	
		}
	}
	

	
	void Grow()
	{//this call adds up the amount of time the weapons been fired
	 //if fireTime is less than bloomstep, then it adds the requested amount of bloom
		// if it's over bloomStep , then it adds the bloom multiplied by the bloomStepSize modifier.
		
		fireTime += Time.deltaTime;
		recoveryTime = 0.0f;
		
		if(currentBloom < maxBloom)
		{
		
			if(fireTime <= bloomStep)
			{
				currentBloom += (bloomPerSecond * Time.deltaTime);
			}
		
			if(fireTime > bloomStep)
			{
				currentBloom += ((bloomPerSecond * bloomStepSize) * Time.deltaTime);
			}
		
		}
		
	}
	
	/* This call shrinks the bloom amount over time. If you are in shrink for less than the recoverystep it
	 * reduces the bloom by the requested amount. Once you exceed the recoverstep time it recovers at the normal rate times 
	 * the recovery step size. This makes recovery faster after a specified amount of time. */
	void Shrink()
	{
		
		fireTime = 0.0f;
		recoveryTime += Time.deltaTime;
		
		if(recoveryTime <= recoverStep)
		{
			currentBloom -= bloomRecoveyPerSecond * Time.deltaTime;	
		}
		
		if(recoveryTime > recoverStep)
		{
			currentBloom -= ((bloomRecoveyPerSecond * recoverStepSize) * Time.deltaTime);	
		}
		
		currentBloom -= bloomRecoveyPerSecond * Time.deltaTime;
		
		if(currentBloom < 0.0f)
		{
			currentBloom = 0.0f;
			_bloomstate = BloomStates.Static;
		}
		
	}
	
	void Reset()
	{
		currentBloom = 0.0f;	
	}
	
	
	/*interface******************************************************************************
	 * *************************************************************************************/
	
	public void SetInit(float bloompersecond, float bloomrecoverypersecond, float maxbloom,
						float bloomstep, float bloomstepsize, float recoverstep, float recoverstepsize)
	{
		bloomPerSecond = bloompersecond;
		bloomRecoveyPerSecond = bloomrecoverypersecond;
		maxBloom = maxbloom;
		bloomStep = bloomstep;
		bloomStepSize = bloomstepsize;
		recoverStep = recoverstep;
		recoverStepSize = recoverstepsize;
		
		Reset();
			
	}
	
	public void SetGrow()
	{
		_bloomstate = BloomStates.Growing;	
		
	}
	
	public void SetShrink()
	{
		_bloomstate = BloomStates.Shrinking;	
	}
	
	public float GetBloom()
	{
		return currentBloom; 
			
	}
	
	public bool IsGrowing()
	{
		return _bloomstate == BloomStates.Growing;	
		
	}
	
}
