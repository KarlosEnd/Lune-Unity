using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lune;

public class TestScript : Lune.Listener {

    void Start() {
        Lune.NetworkManager.Init();
        Lune.NetworkManager.Connect("localhost", 9000);

        Lune.EventHandler.RegisterEvents(this);
    }

    public override void PacketReceive (PacketReceiveEvent packetReceiveEvent) {
        Debug.Log(packetReceiveEvent.GetPacket().strings[0]);
    }

    public override void ServerConnect (ServerConnectEvent serverConnectEvent) {
        Debug.Log("Te has conectado al servidor: " + serverConnectEvent.GetAddress() + ":" + serverConnectEvent.GetPort());
    }

    public override void ServerDisconnect (ServerDisconnectEvent serverDisconnectEvent) {
        Debug.Log("Has sido desconectado del servidor: " + serverDisconnectEvent.GetReason());
    }
}
