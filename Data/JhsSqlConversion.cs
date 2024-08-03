namespace JHS.Framework.Data
{

    public static class JhsSqlConversion
    {

        public static bool SqlBitToBoolean(int? bit)
        {
            if (bit == null)
                return false;
            else if (bit == 1)
                return true;
            else if (bit == 0)
                return false;
            else
                throw new System.Exception($"Invalid bit: {bit}");
        }


    }

}
