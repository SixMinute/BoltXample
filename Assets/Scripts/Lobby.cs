using UnityEngine;
using System.Collections;
using System.Linq;

public class Lobby : MonoBehaviour
{
	bool guiEnabled = true;
	GUIStyle largeFont;

	void OnGUI()
	{
		if(null == largeFont)
		{
			largeFont = new GUIStyle("button");
			largeFont.fontSize = 35;
		}

		GUILayout.BeginArea( new Rect(10, 0, Screen.width - 20, Screen.height - 20) );

		GUI.enabled = guiEnabled;

		if( button("Back") )
		{
			if(BoltNetwork.isConnected)
			{
				BoltLauncher.Shutdown();
				Application.LoadLevel("MainMenu");
			}
		}

		GUILayout.Space(10);

		GUILayout.TextArea(
			( BoltNetwork.isServer ?
				( "clients:\n" + SMUtils.toString( "\n", BoltNetwork.clients.ToArray() ) ) :
				( "server: " + BoltNetwork.server ) ).Replace("Connection ", ""),
			largeFont,
			GUILayout.ExpandWidth(true),
			GUILayout.ExpandHeight(true)
		);

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
