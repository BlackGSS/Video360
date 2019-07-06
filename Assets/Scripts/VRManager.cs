using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class TimeEvent
{
	public float			time;
	public GameObject		obj;
}
public class VRManager : MonoBehaviour
{
	public List<TimeEvent>	listEvents = new List<TimeEvent>();

	[SerializeField]
	private Slider			_slider;
	public static VRManager instance;
	public Material			playMaterial, pauseMaterial;
	public double			pauseTime = 0;

	private double			_totalTime, _currentTime;
	private VideoPlayer		_vPlayer;
	public VideoPlayer		vPlayer	{ get { return _vPlayer; } }
	private byte			_currentEvent;


	private void Awake()
	{
		UnityEngine.XR.XRSettings.enabled = true;

		if (instance == null)
			instance = this;

		print(UnityEngine.XR.XRSettings.isDeviceActive);
	}

	// Use this for initialization
	void Start()
	{
		_vPlayer = GetComponent<VideoPlayer>();
		_totalTime = _vPlayer.clip.length;
		_currentEvent = 0;

		//Ordeno segun el tiempo de reproduccion los eventos que van a suceder
		listEvents.Sort((i, j) => i.time.CompareTo(j.time));

		ReloadVideo();
	}

	public void PlayVideo()
	{
		if (_vPlayer.isPlaying)
		{
			//Pausa el tiempo
			pauseTime = vPlayer.time;
			_vPlayer.Pause();
		}
		else
		{
			//Si se llama y está pausado, vuelve a reproducirlo
			_vPlayer.Play();
		}
	}

	//Poner en play en un tiempo determinado
	public void PlayVideo(float time)
	{
		PlayVideo();
		_vPlayer.time = time;
		pauseTime = 0;
	}

	//Reiniciar el video
	public void ReloadVideo()
	{
		_vPlayer.Stop();
		_currentEvent = 0;

		for (int i = 0; i < listEvents.Count; i++)
		{
			listEvents[i].obj.SetActive(false);
		}

		PlayVideo(0);
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(pauseTime);

		if (_vPlayer.isPlaying)
		{
			_currentTime = _vPlayer.time;
			GetCurrentTime();
			_slider.value = (float)(_currentTime / _totalTime);
		}
	}

	private void GetCurrentTime()
	{
		if (listEvents.Count > 0 && listEvents.Count > _currentEvent)
		{
			if (listEvents[_currentEvent].time <= _currentTime)
			{
				listEvents[_currentEvent].obj.SetActive(true);
				_currentEvent++;
				_vPlayer.Pause();
			}
		}
	}
}