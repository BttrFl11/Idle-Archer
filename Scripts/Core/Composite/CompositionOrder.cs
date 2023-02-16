using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _order;

        private void Awake()
        {
            foreach (var composite in _order)
            {
                composite.Compose();
            }
        }
    }
}