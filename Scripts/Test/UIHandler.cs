using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lune;

public class UIHandler : Lune.Listener {

    public InputField emailInput;
    public InputField passwordInput;
    public Text ErrorText;

    public void Start () {
        EventHandler.RegisterEvents(this);
    }

    public void Login () {
        string email = emailInput.text;
        string password = passwordInput.text;

        ErrorText.text = "";

        GetComponent<AuthClient>().Login(email, password);
    }

    public override void AccountLoginFailed(AccountLoginFailedEvent accountLoginFailedEvent) {
        ErrorText.text = accountLoginFailedEvent.GetError();
    }

}
