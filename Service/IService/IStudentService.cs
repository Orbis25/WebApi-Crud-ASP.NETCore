using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IService
{
    public interface IStudentService : IRepositoryPattern<Student>
    {
    }
}
