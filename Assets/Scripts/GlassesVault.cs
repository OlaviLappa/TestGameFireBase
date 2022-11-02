using UnityEngine;

namespace Assets.Scripts
{
    public class GlassesVault : SettlementData
    {
        private const string KEY = "GLASSES_KEY";
        public int Glasses { get; set; }
        
        public override void Initialize()
        {
            this.Glasses = PlayerPrefs.GetInt(KEY, this.Glasses);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, this.Glasses);
        }
    }
}
