using AutoMapper;
using HelperStockBeta.Application.DTOs;
using HelperStockBeta.Application.Interfaces;
using HelperStockBeta.Domain.Entities;
using HelperStockBeta.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelperStockBeta.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            if (productEntity != null)
            {
                await _productRepository.RemoveAsync(productEntity);
            }
            else
            {
                throw new InvalidOperationException($"Produto com ID {id} não encontrado para remoção.");
            }
        }
    }
}
