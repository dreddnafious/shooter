using UnityEngine;
using System.Collections;

public class gText : MonoBehaviour
{
	Transform myTransform;
	
	float upSpeed;
	float sideSpeed;
	// Use this for initialization
	float fade = 0.0f;
	float lifetime = 1.0f;
	
	
	Vector3 sizeVec;//the beginning size of the grow animation
	Vector3 resizeVector;//the end size of the grow animation.
	
	enum HitType
	{
		None,
		Hit,
		Crit,
		Glancing
		
	}
	
	private HitType _hitType = HitType.None;
	
	
	void Start () 
	{		
		myTransform = transform;//caching the transform
		
		fade = 1.0f;//1.0 == full visibility, used in the fade call
		upSpeed = 0.25f;//determines the speed that numbers scroll up.
		
		sizeVec = new Vector3(0.2f, 0.2f, 0.0f);//the initial size of the instantiated numbers.
		myTransform.localScale = sizeVec;//applying that scale to the number
		
		
		StartCoroutine(KillNumber());//kills the number after lifetime number of seconds.
		

	}
	
	public void SetAsHit(float dmg)
	{
		//sets color, the number drawn, x and y scale, and the X axis movement speed
		SetUpText(Color.white, dmg, 0.27f, 0.27f, 0.0f);
		
		
		_hitType = HitType.Hit;
		
	}
	
	public void SetAsCrit(float dmg)
	{
		SetUpText(Color.red, dmg, 0.40f, 0.40f, 0.04f);
		
		
		_hitType = HitType.Crit;
		
	}
	
	public void SetAsGlancing(float dmg)
	{
		SetUpText(Color.yellow, dmg, 0.25f, 0.25f, -0.04f);
		
		
		_hitType = HitType.Glancing;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
			
		switch(_hitType)
		{
			case HitType.Hit:
				HandleHit();
				break;
			case HitType.Crit:
				HandleCrit();
				break;
			case HitType.Glancing:
				HandleGlancing();
				break;
		
			}			
	}
	
	
	void HandleHit()
	{
		Fade();		
		Move();
		Scale();
			
	}
	
	void HandleCrit()
	{

		Fade();
		Move();
		Scale();
			
	}
	
	void HandleGlancing()
	{
		Fade();
		Move();
		Scale();		
	
	}
	
	
	private void Fade()
	{
		fade -= (Time.deltaTime / lifetime);
		if(fade < 0.0f)
			fade = 0.0f;
		
		//this line changes the alpha by the fade amount to fade the number out.
		gameObject.guiText.material.color = new Color(guiText.material.color.r, guiText.material.color.g, 
														guiText.material.color.b, fade);
		
	}
	
	
	private void Move()
	{
		Vector3 upTick = new Vector3(sideSpeed * Time.deltaTime, upSpeed * Time.deltaTime, 0.0f);
		myTransform.Translate(upTick);		
		
	}
	
	private void Scale()
	{
		iTween.ScaleTo(gameObject, resizeVector, lifetime);
		
	}
	
	private void SetUpText(Color textColor, float dmg, float Xsize, float Ysize, float Xspeed)
	{
		guiText.enabled = false;
		guiText.richText = true;
		guiText.text = "<size=15>" + dmg.ToString() + "</size>";
		guiText.material.color = textColor;
		
		guiText.enabled = true;
		resizeVector = new Vector3(Xsize, Ysize, 0.0f);
		sideSpeed = Xspeed;
		
		
	}
	
	IEnumerator KillNumber()
	{
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);	
	}
}
