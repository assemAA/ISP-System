namespace ISP.DAL.Helper
{
    public class Pagination<T> where T : class
    {

        public T Data { get; set; }
     
        public int TotalPages { get; set; }
        public int CurrentPages { get; set; }

    }
}
