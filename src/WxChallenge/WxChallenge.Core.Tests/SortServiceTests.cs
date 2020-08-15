using System;
using System.Collections.Generic;
using System.Linq;
using WxChallenge.Core.Models;
using WxChallenge.Core.Services;
using Xunit;

namespace WxChallenge.Core.Tests
{
    public class SortServiceTests
    {
        private SortService _sut; // system under test

        [Fact]
        public void SortByField_WhenOptionLow_ShouldSortPriceAscending()
        {
            // Arrange
            _sut = new SortService();

            var unsorted = Unsorted();
            var sortOption = "Low";
            var current = unsorted.Min(p => p.Price);

            // Act
            var sorted = _sut.SortByField(unsorted, sortOption);

            // Assert
            foreach (var product in sorted)
            {
                Assert.True(current <= product.Price);
                current = product.Price;
            }
        }

        [Fact]
        public void SortByField_WhenOptionHigh_ShouldSortPriceDescending()
        {
            // Arrange
            _sut = new SortService();

            var unsorted = Unsorted();
            var sortOption = "High";
            var current = unsorted.Max(p => p.Price);

            // Act
            var sorted = _sut.SortByField(unsorted, sortOption);

            // Assert
            foreach (var product in sorted)
            {
                Assert.True(current >= product.Price);
                current = product.Price;
            }
        }

        [Fact]
        public void SortByField_WhenOptionAscending_ShouldSortNameAscending()
        {
            // Arrange
            _sut = new SortService();

            var unsorted = Unsorted();
            var sortOption = "Ascending";
            var current = unsorted.Min(p => p.Name);

            // Act
            var sorted = _sut.SortByField(unsorted, sortOption);

            // Assert
            foreach (var product in sorted)
            {
                Assert.True(string.Compare(current, product.Name) <= 0);
                current = product.Name;
            }
        }

        [Fact]
        public void SortByField_WhenOptionDescending_ShouldSortNameDescending()
        {
            // Arrange
            _sut = new SortService();

            var unsorted = Unsorted();
            var sortOption = "Descending";
            var current = unsorted.Max(p => p.Name);

            // Act
            var sorted = _sut.SortByField(unsorted, sortOption);

            // Assert
            foreach (var product in sorted)
            {
                Assert.True(string.Compare(current, product.Name) >= 0);
                current = product.Name;
            }
        }

        private List<Product> Unsorted() 
        {
            return new List<Product>
            {
                new Product{ Name = "Product F", Price = 120.5, Quantity = 0},
                new Product{ Name = "Product A", Price = 100.0, Quantity = 0},
                new Product{ Name = "Product E", Price = 120.0, Quantity = 0},
                new Product{ Name = "Product B", Price = 105.0, Quantity = 0},
                new Product{ Name = "Product C", Price = 110.0, Quantity = 0},
                new Product{ Name = "Product D", Price = 115.0, Quantity = 0},
            };
        }
    }
}
