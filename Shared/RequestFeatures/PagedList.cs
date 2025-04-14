using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int PageNumber, int PageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = PageSize,
                CurrentPage = PageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)PageSize)

            };
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count(); var items = source
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(); return new PagedList<T>(items, count, pageNumber, pageSize);
        }

    }
}
