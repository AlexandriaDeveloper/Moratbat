using System.Reflection;
using System.ComponentModel;
using System.Linq.Expressions;
using Domain;
using Domain.Interfaces;

namespace Persistence.Constants
{
    public class Param
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;

        public string? Active { get; set; }
        public string? Direction { get; set; }
    }
}