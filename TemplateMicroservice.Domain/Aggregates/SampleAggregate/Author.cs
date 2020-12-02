using System;
using System.Collections.Generic;
using TemplateMicroservice.Domain.SeedWork;

namespace TemplateMicroservice.Domain.Aggregates.SampleAggregate
{
    public class Author : IAggregateRoot
    {
        public Author()
        {
            Books = new List<Book>();
            Errors = new List<string>();
        }

        public Author(string name, string biog) : this()
        {
            Name = name;
            ShortBiography = biog;
        }

        public string Name { get; set; }

        public string ShortBiography { get; set; }

        public List<Book> Books { get; set; }

        public List<string> Errors { get; set; }
    }
}