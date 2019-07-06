using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioFX		{ CLICK = 0, PLAY }
public enum SceneMode	{ MENU = 0, VRMODE }

//GameManager sigue un patron de programacion Singleton
public class GameManager : MonoBehaviour
{
	private static GameManager	_instance; //variable instancia de la clase
	private AudioClip[]			_arrayFx;
	private AudioSource			_audioSource = null;

	//Creamos con un get una instancia del GameManager
	public static GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject newGameObj = new GameObject("Game Manager");
				_instance = newGameObj.AddComponent<GameManager>();
							newGameObj.AddComponent<AudioSource>();

				DontDestroyOnLoad(newGameObj);
			}

			return _instance;
		}
	}

	//Inicializamos el componente AudioSource
	public void Init()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.loop = false;
		_audioSource.playOnAwake = false;

		_arrayFx = Resources.LoadAll<AudioClip>("Audios/FX/");
	}

	//Funcion para reproducir cualquier sonido
	public void PlayFx(AudioFX fx)
	{
		if (_audioSource == null)
			Init();

		if (_audioSource.isPlaying)
			_audioSource.Stop();

		_audioSource.PlayOneShot(_arrayFx[(int) fx]);
	}
}
