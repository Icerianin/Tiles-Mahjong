using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Other
{
    public class CameraViewResizer : MonoBehaviour
    {
        [SerializeField] private float _offset = 1.5f;
        private void Start()
        {
            Camera.main.orthographicSize = Screen.height / Screen.width * Camera.main.orthographicSize / _offset;
        }
    }
}