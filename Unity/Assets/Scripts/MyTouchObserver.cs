namespace TouchExample {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using SagoTouch;
	using Touch = SagoTouch.Touch;

	public class MyTouchObserver : MonoBehaviour, ISingleTouchObserver {

		#region Fields

		[System.NonSerialized]
		private Camera m_Camera;

		[System.NonSerialized]
		private Renderer m_Renderer;

		[System.NonSerialized]
		private Transform m_Transform;

		[System.NonSerialized]
		private Touch m_Touch;

		[System.NonSerialized]
		private List<Touch> m_Touches;

		[System.NonSerialized]
		private bool handleMultipleTouches = true;

		#endregion


		#region Properties

		public Camera Camera {
			get { return m_Camera = m_Camera ?? CameraUtils.FindRootCamera(this.Transform); }
		}

		public Renderer Renderer {
			get { return m_Renderer = m_Renderer ?? GetComponent<Renderer>(); }
		}

		public Transform Transform {
			get { return m_Transform = m_Transform ?? GetComponent<Transform>(); }
		}

		public List<Touch> Touches {
			get { return m_Touches = m_Touches ?? new List<Touch>(); }
		}

		#endregion


		#region TouchHandlers

		public bool OnTouchBegan(Touch touch) {
			if (HitTest(touch)) {
				if (handleMultipleTouches) {
					this.Touches.Add(touch);
					ReactTouchIn();
					return true;
				}
				if (m_Touch == null) {
					m_Touch = touch;
					ReactTouchIn();
					return true;
				}
			}
			return false;
		}

		public void OnTouchCancelled(Touch touch) {
			OnTouchEnded(touch);
		}

		public void OnTouchEnded(Touch touch) {
			if (handleMultipleTouches) {
				this.Touches.Remove(touch);
				if (this.Touches.Count < 1) {
					ReactTouchOut();
				}
			}
			else {
				ReactTouchOut();
				m_Touch = null;
			}
		}

		public void OnTouchMoved(Touch touch) {
		}

		#endregion


		#region Methods

		private bool HitTest(Touch touch) {
			Bounds bounds = this.Renderer.bounds;
			bounds.extents += Vector3.forward;
			return bounds.Contains(CameraUtils.TouchToWorldPoint(touch, Transform, Camera));
		}

		private void ReactTouchIn() {
			this.Transform.localScale = Vector3.one * 1.2f;
		}

		private void ReactTouchOut() {
			this.Transform.localScale = Vector3.one;
		}

		private void OnEnable() {
			if (TouchDispatcher.Instance) {
				TouchDispatcher.Instance.Add(this, 0, true);
			}
		}

		private void OnDisable() {
			if (TouchDispatcher.Instance) {
				TouchDispatcher.Instance.Remove(this);
			}
		}

		#endregion

	}
}