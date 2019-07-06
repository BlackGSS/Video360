using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.XR.XRSettings.enabled = false;
	}

	public AudioFX buttonClick, buttonPlay;

	[SerializeField]
	private GameObject _portraitCanvas, _landscapeCanvas;

	private void Update()
	{
		bool orientation = (Screen.width < Screen.height);

		_portraitCanvas.SetActive(orientation);
		_landscapeCanvas.SetActive(!orientation);

	}

	public void ButtonChangeScene()
	{
		ButtonFxClick(buttonPlay);
		SceneManager.LoadScene((int) SceneMode.VRMODE);
	}

	public void ButtonClick()
	{
		ButtonFxClick(buttonClick);
	}

	public void ButtonFxClick(AudioFX fx = AudioFX.CLICK)
	{
		GameManager.instance.PlayFx(fx);
	}

	public void ButtonExit()
	{
		Application.Quit();
	}
}
