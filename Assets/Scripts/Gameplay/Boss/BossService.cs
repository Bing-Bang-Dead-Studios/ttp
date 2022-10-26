using System;

public class BossService : IService
{
    private readonly BossDataReader _bossDataDataReader;
    private readonly BossDataWriter _bossDataDataWriter;

    public BossService(
        BossDataReader bossDataReader,
        BossDataWriter bossDataWriter)
    {
        _bossDataDataReader = bossDataReader;
        _bossDataDataWriter = bossDataWriter;
        
        EventDispatcher.Instance.AddListener<EventOnClickScreen>(this, onClickScreen);
    }

    public float GetBossMaxLife()
    {
        return _bossDataDataReader.GetBossMaxLife();
    }
    
    public float GetBossCurrentLife()
    {
        return _bossDataDataReader.GetBossCurrentLife();
    }

    public void onClickScreen()
    {
        _bossDataDataWriter.SetCurrentLife(_bossDataDataReader.GetBossCurrentLife() - 1);
    }
}
