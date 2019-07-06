public class ObjectWithCooldown : ObjectInteractable
{
	public override void ActionAfterClick()
	{
		StartCoroutine(EnableAfterSeconds());
	}
}
