namespace Assets.Scripts.Scenes
{
    public static class DataHolder
    {
        private static int _levelId;

        public static int LevelId
        {
            get
            {
                return _levelId;
            }

            set
            {
                _levelId = value;
            }
        }
    }
}