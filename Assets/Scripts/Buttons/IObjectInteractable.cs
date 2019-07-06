public interface IObjectInteractable
{
	float countDown { get; }
	void OnClick();
	void Selected();
	void ActionAfterClick();
	void ResetCountDown();
}
