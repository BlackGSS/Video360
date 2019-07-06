public class ButtonReload : ObjectWithCooldown
{
	public override void Draw()
	{
		_timeLimit = 1;
		base.Draw();
	}

	public override void OnClick()
	{
		VRManager.instance.ReloadVideo();
	}
}
