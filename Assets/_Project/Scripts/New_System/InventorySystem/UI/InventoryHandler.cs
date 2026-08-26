using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
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

    [Header("Gesture")]
    public float dragThreshold;
    public Vector2 dragStartPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isAnimating) return;
        dragStartPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isAnimating) return;

        float deltaX = eventData.position.x - dragStartPos.x;

        if (Mathf.Abs(deltaX) < dragThreshold) return;
        if (deltaX < 0 && isOpen) return;
        else if (deltaX > 0 && !isOpen) return;

        StartCoroutine(ToggleDrawer());
        eventData.pointerDrag = null;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
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
            drawer.anchoredPosition = Vector2.LerpUnclamped(start, target, curveValue);
            yield return null;
        }

        drawer.anchoredPosition = target;
        isAnimating = false;
    }
}
