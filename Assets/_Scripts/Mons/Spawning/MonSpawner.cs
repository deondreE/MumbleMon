using System;
using _Scripts.Managers;
using _Scripts.Player;
using _Scripts.World;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Mons.Spawning
{
    public class MonSpawner : MonoBehaviour
    {
        private GameManager _gameManager;
        
        
        private MonPlayer _player;

        public BiomeTemplate[] spawnAreas;
        private SpawnArea _spawn;
        private GameObject _mon;
        private GameObject _shinyMon;
        private int _monGroupSize;
        private int _currentCount;
        private int _shinyCount;
        
        private void Awake()
        {
            _player = MonPlayer.instance;
            _gameManager = GameManager.instance;
        }

        // Random Location inside the player spawn radius.
        private Vector3 RandomLocation()
        {
            // Get the spawn radius from the player and convert to diameter
            float distance = Vector3.Distance(PlayerMovement.instance.transform.position, transform.position);

            if (distance <= 12.0f)
            {
                float xPos = Random.Range(_player.spawnRadius, _player.battleRadius) + PlayerMovement.instance.transform.position.x;
                float zPos = Random.Range(_player.spawnRadius, _player.battleRadius) + PlayerMovement.instance.transform.position.z;
                
                // return a random position inside that spawning radius
                return new Vector3(xPos, 0, zPos);
            }

            return new Vector3(0, 0, 0);
        }

        public void Test()
        {
            // Print the Random Location on the press of a button
            Debug.Log($"Testing the Random Location: {RandomLocation()}");
            CheckArea();
        }
        
        // Spawn the mon in from the scriptable object
        private void SpawnGroup(BiomeTemplate biome)
        {
            // Spawn every mon in the list
            foreach (var mon in biome.spawnableMons)
            {
                // Spawn a new mon every 3.0f seconds.
                InvokeRepeating(nameof(SpawnMon), _monGroupSize, 1.0f);
            }
        }
        
        // Spawn the Chosen mon in the game
        private void SpawnMon()
        {
            foreach (var monTemplate in spawnAreas[0].spawnableMons)
            {
                // Get the mon prefab
                _mon = monTemplate.mon.prefab;
                _shinyMon = monTemplate.mon.shinyPrefab;
                _monGroupSize = monTemplate.mon.stats.spawnInfo.groupSize;
                Debug.Log($"Mon Group size: {_monGroupSize}");
            }

            
            // Check if the mon has reached its group size;
            if (_currentCount < _monGroupSize && _currentCount < _gameManager.MAXMONCOUNT)
            {
                GameObject newMon = Instantiate(_mon, RandomLocation(), Quaternion.identity);
                newMon.name = _mon.name;
                _currentCount++;
            }
            else
            {
                // Spawn the Shiny only once, when the group size is reached.
                Invoke(nameof(SpawnShiny), 2.0f);
            }
        }
        
        // Spawn Shiny mon
        private void SpawnShiny()
        {
            _shinyCount++;
            if (_shinyCount >= _monGroupSize + 1 && _shinyCount < _gameManager.MAXSHINYCOUNT)
            {
                GameObject shinyMon = Instantiate(_shinyMon, RandomLocation(), Quaternion.identity);
                shinyMon.name = _shinyMon.name;
            }
        }

        // Check the area to change what mons spawn.
        private void CheckArea()
        {
            if (_spawn == SpawnArea.Desert)
            {
                SpawnGroup(spawnAreas[0]);
            }
        }
    }
}