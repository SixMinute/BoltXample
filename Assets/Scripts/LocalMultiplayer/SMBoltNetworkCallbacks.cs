using UnityEngine;
using System.Collections;

[BoltGlobalBehaviour]
public class SMBoltNetworkCallbacks : Bolt.GlobalEventListener
{
	public override void BoltShutdownBegin(Bolt.AddCallback registerDoneCallback)
	{
		SMUtils.log("bolt shutdown begin");
	}
}
