﻿using ProductImporter.Model;

namespace ProductImporter.Logic.Transformations;

public class NameDecapitaliser : IProductTransformation
{
    private readonly IProductTransformationContext _productTransformationContext;

    public NameDecapitaliser(IProductTransformationContext productTransformationContext)
    {
        _productTransformationContext = productTransformationContext;
    }

    public void Execute()
    {
        var product = _productTransformationContext.GetProduct();

        if (product.Name.Any(char.IsUpper))
        {
            var newProduct = new Product(product.Id, product.Name.ToLowerInvariant(), product.Price, product.Stock);
            _productTransformationContext.SetProduct(newProduct);
        }
    }
}