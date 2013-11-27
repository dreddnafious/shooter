using UnityEngine;
using System.Collections;


	
	
public class EventDictionary : MonoBehaviour
	{

    private static EventDictionary instance = null;
    public static EventDictionary Instance
		{ 
        get {
            if (instance == null)
            {
                Debug.Log("instantiate Event Dictionary");
                GameObject go = new GameObject();
                instance = go.AddComponent<EventDictionary>();
                go.name = "eventdictionary";
            }

            return instance; 
        } 
    }
		
		
	public string onProjectileHit()
	{
		return "OnProjectileHit";
		
	}	
	
	
	public string onRifleFired()
	{
		return "OnRifleFired";
		
	}
	
	public string onGrenadeLaunched()
	{
		return "OnGrenadeLaunched";
	}
	
	public string onGrenadeHit()
	{
		return "OnGrenadeHit";
	}
	
	public string onHealthZero()
	{
		return "OnHealthZero";
		
	}	
	
	public string onFiredOrb()
	{
		return "OnFiredOrb";
		
	}
	
	public string onDealtDamage()
	{	
	return "OnDealtDamage";
	}
	
	public string onDebugText()
	{
		return "OnDebugText";
	}
	public string onCapacityText()
	{
		return "OnCapacityText";
	}
	
	public string onHealthText()
	{
		return "OnHealthText";
	}
	
	public string onTick()
	{
		return "OnTick";
	}
		
}	


	

	

