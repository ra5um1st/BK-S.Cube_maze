using Assets.Scripts.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAllItemsToggleHandler : MonoBehaviour
{
    [SerializeField] private Toggle _handler;
    [SerializeField] private ToggleGroup _toggleGroup;
    [SerializeField] private MenuPresenter _presenter;

    public void OnSelectAllItemsToggled()
    {
        if (_handler.isOn)
        {
            SelectAll(_presenter, _presenter.ItemViewsList);
        }
        else
        {
            UnselectAll(_presenter, _presenter.ItemViewsList);
        }
    }

    private void UnselectAll(MenuPresenter presenter, IEnumerable<ItemView> items)
    {
        foreach (var item in items)
        {
            var activeType = presenter.GetActiveType(_toggleGroup);
            if (item.Type == activeType)
            {
                presenter.UnselectItem(item);
            }
        }
    }

    private void SelectAll(MenuPresenter presenter, IEnumerable<ItemView> items)
    {
        foreach (var item in items)
        {
            var activeType = presenter.GetActiveType(_toggleGroup);
            if (item.Type == activeType)
            {
                presenter.SelectItem(item);
            }
        }
    }
}
