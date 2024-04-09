using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct SpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state) {
        state.RequireForUpdate<Spawner>();
    }

    public void OnUpdate(ref SystemState state) {
        state.Enabled = false;

        var spawner = SystemAPI.GetSingleton<Spawner>();
        var prefab = spawner.itemPrefab;
        var numItems = spawner.numberOfItemsToRender;
        var spawnArea = spawner.spawnArea;
        var random = new Random(2);
        var instances = state.EntityManager.Instantiate(prefab, numItems, Allocator.Temp);
        foreach(var instance in instances) {
            var transform = SystemAPI.GetComponentRW<LocalTransform>(instance);
            transform.ValueRW.Position = random.NextFloat3(new float3(spawnArea.x, spawnArea.y, 0)) - new float3(spawnArea.x/2, spawnArea.y/2,0);
        }
    }
}
