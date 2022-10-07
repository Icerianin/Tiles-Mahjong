using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Tiles
{
    [CreateAssetMenu(fileName = "NewTile", menuName = "Mahjong/New Mahjong Tile")]
    public class TileSettingSO : ScriptableObject
    {
        [SerializeField] private Sprite _icon;

        public Sprite GetIcon()
        {
            return _icon;
        }
    }
}