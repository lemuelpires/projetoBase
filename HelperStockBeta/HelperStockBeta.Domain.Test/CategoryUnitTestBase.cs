using FluentAssertions;
using HelperStockBeta.Domain.Entities;

namespace HelperStockBeta.Domain.Test
{
    public class CategoryUnitTestBase
    {
        #region

        [Fact(DisplayName = "Category name is not null")]
        public void CreateCategory_WithValidParameters_ResultValid()
        {
            Action action = () => new Category(1, "Categoria Teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Category no present id parameter")]
        public void CreateCategory_IdParametersLess_ResultValid()
        {
            Action action = () => new Category(1, "Categoria Teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();

        }
        
        #endregion

        #region Casos de Teste negativos
        [Fact(DisplayName = " Id negative exception. ")]
        public void CreateCategory_NegativeParametersId_ResultException()
        {
            Action action = () => new Category(-1, "Categoria Teste");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Identification is positive values!");


        }
        [Fact(DisplayName = " Name category is null. ")]
        public void CreateCategory_NameParametersNull_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");


        }
        [Fact(DisplayName = " Name short for category is null. ")]
        public void CreateCategory_NameParameterShort_ResultException()
        {
            Action action = () => new Category(1,"Ca");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is minimum 3 charecters");
        }

        #endregion


    }
}