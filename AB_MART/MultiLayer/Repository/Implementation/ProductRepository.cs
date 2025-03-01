using DAL.Entities;
using DAL;

public class ProductRepository :IProductRepository
{
    ApplicationDBContext _context;

    public ProductRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Delete(int? id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

    }

    public void Edit(Product product)
    {
        _context.Products.Attach(product);
        _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product GetById(int? id)
    {
        return _context.Products.Find(id);
    }
}
