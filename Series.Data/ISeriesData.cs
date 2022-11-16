using Series.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Series.Data
{
    public interface ISeriesData
    {
        IEnumerable<SeriesCollection> GetSeriesByName(string searchTerm);
        SeriesCollection GetByID(int id);
    }

    public class InMemorySeriesData : ISeriesData
    {
        readonly List<SeriesCollection> seriesCollection;

        public InMemorySeriesData()
        {
            seriesCollection = new List<SeriesCollection>()
            {
                new SeriesCollection { Id = 1, Channel="CBN", Genre = Genre.Comedy, Name = "The Big Bang Theory"},
                new SeriesCollection { Id = 2, Channel = "Netflix", Genre = Genre.Action, Name = "Money Heist" },
                new SeriesCollection { Id = 3, Channel="Crave", Genre = Genre.Thriller, Name = "Breaking Bad"},
                new SeriesCollection { Id = 4, Channel="Netflix", Genre = Genre.Comedy, Name = "Friends"}
            };
        }
        public SeriesCollection GetByID(int id)
        {
            return seriesCollection.SingleOrDefault(s => s.Id == id);
        }
        public IEnumerable<SeriesCollection> GetSeriesByName(string? searchTerm)
        {
            return from sc in seriesCollection
                   where string.IsNullOrEmpty(searchTerm) || sc.Name.ToLower().StartsWith(searchTerm.ToLower())
                   orderby sc.Id
                   select sc;
        }
    }
}
