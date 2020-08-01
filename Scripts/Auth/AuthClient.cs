using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json;

namespace Lune {
    public class AuthClient : MonoBehaviour {
        public string url;
        private Session session;
        private User user;

        public void Login (string email, string password) {
            StartCoroutine(LoginEnumerator(email, password));
        }
        
        IEnumerator LoginEnumerator (string email, string password) {
            var request = new UnityWebRequest(this.url + "/login", "POST");
            string body = "{\"email\":\"" + email + "\", \"password\": \"" + password + "\"}";
            byte[] bodyRaw = Encoding.UTF8.GetBytes(body);

            request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            

            yield return request.SendWebRequest();
            ParseResponse(request.downloadHandler.text);
        }

        private void ParseResponse (string response) {
            Session result = JsonConvert.DeserializeObject<Session>(response);
            if (result.success) {
                this.Login(result);
            } else {
                AccountLoginFailedEvent ev = new AccountLoginFailedEvent(result.error);
                EventHandler.AccountLoginFailed(ev);
            }
        }

        private void Login (Session session) {
            this.session = session;
            this.user = this.session.user;

            AccountLoginEvent ev = new AccountLoginEvent(session);
            EventHandler.AccountLogin(ev);
        }

        public User GetUser () {
            return this.user;
        }

        public Session GetSession () {
            return this.session;
        }
    }
}