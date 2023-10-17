namespace Schm.UI.Common
{
    public static class PaginationUtilities
    {
        public static dynamic GenerateData(int Draw,int TotalCount,int FilterCount,object Data)
        {
            return new
            {
                draw = Draw,
                recordsTotal = TotalCount,
                recordsFiltered = TotalCount,
                data = Data,
            };
        }
    }
}
