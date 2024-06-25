using UnityEngine;

namespace Scripts
{
    [CreateAssetMenu(menuName = "Items/Dangerous item", fileName = "New Item")]
    public class DangerousItemInfo : ScriptableObject 
    {
        [SerializeField] private GameObject _itemPrefab;


        public GameObject ItemPrefab => _itemPrefab;
    }
}