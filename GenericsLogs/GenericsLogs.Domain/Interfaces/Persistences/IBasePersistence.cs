namespace GenericsLogs.Domain.Interfaces.Persistences
{
    public interface IBasePersistence<TModel, TKey>
        where TModel : class
    {
        void Add(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        List<TModel> GetAll();
        TModel GetbyId(Guid id);
    }
}
