using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lune {
    public class Event {

        private bool cancelled = false;

        public void Emit (object obj) { }

        public bool isCancelled() {
            return this.cancelled;
        }

        public void setCancelled (bool result) {
            this.cancelled = result;
        }
    }
}