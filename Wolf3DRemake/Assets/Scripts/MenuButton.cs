using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuButton : MonoBehaviour {

	public Color hoverColour;
	public Vector2 startSize = new Vector2(250, 50);
	public Vector2 endSize = new Vector2(350, 50);
	new RectTransform transform;
	Image image;

	// Use this for initialization
	void Start () {
		DOTween.Init();
		transform = GetComponent<RectTransform>();
		image = GetComponent<Image>();
	}
	
	public void MouseEnter()
	{
		transform.DOSizeDelta(endSize, 0.5f, true);
		image.DOColor(hoverColour, 0.5F);
	}

	public void MouseExit()
	{
		transform.DOSizeDelta(startSize, 0.5f, true);
		image.DOColor(Color.white, 0.5F);
	}
}
