using UnityEngine;
using System.Collections;

public class fpsraycast : MonoBehaviour
{
	
	
	public GameObject partWeaponEffect;
	private GameObject weaponEffectinstance;

    public Texture image;
	
	private float ScreenMiddleWidth;
	private float ScreenMiddleHeight;
	private float WidthOffset;
	private float HeightOffset;

void OnGUI()
{
  GUI.DrawTexture(new Rect(ScreenMiddleWidth, ScreenMiddleHeight,
			image.width, image.height), image);
}


	//public Transform target1, target2;
	void Start()
	{
		ScreenMiddleWidth = (Screen.width / 2) - (image.width / 2);
		ScreenMiddleHeight = (Screen.height /2) - (image.height /2);
		
		Screen.showCursor = false;	
		//Input.mousePosition
	}
	
	void Update ()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 rayPos = new Vector3(Screen.width / 2, Screen.height /2, 0.0f);
			
			Ray ray = Camera.main.ScreenPointToRay(rayPos);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log("Object hit = " + hit.collider.gameObject.name.ToString()
					+ "object x = " + hit.point.x.ToString()
					+ "object y = " + hit.point.y.ToString());
				
				//Debug.DrawLine(ray.origin, hit.point);
				
				Instantiate(partWeaponEffect, new Vector3(hit.point.x, hit.point.y, hit.point.z),
					Quaternion.identity);
				
			} //end if you hit something
			
		}//end if the mouse button is down
		
	}//end update loop
	
}//end class
