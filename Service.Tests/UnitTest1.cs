using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Service.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<ILoggerManager> _loggerManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICategoryService _categoryService;

        public CategoryServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _mapperMock = new Mock<IMapper>();
            _categoryService = new  CategoryService(_repositoryManagerMock.Object, _loggerManagerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void AddCategory_ShouldReturnNewCategoryId()
        {
            // Arrange
            var categoryDto = new CategoryDto(Guid.Empty, "Test Category", "Test Description");
            var category = new Category { Id = Guid.NewGuid(), Name = "Test Category", Description = "Test Description" };

            _mapperMock.Setup(m => m.Map<Category>(categoryDto)).Returns(category);
            _repositoryManagerMock.Setup(r => r.CategoryRepository.AddCategory(category));
            _repositoryManagerMock.Setup(r => r.Save());

            // Act
            var result = _categoryService.AddCategory(categoryDto);

            // Assert
            Assert.Equal(category.Id, result);
            _repositoryManagerMock.Verify(r => r.CategoryRepository.AddCategory(category), Times.Once);
            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public void DeleteCategory_ShouldDeleteCategory_WhenCategoryExists()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var category = new Category { Id = categoryId, Name = "Test Category", Description = "Test Description" };

            _repositoryManagerMock.Setup(r => r.CategoryRepository.GetCategory(categoryId)).Returns(category);
            _repositoryManagerMock.Setup(r => r.CategoryRepository.DeleteCategory(category));
            _repositoryManagerMock.Setup(r => r.Save());

            // Act
            _categoryService.DeleteCategory(categoryId);

            // Assert
            _repositoryManagerMock.Verify(r => r.CategoryRepository.DeleteCategory(category), Times.Once);
            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public void DeleteCategory_ShouldThrowCategoryNotFoundException_WhenCategoryDoesNotExist()
        {
            // Arrange
            var categoryId = Guid.NewGuid();

            _repositoryManagerMock.Setup(r => r.CategoryRepository.GetCategory(categoryId)).Returns((Category)null);

            // Act & Assert
            Assert.Throws<CategoryNotFoundException>(() => _categoryService.DeleteCategory(categoryId));
        }

        [Fact]
        public void GetCategories_ShouldReturnCategoryDtos()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), Name = "Category 1", Description = "Description 1" },
                new Category { Id = Guid.NewGuid(), Name = "Category 2", Description = "Description 2" }
            };

            var categoryDtos = new List<CategoryDto>
            {
                new CategoryDto(categories[0].Id, categories[0].Name, categories[0].Description),
                new CategoryDto(categories[1].Id, categories[1].Name, categories[1].Description)
            };

            _repositoryManagerMock.Setup(r => r.CategoryRepository.GetCategories()).Returns(categories);
            _mapperMock.Setup(m => m.Map<IEnumerable<CategoryDto>>(categories)).Returns(categoryDtos);

            // Act
            var result = _categoryService.GetCategories();

            // Assert
            Assert.Equal(categoryDtos, result);
            _loggerManagerMock.Verify(l => l.LogInfo("Category Accessed"), Times.Once);
        }

        [Fact]
        public void GetCategoryById_ShouldReturnCategoryDto_WhenCategoryExists()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var category = new Category { Id = categoryId, Name = "Test Category", Description = "Test Description" };
            var categoryDto = new CategoryDto(categoryId, "Test Category", "Test Description");

            _repositoryManagerMock.Setup(r => r.CategoryRepository.GetCategory(categoryId)).Returns(category);
            _mapperMock.Setup(m => m.Map<CategoryDto>(category)).Returns(categoryDto);

            // Act
            var result = _categoryService.GetCategoryById(categoryId);

            // Assert
            Assert.Equal(categoryDto, result);
        }

        [Fact]
        public void UpdateCategory_ShouldUpdateCategory_WhenCategoryExists()
        {
            // Arrange
            var categoryDto = new CategoryDto(Guid.NewGuid(), "Updated Category", "Updated Description");
            var category = new Category { Id = categoryDto.Id, Name = "Old Category", Description = "Old Description" };

            _repositoryManagerMock.Setup(r => r.CategoryRepository.GetCategory(categoryDto.Id)).Returns(category);
            _repositoryManagerMock.Setup(r => r.CategoryRepository.UpdateCategory(category));
            _repositoryManagerMock.Setup(r => r.Save());

            // Act
            _categoryService.UpdateCategory(categoryDto);

            // Assert
            Assert.Equal(categoryDto.Name, category.Name);
            Assert.Equal(categoryDto.Description, category.Description);
            _repositoryManagerMock.Verify(r => r.CategoryRepository.UpdateCategory(category), Times.Once);
            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public void UpdateCategory_ShouldThrowCategoryNotFoundException_WhenCategoryDoesNotExist()
        {
            // Arrange
            var categoryDto = new CategoryDto(Guid.NewGuid(), "Updated Category", "Updated Description");

            _repositoryManagerMock.Setup(r => r.CategoryRepository.GetCategory(categoryDto.Id)).Returns((Category)null);

            // Act & Assert
            Assert.Throws<CategoryNotFoundException>(() => _categoryService.UpdateCategory(categoryDto));
        }
    }
}
