using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Tiles
{
    public class TilesColumn : MonoBehaviour
    {
        [SerializeField] private List<TileBase> _tiles = new List<TileBase>();
        private int _minYTile = 0;

        public void OnTileClicked()
        {
            _tiles.RemoveAt(_minYTile);
            UpdateTilesColumn();
        }

        private void Start()
        {
            for (int i = 0; i < _tiles.Count; i++)
            {
                _tiles[i].SetGroup(this);
            }
            UpdateTilesColumn();
        }

        private void UpdateTilesColumn()
        {
            SetLowestTileOpened(FindMinYTile());
        }

        private int FindMinYTile()
        {
            float minY = float.MaxValue;
            for (int i = 0; i < _tiles.Count; i++)
            {
                if (_tiles[i].transform.position.y < minY)
                {
                    minY = _tiles[i].transform.position.y;
                    _minYTile = i;
                }
            }
            return _minYTile;
        }

        private void SetLowestTileOpened(int lowedTileInd)
        {
            int sortedInd = 0;

            for (int i = 0; i < _tiles.Count; i++)
            {
                _tiles[i].SetSortedOrder(sortedInd);
                sortedInd += 2;

                if (i != lowedTileInd)
                {
                    _tiles[i].IsOpen = false;
                }
                else
                {
                    _tiles[i].IsOpen = true;
                }
            }
        }
    }
}