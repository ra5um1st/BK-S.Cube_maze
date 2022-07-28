using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuPresenter : MonoBehaviour
{
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _removeButton;
    [SerializeField] private Transform _content;
    [SerializeField] private Transform _item;
    [SerializeField] private int _typesCount;

    private List<ItemModel> _itemsList;
    public List<ItemModel> ItemsList => _itemsList;

    private List<ItemView> _itemViewsList;
    public List<ItemView> ItemViewsList => _itemViewsList;

    private static int _totalItemsCount;

    void Start()
    {
        _itemsList = new List<ItemModel>();
        _itemViewsList = new List<ItemView>();
        _addButton.onClick.AddListener(OnAddButtonClick);
        _removeButton.onClick.AddListener(OnRemoveButtonClick);
    }

    public void OnAddButtonClick()
    {
        var itemModel = new ItemModel()
        {
            Text = $"item {_totalItemsCount++}, type {_totalItemsCount % _typesCount}",
            Type = _totalItemsCount % _typesCount,
        };
        _itemsList.Add(itemModel);

        var itemViewInstance = Instantiate(_item, _content);
        itemViewInstance.name = itemModel.Text;
        var itemView = new ItemView(itemViewInstance, _totalItemsCount % _typesCount);
        _itemViewsList.Add(itemView);

        itemView.Text.text = itemModel.Text;
        itemView.Toggle.isOn = itemModel.IsActive;
    }

    public void OnRemoveButtonClick()
    {
        var item = _content.Find(_itemsList.Last().Text);
        Destroy(item.gameObject);

        _itemsList.RemoveAt(_itemsList.Count - 1);
        _itemViewsList.RemoveAt(_itemViewsList.Count - 1);
    }

    public void HideItem(ItemView item)
    {
        var itemContainer = item.Text.transform.parent.gameObject;
        itemContainer.SetActive(false);
    }

    public void ShowItem(ItemView item)
    {
        var itemContainer = item.Text.transform.parent.gameObject;
        itemContainer.SetActive(true);
    }

    public void SelectItem(ItemView item)
    {
        item.Toggle.isOn = true;
    }

    public void UnselectItem(ItemView item)
    {
        item.Toggle.isOn = false;
    }

    public int GetActiveType(ToggleGroup toggleGroup)
    {
        var activeType = 0;
        var toggles = toggleGroup.GetComponentsInChildren<Toggle>();

        foreach (var toggle in toggles)
        {
            if (toggle.isOn)
            {
                break;
            }
            activeType++;
        }

        return activeType;
    }

}
