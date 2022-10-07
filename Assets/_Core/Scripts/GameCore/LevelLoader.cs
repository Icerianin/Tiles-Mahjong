using Core.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Level
{
    public class LevelLoader : Singleton<LevelLoader>
    {
        [SerializeField] private int _levelInd;

        public int GetLevelInd()
        {
            return _levelInd;
        }

        public void NextLevel()
        {
            if (_levelInd == 0)
            {
                _levelInd = 1;
            }
            else
            {
                _levelInd = 0;
            }
            ReloadLevel();
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}