namespace atelier2.Models.Repositories
{
   
    public interface IOrderRepository
    {
        Order GetById(int Id);
        void Add(Order o);
    }
}
