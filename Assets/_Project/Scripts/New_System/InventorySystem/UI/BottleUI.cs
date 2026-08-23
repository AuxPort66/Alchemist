using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

[ExecuteAlways]
public class BottleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform maskArea;
    public Vector2 visibilityPoint;

    RectTransform rt;
    RectTransform rtBottleSprite;
    RectTransform rtBottleHover;

    public float hoverOffset = 20f;
    public float hoverSpeed = 10f;
    Vector2 target;
    Vector2 originalPos;
    bool hovered;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        rtBottleSprite = transform.GetChild(0).GetComponent<RectTransform>();
        rtBottleHover = transform.GetChild(1).GetComponent<RectTransform>();
        originalPos = rtBottleSprite.anchoredPosition;
        target = originalPos;
    }

    private void Update()
    {
        bool visible = isVisible();
        rtBottleSprite.gameObject.SetActive(visible);
        rtBottleHover.gameObject.SetActive(visible);
        MoveToTarget();
    }

    private bool isVisible()
    {
        Vector3 worldPoint = rt.TransformPoint(visibilityPoint);
        Rect maskRect = GetRect(maskArea);
        return maskRect.Contains(worldPoint);
    }

    private void MoveToTarget()
    {
        if(rtBottleSprite.anchoredPosition != target)
        {
            rtBottleSprite.anchoredPosition = Vector2.Lerp(rtBottleSprite.anchoredPosition, target, Time.deltaTime * hoverSpeed);
        }
    }

    private Rect GetRect(RectTransform maskArea)
    {
        Vector3[] corners = new Vector3[4];
        maskArea.GetWorldCorners(corners);
        return new Rect(
            corners[0].x,
            corners[0].y,
            corners[2].x - corners[0].x,
            corners[2].y - corners[0].y
            );
    }

    private void OnDrawGizmos()
    {
        if (rt == null) rt = GetComponent<RectTransform>();
        Vector3 worldPoint = rt.TransformPoint(visibilityPoint);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(worldPoint, 0.2f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (InventoryManager.Instance.isDrawerAnimating() || InventoryManager.Instance.isDrawerClose()) return;
        hovered = true;
        target = originalPos + Vector2.up * hoverOffset;
        UIAudioManager.Instance.PlayBottleUpClip();
        InventoryManager.Instance.SetName(gameObject.GetComponent<InventorySlotUI>().slot.ingredient.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
        target = originalPos;

        InventoryManager.Instance.SetName("");
    }
}
