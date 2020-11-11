namespace TouchExample {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using SagoTouch;
	using Touch = SagoTouch.Touch;

	public class MyTouchArea : MonoBehaviour {
		#region Fields

		[System.NonSerialized]
		private TouchArea m_TouchArea;

		[System.NonSerialized]
		private TouchAreaObserver m_TouchAreaObserver;

		[System.NonSerialized]
		private Transform m_Transform;

		#endregion


		#region Properties

		public TouchArea TouchArea {
			get { return m_TouchArea = m_TouchArea ? m_TouchArea : GetComponent<TouchArea>(); }
		}

		public TouchAreaObserver TouchAreaObserver {
			get { return m_TouchAreaObserver = m_TouchAreaObserver ? m_TouchAreaObserver : GetComponent<TouchAreaObserver>(); }
		}

		public Transform Transform {
			get { return m_Transform = m_Transform ? m_Transform : GetComponent<Transform>(); }
		}

		#endregion


		#region Methods

		private void OnEnable() {
			this.TouchAreaObserver.TouchUpDelegate += OnReactTouchUp;
			this.TouchAreaObserver.TouchDownDelegate += OnReactTouchDown;
		}

		private void OnDisable() {
			this.TouchAreaObserver.TouchUpDelegate -= OnReactTouchUp;
			this.TouchAreaObserver.TouchDownDelegate -= OnReactTouchDown;
		}

		private void OnReactTouchUp(TouchArea touchArea, Touch touch) {
			this.Transform.localScale = Vector3.one;
		}

		private void OnReactTouchDown(TouchArea touchArea, Touch touch) {
			this.Transform.localScale = Vector3.one * 0.8f;
		}

		public void DisableTouchArea() {
			this.TouchArea.enabled = false;
		}

		public void EnableTouchArea() {
			this.TouchArea.enabled = true;
		}

		#endregion

	}
}
