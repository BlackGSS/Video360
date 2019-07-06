public class ButtonExit : ObjectInteractable
{
	public override void Draw()
	{
		_timeLimit = 1;
		base.Draw();
	}

	public override void OnClick()
	{
		GetComponent<ChangeScene>().OnClick();
	}
}
