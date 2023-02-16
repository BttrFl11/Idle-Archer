using PlayerComponents;

public class PlayerStats
{
    private Wallet _wallet;
    public Wallet Wallet => _wallet;

    #region Instance
    private static PlayerStats _i;
    public static PlayerStats I
    {
        get
        {
            if (_i == null)
            {
                return GetInstance();
            }
            else
            {
                return _i;
            }
        }
    }

    private static PlayerStats GetInstance()
    {
        _i = new PlayerStats();
        return _i;
    }
    #endregion

    public PlayerStats()
    {
        Init();
    }

    private void Init()
    {
        _i = this;

        _wallet = new Wallet();
    }

}
