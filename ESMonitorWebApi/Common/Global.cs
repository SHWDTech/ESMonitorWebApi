namespace ESMonitorWebApi.Common
{
    public class Global
    {
        public static string GetProjectType(int type)
        {
            if (type == 1)
            {
                return "商业地产";
            }

            return "";
        }

        public static int GetRate(double value)
        {
            if (value < 0.4)
            {
                return 0;
            }
            if (value > 0.4 && value < 1)
            {
                return 1;
            }
            return 2;
        }
    }
}