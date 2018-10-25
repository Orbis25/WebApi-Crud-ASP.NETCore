using Model;
using Persistence;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class StudentService : IStudentService
    {
        private readonly PersistenceDbContext _dbContext;
        public StudentService(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Student entity)
        {
            try
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {

            try
            {
                var student = _dbContext.Students.Single(x => x.Id == id);
                _dbContext.Remove(student);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Student Get(int id)
        {
            var student = new Student();
            try
            {
                student = _dbContext.Students.Single(x => x.Id == id);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                student = null;
                throw;
            }
            return student;

        }

        public IEnumerable<Student> GetAll()
        {
            var student = new List<Student>();
            try
            {
                student = _dbContext.Students.ToList();
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                student = null;
                throw;
            }
            return student;
        }

        public bool Update(Student entity)
        {
            try
            {
                var model = _dbContext.Students.Single(x => x.Id == entity.Id);
                model.Name = entity.Name;
                model.LastName = entity.LastName;
                model.Bio = entity.Bio;
                _dbContext.Update(model);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
                throw;
            }

            return true;
        }
    }
}
