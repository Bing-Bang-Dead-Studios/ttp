public class BossDataReader
{
    private readonly BossData _bossData;
    
    public BossDataReader(BossData bossData)
    {
        _bossData = bossData;
    }
    
    public float GetBossMaxLife()
    {
        return _bossData.MaxLife;
    }
    
    public float GetBossCurrentLife()
    {
        return _bossData.CurrentLife;
    }
}
