

namespace Persistence.Constants.Param
{
    public class Param
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 25;

        public string? Active { get; set; }
        public string? Direction { get; set; }
    }

}