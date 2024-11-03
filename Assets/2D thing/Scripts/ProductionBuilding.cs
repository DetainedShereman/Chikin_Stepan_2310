using Assets._2D_thing.Scripts;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._2D_thing.Scripts
{

    public class ProductionBuilding : MonoBehaviour
    {
        [SerializeField] private GameResource resource;
        [SerializeField] private GameResource resource_level;
        [SerializeField] private ResourceBank resourceBank;
        [SerializeField] private float Level_0_ProductionTime = 3f;
        [SerializeField] private Button button;
        [SerializeField] private Slider slider;
        private float ProductionTime = 3f;

        static float targetFrameRate = 60f; // ������� ���������� ������ � �������
        static float frameDuration = 1f / targetFrameRate; // ����� ������ �����

        public void Produce()
        {
            // ������������ ProductionTime � �����. � �������
            int level = resourceBank.GetResource(resource_level).Value;
            ProductionTime = Level_0_ProductionTime / (level + 1);

            StartCoroutine(ProduceSource());
        }

        private IEnumerator ProduceSource()
        {
            button.interactable = false;
            slider.value = 0;

            float elapsedTime = 0f;

            while (elapsedTime < ProductionTime)
            {
                elapsedTime += 0.01667f;
                slider.value = elapsedTime / ProductionTime; // ��������� �������
                yield return new WaitForSeconds(frameDuration); // ���� ��������� ����
            }

            // ����� ���������� ������������ ��������� ������
            resourceBank.ChangeResource(resource, 1);

            // ���������� ������ � ���������� �������
            button.interactable = true;
            slider.value = 1f; // ������������� �������� �� ��������
        }
    }
}
