
using Microsoft.EntityFrameworkCore;

namespace Utils
{
    public static class PagingExtension
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int take)
        {
            int originalPages = page;
            page--;
            page = ((page > 0) ? (page * take) : 0);
            DataCollection<T> dataCollection = new DataCollection<T>();
            DataCollection<T> dataCollection2 = dataCollection;
            dataCollection2.Items = await query.Skip(page).Take(take).ToListAsync();
            DataCollection<T> dataCollection3 = dataCollection;
            dataCollection3.Total = await query.CountAsync();
            dataCollection.Page = originalPages;
            DataCollection<T> dataCollection4 = dataCollection;
            if (dataCollection4.Total > 0)
            {
                if (take > 0)
                {
                    dataCollection4.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dataCollection4.Total) / (decimal)take));
                }
                else
                {
                    dataCollection4.Pages = 0;
                }
            }

            return dataCollection4;
        }
    }
}
