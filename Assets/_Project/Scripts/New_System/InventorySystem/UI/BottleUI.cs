using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

[ExecuteAlways]
public class BottleUI : MonoBehaviour
{
    public RectTransform maskArea;
    public Vector2 visibilityPoint;

    RectTransform rt;
    RectTransform rtBottleSprite;


    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        rtBottleSprite = transform.GetChild(0).GetComponent<RectTransform>();
    }

    private void Update()
    {
        rtBottleSprite.gameObject.SetActive(isVisible());
        MoveToTarget();
    }

    private bool isVisible()
    {
        Vector3 worldPoint = rt.TransformPoint(visibilityPoint);
        Rect maskRect = GetRect(maskArea);
        return maskRect.Contains(worldPoint);
    }


    private void OnDrawGizmos()
    {
        if (rt == null) rt = GetComponent<RectTransform>();
        Vector3 worldPoint = rt.TransformPoint(visibilityPoint);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(worldPoint, 0.2f);

        Vector3[] corners = new Vector3[4];
        maskArea.GetWorldCorners(corners);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLineList(corners);
    }

