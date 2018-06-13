namespace AimpSync.ViewModels
{
    public interface IViewModelMapper<T>
    {
        void MapFromModel(T model);
        T MapToModel();
    }
}