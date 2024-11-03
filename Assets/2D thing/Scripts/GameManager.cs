using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2D_thing.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ResourceBank resourceBank;

        private void Awake()
        {
            resourceBank.ChangeResource(GameResource.Humans, 10);
            resourceBank.ChangeResource(GameResource.Food, 5);
            resourceBank.ChangeResource(GameResource.Wood, 5);
        }
    }
}
