using DTO;

public interface IProductService
{
    List<ProductModel> GetAll();
    void Create(ProductModel product);

    ProductModel GetById(int? id);

    void Edit(ProductModel product);

    void Delete(int? id);
}