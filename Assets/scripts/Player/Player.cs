using UnityEngine;
using System.Collections;


/// <summary>
/// Player object that holds stats for the actual game player
/// </summary>

public class Player : MonoBehaviour
{	
	private enum PlayerState
	{		
		Idle,
		Init,
		Playing,
		Dead,
		Respawning		
	}
	
	private enum CombatState
	{		
		Rest,	
		InCombat
	}
	
	private PlayerState _pState = PlayerState.Idle;
	private CombatState _combat = CombatState.Rest;
	

	PlayerStats pStats;

	// Use this for initialization
	void Start ()
	{
		_pState = PlayerState.Init;		
	}
			
	// Update is called once per frame
	void Update ()
	{		
		switch(_pState)
		{
		case PlayerState.Init:
			Init();
			break;
		case PlayerState.Playing:
			Playing();
			break;			
		}//end switch		
	}//end Update()
		
	private void Init()
	{
		pStats = gameObject.GetComponent<PlayerStats>();
		pStats.SetUpStats();
		pStats.Stamina = 100.0f;
		pStats.currentAccuracy = 700.0f;
		pStats.RecalculateHealth();		
		
		_pState = PlayerState.Playing;
		
	}
	
	private void Playing()
	{
		
		RefreshHUD();
		
		switch(_combat)
		{
		case CombatState.Rest:
			break;
		case CombatState.InCombat:
			break;
			
		}
		
		
	}
	
	private void RefreshHUD()
	{
		
		Messenger.Broadcast<string>(EventDictionary.Instance.onCapacityText(), "Capacity: " + pStats.currentCapacity.ToString());
		Messenger.Broadcast<string>(EventDictionary.Instance.onHealthText(), "Health: " + pStats.CurrentHealth.ToString());
		
	}
	
}
