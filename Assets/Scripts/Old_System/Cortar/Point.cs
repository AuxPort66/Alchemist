//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//public class Point : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IDragHandler, IDropHandler
//{

//    public Cortar cortar;

//    public Color c1 = Color.white;
//    public LineRenderer lineRenderer;

//    public void Awake()
//    {
//        cortar = transform.parent.parent.GetComponent<Cortar>();

//        lineRenderer = gameObject.AddComponent<LineRenderer>();
//        lineRenderer.widthMultiplier = 0.02f;
//        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
//        lineRenderer.positionCount = 2;
//        float alpha = 1.0f;
//        Gradient gradient = new Gradient();
//        gradient.SetKeys(
//            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c1, 1.0f) },
//            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
//        );
//        lineRenderer.colorGradient = gradient;
//    }


//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        cortar.actualdrag = this;
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        var auxpoint = gameObject.transform.position;
//        auxpoint.z = 1f;
//        lineRenderer.SetPosition(0,auxpoint);
//        var screenPoint = Input.mousePosition;
//        screenPoint.z = 1.0f;
//        lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(screenPoint));
//    }



//    public void OnDrop(PointerEventData eventData)
//    {
//        cortar.ActivateLine(this);
//    }

//    public void OnEndDrag(PointerEventData eventData)
//    {
//        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
//        lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
//    }

//}
