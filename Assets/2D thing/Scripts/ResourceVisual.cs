using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._2D_thing.Scripts
{
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField] private GameResource resource_name;
        [SerializeField] private GameResource resource_lvl;
        [SerializeField] private TextMeshProUGUI Name;
        [SerializeField] private TextMeshProUGUI Amount;
        [SerializeField] private TextMeshProUGUI Level;
        [SerializeField] private ResourceBank resourceBank;
        private ObservableInt resourceValue;
        private ObservableInt resourceLevel;

        private void Start()
        {
            Name.text = resource_name.ToString();
            resourceValue = resourceBank.GetResource(resource_name);
            resourceValue.OnValueChanged += UpdateItemAmount; // Подписываемся
            UpdateItemAmount(resourceValue.Value);

            resourceLevel = resourceBank.GetResource(resource_lvl);
            resourceLevel.OnValueChanged += UpdateItemLevel; // Подписываемся
            UpdateItemLevel(resourceLevel.Value);
        }

        public void UpdateItemAmount(int newAmount)
        {
            Amount.text = newAmount.ToString();
        }
        public void UpdateItemLevel(int newLevel)
        {
            Level.text = "LVL: " + newLevel.ToString();
        }
    }
}
