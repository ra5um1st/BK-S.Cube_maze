using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsContainerToggleHandler : MonoBehaviour
{
    [SerializeField] private Toggle _sender;
    [SerializeField] private GameObject _panel;

    public void OnItemsContainerToggled()
    {
        if (_sender.isOn)
        {
            _panel.SetActive(true);
        }
        else
        {
            _panel.SetActive(false);
        }
    }
}
