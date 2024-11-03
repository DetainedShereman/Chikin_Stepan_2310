using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._2D_thing.Scripts
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private ResourceBank resourceBank;
        [SerializeField] private GameResource resource;
        [SerializeField] private GameResource resource_lvl;
        [SerializeField] private TextMeshProUGUI Cost;
        [SerializeField] private Button button;
        private int costValue;
        private ObservableInt resourceLevel;

        public void Start()
        {
            resourceLevel = resourceBank.GetResource(resource_lvl);

            costValue = Random.Range(5, 31); // Генерируем цену улучшения
            Cost.text = "cost:" + costValue.ToString() + " " + resource.ToString();
        }

        public void Upgrade()
        {
            int resourceValue = resourceBank.GetResource(resource).Value;

            if (resourceValue >= costValue)
            {
                resourceBank.ChangeResource(resource_lvl, 1);
                resourceBank.ChangeResource(resource, -costValue);
            }
            else
            {
                StartCoroutine(BrokieDetected()); // Кнопка мигает красным и не нажимается .5 секунды
            }
        }

        private IEnumerator BrokieDetected()
        {
            button.interactable = false;
            yield return new WaitForSeconds(0.5f);
            button.interactable = true;
        }
    }
}