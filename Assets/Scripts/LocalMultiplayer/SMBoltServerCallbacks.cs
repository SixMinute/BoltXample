using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

[BoltGlobalBehaviour(BoltNetworkModes.Host)]
public class SMBoltServerCallbacks : Bolt.GlobalEventListener
{
	public static event Action OnStartDone;

    public override void BoltStartDone()
    {
		SMBoltNetwork.myPosition = 0;

        BoltNetwork.EnableLanBroadcast();

		BoltNetwork.LoadScene("Lobby");

		sendStartResult();
	}

	public override void EntityAttached(BoltEntity entity)
	{
//		SMUtils.log("entity attached:", entity, entity.isOwner);
	}

	void sendStartResult()
	{
		if(null != OnStartDone)
		{
			OnStartDone.Invoke();
			OnStartDone = null;
		}
	}
}
