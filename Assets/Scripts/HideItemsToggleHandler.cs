using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideItemsToggleHandler : MonoBehaviour
{
    [SerializeField] private Toggle _handler;
    [SerializeField] private ToggleGroup _toggleGroup;
    [SerializeField] private MenuPresenter _presenter;

    public void OnHideItemsToggled()
    {
        if (_handler.isOn)
        {
            HideAll(_presenter, _presenter.ItemViewsList);
        }
        else
        {
            ShowAll(_presenter, _presenter.ItemViewsList);
        }
    }

    private void ShowAll(MenuPresenter presenter, IEnumerable<ItemView> items)
    {
        foreach (var item in items)
        {
            var activeType = presenter.GetActiveType(_toggleGroup);
            if (item.Type == activeType)
            {
                presenter.ShowItem(item);
            }
        }
    }

    private void HideAll(MenuPresenter presenter, IEnumerable<ItemView> items)
    {
        foreach (var item in items)
        {
            var activeType = presenter.GetActiveType(_toggleGroup);
            if (item.Type == activeType)
            {
                presenter.HideItem(item);
            }
        }
    }

}
