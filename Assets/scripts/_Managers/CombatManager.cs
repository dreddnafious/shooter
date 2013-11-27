using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour 
{
	public GUIText combatText;
	
	GUIText tmpText;
	
	
	private float tickRate = 2.0f;
	
	private enum CombatState
	{
		
		idle,
		incombat,
	}
	
	
	private CombatState _combatstate = CombatState.idle;
	
	private bool counting = false;
	
	
	void OnEnable()
	{
		
		Messenger.AddListener<Vector3, float, string>(EventDictionary.Instance.onDealtDamage() , OnDealtDamage);	
		
		
	}

	// Use this for initialization
	void Start () 
	{
		
		
		
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
		switch(_combatstate)
		{
		case CombatState.idle:
			break;
		case CombatState.incombat:
			InCombat();
			break;
			
		}
		
		


	}
	
	private void InCombat()
	{
		
		
		if(!counting)
		{
			//Debug.Log("InCombat Called");
			counting = true;
			StartCoroutine(Tick());
			
		}
		
		
	}
	
	void OnDealtDamage(Vector3 position, float dmg, string hittype)
	{
		
		_combatstate = CombatState.incombat;

		Vector3 newSet = Camera.main.WorldToScreenPoint(position);
		newSet.x /= Screen.width;
		newSet.y /= Screen.height;
		
		newSet.y += 0.03f;//offset the floating numbers up a bit.
		
		tmpText = (GUIText)Instantiate(combatText, newSet, Quaternion.identity);
		
		if(hittype == "hit")
		{

			tmpText.GetComponent<gText>().SetAsHit(dmg);	
			
		}
		
		if(hittype == "crit")
		{

			tmpText.GetComponent<gText>().SetAsCrit(dmg);
		}
		
		if(hittype == "glancing")
		{

			tmpText.GetComponent<gText>().SetAsGlancing(dmg);
			
		}
		
		
	}
	
	
	private IEnumerator Tick()
	{
		//broadcasts an OnTick event that interested objects can react to, once per second.
		yield return new WaitForSeconds(tickRate);
		Messenger.Broadcast(EventDictionary.Instance.onTick());
		counting = false;
		
	}
}
