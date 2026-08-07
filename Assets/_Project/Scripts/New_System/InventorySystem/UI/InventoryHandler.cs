using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHandler : MonoBehaviour, IPointerClickHandler
{
    [Header("Drawer")]
    public RectTransform drawer;
    public Vector2 closedPos;
    public Vector2 openPos;

    [Header("Animation")]
    public float duration;
    public AnimationCurve curve;

    public bool isOpen = true;
    public bool isAnimating = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isAnimating)
        {
            StartCoroutine(ToggleDrawer());
        }
    }

    private IEnumerator ToggleDrawer()
    {
        isAnimating = true;
        Vector2 start = drawer.anchoredPosition;
        Vector2 target = isOpen ? closedPos : openPos;
        isOpen = !isOpen;

        float t = 0f;

        while(t < duration)
        {
            t += Time.deltaTime;

            float curveValue = curve.Evaluate(t / duration);
            drawer.anchoredPosition = Vector2.Lerp(start, target, curveValue);
            yield return null;
        }

        drawer.anchoredPosition = target;
        isAnimating = false;
    }
}
