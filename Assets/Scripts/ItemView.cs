using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items
{
    public class ItemView
    {
        private Text _text;
        public Text Text => _text;

        private Toggle _toggle;
        public Toggle Toggle => _toggle;

        public int Type { get; set; }

        public ItemView(Transform parent, int type)
        {
            _text = parent.Find("Text").GetComponent<Text>();
            _toggle = parent.Find("Toggle").GetComponent<Toggle>();
            Type = type;
        }
    }
}
