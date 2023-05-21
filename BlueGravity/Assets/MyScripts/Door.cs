using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MyScripts;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Place place = Place.Shop;
    [SerializeField] private Door destinationDoor;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private LayerMask playerLayer;
    private Fader _fader;

    private void Start()
    {
        var parent = transform.parent;
        _fader = parent.transform.parent.GetComponent<Fader>();
        _fader.OnFadeOutFinished += ActivateCamera;
    }


    private void Update()
    {
        if (collider.IsTouchingLayers(playerLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(_fader.FadeOutAndIn(destinationDoor.transform));
            }
        }
    }

    private void ActivateCamera(Transform destination)
    {
        if (place == destination.GetComponent<Door>().GetPlace()) return;

        Debug.Log(place.ToString());
        Debug.Log(destinationDoor.GetPlace());

        CameraManager.Instance.PickCamera(place).SetActive(false);
        CameraManager.Instance.PickCamera(destinationDoor.GetPlace()).SetActive(true);
    }

    public Place GetPlace() => place;
}

public enum Place
{
    Town,
    Shop
}