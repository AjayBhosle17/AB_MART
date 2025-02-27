using DAL.Entities;

public interface ICategoryRepository
{
    List<Category> GetAll();
    void Create(Category category);

    Category GetById(int? id);

    void Edit(Category category);

    void Delete(int? id);
}