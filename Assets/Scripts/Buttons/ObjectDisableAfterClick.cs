public class ObjectDisableAfterClick : ObjectInteractable
{
	public override void ActionAfterClick()
	{
		gameObject.SetActive(false);
	}
}
