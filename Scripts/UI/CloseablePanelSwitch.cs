using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class CloseablePanelSwitch : PanelSwitch
    {
        [SerializeField] private RectTransform _rootPanel;
        [SerializeField, Tooltip("X - close position Y ; Y - opened position Y")] private Vector2 _rootPositions;
        [SerializeField] private float _closeAnimationTime;

        private float _endPositionY;
        private bool _isOpened;

        private bool IsOpened
        {
            get => _isOpened;
            set
            {
                _isOpened = value;
                _endPositionY = _isOpened ? _rootPositions.y : _rootPositions.x;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            IsOpened = false;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            MoveRoot();
        }

        private void MoveRoot()
        {
            var root = _rootPanel.anchoredPosition3D;
            _rootPanel.anchoredPosition3D = Vector2.Lerp(root, new Vector2(root.x, _endPositionY), _closeAnimationTime);
        }

        public override void OnButton(int index)
        {
            if (_activeIndex == index)
            {
                IsOpened = !IsOpened;
            }
            else
            {
                if (IsOpened == false)
                    _panel.anchoredPosition3D = new Vector2(-_distanceBtwPanelsX * index, _panel.anchoredPosition3D.y);

                IsOpened = true;
            }

            _activeIndex = index;
            _endPosition.x = -_distanceBtwPanelsX * _activeIndex;
        }
    }
}