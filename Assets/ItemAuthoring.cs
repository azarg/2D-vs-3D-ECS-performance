using Unity.Entities;
using UnityEngine;

public class ItemAuthoring : MonoBehaviour
{
    class Baker : Baker<ItemAuthoring> {
        public override void Bake(ItemAuthoring authoring) {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Item { });
        }
    }
}

public struct Item : IComponentData { }