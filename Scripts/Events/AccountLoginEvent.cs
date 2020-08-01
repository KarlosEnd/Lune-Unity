using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class AccountLoginEvent : Lune.Event {
        private Session session;
        private User user;

        public AccountLoginEvent (Session session) {
            this.session = session;
            this.user = session.user;
        }

        public Session GetSession () {
            return this.session;
        }

        public User GetUser () {
            return this.user;
        }
    }
}