public class BossDataWriter
{
    private readonly BossData _bossData;
    
    public BossDataWriter(BossData bossData)
    {
        _bossData = bossData;
    }

    public void SetBossMaxLife(float bossMaxLife)
    {
        _bossData.MaxLife = bossMaxLife;
    }

    public void SetCurrentLife(float bossCurrentLife)
    {
        _bossData.CurrentLife = bossCurrentLife;
    }
}
