namespace ToDoListApplication.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageSize, int pageIndex, int totalCount, int totalPage, IReadOnlyList<T> data)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalItem = totalCount;
            TotalPages = totalPage;
            this.data = data;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalItem { get; set; }
        public IReadOnlyList<T> data { get; set; }
    }
}
