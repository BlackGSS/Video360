using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private IObjectInteractable _target;

	private void Update()
	{
		RaycastHit _hit;
		if (Physics.Raycast(transform.position, transform.forward, out _hit, Mathf.Infinity))
		{
			IObjectInteractable objectHit = _hit.collider.GetComponent<IObjectInteractable>();
			if (objectHit != _target)
			{
				if (_target != null)
					_target.ResetCountDown();

				_target = objectHit;
			}

			_target.Selected();

		}
		else
		{
			if (_target != null)
			{
				_target.ResetCountDown();
				_target = null;
			}
		}
	}

}
