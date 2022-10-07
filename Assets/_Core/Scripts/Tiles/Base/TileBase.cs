using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Tiles
{
    public class TileBase : MonoBehaviour
    {
        [SerializeField] private TileSettingSO _tileSetting;
        [SerializeField] private SpriteRenderer _iconDisplayer;
        [SerializeField] private SpriteRenderer _borderDisplayer;

        private TilesColumn _tilesGroup;
        private bool _isOpen = true;

        public bool IsOpen
        { 
            get => _isOpen;
            set
            {
                _isOpen = value;
                ChangeBordersColor();
            }
        }

        public void SetGroup(TilesColumn tilesColumn)
        {
            _tilesGroup = tilesColumn;
        }

        public void Click()
        {
            if (!_isOpen)
                return;

            if (_tilesGroup)
                _tilesGroup.OnTileClicked();

            _isOpen = false;
        }

        public void SetSortedOrder(int layerInd)
        {
            _borderDisplayer.sortingOrder = layerInd;
            _iconDisplayer.sortingOrder = layerInd + 1;
        }

        public TileSettingSO GetSettings()
        {
            return _tileSetting;
        }

        private void Start()
        {
            _borderDisplayer = GetComponent<SpriteRenderer>();
            _iconDisplayer.sprite = _tileSetting.GetIcon();
        }

        private void ChangeBordersColor()
        {
            if (_isOpen)
            {
                _borderDisplayer.color = Color.white;
            }
            else
            {
                _borderDisplayer.color = Color.gray;
            }
        }
    }
}