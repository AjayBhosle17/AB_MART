using DAL;
using DAL.Entities;

public class CategoryRepository : ICategoryRepository
{
    ApplicationDBContext _context;

    public CategoryRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public void Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Delete(int? id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        
    }

    public void Edit(Category category)
    {
        _context.Categories.Attach(category);
        _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
    }

    public List<Category> GetAll()
    {
        return _context.Categories.ToList();
    }

    public Category GetById(int? id)
    {
        return _context.Categories.Find(id);
    }
}