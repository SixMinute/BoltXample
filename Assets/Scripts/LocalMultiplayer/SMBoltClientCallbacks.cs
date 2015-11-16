using UnityEngine;
using System.Collections;
using System;

[BoltGlobalBehaviour(BoltNetworkModes.Client)]
public class SMBoltClientCallbacks : Bolt.GlobalEventListener
{
    public static event Action<bool> OnConnectResult;
    private bool _continueSearching;

    public override void BoltStartDone()
    {
        BoltNetwork.EnableLanBroadcast();
        // BoltNetwork.SetHostInfo(Config.GAMENAME, null);

        // BoltNetwork.Connect( new UdpKit.UdpEndPoint(UdpKit.UdpIPv4Address.Any, SMBoltNetwork.LAN_PORT) );

        _continueSearching = true;
        StartCoroutine( startSearching() );
    }

    IEnumerator startSearching()
    {
        yield return null;

        while(_continueSearching)
        {
            yield return new WaitForSeconds(1.0f);

            //if we have a session then auto-connect
            if(BoltNetwork.SessionList.Count > 0)
            {
                foreach(var s in BoltNetwork.SessionList)
                {
                    BoltNetwork.Connect(s.Value.LanEndPoint);

                    _continueSearching = false;
                    yield break;
                }
            }
        }
    }

	public override void Disconnected(BoltConnection connection)
	{
		base.Disconnected(connection);

		BoltLauncher.Shutdown();
		Application.LoadLevel("MainMenu");
	}

    public override void ConnectFailed(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
    {
		base.ConnectFailed(endpoint, token);

        sendResult(false);
    }

    public override void Connected(BoltConnection connection)
	{
		base.Connected(connection);

        sendResult(true);
    }

    void sendResult(bool success)
    {
        if(null != OnConnectResult)
        {
            OnConnectResult.Invoke(success);
            OnConnectResult = null;
        }
    }
}
