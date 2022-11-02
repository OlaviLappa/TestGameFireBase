using Assets.Scripts;
using UnityEngine.Events;

public class SettlementSystem
{
    public GlassesVault _glassesVault;

    public int glasses => this._glassesVault.Glasses;

    public SettlementSystem(GlassesVault glassesVault)
    {
        this._glassesVault = glassesVault;
    }

    public bool IsEnoughGlasses(int value)
    {
        return glasses >= value;
    }

    public void AddGlasses(object sender, int value)
    {
        this._glassesVault.Glasses += value;
        this._glassesVault.Save();
    }
}
