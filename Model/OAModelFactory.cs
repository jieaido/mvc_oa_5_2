namespace MVCOA_5.Model
{
    // ReSharper disable once InconsistentNaming
    public static class OAModelFactory
    {
        private static OAModels _oaModels = null;
        public static OAModels GetOaModels()
        {
            //double check 双重锁定
            if (_oaModels == null)
            {
                lock ("a")
                {
                    if (_oaModels == null)
                    {
                        _oaModels = new OAModels();
                    }

                }
                return _oaModels;

            }
            return _oaModels;

        }
    }
}
