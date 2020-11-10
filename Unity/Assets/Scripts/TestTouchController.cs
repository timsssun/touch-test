using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SagoTouch;

public class TestTouchController : MonoBehaviour
{
	#region Methods

	public void DisableAllTouch() {
		if (TouchDispatcher.Instance) {
			TouchDispatcher.Instance.enabled = false;
		}
	}

	public void EnableAllTouch() {
		if (TouchDispatcher.Instance) {
			TouchDispatcher.Instance.enabled = true;
		}
	}

	#endregion
}
