using UnityEngine;
using System.Collections;

public class GUI_Manager : MonoBehaviour
{
	
	public GUIText debugText;
	private Vector3 dTextPos;
	
	public GUIText capacityText;
	private Vector3 cTextPos;
	
	public GUIText healthText;
	private Vector3 hTextPos;
	
	private Vector3 textScale;
	
	
	private enum HUDStates
	{
		Idle,	
		InGame
		
		
	}
	
	HUDStates _hudstate = HUDStates.InGame;

	// Use this for initialization
	void Start ()
	{
		//locks the cursor in place and hides it.
		Screen.lockCursor = true;
		Screen.showCursor = false;
		
		
		textScale = new Vector3(0.45f, 0.45f, 0.0f);
		
		
		dTextPos = new Vector3(0.05f, 0.05f, 0.0f);
		debugText = (GUIText)Instantiate(debugText, dTextPos, Quaternion.identity);
		debugText.transform.localScale = textScale;
		debugText.enabled = false;
		
		cTextPos = new Vector3(0.05f, 0.10f, 0.0f);
		capacityText = (GUIText)Instantiate(debugText, cTextPos, Quaternion.identity);
		capacityText.transform.localScale = textScale;
		capacityText.material.color = Color.blue;
		capacityText.enabled = false;
		
		
		hTextPos = new Vector3(0.05f, 0.15f, 0.0f);
		healthText = (GUIText)Instantiate(debugText, hTextPos, Quaternion.identity);
		healthText.transform.localScale = textScale;
		healthText.material.color = Color.yellow;
		healthText.enabled = false;
		
	}
	
	void OnEnable()
	{
		
		Messenger.AddListener<string>(EventDictionary.Instance.onDebugText(), OnDebugText);
		Messenger.AddListener<string>(EventDictionary.Instance.onCapacityText(), OnCapacityText);
		Messenger.AddListener<string>(EventDictionary.Instance.onHealthText(), OnHealthText);
			
	}	
	

	
	// Update is called once per frame
	void Update ()
	{
		
		switch(_hudstate)
		{
		case HUDStates.Idle:
			break;
		case HUDStates.InGame:
			InGame();
			break;
			
			
		}
	
	}
	
	private void InGame()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Screen.lockCursor = false;
			Screen.showCursor = true;
			
		}
		
	}
	
	private void OnDebugText(string text)
	{
		debugText.text = text;
		
		if(!debugText.enabled)
		debugText.enabled = true;
		

		
	}
	
	private void OnCapacityText(string text)
	{
		capacityText.text = text;
		
		if(!capacityText.enabled)
		capacityText.enabled = true;		
		
	}
	
		private void OnHealthText(string text)
	{
		healthText.text = text;
		
		if(!healthText.enabled)
		healthText.enabled = true;		
		
	}
	
}
