using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

	public AudioFX		fx;
	public SceneMode	sceneToGo;

	public void OnClick()
	{
		//GameManager.instance.PlayFx(fx);
		SceneManager.LoadScene((int)sceneToGo);
	}
}
