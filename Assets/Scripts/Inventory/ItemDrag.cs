using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    [NonSerialized] public bool IsInsideSlot;
    private bool _dragOncePerFrame = true;

    #region Initter
    private static UnityEvent _initAll = new();
    private void Awake()
    {
        _initAll.AddListener(OnInitAll);
    }
    public static void InitAll()
    {
        _initAll.Invoke();
    }
    private void OnInitAll()
    {
        _canvas = ActiveCanvas.Canvas;
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    #endregion

    public void Init()
    {
        _canvas = ActiveCanvas.Canvas;
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        _dragOncePerFrame = true;
    }

    #region Drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = .6f;
        transform.SetAsLastSibling();

        if (IsInsideSlot)
        {
            transform.parent.GetComponent<Slot>().ItemInside = null;
            transform.SetParent(transform.parent.parent.parent, true);
            IsInsideSlot = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(_dragOncePerFrame)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
            _dragOncePerFrame = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }
    #endregion
}