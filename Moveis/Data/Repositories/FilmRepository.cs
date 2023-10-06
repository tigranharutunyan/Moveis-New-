using Moveis.Data.Entity;
using Moveis.Data.Repositories.Interface;

namespace Moveis.Data.Repositories
{
    public class FilmRepository:IFilmRepostory
    {
        private readonly MyFilmContext _filmContext;
        public FilmRepository(MyFilmContext filmContext)
        {
            _filmContext = filmContext;
        }

        public void Add(Film film)
        {   
            _filmContext.Add(film);
            _filmContext.SaveChanges();
            
        }

        public void Delete(Film film)
        {
           _filmContext.Remove(film);
            _filmContext.SaveChanges();    
        }

        public List<Film> Filter(Film film)
        {
            return _filmContext.Films.Where( f=> (film.Name == null || (f.Name.ToLower().Contains(film.Name.ToLower())
            && (film.AllowAge == null || (f.AllowAge == film.AllowAge))
            && (film.Genre == 0 || (f.Genre == film.Genre))
            && (film.Lenguage == 0 || (f.Lenguage == film.Lenguage))
            && (film.Quality == 0 || (f.Quality == film.Quality))
            && (film.DOC == null || (f.DOC == film.DOC))
            && (film.CountryId == 0 || (f.CountryId == film.CountryId))
            && (film.DirectorId == 0 || (f.DirectorId == film.DirectorId))))).ToList();
        }


        public List<Film> GetAll()
        {
            return  _filmContext.Films.ToList();
        }

        public Film GetById(int id)
        {
            return _filmContext.Films.Find(id);
        }

        public void SaveChanges()
        {
            _filmContext.SaveChanges();
        }
    }
}
