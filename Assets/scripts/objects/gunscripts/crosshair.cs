using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour
{
	
	private Texture image;
	public Texture secondCrosshair;
	public Texture firstCrosshair;
	
	
	//public bloomcontrol bloomController;
	
	
	private float ScreenMiddleWidth;//middle width accounting for image size
	private float ScreenMiddleHeight;//middle height accounting for image size

	// Use this for initialization
	void Start ()
	{
		
		image = firstCrosshair;
		//grabbing the middle of the screen adjusted for the size of the crosshair
		ScreenMiddleWidth = (Screen.width / 2) - (image.width / 2);
		ScreenMiddleHeight = (Screen.height /2) - (image.height /2);
	
	}
	
	void OnGUI()
	{
	  GUI.DrawTexture(new Rect(ScreenMiddleWidth, ScreenMiddleHeight,
				image.width, image.height), image);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void SetCrosshair(string imagename)
	{
		if(imagename == "grenade")
			
		image = secondCrosshair;
		
		
		else
			image = firstCrosshair;
		
		
		
		//grabbing the middle of the screen adjusted for the size of the crosshair
		ScreenMiddleWidth = (Screen.width / 2) - (image.width / 2);
		ScreenMiddleHeight = (Screen.height /2) - (image.height /2);
	
		
	}
	
}
