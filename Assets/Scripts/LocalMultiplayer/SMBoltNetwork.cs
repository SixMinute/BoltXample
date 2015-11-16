using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SMBoltNetwork : MonoBehaviour
{
    public const ushort LAN_PORT = 27000;
	public static int gameType;
	public static int myPosition;

	public static List< List<string> > toDraw = new List< List<string> > {
		new List<string> { "horse", "cat", "dog", "hamster" },
		new List<string> { "car", "bike", "motorbike", "tractor" }
	};

	public static string GetWhatToDraw()
	{
		string _toDraw = toDraw[gameType][myPosition];
		_toDraw = _toDraw.Substring(0, 1).ToUpper() + _toDraw.Substring(1);

		SMUtils.log("gameType", gameType, "myPosition", myPosition, "toDraw", _toDraw);
		return _toDraw;
	}

	public static int NUM_CONNECTED;
}
