using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public PlayerManager PlayerPrefab;

    public bool IsSpawnStart;

    public Transform Spawn;

    public Transform MainCamer;
    // Start is called before the first frame update
    void Start()
    {
        if (IsSpawnStart)
        {
            PlayerManager player = GameObject.Instantiate<PlayerManager>(PlayerPrefab, Spawn.position, Spawn.rotation);

            MainCamer.SetParent(player.camera_parrent);

            MainCamer.localPosition = Vector3.zero;

            MainCamer.localRotation = Quaternion.identity;


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
