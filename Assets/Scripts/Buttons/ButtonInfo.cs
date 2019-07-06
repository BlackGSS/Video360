public class ButtonInfo : ObjectDisableAfterClick
{
	public override void OnClick()
	{
		//Tras haber estado 6 seg leyendo la info, lanzamos que vuelva a reproducirse
		VRManager.instance.PlayVideo();
	}
}
