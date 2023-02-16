using Assets.Scripts.Core;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerCompositeRoot : CompositeRoot
    {
        public override void Compose()
        {
            new PlayerStats();
        }
    }
}