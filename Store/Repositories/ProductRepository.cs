using System.Reflection.Metadata.Ecma335;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{

    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);


        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductWithDetails(ProductRequestParameters p)
        {
            return _context
                   .Products
                   .FilteredByCategoryId(p.CategoryId)
                   .FilteredBySearchTerm(p.SearchTerm)
                   .FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice)
                   .ToPaginate(p.PageNumber, p.PageSize);


        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(P => P.ProductId == id, trackChanges);
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
            .Where(p => p.ShowCase.Equals(true));
        }

        public void UpdateOneProduct(Product product) => Update(product);



    }

}