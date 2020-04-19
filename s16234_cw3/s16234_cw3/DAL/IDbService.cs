using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using s16234_cw3.Models;

namespace s16234_cw3.DAL
{
    interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
