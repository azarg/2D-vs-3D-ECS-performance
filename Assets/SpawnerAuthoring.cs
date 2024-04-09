using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject itemPrefab;
    public int numberOfItemsToRender;
    public Vector2 spawnArea;

    class Baker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring) {
            var entity = GetEntity(TransformUsageFlags.None);
            var prefabEntity = GetEntity(authoring.itemPrefab, TransformUsageFlags.Dynamic);
            AddComponent(entity, new Spawner {
                itemPrefab = prefabEntity,
                numberOfItemsToRender = authoring.numberOfItemsToRender,
                spawnArea = (float2)authoring.spawnArea,
            });
        }
    }
}

public struct Spawner : IComponentData
{
    public Entity itemPrefab;
    public int numberOfItemsToRender;
    public float2 spawnArea;
}