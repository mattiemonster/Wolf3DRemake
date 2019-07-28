using UnityEngine;
using DG.Tweening;

public class MBOld : MonoBehaviour
{
    [Header("Button Values")]
    public Vector2 defaultSize;
    public Vector2 hoverSize;
    public float scaleTime = 0.2f;
    public float defaultXPos;

    public GameObject button;

    private RectTransform rTransform;
    private float hoverSizeXDiff;

    void Start()
    {
        defaultSize = button.GetComponent<RectTransform>().sizeDelta;
        if (hoverSize == null)
            Debug.LogError("Menu button " + gameObject.name + " has no hover size.");
        rTransform = button.GetComponent<RectTransform>();
        //hoverSizeXDiff = hoverSize.x - defaultSize.x;
        //Debug.Log(hoverSizeXDiff);
        //Debug.Log(defaultXPos);
    }

    public void OnPointerEnter()
    {
        rTransform.DOSizeDelta(hoverSize, scaleTime);
        //rTransform.DOMoveX(rTransform.sizeDelta.x - (hoverSizeXDiff / 2), scaleTime);
    }

    public void OnPointerExit()
    {
        rTransform.DOSizeDelta(defaultSize, scaleTime);
        //rTransform.DOMoveX(defaultXPos, scaleTime);
    }

}
