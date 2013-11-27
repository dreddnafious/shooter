using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
	
	public float MaxHealth{get; set;}
	public float CurrentHealth{get; set;}
	public float MoveRate{get; set;}
	public float CurrentMoveRate{get; set;}
	public float Damage{get; set;}
	//public float Armor{get; set;}
	public float Shield{get; set;}
	
	
	public float Accuracy{get; set;}
	public float Cruelty{get; set;}
	public float Swiftness{get;set;}
	public float Capacity{get; set;}
	public float Power{get; set;}
	public float Zeal{get; set;}
	public float Fortitude{get; set;}
	public float Stamina{get; set;}
	public float Defiance{get; set;}
	public float Armor{get; set;}
	
	public int Level{get; set;}
	
	public float HealthRegen{get; set;}
	public float CapacityRegen{get; set;}
	public float ArmorReduction{get;set;}
	public float DefianceReduction{get;set;}

	public float currentAccuracy{get; set;}
	public float currentCruelty{get; set;}
	public float currentSwiftness{get;set;}
	public float currentCapacity{get; set;}
	public float currentPower{get; set;}
	public float currentZeal{get; set;}
	public float currentFortitude{get; set;}
	public float currentStamina{get; set;}
	public float currentDefiance{get; set;}
	public float currentArmor{get; set;}
	
	//public float currentMoveRate{get;set;}
	

	
	public float currentHealthRegen{get; set;}
	public float currentCapacityRegen{get; set;}
	public float currentArmorReduction{get;set;}
	public float currentDefianceReduction{get;set;}
	
	
	public float CrueltyModifier{get;set;}
	
	
	
	
	//experience system.
	public float currentExperience{get;set;}
	public float experienceToNextLevel{get;set;}
	public int level{get;set;}
	
	
/*	
Accuracy - the base chance to crit is derived from a player's accuracy stat.
Cruelty - increases the percentage of crit damage a player deals.
Swiftness - increases a player's rate of fire.
Capacity - a player’s nanite pool is based on his power and level.
Power - increases the damage and healing of nano-based effects.
Zeal - increases the damage of physical based attacks.
Fortitude - reduces a player’s chance to be crit, determines a player's chance to cause a blow to be a glancing blow.
Stamina - A players health pool is determined via both level and stamina.
Defiance - increases the chance a player will end a negative status effect early. Reduces nanite based damage by a percentage.
Armor - reduces the physical damage a player receives by a percentage.
*/

	// Use this for initialization
	void Start ()
	{//using default values for testing, should pull from equipment script
		//SetUpStats();
		
	}
	
	void OnEnable()
	{
		
		Messenger.AddListener(EventDictionary.Instance.onTick(), OnTick);
			
	}	
	

	public void SetUpStats()
	{
		Accuracy = 50f;
		Cruelty = 50f;
		Swiftness = 50f;
		Capacity = 150f;
		Power = 0f;
		Zeal = 0f;
		
		Fortitude = 50f;
		currentFortitude = Fortitude;
		Stamina = 70f;
		Defiance = 50f;
		Armor = 300f;	
		
		Level = 10;
		
		MaxHealth = Stamina * 5f;
		CurrentHealth = MaxHealth;
		
		ArmorReduction = Armor / (100f * Level);
		currentArmorReduction = ArmorReduction;
		
		DefianceReduction = Defiance / (100f * Level);
		currentDefianceReduction = DefianceReduction;
		
		HealthRegen = 0.01f;
		currentHealthRegen = HealthRegen;
		
		CapacityRegen = 0.25f;
		currentCapacityRegen = CapacityRegen;
		
		currentCapacity = Capacity;
		
		CrueltyModifier = Cruelty / (20 * Level);
		
		//Debug.Log("SetupStats Called CurrentHealth = " + CurrentHealth);
		
		MoveRate = 5.0f;
		CurrentMoveRate = MoveRate;
		
	}
	
	public float RecalculateHealth()
	{
		MaxHealth = Stamina * 5f;
		CurrentHealth = MaxHealth;
		Debug.Log("RecalculateHealth Called CurrentHealth = " + CurrentHealth);
		return MaxHealth;
		
	}
	
	private void CapacityTick()
	{
		currentCapacity += (Capacity * currentCapacityRegen);
		if (currentCapacity > Capacity)
			currentCapacity = Capacity;
		
	}
	
	private void OnTick()
	{
		//this event is called once per second by the combat manager while in combat.
		CapacityTick();
		//Debug.Log("capacity tick called, currentCapacity = " + currentCapacity.ToString());
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	
	
	
}
