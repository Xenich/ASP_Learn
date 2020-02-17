using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_MVC_MODELS.Models
{
    /// <summary>
    /// Класс для пагинации
    /// </summary>
    public class PageViewModel
    {
        public int PageNumber { get; private set; }     // текущая страница
        public int TotalPages { get; private set; }     // всего страниц

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count">Количество записей всего</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество отображаемых на странице записей</param>
        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling( count / (double)pageSize);
        }

        public bool hasPreviousPage
        {
            get { return (PageNumber > 1); }
        }
        public bool HasNextPage
        {
            get { return (PageNumber < TotalPages); }
        }
    }
}
