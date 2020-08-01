using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lune;

public class TestScript : Lune.Listener {

    public GameObject loginCanvas;
    public GameObject serverListCanvas;
    public GameObject AddServerCanvas;
    public GameObject DirectConnectCanvas;
    public GameObject GlobalCanvas;
    public Text usernameText;

    void Start() {
        LuneCore.Init();

        // Lune.NetworkManager.Connect("localhost", 9000);
        Lune.EventHandler.RegisterEvents(this);
    }

    public void GoToServerList () {
        AddServerCanvas.SetActive(false);
        DirectConnectCanvas.SetActive(false);
        serverListCanvas.SetActive(true);
    }

    public void GoToAddServer () {
        serverListCanvas.SetActive(false);
        AddServerCanvas.SetActive(true);
    }

    public void GoToDirectConnect () {
        serverListCanvas.SetActive(false);
        AddServerCanvas.SetActive(true);
    }

    public override void AccountLogin(AccountLoginEvent accountLoginEvent) {
        GlobalCanvas.SetActive(true);
        usernameText.text = accountLoginEvent.GetUser().username;

        loginCanvas.SetActive(false);
        serverListCanvas.SetActive(true);
    }
}
