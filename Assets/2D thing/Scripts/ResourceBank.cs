using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._2D_thing.Scripts
{
    public class ResourceBank : MonoBehaviour
    {
        private Dictionary<GameResource, ObservableInt> resources = new Dictionary<GameResource, ObservableInt>();

        private void Awake()
        {
            // «аполнение словар€ начальными значени€ми (нул€ми)
            foreach (GameResource resource in System.Enum.GetValues(typeof(GameResource)))
            {
                resources[resource] = new ObservableInt();
            }
        }

        public void ChangeResource(GameResource r, int v)
        {
            if (resources.ContainsKey(r))
            {
                resources[r].Value += v;
            }
        }

        public ObservableInt GetResource(GameResource r)
        {
            if (resources.ContainsKey(r))
            {
                return resources[r];
            }

            return null;
        }
    }
}
