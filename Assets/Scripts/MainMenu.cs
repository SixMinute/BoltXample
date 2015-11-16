using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	bool guiEnabled = true;
	GUIStyle largeFont;

	void OnGUI ()
	{
		if(null == largeFont)
		{
			largeFont = new GUIStyle("button");
			largeFont.fontSize = 35;
		}

		GUILayout.BeginArea( new Rect(10, 0, Screen.width - 20, Screen.height - 20) );

		GUI.enabled = guiEnabled;

		if( button("Start") )
		{
			BoltLauncher.StartServer( new UdpKit.UdpEndPoint(UdpKit.UdpIPv4Address.Any, SMBoltNetwork.LAN_PORT) );
		}

		if( button("Join") )
		{
			BoltLauncher.StartClient();
		}

		GUILayout.EndArea();
	}

	bool button(string title)
	{
		GUILayout.Space(10);

		bool clicked = GUILayout.Button( title, largeFont, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) );

		if(clicked)
		{
			guiEnabled = false;
		}
		
		return clicked;
	}
}
