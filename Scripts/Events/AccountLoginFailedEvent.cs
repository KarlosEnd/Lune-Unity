using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class AccountLoginFailedEvent : Lune.Event {
        private string error;

        public AccountLoginFailedEvent (string error) {
            this.error = error;
        }

        public string GetError () {
            return this.error;
        }
    }
}