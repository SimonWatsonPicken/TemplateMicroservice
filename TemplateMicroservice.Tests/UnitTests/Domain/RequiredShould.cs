using System;
using System.Collections.Generic;
using TemplateMicroservice.Domain;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Domain
{
    public class RequiredShould
    {
        [Fact]
        public void ShouldThrowArgumentNullExceptionForNullString()
        {
            // Arrange.
            // Act.
            // Assert.
            Assert.Throws<ArgumentNullException>(() => Required.StringNotEmpty(null));
        }

        [Fact]
        public void ShouldThrowArgumentExceptionForEmptyString()
        {
            // Arrange.
            var value = string.Empty;

            // Act.
            // Assert.
            Assert.Throws<ArgumentException>(() => Required.StringNotEmpty(value));
        }

        [Fact]
        public void ShouldSucceedForValidString()
        {
            // Arrange.
            const string value = "Success";

            // Act.
            var e = Record.Exception(() => Required.StringNotEmpty(value));

            // Assert.
            Assert.Null(e);
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionForNullCollection()
        {
            // Arrange.
            // Act.
            // Assert.
            Assert.Throws<ArgumentNullException>(() => Required.CollectionNotEmpty((List<string>) null));
        }

        [Fact]
        public void ShouldThrowArgumentExceptionForEmptyCollection()
        {
            // Arrange.
            // ReSharper disable once CollectionNeverUpdated.Local
            var value = new List<string>();

            // Act.
            // Assert.
            Assert.Throws<ArgumentException>(() => Required.CollectionNotEmpty(value));
        }

        [Fact]
        public void ShouldSucceedForValidCollection()
        {
            // Arrange.
            var value = new List<string> {"Nothing", "succeeds", "like", "success"};

            // Act.
            var e = Record.Exception(() => Required.CollectionNotEmpty(value));

            // Assert.
            Assert.Null(e);
        }
    }
}