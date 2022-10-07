using Core.Tiles;
using Core.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Level
{
    public class LevelTilesContainer : MonoBehaviour
    {
        private GameStatusUI _gameStatusUI;
        private TilesContainer _tilesContainer;
        private int _curTilesCount;

        private void OnDisable()
        {
            if (_tilesContainer)
                _tilesContainer.OnTileDestroyed -= OnTileDestroyed;
        }

        public void SetComponents(TilesContainer tilesContainer, GameStatusUI gameStatusUI)
        {
            _tilesContainer = tilesContainer;
            _tilesContainer.OnTileDestroyed += OnTileDestroyed;
            _gameStatusUI = gameStatusUI;
        }

        private void Start()
        {
            _curTilesCount = GetComponentsInChildren<TileBase>().Length;
        }

        private void OnTileDestroyed()
        {
            _curTilesCount--;
            if(_curTilesCount == 0)
            {
                if (_gameStatusUI)
                    _gameStatusUI.OnGameComplited();
            }
        }
    }
}