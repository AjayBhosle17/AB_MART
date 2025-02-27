using AutoMapper;
using DAL.Entities;
using DTO;

public class CategoryService : ICategoryService
{
    ICategoryRepository _repo;
    IMapper _mapper;

    public CategoryService(ICategoryRepository repo , IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public void Create(CategoryModel model)
    {
        var category = _mapper.Map<Category>(model);
        _repo.Create(category);
    }

    public void Delete(int? id)
    {
        _repo.Delete(id);
    }

    public void Edit(CategoryModel category)
    {
        _repo.Edit(_mapper.Map<Category>(category));
    }

    public List<CategoryModel> GetAll()
    {
        var categoriesModel = _mapper.Map<List<CategoryModel>>(_repo.GetAll());

        return categoriesModel;
    }

    public CategoryModel GetById(int? id)
    {
        return _mapper.Map<CategoryModel>(_repo.GetById(id));
    }
}