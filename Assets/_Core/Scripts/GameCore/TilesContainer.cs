using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Tiles;
using System;
using System.Linq;

namespace Core.Level
{
    public class TilesContainer : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private float _offset = 1f;

        private List<TileBase> _containedTiles = new List<TileBase>();

        private bool _gameIsOver = false;

        public Action OnGameOvered;
        public Action OnTileDestroyed;

        private void Update()
        {
            if (_gameIsOver)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if(hit)
                {
                    if (hit.collider.TryGetComponent<TileBase>(out TileBase tile))
                    {
                        OnTileClicked(tile);
                    }
                }
            }
        }

        private void OnTileClicked(TileBase tile)
        {
            if (tile.IsOpen)
            {
                if (_containedTiles.Count < 7)
                {
                    tile.Click();
                    _containedTiles.Add(tile);
                    AddToContainer();
                }
            }
        }

        private void AddToContainer()
        {
            _containedTiles[_containedTiles.Count - 1].transform.position
                = _container.position + Vector3.right * _offset * _containedTiles.Count;

            CheckForSameTiles();
        }

        private void CheckForSameTiles()
        {
            _containedTiles = _containedTiles.OrderBy(tmp => tmp.GetSettings().GetInstanceID()).ToList();

            int id = _containedTiles[0].GetSettings().GetInstanceID();
            int sameCount = 0;
            bool needToClear = false;

            for (int i = 0; i < _containedTiles.Count; i++)
            {
                if(id != _containedTiles[i].GetSettings().GetInstanceID())
                {
                    id = _containedTiles[i].GetSettings().GetInstanceID();
                    sameCount = 1;
                }
                else
                {
                    sameCount++;
                    if(sameCount == 3)
                    {
                        for (int k = i - 2; k <= i; k++)
                        {
                            _containedTiles[k].gameObject.SetActive(false);
                            OnTileDestroyed?.Invoke();
                        }
                        needToClear = true;
                    }
                }
            }

            if (needToClear)
            {
                _containedTiles.RemoveAll(tmp => !tmp.gameObject.activeSelf);
                RegroupTiles();
            }
            else
            {
                if(_containedTiles.Count == 7)
                {
                    _gameIsOver = true;
                    OnGameOvered?.Invoke();
                }
            }
        }

        private void RegroupTiles()
        {
            for (int i = 0; i < _containedTiles.Count; i++)
            {
                _containedTiles[i].transform.position
                = _container.position + Vector3.right * _offset * (i + 1);
            }
        }
    }
}