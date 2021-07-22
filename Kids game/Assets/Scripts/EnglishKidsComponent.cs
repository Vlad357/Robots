using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class EnglishKidsComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Camera MainCamera;
    public Transform Parent;
    public EnglishKidsAudio AudioManager;

    private Vector3 _dislocation;
    private Vector3 _startPosition;

    public void FalseAnser()
    {
        transform.position = _startPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        TakeComponent(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        HoldComponent(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ReleaseComponent();
    }

    private void TakeComponent(PointerEventData eventData)
    {
        AudioManager.Pick();
        _startPosition = transform.position;
        _dislocation = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
        Parent = transform.parent;
        transform.SetParent(Parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.DORotate(new Vector3(0, 0, 0), 0.5f);
    }

    private void HoldComponent(PointerEventData eventData)
    {
        Vector3 ComponentNewPosition = MainCamera.ScreenToWorldPoint(eventData.position);
        ComponentNewPosition.z = 0;
        transform.position = ComponentNewPosition + _dislocation;
    }

    private void ReleaseComponent()
    {
        transform.SetParent(Parent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
