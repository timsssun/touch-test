namespace TouchExample {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using SagoTouch;
    using Touch = SagoTouch.Touch;

    public class MyTouchObserver : MonoBehaviour, ISingleTouchObserver {

        public bool OnTouchBegan(Touch touch) {
            Debug.Log("touched");
            return false;
        }

        public void OnTouchCancelled(Touch touch) {
        }

        public void OnTouchEnded(Touch touch) {
        }

        public void OnTouchMoved(Touch touch) {
        }

        void OnEnable() {
            if (TouchDispatcher.Instance) {
                TouchDispatcher.Instance.Add(this, 0, true);
            }
        }

        void OnDisable() {
            if (TouchDispatcher.Instance) {
                TouchDispatcher.Instance.Remove(this);
            }
        }

    }
}