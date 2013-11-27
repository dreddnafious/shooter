using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	
	public AudioClip sound_laserRifle;
	public AudioClip sound_minorExplosion;
	public AudioClip sound_GrenadeLaunch;
	public AudioClip sound_GrenadeExplosion;
	
	void OnEnable()
	{
		Messenger.AddListener<Vector3, PlayerStats>(EventDictionary.Instance.onGrenadeHit(), OnGrenadeHit);
		Messenger.AddListener<Vector3, Vector3, PlayerStats>(EventDictionary.Instance.onGrenadeLaunched(), OnGrenadeLaunched);
		Messenger.AddListener<Vector3, Vector3, PlayerStats>(EventDictionary.Instance.onRifleFired(), OnRifleFired);
		Messenger.AddListener<Vector3>(EventDictionary.Instance.onHealthZero(), OnHealthZero);		
	}
	
	
	void OnDisable()
	{
		//Messenger.RemoveListener(EventDictionary.Instance.onRifleFired(), OnRifleFired);
		
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	
	void OnRifleFired(Vector3 position, Vector3 targetposition, PlayerStats pStats)
	{
		audio.PlayOneShot(sound_laserRifle);	
		
	}
	
	void OnGrenadeLaunched(Vector3 position, Vector3 targetposition, PlayerStats pStats)
	{
		audio.PlayOneShot(sound_GrenadeLaunch);
		
	}
	
	void OnGrenadeHit(Vector3 position, PlayerStats pStats)
	{
		audio.PlayOneShot(sound_GrenadeExplosion);
		
	}
	
	void OnHealthZero(Vector3 tmpVec)
	{
		float lastvolume = audio.volume;
		audio.volume = 1.0f;
		//Debug.Log("Boom Sound");
		audio.PlayOneShot(sound_minorExplosion);
		audio.volume = lastvolume;
		
	}
	
}
