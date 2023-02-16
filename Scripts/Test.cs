using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Test : MonoBehaviour
    {
        public Enemy Enemy;
        public ArcherDataSO ArcherData;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ArcherData.AttackSpeed = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ArcherData.AttackSpeed = 1;
            }
        }
    }
}