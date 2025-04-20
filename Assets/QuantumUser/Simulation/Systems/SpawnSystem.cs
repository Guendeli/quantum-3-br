using Quantum.Collections;

namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class SpawnSystem : SystemSignalsOnly, ISignalOnPlayerAdded
    {
        public void OnPlayerAdded(Frame f, PlayerRef player, bool firstTime)
        {
            if (!firstTime)
                return;

            EntityRef playerEntity = CreatePlayer(f, player);
            
            PlacePlayerOnSpawnPoint(f, playerEntity);
            
        }

        /// <summary>
        /// Place the player on an available spawn point
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="playerEntity"></param>
        private void PlacePlayerOnSpawnPoint(Frame frame, EntityRef playerEntity)
        {
            SpawnPointManager* spawnPointManager = frame.Unsafe.GetPointerSingleton<SpawnPointManager>();
            QList<EntityRef> availableSpawnPoints = frame.ResolveList(spawnPointManager->AvailableSpawnPoints);
            QList<EntityRef> usedSpawnPoints = frame.ResolveList(spawnPointManager->UsedSpawnPoints);
            
            // True if we just entered the simulation, populate for first time
            if (availableSpawnPoints.Count == 0 && usedSpawnPoints.Count == 0)
            {
                foreach (EntityComponentPair<SpawnPoint> componentPair in frame.GetComponentIterator<SpawnPoint>())
                {
                    availableSpawnPoints.Add(componentPair.Entity);
                }
            }

            int randomIndex = frame.RNG->Next(0, availableSpawnPoints.Count); // Deterministic RNG with the fair roll of a dice
            EntityRef spawnPoint = availableSpawnPoints[randomIndex];
            Transform2D transform2D = frame.Get<Transform2D>(spawnPoint);
            Transform2D* playerTransform = frame.Unsafe.GetPointer<Transform2D>(playerEntity);
            
            playerTransform->Position = transform2D.Position;
            
            availableSpawnPoints.RemoveAt(randomIndex);
            usedSpawnPoints.Add(spawnPoint);
            
            if(availableSpawnPoints.Count == 0)
            {
                spawnPointManager->AvailableSpawnPoints = usedSpawnPoints;
                spawnPointManager->UsedSpawnPoints = new QListPtr<EntityRef>();
            }

        }

        private static EntityRef CreatePlayer(Frame f, PlayerRef player)
        {
            RuntimePlayer playerData = f.GetPlayerData(player);
            EntityRef playerEntity = f.Create(playerData.PlayerAvatar);
            PlayerLink playerLink = new PlayerLink()
            {
                Player = player
            };
            
            f.Add(playerEntity, playerLink);
            
            // TODO: use KCCSettings.init() instead of setting the component values directly
            KCC* kcc = f.Unsafe.GetPointer<KCC>(playerEntity);
            KCCSettings settings = f.FindAsset(kcc->Settings);
            settings.Init(ref *kcc);

            return playerEntity;
        }
    }
}
