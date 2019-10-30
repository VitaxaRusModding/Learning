using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Player PlayerPrefab;

    public bool IsSpawnStart;

    public Transform Spawn;

    public Transform MainCamer;
    // Start is called before the first frame update
    void Start()
    {
        if (IsSpawnStart)
        {
            Player player = GameObject.Instantiate<Player>(PlayerPrefab, Spawn.position, Spawn.rotation);

            MainCamer.SetParent(player.camera_parrent);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
