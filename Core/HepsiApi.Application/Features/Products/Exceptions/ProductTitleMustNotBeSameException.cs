using HepsiApi.Application.Bases;

namespace HepsiApi.Application.Features.Products.Exceptions;


public class ProductTitleMustNotBeSameException : BaseException
{
  public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var!")
  {

  }
}