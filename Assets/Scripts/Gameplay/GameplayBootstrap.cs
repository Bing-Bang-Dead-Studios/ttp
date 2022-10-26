using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayBootstrap : MonoBehaviour
{
    
    void Awake()
    {
        ServiceLocator.Initiailze();
        EventDispatcher.Initiailze();
        
        InitializeBossService();
    }

    private void InitializeBossService()
    {
        BossData bossData = new BossData();
        BossDataReader bossDataReader = new BossDataReader(bossData);
        BossDataWriter bossDataWriter = new BossDataWriter(bossData);
        
        ServiceLocator.Instance.Register(new BossService(
            bossDataReader,
            bossDataWriter
        ));
    }
}
