using System.Collections;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IObjectInteractable
{
	protected float			_countdown;
	protected float			_timeLimit = 6, _cooldown = 1;
	protected Collider		_collider;
	protected MeshRenderer	_mesh;

	public float countDown { get { return _countdown; } }

	protected void Awake()
	{
		_collider	= GetComponent<Collider>();
		_mesh		= GetComponent<MeshRenderer>();
	}

	public void Selected()
	{
		_countdown += Time.deltaTime;

		//Esperamos un tiempo para realizar la accion
		if (_countdown >= _timeLimit)
		{
			ResetCountDown();
			OnClick();
			ActionAfterClick();
		}
		else
			Draw();

	}

	public virtual void OnClick()
	{
		
	}

	public virtual void ActionAfterClick()
	{

	}

	//Resetear el contador y vuelve a pintar todo el botón
	public void ResetCountDown()
	{
		_countdown = 0;
		Draw();
	}

	protected IEnumerator EnableAfterSeconds()
	{
		_collider.enabled	= false;
		_mesh.enabled		= false;

		yield return new WaitForSeconds(_cooldown);

		_collider.enabled	= true;
		_mesh.enabled		= true;
	}

	public virtual void Draw()
	{
		_mesh.material.SetFloat("_Cutoff", Mathf.Clamp(_countdown, 0.0001f, 1f));
	}

}
