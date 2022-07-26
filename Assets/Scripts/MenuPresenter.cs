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

    private List<ItemModel> _itemsList;
    private List<ItemView> _itemViewsList;
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
            Text = $"item {_totalItemsCount++}"
        };
        _itemsList.Add(itemModel);

        var itemViewInstance = Instantiate(_item, _content);
        itemViewInstance.name = itemModel.Text;
        var itemView = new ItemView(itemViewInstance);
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

    class ItemModel
    {
        public string Text { get; set; }
        public bool IsActive { get; set; }
    }

    class ItemView
    {
        private Text _text;
        public Text Text => _text;

        private Toggle _toggle;
        public Toggle Toggle => _toggle;

        public ItemView(Transform parent)
        {
            _text = parent.Find("Text").GetComponent<Text>();
            _toggle = parent.Find("Toggle").GetComponent<Toggle>();
        }
    }
}
