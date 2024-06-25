using System;
using TMPro;
using UnityEngine;

namespace Scripts
{
    /// <summary>
    /// �����, ����������� ��������� ������� ��������� �� ���������� ���� �� ���������� ���������
    /// </summary>
    public class DangerousItemsStashChecker : MonoBehaviour
    {
        /// <summary>
        /// ��������� ���������� ������� ��������� � �������,
        /// ������� � ����������, � ������ ��������� ������������� �� ����
        /// </summary>
        [Min(0)]
        [SerializeField] private int _requestItemCount;
        [SerializeField] private DangerousItemsStash _checkedStorage;
        [SerializeField] private TextMeshPro _targetStateDisplayer;

        public bool isTargetNumberDangerousItemHasBeenMet;


        public event Action ItemCountInStashWasChanged;


        public int DangerousItemsCount => _checkedStorage.DangerousItemsCount;
        public int RequestDangerousItemsCount => _requestItemCount;


        #region MonoBehavior

        private void Awake()
        {
            if (_requestItemCount == 0)
                _requestItemCount = CountNumberDangerousItemsOnScene();

            if (_checkedStorage is null)
                throw new NullReferenceException("��������������� ��������� ������� ���������� - Null");
        }

        private void Start()
        {
            UpdateDisplayingDangerousItemsCount();
        }

        private void OnEnable()
        {
            _checkedStorage.DangerousItemsCountWasChanged += CheckStorageOnDangerousItemsCount;
        }

        private void OnDisable()
        {
            _checkedStorage.DangerousItemsCountWasChanged -= CheckStorageOnDangerousItemsCount;
        }

        #endregion


        /// <summary>
        /// ����� �������� ������� ��������� �� �����,
        /// ������� ��������� ������� � ����� DangerousItem
        /// </summary>
        /// <returns>���������� ������� ���������</returns>
        private int CountNumberDangerousItemsOnScene() =>
            GameObject.FindGameObjectsWithTag("DangerousItem").Length;

        private void CheckStorageOnDangerousItemsCount()
        {
            UpdateDisplayingDangerousItemsCount();
            if (DangerousItemsCount >= _requestItemCount)
                isTargetNumberDangerousItemHasBeenMet = true;
            else isTargetNumberDangerousItemHasBeenMet = false;
            ItemCountInStashWasChanged?.Invoke();
        }

        private void UpdateDisplayingDangerousItemsCount() =>
            _targetStateDisplayer.text = $"{DangerousItemsCount} ��������� �� {_requestItemCount}";

    }
}


