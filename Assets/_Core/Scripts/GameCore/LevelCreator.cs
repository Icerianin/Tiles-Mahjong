using Core.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Level
{
    public class LevelCreator : MonoBehaviour
    {
        [SerializeField] private LevelTilesContainer[] _levelPrefab;
        [SerializeField] private GameStatusUI _gameStatusUI;
        [SerializeField] private TilesContainer _tilesContainer;

        public Action<LevelTilesContainer> OnLevelSet;

        private void Start()
        {
            LevelTilesContainer levelTilesContainer = Instantiate(_levelPrefab[LevelLoader.Instance.GetLevelInd()]);
            levelTilesContainer.SetComponents(_tilesContainer, _gameStatusUI);
            OnLevelSet?.Invoke(_levelPrefab[LevelLoader.Instance.GetLevelInd()]);
        }
    }
}