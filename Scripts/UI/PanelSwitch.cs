using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PanelSwitch : MonoBehaviour
    {
        [SerializeField] private float _animationTime;
        [SerializeField] private Canvas _canvas;
        [SerializeField] protected RectTransform _panel;

        protected float _distanceBtwPanelsX;
        protected Vector2 _endPosition;
        protected int _activeIndex = int.MaxValue;

        protected virtual void Awake()
        {
            _distanceBtwPanelsX = _canvas.pixelRect.width;
            _endPosition.y = _panel.anchoredPosition3D.y;
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var panelPos = _panel.anchoredPosition3D;

            _panel.anchoredPosition3D = Vector2.Lerp(panelPos, _endPosition, _animationTime);
        }

        public virtual void OnButton(int index)
        {
            _activeIndex = index;
            _endPosition.x = -_distanceBtwPanelsX * _activeIndex;
        }
    }
}