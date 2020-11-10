namespace TouchExample {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using SagoTouch;
    using Touch = SagoTouch.Touch;

    public class MyTouchObserver : MonoBehaviour, ISingleTouchObserver {

		#region Properties

		[System.NonSerialized]
        private Camera m_Camera;

        [System.NonSerialized]
        private Renderer m_Renderer;

        [System.NonSerialized]
        private Transform m_Transform;

        public Camera Camera {
            get { return m_Camera = m_Camera ?? CameraUtils.FindRootCamera(this.Transform); }
        }

        public Renderer Renderer {
            get { return m_Renderer = m_Renderer ?? GetComponent<Renderer>(); }
        }

        public Transform Transform {
            get { return m_Transform = m_Transform ?? GetComponent<Transform>(); }
        }

		#endregion


		#region Touch

		public bool OnTouchBegan(Touch touch) {
            Debug.Log("touched");
            Bounds bounds = this.Renderer.bounds;
            bounds.extents += Vector3.forward;
            return bounds.Contains(CameraUtils.TouchToWorldPoint(touch, Transform, Camera));
        }

        public void OnTouchCancelled(Touch touch) {
        }

        public void OnTouchEnded(Touch touch) {
            Debug.Log("touch ended");
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

		#endregion

	}
}