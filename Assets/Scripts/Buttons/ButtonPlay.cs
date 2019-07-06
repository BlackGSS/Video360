public class ButtonPlay : ObjectWithCooldown
{
	public override void Draw()
	{
		_timeLimit = 1.5f;
		if (!VRManager.instance.vPlayer.isPlaying)
		{
			_mesh.material = VRManager.instance.playMaterial;
		}
		else
		{
			_mesh.material = VRManager.instance.pauseMaterial;
		}

		base.Draw();
	}

	public override void OnClick()
	{
		if (VRManager.instance.pauseTime == 0)
		{
			VRManager.instance.PlayVideo();
		}
		else
		{
			if (!VRManager.instance.vPlayer.isPlaying)
			{
				VRManager.instance.PlayVideo((float)VRManager.instance.pauseTime);
			}
		}

		
	}
}
