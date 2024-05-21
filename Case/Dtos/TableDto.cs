namespace Case.Dtos
{
    public class TableDto<T> where T : class
    {
        public int RecordsTotal { get; set; }
        public List<T> Data { get; set; }
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
    }
}
